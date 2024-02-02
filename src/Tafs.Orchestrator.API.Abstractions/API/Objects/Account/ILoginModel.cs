//
//  ILoginModel.cs
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

namespace Tafs.Orchestrator.API.Abstractions.API.Objects.Account
{
    /// <summary>
    /// Represents the body of a login request based on username and password.
    /// </summary>
    [PublicAPI]
    public interface ILoginModel
    {
        /// <summary>
        /// Gets the name of the tenant to authenticate against.
        /// </summary>
        public string TenancyName { get; }

        /// <summary>
        /// Gets the username or email address.
        /// </summary>
        [MinLength(1), Required] public string UsernameOrEmailAddress { get; }

        /// <summary>
        /// Gets the password.
        /// </summary>
        [MinLength(1), Required] public string Password { get; }
    }
}
