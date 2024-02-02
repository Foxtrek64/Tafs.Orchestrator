//
//  IPermission.cs
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

namespace Tafs.Orchestrator.API.Abstractions.API.Objects.Permissions
{
    /// <summary>
    /// Stores information about an application permission and role association.
    /// </summary>
    [PublicAPI]
    public interface IPermission
    {
        /// <summary>
        /// Gets the unique id of this permission.
        /// </summary>
        long Id { get; }

        /// <summary>
        /// Gets the name of the application permission.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets a value indicating whether a user associated with the role
        /// will be allowed or denied to perform the actions governed by the permission.
        /// </summary>
        bool IsGranted { get; }

        /// <summary>
        /// Gets the unique id of the role associated with the permission.
        /// </summary>
        int RoleId { get; }

        /// <summary>
        /// Gets the application scope in which the permission will be applied.
        /// </summary>
        PermissionScope Scope { get; }
    }
}
