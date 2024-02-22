//
//  IOrchestratorRestQueuesAPI.cs
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

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Remora.Rest.Core;
using Remora.Results;
using Tafs.Orchestrator.API.Abstractions.API.Objects.Data;
using Tafs.Orchestrator.API.Abstractions.API.Objects.Folders;
using Tafs.Orchestrator.API.Abstractions.API.Objects.OData;
using Tafs.Orchestrator.API.Abstractions.API.Objects.Queues;
using Tafs.Orchestrator.API.Abstractions.API.Objects.Tags;

namespace Tafs.Orchestrator.API.Abstractions.API.Rest
{
    /// <summary>
    /// Represents the Orchestrator Queues API.
    /// </summary>
    [PublicAPI]
    public interface IOrchestratorRestQueueDefinitionsAPI
    {
        /// <summary>
        /// Gets a list of queue definitions.
        /// </summary>
        /// <param name="parameters">OData parameters for filtering results.</param>
        /// <param name="organizationId">The organization id.</param>
        /// <returns>A list of queue definitions.</returns>
        Task<Result<IEnumerable<IQueueDefinition>>> GetQueueDefinitions(IParameters parameters, long organizationId);

        /// <summary>
        /// Creates a new queue definition.
        /// </summary>
        /// <param name="organizationId">The folder/org unit to create the queue in.</param>
        /// <param name="queueName">The name of the queue.</param>
        /// <param name="description">Additional information about the queue.</param>
        /// <param name="retryCount">The number of times to retry. If <c>0</c>, <see cref="IQueueDefinition.AcceptAutomaticallyRetry"/> is false.</param>
        /// <param name="encrypted">Whether to encrypt the queue.</param>
        /// <param name="specificDataJsonSchema">The json schema controlling the specific data field.</param>
        /// <param name="outputDataJsonSchema">The json schema controlling the output data field.</param>
        /// <param name="analyticsDataJsonSchema">The json schema controlling the analytics data field.</param>
        /// <param name="slaInMinutes">The time in minutes before the queue item should be completed.</param>
        /// <param name="riskSlaInMinutes">The time in minutes before the queue item should be considered at risk.</param>
        /// <param name="tags">A list of tags.</param>
        /// <returns>The created queue definition.</returns>
        Task<Result<IQueueDefinition>> CreateQueueDefinition
        (
            long organizationId,
            string queueName,
            Optional<string> description,
            Optional<string> retryCount,
            Optional<bool> encrypted,
            Optional<string> specificDataJsonSchema,
            Optional<string> outputDataJsonSchema,
            Optional<string> analyticsDataJsonSchema,
            Optional<int> slaInMinutes,
            Optional<int> riskSlaInMinutes,
            Optional<IReadOnlyList<ITag>> tags
        );

        /// <summary>
        /// Creates a new queue definition.
        /// </summary>
        /// <param name="organizationId">The folder to create the queue in.</param>
        /// <param name="queueDefinition">The queue definition representing the queue to create.</param>
        /// <returns>The created queue definition.</returns>
        Task<Result<IQueueDefinition>> CreateQueueDefinition(long organizationId, IQueueDefinition queueDefinition);

        /// <summary>
        /// Gets the queue definition with the specified key in the specified folder.
        /// </summary>
        /// <param name="key">The unique id of the queue definition.</param>
        /// <param name="organizationId">The id of the folder the queue definition belongs to.</param>
        /// <returns>The queue definition.</returns>
        Task<Result<IQueueDefinition>> GetQueueDefinition(long key, long organizationId);

        /// <summary>
        /// Updates the queue definition specified by the provided key.
        /// </summary>
        /// <param name="key">The unique id of the queue definition.</param>
        /// <param name="queueDefinition">The queue definition to use to replace the existing definition.</param>
        /// <param name="organizationId">The organization id.</param>
        /// <returns>The result of the update operation.</returns>
        Task<Result> UpdateQueueDefinition(long key, IQueueDefinition queueDefinition, long organizationId);

        /// <summary>
        /// Deletes the specified queue definition.
        /// </summary>
        /// <param name="key">The unique id of the queue definition.</param>
        /// <param name="organizationId">The organization id.</param>
        /// <returns>The result of the delete operation.</returns>
        Task<Result> DeleteQueueDefinition(long key, long organizationId);

        /// <summary>
        /// Requests the generation of a CSV export of the queue items using the specified <paramref name="parameters"/>.
        /// </summary>
        /// <param name="key">The unique id of the queue definition.</param>
        /// <param name="parameters">OData parameters used to configure the request.</param>
        /// <param name="organizationId">The organization id.</param>
        /// <returns>An <see cref="IExportModel"/> representing the status of the request.</returns>
        Task<Result<IExportModel>> StartCsvExport(long key, IParameters parameters, long organizationId);

        /// <summary>
        /// Gets ta given queue item JSON schema as a .json file, based on the queue definition id.
        /// </summary>
        /// <param name="key">The unique id of the queue definition.</param>
        /// <param name="jsonSchemaType">The json type.</param>
        /// <param name="organizationId">The organization id.</param>
        /// <returns>A stream representing the download.</returns>
        Task<Result<Stream>> GetJsonSchemaDefinition(long key, string jsonSchemaType, long organizationId);

        /// <summary>
        /// Get an Excel file containing all items in the given queue.
        /// </summary>
        /// <param name="key">The unique id of the queue definition.</param>
        /// <param name="parameters">OData parameters used to configure the request.</param>
        /// <param name="organizationId">The organization id.</param>
        /// <returns>A stream representing the download.</returns>
        [Obsolete("Deprecated in 17.0. See https://docs.uipath.com/orchestrator/automation-cloud/latest/release-notes/release-notes-june-2023#deprecation-of-reports-endpoints", false)]
        Task<Result<Stream>> GetReport(long key, IParameters parameters, long organizationId);

        /// <summary>
        /// Gets all accessible folders where the queue is shared, and the
        /// total count of folders where it is shared (including inaccessible folders).
        /// </summary>
        /// <param name="key">The unique id of the queue definition.</param>
        /// <param name="organizationId">The organization id.</param>
        /// <returns>A set of accessible folders.</returns>
        Task<Result<IAccessibleFolders>> GetFoldersForQueue(long key, long organizationId);

        /// <summary>
        /// Gets the queues from all of the folders in which the current user has the Queues.View permission, except those in the excluded folder.
        /// </summary>
        /// <param name="excludeFolderId">The id of the folder to exclude.</param>
        /// <param name="parameters">OData parameters used to configure the request.</param>
        /// <param name="organizationId">The organization id.</param>
        /// <returns>A collection of queue definitions.</returns>
        Task<Result<IReadOnlyList<IQueueDefinition>>> GetQueuesAcrossFolders(Optional<long> excludeFolderId, Optional<IParameters> parameters, long organizationId);

        /// <summary>
        /// Makes the queue visible in the specified folders.
        /// </summary>
        /// <param name="queueIds">The ids of the queues to share.</param>
        /// <param name="toAddFolderIds">The folders to allow sharing with.</param>
        /// <param name="toRemoveFolderIds">The folders to reovke sharing with.</param>
        /// <param name="organizationID">The organization id.</param>
        /// <returns>The result of the share operation.</returns>
        Task<Result> ShareToFolders
        (
            Optional<IReadOnlyList<long>> queueIds,
            Optional<IReadOnlyList<long>> toAddFolderIds,
            Optional<IReadOnlyList<long>> toRemoveFolderIds,
            long organizationID
        );
    }
}
