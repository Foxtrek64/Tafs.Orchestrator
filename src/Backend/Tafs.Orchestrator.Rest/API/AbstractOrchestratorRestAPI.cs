//
//  AbstractOrchestratorRestAPI.cs
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
using System.Text.Json;
using JetBrains.Annotations;
using Remora.Rest;
using Tafs.Orchestrator.Caching.Abstractions.Services;

namespace Tafs.Orchestrator.Rest.Rest
{
    /// <summary>
    /// Acts as an abstract base for REST API instances.
    /// </summary>
    public abstract class AbstractOrchestratorRestAPI : IRestCustomizable
    {
        /// <summary>
        /// Gets the <see cref="RestHttpClient{TError}"/> available to the API instance.
        /// </summary>
        protected IRestHttpClient RestHttpClient { get; }

        /// <summary>
        /// Gets the <see cref="JsonSerializerOptions"/> available to the API instance.
        /// </summary>
        protected JsonSerializerOptions JsonOptions { get; }

        /// <summary>
        /// Gets the rate limit memory cache.
        /// </summary>
        protected ICacheProvider RateLimitCache { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AbstractOrchestratorRestAPI"/> class.
        /// </summary>
        /// <param name="restHttpClient">The Orchestrator-specialized http client.</param>
        /// <param name="jsonOptions">The Remora-specialized json options.</param>
        /// <param name="rateLimitCache">The memor cache used for rate limits.</param>
        protected AbstractOrchestratorRestAPI
        (
            IRestHttpClient restHttpClient,
            JsonSerializerOptions jsonOptions,
            ICacheProvider rateLimitCache
        )
        {
            RestHttpClient = restHttpClient;
            JsonOptions = jsonOptions;
            RateLimitCache = rateLimitCache;
        }

        /// <inheritdoc/>
        public RestRequestCustomization WithCustomization(Action<RestRequestBuilder> requestCustomizer)
        {
            return RestHttpClient.WithCustomization(requestCustomizer);
        }

        /// <inheritdoc/>
        public void RemoveCustomization(RestRequestCustomization customization)
        {
            RestHttpClient.RemoveCustomization(customization);
        }
    }
}
