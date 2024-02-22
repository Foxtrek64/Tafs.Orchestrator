//
//  IVersionedEntity.cs
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

namespace Tafs.Orchestrator.API.Abstractions.API.Objects.Entities
{
    /// <summary>
    /// Represents a versioned entitity.
    /// </summary>
    public interface ILongVersionedEntity
    {
        /// <summary>
        /// Gets an identifier used for optimistic concurrency, so
        /// Orchestrator can figure out whether data is out of date or not.
        /// </summary>
        byte RowVersion { get; }

        /// <summary>
        /// Gets the unique id of the object.
        /// </summary>
        long Id { get; }
    }
}
