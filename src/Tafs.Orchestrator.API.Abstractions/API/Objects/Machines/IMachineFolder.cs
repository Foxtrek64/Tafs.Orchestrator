//
//  IMachineFolder.cs
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
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;
using Tafs.Orchestrator.API.Abstractions.API.Objects.EndpointDetection;
using Tafs.Orchestrator.API.Abstractions.API.Objects.Robots;
using Tafs.Orchestrator.API.Abstractions.API.Objects.Updates;

namespace Tafs.Orchestrator.API.Abstractions.API.Objects.Machines
{
    /// <summary>
    /// Describes the machine that hosts the robot.
    /// </summary>
    [PublicAPI]
    public interface IMachineFolder
    {
        /// <summary>
        /// Gets the automatically generated key from the server for the robot machine.
        /// </summary>
        /// <remarks>
        /// For the robot to work, the same key must exist on both the robot and Orchestrator.
        /// All robots on a machine must have the same licese key in order to register correctly.
        /// </remarks>
        [StringLength(255)] string LicenseKey { get; }

        /// <summary>
        /// Gets the name of the Machine a robot is hosted on.
        /// </summary>
        [StringLength(450)] string Name { get; }

        /// <summary>
        /// Gets a description of the machine.
        /// </summary>
        [StringLength(500)] string Description { get; }

        /// <summary>
        /// Gets the type of the machine.
        /// </summary>
        MachineType Type { get; }

        /// <summary>
        /// Gets the scope of the machine.
        /// </summary>
        MachineScope Scope { get; }

        /// <summary>
        /// Gets the number of NonProduction slots to be reserved at runtime.
        /// </summary>
        int NonProductionSlots { get; }

        /// <summary>
        /// Gets the number of NonProduction slots to be reserved at runtime.
        /// </summary>
        int UnattendedSlots { get; }

        /// <summary>
        /// Gets the number of Headless slots to be reserved at runtime.
        /// </summary>
        int HeadlessSlots { get; }

        /// <summary>
        /// Gets the number of TestAutomation slots to be reserved at runtime.
        /// </summary>
        int TestAutomationSlots { get; }

        /// <summary>
        /// Gets the number of AutomationCloud slots to be reserved at runtime.
        /// </summary>
        int AutomationCloudSlots { get; }

        /// <summary>
        /// Gets the number of AutomationCloud TestAutomation slots to be reserved at runtime.
        /// </summary>
        int AutomationCloudTestAutomationSlots { get; }

        /// <summary>
        /// Gets an immutable unique identifier that is preserved during tenant migration.
        /// </summary>
        Guid Key { get; }

        /// <summary>
        /// Gets the EDR protection status of the connected hosts.
        /// </summary>
        EndpointDetectionStatus EndpointDetectionStatus { get; }

        /// <summary>
        /// Gets the versions of the Robots hosted on the Machine.
        /// </summary>
        IReadOnlyList<IMachinesRobotVersion> RobotVersions { get; }

        /// <summary>
        /// Gets a list of robots assigned to the machine template.
        /// </summary>
        IReadOnlyList<IRobotUser> RobotUsers { get; }

        /// <summary>
        /// Gets the automation type this machine supports.
        /// </summary>
        AutomationType AutomationType { get; }

        /// <summary>
        /// Gets the target frameworks the machine supports.
        /// </summary>
        MachineTargetFramework TargetFramework { get; }

        /// <summary>
        /// Gets the update policy for this machine.
        /// </summary>
        IUpdatePolicy UpdatePolicy { get; }
    }
}
