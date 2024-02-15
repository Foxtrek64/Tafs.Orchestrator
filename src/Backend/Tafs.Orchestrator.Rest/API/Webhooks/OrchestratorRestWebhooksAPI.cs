//
//  OrchestratorRestWebhooksAPI.cs
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
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Remora.Rest;
using Remora.Rest.Core;
using Remora.Rest.Extensions;
using Remora.Results;
using Tafs.Orchestrator.API.Abstractions.API.Objects.OData;
using Tafs.Orchestrator.API.Abstractions.API.Objects.Webhooks;
using Tafs.Orchestrator.API.Abstractions.API.Rest;
using Tafs.Orchestrator.Caching.Abstractions.Services;
using Tafs.Orchestrator.Rest.Extensions;
using Tafs.Orchestrator.Rest.Rest;

namespace Tafs.Orchestrator.Rest.API.Webhooks
{
    /// <inheritdoc cref="IOrchestratorRestWebhooksAPI"/>
    public sealed class OrchestratorRestWebhooksAPI
    (
            IRestHttpClient restHttpClient,
            JsonSerializerOptions jsonOptions,
            ICacheProvider rateLimitCache
    )
        : AbstractOrchestratorRestAPI(restHttpClient, jsonOptions, rateLimitCache),
        IOrchestratorRestWebhooksAPI
    {
        /// <inheritdoc/>
        public async Task<Result<IEnumerable<IWebhook>>> ListWebhooksAsync(IParameters? parameters = null, CancellationToken ct = default)
        {
            var result = await RestHttpClient.GetAsync<ODataCollectionWrapper<IWebhook>>
            (
                "odata/Webhooks",
                b => b
                    .AddODataQueryParameters(parameters)
                    .WithRateLimitContext(RateLimitCache),
                ct: ct
            );

            return result.IsDefined(out var odataCollectionWrapper)
                ? Result<IEnumerable<IWebhook>>.FromSuccess(odataCollectionWrapper.Value)
                : Result<IEnumerable<IWebhook>>.FromError(result);
        }

        /// <inheritdoc/>
        public async Task<Result<IWebhook>> CreateWebhookAsync
        (
            Guid key,
            string name,
            Uri url,
            bool enabled,
            bool subscribeToAllEvents,
            bool allowInsecureSsl,
            Optional<string> description = default,
            Optional<string> secret = default,
            Optional<IReadOnlyList<IPartialWebhookEvent>> events = default,
            CancellationToken ct = default
        )
        {
            if (name.Length > 128)
            {
                return new ArgumentOutOfRangeError(nameof(name), "The name must be between 0 and 128 characters.");
            }

            if (url.AbsoluteUri.Length > 2000)
            {
                return new ArgumentOutOfRangeError(nameof(name), "The url must be between 0 and 2000 characters.");
            }

            if (secret.HasValue && secret.Value.Length > 100)
            {
                return new ArgumentOutOfRangeError(nameof(secret), "The secret must be between 0 and 100 characters.");
            }

            return await RestHttpClient.PostAsync<IWebhook>
            (
                "odata/Webhooks",
                b => b.WithJson
                    (
                        json =>
                        {
                            json.WriteString("Key", key);
                            json.WriteString("Name", name);
                            json.Write("Description", description, JsonOptions);
                            json.WriteString("Url", url.AbsoluteUri);
                            json.WriteBoolean("Enabled", enabled);
                            json.Write("Secret", secret, JsonOptions);
                            json.WriteBoolean("SubscribeToAllEvents", subscribeToAllEvents);
                            json.WriteBoolean("AllowInsecureSsl", allowInsecureSsl);
                            json.Write("Events", events, JsonOptions);
                        }
                    ).WithRateLimitContext(RateLimitCache),
                ct: ct);
        }

        /// <inheritdoc/>
        public Task<Result<IWebhook>> GetWebhookByKeyAsync(long key, IParameters? parameters = null, CancellationToken ct = default)
            => RestHttpClient.GetAsync<IWebhook>
            (
                $"/odata/Webhooks({key})",
                b => b
                    .AddQueryParameter("$expand", parameters?.Expand ?? default)
                    .AddQueryParameter("$select", parameters?.Select ?? default),
                ct: ct
            );

        /// <inheritdoc/>
        public Task<Result<IWebhook>> UpdateWebhookAsync(long key, IWebhook webhook, CancellationToken ct = default)
            => RestHttpClient.PutAsync<IWebhook>
            (
                $"/odata/Webhooks({key})",
                b => b.WithJson(json =>
                {
                    json.Write("Key", webhook.Key, JsonOptions);
                    json.WriteString("Name", webhook.Name);
                    json.Write("Description", webhook.Description, JsonOptions);
                    json.WriteString("Url", webhook.Url.AbsoluteUri);
                    json.WriteBoolean("Enabled", webhook.Enabled);
                    json.Write("Secret", webhook.Secret, JsonOptions);
                    json.WriteBoolean("SubscribeToAllEvents", webhook.SubscribeToAllEvents);
                    json.WriteBoolean("AllowInsecureSsl", webhook.AllowInsecureSsl);
                    json.Write("Events", webhook.Events, JsonOptions);
                    json.Write("Id", webhook.Id, JsonOptions);
                }).WithRateLimitContext(RateLimitCache),
                ct: ct
            );

        /// <inheritdoc/>
        public Task<Result<IWebhook>> UpdateWebhookAsync
        (
            long key,
            Optional<Guid> webhookKey = default,
            Optional<string> name = default,
            Optional<string> description = default,
            Optional<Uri> url = default,
            Optional<bool> enabled = default,
            Optional<string> secret = default,
            Optional<bool> subscribeToAllEvents = default,
            Optional<bool> allowInsecureSsl = default,
            Optional<IReadOnlyList<IPartialWebhookEvent>> events = default,
            CancellationToken ct = default
        )
            => RestHttpClient.PatchAsync<IWebhook>
            (
                $"/odata/Webhooks({key})",
                b => b.WithJson(json =>
                {
                    json.Write("Key", webhookKey, JsonOptions);
                    json.Write("Name", name, JsonOptions);
                    json.Write("Description", description, JsonOptions);
                    Optional<string?> absoluteUri = url.HasValue
                        ? url.Value?.AbsoluteUri
                        : default;
                    json.Write("Url", absoluteUri, JsonOptions);
                    json.Write("Enabled", enabled, JsonOptions);
                    json.Write("Secret", secret, JsonOptions);
                    json.Write("SubscribeToAllEvents", subscribeToAllEvents, JsonOptions);
                    json.Write("AllowInsecureSsl", allowInsecureSsl, JsonOptions);
                    json.Write("Events", events, JsonOptions);
                }).WithRateLimitContext(RateLimitCache),
                ct: ct
            );

        /// <inheritdoc/>
        public Task<Result> DeleteWebhookAsync(long key, CancellationToken ct = default)
            => RestHttpClient.DeleteAsync
            (
                $"/odata/Webhooks({key})",
                b => b.WithRateLimitContext(RateLimitCache),
                ct
            );

        /// <inheritdoc/>
        public Task<Result<IPingEvent>> PingWebhookAsync(long key, IParameters? parameters = null, CancellationToken ct = default)
            => RestHttpClient.PostAsync<IPingEvent>
            (
                $"/odata/Webhooks({key})/UiPath.Server.Configuration.OData.Ping",
                b => b.AddQueryParameter("$expand", parameters?.Expand ?? default)
                .AddQueryParameter("$select", parameters?.Select ?? default)
                .WithRateLimitContext(RateLimitCache),
                ct: ct
            );

        /// <inheritdoc/>
        public async Task<Result<IEnumerable<IWebhookEventType>>> GetEventTypesAsync(IParameters? parameters = null, CancellationToken ct = default)
        {
            var result = await RestHttpClient.GetAsync<ODataCollectionWrapper<IWebhookEventType>>
                (
                    "/odata/Webhooks/UiPath.Server.Configuration.OData.GetEventTypes",
                    b => b.AddODataQueryParameters(parameters).WithRateLimitContext(RateLimitCache),
                    ct: ct
                );

            return result.IsDefined(out var odataCollectionWrapper)
                ? Result<IEnumerable<IWebhookEventType>>.FromSuccess(odataCollectionWrapper.Value)
                : Result<IEnumerable<IWebhookEventType>>.FromError(result);
        }

        /// <inheritdoc/>
        public async Task<Result<ICustomEvent<TPayload>>> TriggerCustomEventAsync<TPayload>
        (
            TPayload payload,
            IParameters? parameters = null,
            CancellationToken ct = default
        )
            => await RestHttpClient.PostAsync<ICustomEvent<TPayload>>
            (
                "/odata/Webhooks/UiPath.Server.Configuration.OData.TriggerCustom",
                b => b
                    .WithJson(json => JsonSerializer.Serialize(json, payload, JsonOptions), withStartEndMarkers: false)
                    .AddODataQueryParameters(parameters)
                    .WithRateLimitContext(RateLimitCache),
                ct: ct
            );
    }
}
