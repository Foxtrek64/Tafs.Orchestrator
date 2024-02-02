//
//  UpdateReason.cs
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
    /// Enumerates the reasons to perform an update operation.
    /// </summary>
    [PublicAPI]
    public enum UpdateReason
    {
        /// <summary>
        /// A new <see cref="UpdateType.SpecificVersion"/> is available.
        /// </summary>
        NonCompliantWithDifferentVersion,

        /// <summary>
        /// A new version is available.
        /// </summary>
        NonCompliantWithoutTargetVersion,

        /// <summary>
        /// Update not applicable because machine has not communicated in longer than cutoff date.
        /// </summary>
        NotApplicableForOlderSessions,

        /// <summary>
        /// Update not applicable because it is not relevant for the machine type.
        /// </summary>
        NotApplicableForMachineType,

        /// <summary>
        /// Update not applicable because the machine has no robots.
        /// </summary>
        NotApplicableTemplateWithoutRobotSessions,

        /// <summary>
        /// Update not applicable for the platform.
        /// </summary>
        NotApplicableForPlatform,

        /// <summary>
        /// Update not applicable for the target platform.
        /// </summary>
        NotApplicableForTargetPlatform
    }
}
