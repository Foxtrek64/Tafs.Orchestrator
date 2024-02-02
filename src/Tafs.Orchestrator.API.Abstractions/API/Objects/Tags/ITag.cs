//
//  ITag.cs
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

namespace Tafs.Orchestrator.API.Abstractions.API.Objects.Tags
{
    /// <summary>
    /// Describes a data tag, which provides additional information for objects.
    /// </summary>
    [PublicAPI]
    public interface ITag
    {
        /// <summary>
        /// Gets the name of this tag.
        /// </summary>
        [StringLength(256)] string Name { get; }

        /// <summary>
        /// Gets the display name for this tag.
        /// </summary>
        [StringLength(256)] string DisplayName { get; }

        /// <summary>
        /// Gets the value of this tag.
        /// </summary>
        [StringLength(256)] string Value { get; }

        /// <summary>
        /// Gets the display value for this tag.
        /// </summary>
        [StringLength(256)] string DisplayValue { get; }
    }
}
