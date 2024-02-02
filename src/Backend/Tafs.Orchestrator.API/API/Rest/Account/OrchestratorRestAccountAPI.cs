//
//  OrchestratorRestAccountAPI.cs
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
using System.Reflection;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Remora.Rest;
using Remora.Rest.Extensions;
using Remora.Results;
using Tafs.Orchestrator.API.Abstractions.API.Objects.Account;
using Tafs.Orchestrator.API.Abstractions.API.Rest;

namespace Tafs.Orchestrator.API.API.Rest.Account
{
    /// <inheritdoc cref="Tafs.Orchestrator.API.Abstractions.API.Rest.IOrchestratorRestAccountAPI"/>
    [PublicAPI]
    public class OrchestratorRestAccountAPI
    (
            IRestHttpClient restHttpClient,
            JsonSerializerOptions jsonOptions
    )
        : AbstractOrchestratorRestAPI(restHttpClient, jsonOptions),
        IOrchestratorRestAccountAPI
    {
        /// <inheritdoc/>
        public virtual async Task<Result<string>> AuthenticateAsync(ILoginModel loginModel, CancellationToken ct = default)
        {
            PropertyInfo usernameOrEmailAddress = loginModel.GetType().GetProperty(nameof(ILoginModel.UsernameOrEmailAddress));
            var stringLength = (StringLengthAttribute)usernameOrEmailAddress.GetCustomAttribute(typeof(StringLengthAttribute));
            stringLength.IsValid(loginModel.UsernameOrEmailAddress);

            PropertyInfo password = loginModel.GetType().GetProperty(nameof(ILoginModel.Password));
            stringLength = (StringLengthAttribute)password.GetCustomAttribute(typeof(StringLengthAttribute));
            stringLength.IsValid(loginModel.Password);

            return await RestHttpClient.PostAsync<string>
            (
                endpoint: "api/Account/Authenticate",
                requestBuilder => requestBuilder.WithJson
                (
                    json =>
                    {
                        json.Write("tenancyName", loginModel.TenancyName, JsonOptions);
                        json.WriteString("usernameOrEmailAddress", loginModel.UsernameOrEmailAddress);
                        json.WriteString("password", loginModel.Password);
                    }
                ),
                ct: ct
            );
        }
    }
}
