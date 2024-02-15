//
//  IParameters.cs
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

using Remora.Rest.Core;

namespace Tafs.Orchestrator.API.Abstractions.API.Objects.OData
{
    /// <summary>
    /// Represents a set of OData Parameters.
    /// </summary>
    public interface IParameters
    {
        /// <summary>
        /// Gets a value indicating the related entities to be represented inline.
        /// The maximum depth is 2.
        /// </summary>
        Optional<string> Expand { get; }

        /// <summary>
        /// Gets a value restricting the set of items returned.
        /// The maximum number of expressions is 100.
        /// </summary>
        Optional<string> Filter { get; }

        /// <summary>
        /// Gets a value limiting the properties returned by the result.
        /// </summary>
        Optional<string> Select { get; }

        /// <summary>
        /// Gets a value specifying the order in which items are returned.
        /// The maximum number of expressions is 5.
        /// </summary>
        Optional<string> OrderBy { get; }

        /// <summary>
        /// Gets a value limiting the number of items returned from a collection.
        /// The maximum value is 1000.
        /// </summary>
        Optional<int> Top { get; }

        /// <summary>
        /// Gets the number of items to be excuded from the queried collection.
        /// </summary>
        Optional<int> Skip { get; }

        /// <summary>
        /// Gets a value indicating whether the total count of items within a
        /// collection are returned in the result.
        /// </summary>
        Optional<bool> Count { get; }
    }
}
