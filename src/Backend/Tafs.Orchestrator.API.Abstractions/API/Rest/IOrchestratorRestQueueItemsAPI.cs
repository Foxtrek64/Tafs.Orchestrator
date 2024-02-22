//
//  IOrchestratorRestQueueItemsAPI.cs
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
using System.Text;
using System.Threading.Tasks;
using Remora.Rest.Core;
using Remora.Results;
using Tafs.Orchestrator.API.Abstractions.API.Objects.Bulk;
using Tafs.Orchestrator.API.Abstractions.API.Objects.Entities;
using Tafs.Orchestrator.API.Abstractions.API.Objects.OData;
using Tafs.Orchestrator.API.Abstractions.API.Objects.QueueItems;

namespace Tafs.Orchestrator.API.Abstractions.API.Rest
{
    /// <summary>
    /// Represents the Orchestrator QueueItems API.
    /// </summary>
    public interface IOrchestratorRestQueueItemsAPI
    {
        /// <summary>
        /// Gets a collection of queue items based off the specified <paramref name="parameters"/>.
        /// </summary>
        /// <param name="parameters">OData parameters for configuring this request.</param>
        /// <param name="organizationId">The organization id.</param>
        /// <returns>A list of queue items.</returns>
        Task<Result<IEnumerable<IQueueItem>>> GetQueueItems(IParameters parameters, long organizationId);

        /// <summary>
        /// Gets the specified queue item by id.
        /// </summary>
        /// <param name="key">The unique id of the queue item.</param>
        /// <param name="organizationId">The organization id.</param>
        /// <returns>The requested queue item.</returns>
        Task<Result<IQueueItem>> GetQueueItem(long key, long organizationId);

        /// <summary>
        /// Deletes the specified queue item.
        /// </summary>
        /// <param name="key">The unique id of the queue item.</param>
        /// <param name="organizationId">The organization id.</param>
        /// <returns>The result of the delete operation.</returns>
        Task<Result> DeleteQueueItem(long key, long organizationId);

        /// <summary>
        /// Replaces the queue item with the specified <paramref name="key"/> with
        /// the specified <paramref name="item"/>.
        /// </summary>
        /// <param name="key">The unique id of the queue item.</param>
        /// <param name="item">The item to use to update the existing item.</param>
        /// <param name="organizationID">The organization id.</param>
        /// <returns>The result of the update operation.</returns>
        Task<Result> UpdateQueueItem(long key, IQueueItem item, long organizationID);

        /// <summary>
        /// Retrieves the last retry of the specified queue item.
        /// </summary>
        /// <param name="key">The unique id of the queue item.</param>
        /// <param name="parameters">OData parameters for configuring this request.</param>
        /// <param name="organizationId">The organization id.</param>
        /// <returns>The last retry, if available; otherwise, <see langword="null"/>.</returns>
        Task<Result<IQueueItem?>> GetItemLastRetry(long key, IParameters parameters, long organizationId);

        /// <summary>
        /// Gets data about the processing history of the given queue item.
        /// </summary>
        /// <param name="key">The unique id of the queue item.</param>
        /// <param name="parameters">OData parameters for configuring this request.</param>
        /// <param name="organizationId">The organization id.</param>
        /// <returns>All previous and current queue items with the specified <paramref name="key"/>.</returns>
        Task<Result<IEnumerable<IQueueItem>>> GetItemProcessingHistory(long key, IParameters parameters, long organizationId);

        /// <summary>
        /// Upodates the progress field of a queue item with the status <see cref="QueueItemStatus.InProgress"/>.
        /// </summary>
        /// <param name="key">The unique id of the queue item.</param>
        /// <param name="progress">The current status.</param>
        /// <param name="organizationId">The organization id.</param>
        /// <returns>The result of the update operation.</returns>
        Task<Result> SetTransactionProgress(long key, string progress, long organizationId);

        /// <summary>
        /// Returns a collection of users having the permission for Queue Items review.
        /// </summary>
        /// <param name="parameters">OData parameters for configuring this request.</param>
        /// <param name="organizationID">The organization id.</param>
        /// <returns>A list of reviewers.</returns>
        Task<Result<IEnumerable<ISimpleUser>>> GetReviewers(IParameters parameters, long organizationID);

        /// <summary>
        /// Sets the given queue items' statuses to Deleted.
        /// </summary>
        /// <param name="queueItems">A colleciton of ids of queue items to delete.</param>
        /// <param name="organizationId">The organization id.</param>
        /// <returns>A list of deleted ids.</returns>
        Task<Result<IBulkOperationResponse<long>>> DeleteBulk(IReadOnlyCollection<ILongVersionedEntity> queueItems, long organizationId);

        /// <summary>
        /// Sets the reviewer for multiple items.
        /// </summary>
        /// <remarks>
        /// To set the reviewer for a single item, use <see cref="UpdateQueueItem(long, IQueueItem, long)"/>.
        /// </remarks>
        /// <param name="userId">The id of the user to be set as the reviewer. If not provided, the reviewer is cleared.</param>
        /// <param name="queueItems">A list of queue items to update.</param>
        /// <param name="organizationId">The organization id.</param>
        /// <returns>A list of ids of updated queue items.</returns>
        Task<Result<IBulkOperationResponse<long>>> SetItemReviewerBulk(Optional<long> userId, IReadOnlyCollection<ILongVersionedEntity> queueItems, long organizationId);

        /// <summary>
        /// Updates the review status of the specified <paramref name="queueItems"/> to an indicated <paramref name="status"/>.
        /// </summary>
        /// <param name="status">The new value for the review status.</param>
        /// <param name="queueItems">The queue item ids to update.</param>
        /// <param name="organizationId">The organization id.</param>
        /// <returns>A list of ids of updated queue items.</returns>
        Task<Result<IBulkOperationResponse<long>>> SetItemReviewStatusBulk(string status, IReadOnlyCollection<ILongVersionedEntity> queueItems, long organizationId);
    }
}
