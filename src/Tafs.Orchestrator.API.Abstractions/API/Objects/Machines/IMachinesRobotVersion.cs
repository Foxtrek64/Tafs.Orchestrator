//
//  IMachinesRobotVersion.cs
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

namespace Tafs.Orchestrator.API.Abstractions.API.Objects.Machines
{
    /// <summary>
    /// Describes a version of a robot.
    /// </summary>
    public interface IMachinesRobotVersion
    {
        /// <summary>
        /// Gets the number of Robots on the machine with the specified version.
        /// </summary>
        long Count { get; }

        /// <summary>
        /// Gets the version of the Robot hosted on the machine.
        /// </summary>
        string Version { get; }

        /// <summary>
        /// Gets the id of the Machine.
        /// </summary>
        long MachineId { get; }
    }
}
