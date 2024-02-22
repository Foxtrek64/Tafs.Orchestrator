//
//  RobotType.cs
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

namespace Tafs.Orchestrator.API.Abstractions.API.Objects.Robots
{
    /// <summary>
    /// Enumerates the types of robots.
    /// </summary>
    public enum RobotType
    {
        /// <summary>
        /// Non-production unattended license. For development purposes only. Cannot execute test cases.
        /// </summary>
        NonProduction,

        /// <summary>
        /// Works on the same workstation as a humnan user and is launched through user agents.
        /// </summary>
        Attended,

        /// <summary>
        /// Runs without human intervention and can automate any number of processes. Has all the
        /// capabilities of an attended bot plus remote execution, monitoring, scheduling, and providing support
        /// for work queues. Can execute any process type except for test cases.
        /// </summary>
        Unattended,

        /// <summary>
        /// Legacy robot development license. Replaced with <see cref="NonProduction"/>.
        /// </summary>
        [Obsolete("Replaced with NonProduction")]
        Development,

        /// <summary>
        /// Legacy Studio developer license. Replaced by RpaDeveloper.
        /// </summary>
        [Obsolete("Replaced by RpaDeveloper")]
        Studio,

        /// <summary>
        /// Connects your Studio to Orchestrator for development purposes.
        /// </summary>
        RpaDeveloper,

        /// <summary>
        /// Legacy StudioX developer license. Replaced by <see cref="CitizenDeveloper"/>.
        /// </summary>
        StudioX,

        /// <summary>
        /// Connects your StudioX to Orchestrator for development purposes.
        /// </summary>
        CitizenDeveloper,

        /// <summary>
        /// Server without a desktop environment such as Server Core.
        /// </summary>
        Headless,

        /// <summary>
        /// Legacy developer license with expanded features. Replaced by <see cref="RpaDeveloper"/>.
        /// </summary>
        [Obsolete("Replaced by RpaDeveloper.")]
        RpaDeveloperPro,

        /// <summary>
        /// Legacy Studio license with expanded features. Replaced by <see cref="RpaDeveloper"/>.
        /// </summary>
        [Obsolete("Replaced by RpaDeveloper.")]
        StudioPro,

        /// <summary>
        /// Robot for running tests.
        /// </summary>
        TestAutomation,

        /// <summary>
        /// Cloud-hosted Orchestrator.
        /// </summary>
        AutomationCloud,

        /// <summary>
        /// Serverless cloud-hosted robot.
        /// </summary>
        Serverless,

        /// <summary>
        /// UiPath Starter Kit license.
        /// </summary>
        AutomationKit,

        /// <summary>
        /// Serverless robot for running tests.
        /// </summary>
        ServerlessTestAutomation,

        /// <summary>
        /// Test automation running in the Automation Cloud.
        /// </summary>
        AutomationCloudTestAutomation,

        /// <summary>
        /// Cloud-based automation canvas, enabling you to build and test cross-platform automations across online business
        /// apps and service.
        /// </summary>
        AttendedStudioWeb
    }
}
