//
//  QueueItemStatus.cs
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

namespace Tafs.Orchestrator.API.Abstractions.API.Objects.QueueItems
{
    /// <summary>
    /// Enumerates the queue statuses.
    /// </summary>
    public enum QueueItemStatus
    {
        /// <summary>
        /// The queue item was created and is awaiting processing.
        /// </summary>
        New = 0,

        /// <summary>
        /// The queue item is currently being worked.
        /// </summary>
        InProgress = 1,

        /// <summary>
        /// The queue items failed processing.
        /// </summary>
        Failed = 2,

        /// <summary>
        /// The queue item was successful.
        /// </summary>
        Successful = 3,

        /// <summary>
        /// The queue item was abandoned.
        /// </summary>
        Abandoned = 4,

        /// <summary>
        /// The queue item was retried.
        /// </summary>
        Retried = 5,

        /// <summary>
        /// The queue item was deleted.
        /// </summary>
        Deleted = 6,
    }
}
