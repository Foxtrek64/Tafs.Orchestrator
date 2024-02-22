//
//  IQueueItem.cs
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
using System.Text.Json;
using JetBrains.Annotations;
using Remora.Rest.Core;
using Tafs.Orchestrator.API.Abstractions.API.Objects.Entities;
using Tafs.Orchestrator.API.Abstractions.API.Objects.Robots;
using Tafs.Orchestrator.API.Abstractions.Results;

namespace Tafs.Orchestrator.API.Abstractions.API.Objects.QueueItems
{
    /// <summary>
    /// Defines a piece of data that can be processsed by a bot and the information associated with its processing status.
    /// Queue items are grouped in queues.
    /// </summary>
    [PublicAPI]
    public interface IQueueItem : ILongVersionedEntity
    {
        /// <summary>
        /// Gets the id of the queue this item belongs to.
        /// </summary>
        Optional<long> QueueDefinitionId { get; }

        // Queue Definition intentionally excluded.

        /// <summary>
        /// Gets information about why this queue item failed.
        /// Will be empty if the queue item is not in a failed status.
        /// </summary>
        Optional<QueueItemExceptionError?> ProcessingException { get; }

        /// <summary>
        /// Gets a value indicating whether the item has encrypted data in the database.
        /// </summary>
        Optional<bool> Encrypted { get; }

        /// <summary>
        /// Gets custom data for use when processing the queue item.
        /// </summary>
        Optional<JsonElement> SpecificContent { get; }

        /// <summary>
        /// Gets <see cref="SpecificContent"/> as a raw json string.
        /// </summary>
        Optional<string?> SpecificData { get; }

        /// <summary>
        /// Gets custom data from processing output.
        /// </summary>
        Optional<JsonElement> Output { get; }

        /// <summary>
        /// Gets <see cref="Output"/> as a raw json string.
        /// </summary>
        Optional<string?> OutputData { get; }

        /// <summary>
        /// Gets custom data for further analytics processing.
        /// </summary>
        Optional<JsonElement> Analytics { get; }

        /// <summary>
        /// Gets <see cref="Analytics"/> as a raw json string.
        /// </summary>
        Optional<string?> AnalyticsData { get; }

        /// <summary>
        /// Gets the processing state of the item.
        /// </summary>
        Optional<QueueItemStatus> Status { get; }

        /// <summary>
        /// Gets the review state of the item.
        /// </summary>
        /// <remarks>
        /// Present only if the queue item <see cref="Status"/> is <see cref="QueueItemStatus.Failed"/>.
        /// </remarks>
        Optional<QueueItemReviewStatus> ReviewStatus { get; }

        /// <summary>
        /// Gets the user id of the reviewer.
        /// </summary>
        /// <remarks>
        /// Present only if the queue item <see cref="Status"/> is <see cref="QueueItemStatus.Failed"/>
        /// and <see cref="ReviewStatus"/> is <see cref="QueueItemReviewStatus.InReview"/>.
        /// </remarks>
        Optional<long?> ReviewerUserId { get; }

        // ReviewerUser intentionally omitted.

        /// <summary>
        /// Gets the unique identifier of this queue item.
        /// </summary>
        Optional<Guid> Key { get; }

        /// <summary>
        /// Gets an optional, user-specified value for queue item identification.
        /// </summary>
        [StringLength(128)] Optional<string?> Reference { get; }

        /// <summary>
        /// Gets the procesing exception type.
        /// </summary>
        Optional<QueueItemExceptionType> ProcessingExceptionType { get; }

        /// <summary>
        /// Gets the latest date and time at which the item should be processed.
        /// </summary>
        Optional<DateTimeOffset?> DueDate { get; }

        /// <summary>
        /// Gets the time which is considered as a risk zone for the item to be processed.
        /// </summary>
        Optional<DateTimeOffset?> RiskSlaDate { get; }

        /// <summary>
        /// Getst he processing importance for a given item.
        /// </summary>
        Optional<QueueItemPriority> Priority { get; }

        /// <summary>
        /// Gets the robot responsible for processing this queue item.
        /// </summary>
        Optional<ISimpleRobot> Robot { get; }

        /// <summary>
        /// Gets the earliest date and time at which the itme is available for processing.
        /// </summary>
        Optional<DateTimeOffset?> DeferDate { get; }

        /// <summary>
        /// Gets the date and time at which the item started processing.
        /// </summary>
        Optional<DateTimeOffset?> StartProcessing { get; }

        /// <summary>
        /// Gets the date and time at which the item ended processing.
        /// </summary>
        Optional<DateTimeOffset?> EndProcessing { get; }

        /// <summary>
        /// Gets the total number of seconds that the last failed processing lasted.
        /// </summary>
        Optional<int> SecondsInPreviousAttempts { get; }

        /// <summary>
        /// Gets the id of an ancestor item connected to the current item.
        /// </summary>
        Optional<long?> AncestorId { get; }

        /// <summary>
        /// Gets the number of times this work item has been processed.
        /// </summary>
        /// <remarks>
        /// This can be higher than 0 only if MaxRetried is set and the item processing
        /// failed at least once with ApplicationException.
        /// </remarks>
        Optional<int> RetryNumber { get; }

        /// <summary>
        /// Gets the date and time when the item was created.
        /// </summary>
        Optional<DateTimeOffset> CreationTime { get; }

        /// <summary>
        /// Gets the current queue item progress.
        /// </summary>
        Optional<string?> Progress { get; }

        /// <summary>
        /// Gets the folder this queue belongs to.
        /// </summary>
        [Obsolete("Deprecated in 17.0", false)] Optional<int> OrganizationUnitId { get; }

        /// <summary>
        /// Gets the fully-qualified folder name.
        /// </summary>
        [Obsolete("Deprecated in 17.0", false)] Optional<string> OrganizationUnitFullyQualifiedName { get; }
    }
}
