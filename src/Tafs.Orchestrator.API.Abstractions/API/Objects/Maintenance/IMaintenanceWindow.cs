//
//  IMaintenanceWindow.cs
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
using JetBrains.Annotations;

namespace Tafs.Orchestrator.API.Abstractions.API.Objects.Maintenance
{
    /// <summary>
    /// Describes a maintenance window for a cloud machine.
    /// </summary>
    [PublicAPI]
    public interface IMaintenanceWindow
    {
        /// <summary>
        /// Gets a value indicating whether the maintenance window is enabled.
        /// </summary>
        bool Enabled { get; }

        /// <summary>
        /// Gets the strategy for stopping jobs when the window begins.
        /// </summary>
        JobStopStrategy JobStopStrategy { get; }

        /// <summary>
        /// Gets the recurrence pattern as a cron expression.
        /// </summary>
        string CronExpression { get; }

        /// <summary>
        /// Gets the timezone id.
        /// </summary>
        string TimezoneId { get; }

        /// <summary>
        /// Gets the duration of the maintenance window in minutes.
        /// </summary>
        int Duration { get; }

        /// <summary>
        /// Gets the next execution time of the maintenance window.
        /// </summary>
        DateTimeOffset NextExecutionTime { get; }
    }
}
