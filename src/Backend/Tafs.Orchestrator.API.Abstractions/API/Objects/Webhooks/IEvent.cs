//
//  IEvent.cs
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
using System.ComponentModel.DataAnnotations;
using Remora.Rest.Core;

namespace Tafs.Orchestrator.API.Abstractions.API.Objects.Webhooks
{
    /// <summary>
    /// Represents a webhook event.
    /// </summary>
    public interface IEvent
    {
        /// <summary>
        /// Gets the event type.
        /// </summary>
        string Type { get; }

        /// <summary>
        /// Gets the event id.
        /// </summary>
        [StringLength(50)] string EventId { get; }

        /// <summary>
        /// Gets the unique id of the entity.
        /// </summary>
        Optional<Guid> EntityKey { get; }

        /// <summary>
        /// Gets the timestamp of the event.
        /// </summary>
        Optional<DateTimeOffset> Timestamp { get; }

        /// <summary>
        /// Gets the source of the event.
        /// </summary>
        Optional<long> EventSourceId { get; }

        /// <summary>
        /// Gets the tenant id.
        /// </summary>
        Optional<int> TenantId { get; }

        /// <summary>
        /// Gets the organization id.
        /// </summary>
        Optional<long> OrganizationUnitId { get; }

        /// <summary>
        /// Gets the organization key.
        /// </summary>
        Optional<Guid> OrganizationalUnitKey { get; }

        /// <summary>
        /// Gets the user id.
        /// </summary>
        Optional<long> UserId { get; }
    }
}
