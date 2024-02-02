//
//  IWebhook.cs
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
using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;
using Remora.Rest.Core;

namespace Tafs.Orchestrator.API.Abstractions.API.Objects.Webhooks
{
    /// <summary>
    /// Represents a webhook.
    /// </summary>
    [PublicAPI]
    public interface IWebhook
    {
        /// <summary>
        /// Gets the unique id for this webhook.
        /// </summary>
        Optional<long> Id { get; }

        /// <summary>
        /// Gets the unique key for this webhook.
        /// </summary>
        Optional<Guid> Key { get; }

        /// <summary>
        /// Gets the name of the webhook.
        /// </summary>
        [StringLength(128)] string Name { get; }

        /// <summary>
        /// Gets the description.
        /// </summary>
        [StringLength(256)] Optional<string> Description { get; }

        /// <summary>
        /// Gets the URL the webhook posts to.
        /// </summary>
        [StringLength(2000)] Uri Url { get; }

        /// <summary>
        /// Gets a value indicating whether this webhook is enabled.
        /// </summary>
        bool Enabled { get; }

        /// <summary>
        /// Gets the webhook secret used to verify the endpoint.
        /// </summary>
        [StringLength(100)] Optional<string> Secret { get; }

        /// <summary>
        /// Gets a value indicating whether this webhook handles all events.
        /// </summary>
        bool SubscribeToAllEvents { get; }

        /// <summary>
        /// Gets a value indicating whether this endpoint will ignore SSL errors.
        /// </summary>
        bool AllowInsecureSsl { get; }

        /// <summary>
        /// Gets a list of events this webhook reports on.
        /// </summary>
        IReadOnlyList<IPartialWebhookEvent> Events { get; }
    }
}
