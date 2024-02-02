//
//  ILightRole.cs
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

using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;

namespace Tafs.Orchestrator.API.Abstractions.API.Objects.Roles
{
    /// <summary>
    /// Describes a basic role.
    /// </summary>
    [PublicAPI]
    public interface ILightRole
    {
        /// <summary>
        /// Gets the unique id of this role.
        /// </summary>
        long Id { get; }

        /// <summary>
        /// Gets a custom name for this role.
        /// </summary>
        [MaxLength(64)] string Name { get; }

        /// <summary>
        /// Gets an alternative name used for UI display.
        /// </summary>
        [MaxLength(64)] string DisplayName { get; }

        /// <summary>
        /// Gets a value allowing grouping multiple roles together.
        /// </summary>
        string Groups { get; }

        /// <summary>
        /// Gets a value indicating whether this role is defined by the
        /// application and cnanot be deleted or it is user defined and
        /// can be deleted.
        /// </summary>
        bool IsStatic { get; }

        /// <summary>
        /// Gets a value indicating whether the permissions for this role
        /// can be modified at all.
        /// </summary>
        bool IsEditable { get; }
    }
}
