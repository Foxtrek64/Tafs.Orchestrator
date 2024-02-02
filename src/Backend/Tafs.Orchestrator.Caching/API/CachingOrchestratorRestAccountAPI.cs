//
//  CachingOrchestratorRestAccountAPI.cs
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

using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Remora.Rest;
using Remora.Results;
using Tafs.Orchestrator.API.Abstractions.API.Objects.Account;
using Tafs.Orchestrator.API.Abstractions.API.Rest;
using Tafs.Orchestrator.Caching.Services;

namespace Tafs.Orchestrator.Caching.API
{
    /// <summary>
    /// Decorates the registered channel API with caching functionality.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="CachingOrchestratorRestAccountAPI"/> class.
    /// </remarks>
    /// <param name="actual">The decorated instance.</param>
    /// <param name="cacheService">The cache service.</param>
    [PublicAPI]
    public partial class CachingOrchestratorRestAccountAPI
    (
        IOrchestratorRestAccountAPI actual,
        CacheService cacheService
    ) : IOrchestratorRestAccountAPI, IRestCustomizable
    {
        private readonly IOrchestratorRestAccountAPI _actual = actual;
        private readonly CacheService _cacheService = cacheService;

        /// <inheritdoc/>
        public async Task<Result<string>> AuthenticateAsync(ILoginModel loginModel, CancellationToken ct = default)
        {
            var key = new KeyHelpers.AuthenticationCacheKey();
            var cacheResult = await _cacheService.TryGetValueAsync<string>(key, ct);

            if (cacheResult.IsSuccess)
            {
                return cacheResult;
            }

            var authenticateResult = await _actual.AuthenticateAsync(loginModel, ct);

            if (!authenticateResult.IsDefined(out string? authKey))
            {
                return authenticateResult;
            }

            await _cacheService.CacheAsync(key, authKey, ct);

            return authKey;
        }
    }
}
