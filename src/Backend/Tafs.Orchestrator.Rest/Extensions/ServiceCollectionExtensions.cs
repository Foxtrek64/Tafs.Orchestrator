//
//  ServiceCollectionExtensions.cs
//
//  Author:
//       Devin Duanne <dduanne@tafs.com>
//
//  Copyright (c) TAFS, LLC.
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Lesser General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU Lesser General Public License for more details.
//
//  You should have received a copy of the GNU Lesser General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
//

using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using Polly;
using Polly.Contrib.WaitAndRetry;
using Remora.Rest;
using Remora.Rest.Extensions;
using Tafs.Orchestrator.API.Abstractions.API.Rest;
using Tafs.Orchestrator.API.API.Rest.Account;
using Tafs.Orchestrator.Caching.Abstractions.Services;

namespace Tafs.Orchestrator.Rest.Extensions
{
    /// <summary>
    /// Defines various extension methods for the <see cref="IServiceCollection"/> interface.
    /// </summary>
    [PublicAPI]
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the services required for Discord's REST API.
        /// </summary>
        /// <param name="serviceCollection">The service collection.</param>
        /// <param name="tokenFactory">
        /// A function that creates or retrieves the authorization token and its token type.
        /// </param>
        /// <param name="buildClient">Extra client building operations.</param>
        /// <returns>The service collection, with the services added.</returns>
        public static IServiceCollection AddOrchestratorRest
        (
            this IServiceCollection serviceCollection,
            Func<IServiceProvider, (string Token, OrchestratorTokenType TokenType)> tokenFactory,
            Action<IHttpClientBuilder>? buildClient = null
        )
        {
            serviceCollection.AddSingleton<IAsyncTokenStore>(ctx =>
            {
                var (token, type) = tokenFactory(ctx);
                return new StaticTokenStore(token, type);
            });

            return serviceCollection.AddOrchestratorRest(buildClient);
        }

        /// <summary>
        /// Adds the services required for Discord's REST API.
        /// </summary>
        /// <param name="serviceCollection">The service collection.</param>
        /// <param name="buildClient">Extra client building operations.</param>
        /// <returns>The service collection, with the services added.</returns>
        public static IServiceCollection AddDiscordRest
        (
            this IServiceCollection serviceCollection,
            Action<IHttpClientBuilder>? buildClient = null
        )
        {
            serviceCollection.AddMemoryCache();

            serviceCollection.TryAddSingleton<MemoryCacheProvider>();
            serviceCollection.AddSingleton<ICacheProvider>(s => s.GetRequiredService<MemoryCacheProvider>());

            serviceCollection.ConfigureOrchestratorJsonConverters();

            serviceCollection.AddTransient<TokenAuthorizationHandler>();

            serviceCollection.TryAddTransient<IOrchestratorRestAccountAPI>(s => new OrchestratorRestAccountAPI
            (
                s.GetRequiredService<IRestHttpClient>(),
                s.GetRequiredService<IOptionsMonitor<JsonSerializerOptions>>().Get("Orchestrator"),
                s.GetRequiredService<ICacheProvider>()
            ));

            var rateLimitPolicy = OrchestratorRateLimitPolicy.Create();
            var retryDelay = Backoff.DecorrelatedJitterBackoffV2(TimeSpan.FromSeconds(1), 5);
            var clientBuilder = serviceCollection
                .AddRestHttpClient<RestError>("Discord")
                .ConfigureHttpClient((_, client) =>
                {
                    var assemblyName = Assembly.GetExecutingAssembly().GetName();
                    var name = assemblyName.Name ?? "Tafs.Orchestrator";
                    var version = assemblyName.Version ?? new Version(1, 0, 0);

                    client.BaseAddress = Constants.BaseURL;
                    client.DefaultRequestHeaders.UserAgent.Add
                    (
                        new ProductInfoHeaderValue(name, version.ToString())
                    );
                })
                .AddHttpMessageHandler<TokenAuthorizationHandler>()
                .AddTransientHttpErrorPolicy
                (
                    b => b
                        .WaitAndRetryAsync(retryDelay)
                )
                .AddPolicyHandler
                (
                    Policy.HandleResult<HttpResponseMessage>(r => r.StatusCode == HttpStatusCode.TooManyRequests)
                        .WaitAndRetryForeverAsync
                        (
                            (_, response, _) =>
                            {
                                if (response.Result == default)
                                {
                                    return TimeSpan.FromSeconds(1);
                                }

                                return response.Result.Headers.RetryAfter is null or { Delta: null }
                                    ? TimeSpan.FromSeconds(1)
                                    : response.Result.Headers.RetryAfter.Delta.Value;
                            },
                            (_, _, _, _) => Task.CompletedTask
                        )
                        .WrapAsync(rateLimitPolicy)
                );

            // Run extra user-provided client building operations.
            buildClient?.Invoke(clientBuilder);

            return serviceCollection;
        }

        /// <summary>
        /// Registers a decorator service, replacing the existing interface.
        /// </summary>
        /// <remarks>
        /// Implementation based off of
        /// https://greatrexpectations.com/2018/10/25/decorators-in-net-core-with-dependency-injection/.
        /// </remarks>
        /// <param name="services">The service collection.</param>
        /// <typeparam name="TInterface">The interface type to decorate.</typeparam>
        /// <typeparam name="TDecorator">The decorator type.</typeparam>
        /// <returns>The service collection, with the decorated service.</returns>
        public static IServiceCollection Decorate<TInterface, TDecorator>(this IServiceCollection services)
            where TInterface : class
            where TDecorator : class, TInterface
        {
            var wrappedDescriptor = services.First(s => s.ServiceType == typeof(TInterface));

            var objectFactory = ActivatorUtilities.CreateFactory(typeof(TDecorator), new[] { typeof(TInterface) });
            services.Replace(ServiceDescriptor.Describe
            (
                typeof(TInterface),
                s => (TInterface)objectFactory(s, new[] { s.CreateInstance(wrappedDescriptor) }),
                wrappedDescriptor.Lifetime
            ));

            return services;
        }

        private static object CreateInstance(this IServiceProvider services, ServiceDescriptor descriptor)
        {
            if (descriptor.ImplementationInstance is not null)
            {
                return descriptor.ImplementationInstance;
            }

            return descriptor.ImplementationFactory is not null
                ? descriptor.ImplementationFactory(services)
                : ActivatorUtilities.GetServiceOrCreateInstance
                (
                    services,
                    descriptor.ImplementationType ?? throw new InvalidOperationException()
                );
        }
    }
}
