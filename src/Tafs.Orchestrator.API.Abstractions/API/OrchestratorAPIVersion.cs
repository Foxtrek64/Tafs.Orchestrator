//
//  OrchestratorAPIVersion.cs
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

namespace Tafs.Orchestrator.API.Abstractions.API
{
    /// <summary>
    /// Enumerates various released versions of Orchestrator's API.
    /// </summary>
    [PublicAPI]
    public enum OrchestratorAPIVersion
    {
        /// <summary>
        /// Version 17.0 of the API.
        /// </summary>
        V17 = 17,

        /// <summary>
        /// Version 18 of the API.
        /// </summary>
        V18 = 18,

        /// <summary>
        /// The current, stapble version of the API.
        /// </summary>
        Stable = V18
    }
}
