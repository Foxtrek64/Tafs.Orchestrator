using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Remora.Rest.Extensions;
using Remora.Rest.Json;
using Remora.Rest.Json.Policies;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Tafs.Orchestrator.API.Extensions
{
    /// <summary>
    /// Defines various extension methods to the <see cref="IServiceCollection"/> class.
    /// </summary>
    [PublicAPI]
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Configures Discord-specific JSON converters.
        /// </summary>
        /// <param name="serviceCollection">The service collection.</param>
        /// <param name="optionsName">The name of the serializer options, if any.</param>
        /// <param name="allowUnknownEvents">Whether the API will deserialize unknown events.</param>
        /// <returns>The service collection, with the services.</returns>
        public static IServiceCollection ConfigureDiscordJsonConverters
        (
            this IServiceCollection serviceCollection,
            string? optionsName = "Orchestrator",
            bool allowUnknownEvents = true
        )
        {
            var snakeCase = new SnakeCaseNamingPolicy();

            serviceCollection.TryAddSingleton(snakeCase);
            serviceCollection.ConfigureRestJsonConverters(optionsName);

            serviceCollection
                .Configure<JsonSerializerOptions>
                (
                    optionsName,
                    options =>
                    {
                        options.PropertyNamingPolicy = snakeCase;

                        /*
                        options
                            .AddAuditLogObjectConverters();
                        */
                    }
                );

            return serviceCollection;
        }

        /*
        /// <summary>
        /// Adds the JSON converters that handle audit log objects.
        /// </summary>
        /// <param name="options">The serializer options.</param>
        /// <returns>The options, with the converters added.</returns>
        private static JsonSerializerOptions AddAuditLogObjectConverters(this JsonSerializerOptions options)
        {
            options.AddDataObjectConverter<IAuditLog, AuditLog>();
            options.AddDataObjectConverter<IAuditLogEntry, AuditLogEntry>();
            options.AddDataObjectConverter<IOptionalAuditEntryInfo, OptionalAuditEntryInfo>()
                .WithPropertyConverter
                (
                    ae => ae.Type,
                    new StringEnumConverter<PermissionOverwriteType>(asInteger: true)
                );

            options.AddConverter<AuditLogChangeConverter>();

            return options;
        }
        */
    }
}
