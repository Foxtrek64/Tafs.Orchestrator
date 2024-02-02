//
//  UpdateStatus.cs
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

using JetBrains.Annotations;

namespace Tafs.Orchestrator.API.Abstractions.API.Objects.Updates
{
    /// <summary>
    /// Enumerates the statuses of an update operation.
    /// </summary>
    [PublicAPI]
    public enum UpdateStatus
    {
        /// <summary>
        /// No update status.
        /// </summary>
        None = 0,

        /// <summary>
        /// An update is currently being installed.
        /// </summary>
        InProgress,

        /// <summary>
        /// An update failed.
        /// </summary>
        Failed,

        /// <summary>
        /// The Robot is not up to date and is pending an update.
        /// </summary>
        NonCompliant,

        /// <summary>
        /// The Robot is compliant. Nothing to do.
        /// </summary>
        Compliant,

        /// <summary>
        /// The update operation does not apply to this machine.
        /// </summary>
        /// <example>
        /// A Robot is running version 2023.1.1, but 2022.10.1 is the selected <see cref="UpdateType.SpecificVersion"/>.
        /// </example>
        NotApplicable,

        /// <summary>
        /// A Robot is noncompliant and an update is scheduled during a maintenance window.
        /// </summary>
        Scheduled,

        /// <summary>
        /// An update failed and is scheduled to retry during the next maintenance window.
        /// </summary>
        FailedRescheduled
    }
}
