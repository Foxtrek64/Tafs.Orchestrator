//
//  IBulkOperationResponse.cs
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

using System.Collections.Generic;

namespace Tafs.Orchestrator.API.Abstractions.API.Objects.Bulk
{
    /// <summary>
    /// Represents the result of a bulk operation.
    /// </summary>
    /// <typeparam name="TItem">The type of item to return.</typeparam>
    public interface IBulkOperationResponse<out TItem>
    {
        /// <summary>
        /// Gets a value indicating whether the operation was a success.
        /// </summary>
        bool Success { get; }

        /// <summary>
        /// Gets the status of the operation.
        /// </summary>
        string Message { get; }

        /// <summary>
        /// Gets a list of the items that failed.
        /// </summary>
        IReadOnlyList<TItem> FailedItems { get; }
    }
}
