//
//  IDirectoryPermission.cs
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
using Tafs.Orchestrator.API.Abstractions.API.Objects.Roles;

namespace Tafs.Orchestrator.API.Abstractions.API.Objects.DirectoryService
{
    /// <summary>
    /// Represents a directory permission.
    /// </summary>
    [PublicAPI]
    public interface IDirectoryPermission
    {
        /// <summary>
        /// Gets the name of the directory group modified by this permission.
        /// </summary>
        public string DirectoryGroup { get; }

        /// <summary>
        /// Gets a list of organization units.
        /// </summary>
        public IReadOnlyList<IUserOrganizationUnit> OrganizationUnits { get; }

        /// <summary>
        /// Gets a list of roles.
        /// </summary>
        public IReadOnlyList<ILightRole> Roles { get; }
    }
}
