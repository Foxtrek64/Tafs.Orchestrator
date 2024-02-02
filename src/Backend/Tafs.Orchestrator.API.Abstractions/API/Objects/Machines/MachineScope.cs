//
//  MachineScope.cs
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

namespace Tafs.Orchestrator.API.Abstractions.API.Objects.Machines
{
    /// <summary>
    /// Enumerates the machine scopes.
    /// </summary>
    [PublicAPI]
    public enum MachineScope
    {
        /// <summary>
        /// Server operates on dedicated architecture (e.g. a local VM).
        /// </summary>
        Default,

        /// <summary>
        /// Server operates on shared archetecture.
        /// </summary>
        Shared,

        /// <summary>
        /// Server operates on PW archetecture.
        /// </summary>
        // TODO: Find out what this actually is/means.
        PW,

        /// <summary>
        /// Server operates on cloud (AWS/Azure) Virtual Private Servers.
        /// </summary>
        Cloud,

        /// <summary>
        /// Server operates in a serverless context (e.g. Docker).
        /// </summary>
        Serverless
    }
}
