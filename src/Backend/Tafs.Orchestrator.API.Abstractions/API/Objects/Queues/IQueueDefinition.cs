//
//  IQueueDefinition.cs
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
using System.Text.Json;
using JetBrains.Annotations;
using Remora.Rest.Core;
using Tafs.Orchestrator.API.Abstractions.API.Objects.Tags;

namespace Tafs.Orchestrator.API.Abstractions.API.Objects.Queues
{
    /// <summary>
    /// Describes an Orchestrator Queue Definition.
    /// </summary>
    /// <remarks>
    /// The definition of a work queue. A work queue contains work items that are processed by robots.
    /// </remarks>
    [PublicAPI]
    public interface IQueueDefinition
    {
        /// <summary>
        /// Gets the unique identifier of the queue.
        /// </summary>
        Optional<Guid> Key { get; }

        /// <summary>
        /// Gets the queue definition id.
        /// </summary>
        Optional<long> Id { get; }

        /// <summary>
        /// Gets the custom name for the queue.
        /// </summary>
        [StringLength(int.MaxValue, MinimumLength = 1)] string Name { get; }

        /// <summary>
        /// Gets additional information about the queue.
        /// </summary>
        Optional<string> Description { get; }

        /// <summary>
        /// Gets the number of times an item of this queue can be retried if its processing fails with an application
        /// exception and <see cref="AcceptAutomaticallyRetry"/> is <see langword="true"/>.
        /// </summary>
        Optional<int> MaxNumberOfRetries { get; }

        /// <summary>
        /// Gets a value indicating whether a robot should retry to process an item if a previous iteration failed with
        /// an application exception.
        /// </summary>
        Optional<bool> AcceptAutomaticallyRetry { get; }

        /// <summary>
        /// Gets a value indicating whether the Item Reference field should be unique per queue item.
        /// </summary>
        /// <remarks>
        ///  Deleted and retried items are not checked against this rule.
        /// </remarks>
        Optional<bool> EnforceUniqueReference { get; }

        /// <summary>
        /// Gets a value indicating whether the queue's item data is encrypted at rest.
        /// </summary>
        Optional<bool> Encrypted { get; }

        /// <summary>
        /// Gets the JSON schema enforced by the Specific Data field.
        /// </summary>
        Optional<JsonElement> SpecificDataJsonSchema { get; }

        /// <summary>
        /// Gets the JSON schema enforced by the Output Data field.
        /// </summary>
        Optional<JsonElement> OutputDataJsonSchema { get; }

        /// <summary>
        /// Gets the JSON schema enforced by the Analytics Data field.
        /// </summary>
        Optional<JsonElement> AnalyticsDataJsonSchema { get; }

        /// <summary>
        /// Gets the date and time when the queue was created.
        /// </summary>
        Optional<DateTimeOffset> CreationTime { get; }

        /// <summary>
        /// Gets the id of the process schedule associated with this queue.
        /// </summary>
        Optional<long> ProcessScheduleId { get; }

        /// <summary>
        /// Gets the queue item processing SLA on the QueueDefinition level.
        /// </summary>
        [ValueRange(0, 2147483647)] Optional<int> SlaInMinutes { get; }

        /// <summary>
        /// Gets the queue item processing Risk SLA on the QueueDefinition level.
        /// </summary>
        [ValueRange(0, 2147483647)] Optional<int> RiskSlaInMinutes { get; }

        /// <summary>
        /// Gets the ProcessId the queue is associated with.
        /// </summary>
        Optional<long> ReleaseId { get; }

        /// <summary>
        /// Gets a value indicating wheter the release is in the current folder.
        /// </summary>
        Optional<bool> IsProcessInCurrentFolder { get; }

        /// <summary>
        /// Gets the number of folders where the queue is shared.
        /// </summary>
        Optional<int> FolderCount { get; }

        /// <summary>
        /// Gets the folder this queue belongs to.
        /// </summary>
        [Obsolete("Deprecated in 17.0", false)] Optional<int> OrganizationUnitId { get; }

        /// <summary>
        /// Gets the fully-qualified folder name.
        /// </summary>
        [Obsolete("Deprecated in 17.0", false)] Optional<string> OrganizationUnitFullyQualifiedName { get; }

        /// <summary>
        /// Gets a set of tags describing this queue.
        /// </summary>
        IReadOnlyList<ITag> Tags { get; }
    }
}
