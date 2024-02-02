//
//  IRole.cs
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

using System.Collections.Generic;
using JetBrains.Annotations;
using Tafs.Orchestrator.API.Abstractions.API.Objects.Permissions;

namespace Tafs.Orchestrator.API.Abstractions.API.Objects.Roles
{
    /// <summary>
    /// A role acts as a grouping of permissions.
    /// Roles are associated with users to provide application authorization.
    /// </summary>
    [PublicAPI]
    public interface IRole : ILightRole
    {
        /// <summary>
        /// Gets the role type based on the permissions it includes.
        /// </summary>
        RoleType Type { get; }

        /// <summary>
        /// Gets a list of permissions.
        /// </summary>
        IReadOnlyList<IPermission> Permissions { get; }
    }
}
