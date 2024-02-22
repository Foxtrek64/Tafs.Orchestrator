//
//  ISimpleRobot.cs
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
using Remora.Rest.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using Tafs.Orchestrator.API.Abstractions.API.Objects.Environments;

namespace Tafs.Orchestrator.API.Abstractions.API.Objects.Robots
{
    /// <summary>
    /// Represents a simple robot.
    /// </summary>
    [PublicAPI]
    public interface ISimpleRobot
    {
        /// <summary>
        /// Gets the robot license key.
        /// </summary>
        /// <remarks>
        /// The key is automatically generated from the server for the robot machine.
        /// For the robot to work, the same key must exist on both the robot and orchestrator.
        /// All bots on a machine must have the same license key in order to register correctly.
        /// </remarks>
        [StringLength(255)] Optional<string> LicenseKey { get; }

        /// <summary>
        /// Gets the name of the machine a robot is hosted on.
        /// </summary>
        [StringLength(450)] Optional<string> MachineName { get; }

        Optional<long> MachineId { get; }

        /// <summary>
        /// Gets a custom name for the robot.
        /// </summary>
        [StringLength(19)] string Name { get; }

        /// <summary>
        /// Gets the machine username.
        /// </summary>
        /// <remarks>
        /// If the user is in a domain, the username must be in a DOMAIN\username format.
        /// </remarks>
        [StringLength(100)] Optional<string> Username { get; }

        /// <summary>
        /// Gets the value of the key in the external store used to store the password.
        /// </summary>
        [StringLength(450)] Optional<string> ExternalName { get; }

        /// <summary>
        /// Gets additional information about the robot.
        /// </summary>
        [StringLength(500)] string Description { get; }

        /// <summary>
        /// Gets the robot type.
        /// </summary>
        RobotType Type { get; }

        /// <summary>
        /// Gets the hosting type.
        /// </summary>
        HostingType HostingType { get; }

        /// <summary>
        /// Gets the robot provision type.
        /// </summary>
        Optional<ProvisionType> ProvisionType { get; }

        /// <summary>
        /// Gets the Windows password associated with the machine username.
        /// </summary>
        [StringLength(100)] Optional<string> Password { get; }

        /// <summary>
        /// Gets the Credential Store used to store the password.
        /// </summary>
        Optional<long> CredentialStoreId { get; }

        /// <summary>
        /// Gets the associated user's id.
        /// </summary>
        Optional<long?> UserId { get; }

        /// <summary>
        /// Gets a value indicating whether the robot is enabled.
        /// </summary>
        Optional<bool> Enabled { get; }

        /// <summary>
        /// Gets the robot credentials type.
        /// </summary>
        Optional<CredentialType> CredentialType { get; }

        /// <summary>
        /// Gets a collection of the environments the robot is part of.
        /// </summary>
        Optional<IReadOnlyList<IEnvironment>> Environments { get; }

        /// <summary>
        /// Gets a list of the environment names the robot is a member of.
        /// </summary>
        Optional<IReadOnlyList<string>> RobotEnvironments { get; }

        /// <summary>
        /// Gets a colleciton of key-value pairs containing execution settings for the robot.
        /// </summary>
        Optional<JsonElement> ExecutionSettings { get; }

        /// <summary>
        /// Gets a value indicating whether the robot uses an external licese.
        /// </summary>
        Optional<bool> IsExternalLicensed { get; }

        /// <summary>
        /// Gets a value indicating whther the bot can be used concurrently on multiple machines.
        /// </summary>
        Optional<bool> LimitConcurrentExecution { get; }

        /// <summary>
        /// Gets the date and time this robot was last modified.
        /// </summary>
        Optional<DateTimeOffset?> LastModificationTime { get; }

        /// <summary>
        /// Gets the user id of the user who last modified this robot.
        /// </summary>
        Optional<long?> LastModifierUserId { get; }

        /// <summary>
        /// Gets the date and time this robot was created.
        /// </summary>
        Optional<DateTimeOffset> CreationTime { get; }

        /// <summary>
        /// Gets the id of the user who created this robot.
        /// </summary>
        Optional<long> CreatorUserId { get; }

        /// <summary>
        /// Gets the id of this robot.
        /// </summary>
        Optional<long> Id { get; }
    }
}
