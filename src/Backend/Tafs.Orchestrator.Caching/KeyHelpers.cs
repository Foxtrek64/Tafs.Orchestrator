//
//  KeyHelpers.cs
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

using System.Text;
using JetBrains.Annotations;
using Tafs.Orchestrator.Caching.Abstractions;

namespace Tafs.Orchestrator.Caching
{
    /// <summary>
    /// Helpers for Discord-related cache keys.
    /// </summary>
    [PublicAPI]
    public static class KeyHelpers
    {
        /// <summary>
        /// Retrieves the authentication token.
        /// </summary>
        public record AuthenticationCacheKey() : CacheKey
        {
            /// <inheritdoc/>
            protected override StringBuilder AppendToString(StringBuilder stringBuilder)
            => stringBuilder.Append("AuthenticationToken");
        }
    }
}
