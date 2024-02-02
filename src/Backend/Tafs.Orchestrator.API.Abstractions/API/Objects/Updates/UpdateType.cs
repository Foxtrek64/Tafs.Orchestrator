//
//  UpdateType.cs
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
    /// Enumerates the update policy types.
    /// </summary>
    [PublicAPI]
    public enum UpdateType
    {
        /// <summary>
        /// None. Do not automatically update robots..
        /// </summary>
        None = 0,

        /// <summary>
        /// Ensure all robots are running the specified version.
        /// </summary>
        SpecificVersion,

        /// <summary>
        /// Ensure all robots are running the latest version.
        /// </summary>
        LatestVersion,

        /// <summary>
        /// Ensure all robots are running the latest patch version.
        /// Further updates must be managed by an administrator.
        /// </summary>
        LatestPatch
    }
}
