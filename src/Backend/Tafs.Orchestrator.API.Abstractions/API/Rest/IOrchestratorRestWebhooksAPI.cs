//
//  IOrchestratorRestWebhooksAPI.cs
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
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Remora.Rest.Core;
using Remora.Results;
using Tafs.Orchestrator.API.Abstractions.API.Objects.OData;
using Tafs.Orchestrator.API.Abstractions.API.Objects.Webhooks;

namespace Tafs.Orchestrator.API.Abstractions.API.Rest
{
    /// <summary>
    /// Represents the Orchestrator Webhooks API.
    /// </summary>
    [PublicAPI]
    public interface IOrchestratorRestWebhooksAPI
    {
        /// <summary>
        /// Gets a list of webhooks.
        /// </summary>
        /// <param name="parameters">OData parameters to use to filter the results.</param>
        /// <param name="ct">A cancellation tokn for this operation.</param>
        /// <returns>A list of webhooks.</returns>
        Task<Result<IEnumerable<IWebhook>>> ListWebhooksAsync(IParameters? parameters = null, CancellationToken ct = default);

        /// <summary>
        /// Creates a new webhook based off the provided webhook.
        /// </summary>
        /// <param name="key">The key used to identify the webhook.</param>
        /// <param name="name">The name.</param>
        /// <param name="url">The url.</param>
        /// <param name="enabled">Webhook Enabled.</param>
        /// <param name="subscribeToAllEvents">Subscribe to everything.</param>
        /// <param name="allowInsecureSsl">Allow insecure ssl.</param>
        /// <param name="description">The description.</param>
        /// <param name="secret">Webhook secret.</param>
        /// <param name="events">List of events to subscribe to.</param>
        /// <param name="ct">A cancellation tokn for this operation.</param>
        /// <returns>The updated webhook.</returns>
        /// <returns>The created webhook.</returns>
        Task<Result<IWebhook>> CreateWebhookAsync
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
        );

        /// <summary>
        /// Gets a webhook using the provided key.
        /// </summary>
        /// <param name="key">The key which identifies the webhook.</param>
        /// <param name="parameters">OData parameters.</param>
        /// <param name="ct">A cancellation tokn for this operation.</param>
        /// <returns>The webhook.</returns>
        Task<Result<IWebhook>> GetWebhookByKeyAsync(long key, IParameters? parameters = null, CancellationToken ct = default);

        /// <summary>
        /// Updates an existing webhook subscription.
        /// </summary>
        /// <param name="key">The key to use to identify the webhook.</param>
        /// <param name="webhook">The webhook with updated values.</param>
        /// <param name="ct">A cancellation tokn for this operation.</param>
        /// <returns>The updated webhook.</returns>
        Task<Result<IWebhook>> UpdateWebhookAsync(long key, IWebhook webhook, CancellationToken ct = default);

        /// <summary>
        /// Patches a webhook.
        /// </summary>
        /// <param name="key">The key used to identify the webhook.</param>
        /// <param name="webhookKey">The key from the webhook.</param>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        /// <param name="url">The url.</param>
        /// <param name="enabled">Webhook Enabled.</param>
        /// <param name="secret">Webhook secret.</param>
        /// <param name="subscribeToAllEvents">Subscribe to everything.</param>
        /// <param name="allowInsecureSsl">Allow insecure ssl.</param>
        /// <param name="events">List of events to subscribe to.</param>
        /// <param name="ct">A cancellation tokn for this operation.</param>
        /// <returns>The updated webhook.</returns>
        Task<Result<IWebhook>> UpdateWebhookAsync
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
        );

        /// <summary>
        /// Deletes a webhook.
        /// </summary>
        /// <param name="key">The key to use to identify the webhook.</param>
        /// <param name="ct">A cancellation tokn for this operation.</param>
        /// <returns>A deletion result which may or may not have succeeded.</returns>
        Task<Result> DeleteWebhookAsync(long key, CancellationToken ct = default);

        /// <summary>
        /// Sends a Ping request to a webhook endpoint to test the webhook.
        /// </summary>
        /// <param name="key">The key used to identify the webhook.</param>
        /// <param name="parameters">OData parameters used to filter the result.</param>
        /// <param name="ct">A cancellation token for this operation.</param>
        /// <returns>The ping event.</returns>
        Task<Result<IPingEvent>> PingWebhookAsync(long key, IParameters? parameters = null, CancellationToken ct = default);

        /// <summary>
        /// Gets a list of event types a webhook can subscribe to.
        /// </summary>
        /// <param name="parameters">OData parameters used to filter the result.</param>
        /// <param name="ct">A cancellation tokn for this operation.</param>
        /// <returns>A list of webhooks.</returns>
        Task<Result<IEnumerable<IWebhookEventType>>> GetEventTypesAsync(IParameters parameters, CancellationToken ct = default);

        /// <summary>
        /// Triggers a custom event type.
        /// </summary>
        /// <typeparam name="TPayload">The type of the payload.</typeparam>
        /// <param name="payload">The event payload.</param>
        /// <param name="parameters">OData parameters used to filter the result.</param>
        /// <param name="ct">A cancellation tokn for this operation.</param>
        /// <returns>The custom event.</returns>
        Task<Result<ICustomEvent<TPayload>>> TriggerCustomEventAsync<TPayload>
        (
            TPayload payload,
            IParameters? parameters = null,
            CancellationToken ct = default
        );
    }
}
