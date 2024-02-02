//
//  IUpdateInfo.cs
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
    /// Describes a specific update operation.
    /// </summary>
    [PublicAPI]
    public interface IUpdateInfo
    {
        /// <summary>
        /// Gets the status of this update operation.
        /// </summary>
        UpdateStatus UpdateStatus { get; }

        /// <summary>
        /// Gets the reason for this update.
        /// </summary>
        UpdateReason Reason { get; }

        /// <summary>
        /// Gets the version this update should update to.
        /// </summary>
        string TargetUpdateVersion { get; }

        /// <summary>
        /// Gets a value indicating whether this is a communtiy update.
        /// </summary>
        bool IsCommunity { get; }

        /// <summary>
        /// Gets a status string describing the progress of the update.
        /// </summary>
        string StatusInfo { get; }
    }
}
