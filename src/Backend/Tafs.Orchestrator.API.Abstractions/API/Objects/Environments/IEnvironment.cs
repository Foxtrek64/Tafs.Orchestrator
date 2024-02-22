//
//  IEnvironment.cs
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
using Remora.Rest.Core;
using Tafs.Orchestrator.API.Abstractions.API.Objects.Robots;

namespace Tafs.Orchestrator.API.Abstractions.API.Objects.Environments
{
    /// <summary>
    /// Describes a grouping of robots.
    /// </summary>
    [PublicAPI]
    public interface IEnvironment
    {
        /// <summary>
        /// Gets the name of the environment.
        /// </summary>
        [StringLength(100)] string Name { get; }

        /// <summary>
        /// Gets a description of the environment.
        /// </summary>
        [StringLength(500)] Optional<string> Description { get; }

        /// <summary>
        /// Gets a list of the robots associated with the current environment.
        /// </summary>
        Optional<IReadOnlyList<ISimpleRobot>> Robots { get; }

        /// <summary>
        /// Gets the environment type.
        /// </summary>
        [Obsolete("Deprecated in version 17.0.")]
        Optional<string> Type { get; }

        /// <summary>
        /// Gets the environment id.
        /// </summary>
        Optional<long> Id { get; }
    }
}
