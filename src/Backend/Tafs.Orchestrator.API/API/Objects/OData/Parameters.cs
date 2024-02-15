//
//  Parameters.cs
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
using Tafs.Orchestrator.API.Abstractions.API.Objects.OData;

namespace Tafs.Orchestrator.API.API.Objects.OData
{
    /// <inheritdoc/>
    public sealed record class Parameters
    (
        Optional<string> Expand,
        Optional<string> Filter,
        Optional<string> Select,
        Optional<string> OrderBy,
        Optional<int> Top,
        Optional<int> Skip,
        Optional<bool> Count
    ) : IParameters;
}
