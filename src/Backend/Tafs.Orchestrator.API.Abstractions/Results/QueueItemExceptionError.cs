//
//  QueueItemExceptionError.cs
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
using Remora.Rest.Core;
using Remora.Results;

namespace Tafs.Orchestrator.API.Abstractions.Results
{
    /// <summary>
    /// Stores information about exceptions thrown while processing failed queue items.
    /// </summary>
    /// <remarks>
    /// Represeents the ProcessingExceptionDto object.
    /// </remarks>
    public sealed record class QueueItemExceptionError
    (
        Optional<string> Reason,
        Optional<string> Details,
        Optional<QueueItemExceptionType> Type,
        Optional<string> AssociatedImageFilePath,
        Optional<DateTimeOffset> CreationTime
    )
        : ResultError(Reason.AsNullable() ?? "The queue item encountered an error while processing.")
    {
        /// <summary>
        /// Gets the reason the processing failed.
        /// </summary>
        public Optional<string> Reason { get; init; } = Reason;

        /// <summary>
        /// Gets additional details about the exception.
        /// </summary>
        public Optional<string> Details { get; init; } = Details;

        /// <summary>
        /// Gets the processing exception type.
        /// </summary>
        public Optional<QueueItemExceptionType> Type { get; init; } = Type;

        /// <summary>
        /// Gets a path on the robot host to an image file that stores relevant information
        /// about the exception - e.g. a system print screen.
        /// </summary>
        public Optional<string> AssociatedImageFilePath { get; init; } = AssociatedImageFilePath;

        /// <summary>
        /// Gets the time when the exception occurred.
        /// </summary>
        public Optional<DateTimeOffset> CreationTime { get; init; } = CreationTime;
    }
}
