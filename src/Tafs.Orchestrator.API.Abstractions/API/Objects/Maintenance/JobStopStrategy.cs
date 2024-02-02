//
//  JobStopStrategy.cs
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

namespace Tafs.Orchestrator.API.Abstractions.API.Objects.Maintenance
{
    /// <summary>
    /// Enumerates the job stop strategies for a maintenance window.
    /// </summary>
    [PublicAPI]
    public enum JobStopStrategy
    {
        /// <summary>
        /// Do not stop bots. Wait for them to finish.
        /// </summary>
        None,

        /// <summary>
        /// Terminate bot processes.
        /// </summary>
        Kill
    }
}
