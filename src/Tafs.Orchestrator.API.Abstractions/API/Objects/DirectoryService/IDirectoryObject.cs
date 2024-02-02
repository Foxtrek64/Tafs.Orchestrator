//
//  IDirectoryObject.cs
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
    /// A base type describing a kind of directory object.
    /// </summary>
    [PublicAPI]
    public interface IDirectoryObject
    {
        /// <summary>
        /// Gets the kind of directory object represented.
        /// </summary>
        DirectoryObjectType Type { get; }

        /// <summary>
        /// Gets the source of the object.
        /// </summary>
        string Source { get; }

        /// <summary>
        /// Gets the domain this object belongs to.
        /// </summary>
        string Domain { get; }

        /// <summary>
        /// Gets the identifier for this object.
        /// </summary>
        string Identifier { get; }

        /// <summary>
        /// Gets the identity name.
        /// </summary>
        string IdentityName { get; }

        /// <summary>
        /// Gets the display name.
        /// </summary>
        string DisplayName { get; }
    }
}
