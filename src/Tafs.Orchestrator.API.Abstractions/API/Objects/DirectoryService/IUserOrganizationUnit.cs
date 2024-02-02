//
//  IUserOrganizationUnit.cs
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

namespace Tafs.Orchestrator.API.Abstractions.API.Objects.DirectoryService
{
    /// <summary>
    /// Describes an organization unit in Orchestrator.
    /// </summary>
    /// <remarks>
    /// An orchestrator unit can be understaood as a company department and it is used to group different entities.
    /// </remarks>
    [PublicAPI]
    public interface IUserOrganizationUnit
    {
        /// <summary>
        /// Gets the id of this User Organization Unit.
        /// </summary>
        long Id { get; }

        /// <summary>
        /// Gets the unique user id.
        /// </summary>
        long UserId { get; }

        /// <summary>
        /// Gets the name of the user.
        /// </summary>
        string Username { get; }

        /// <summary>
        /// Gets the unique id of the organization unit.
        /// </summary>
        long OrganizationUnitId { get; }

        /// <summary>
        /// Gets the name of the organization unit.
        /// </summary>
        string OrganizationUnitName { get; }
    }
}
