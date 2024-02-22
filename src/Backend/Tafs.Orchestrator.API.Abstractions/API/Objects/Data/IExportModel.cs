//
//  IExportModel.cs
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
using Remora.Rest.Core;

namespace Tafs.Orchestrator.API.Abstractions.API.Objects.Data
{
    /// <summary>
    /// Gets the status of an export.
    /// </summary>
    public interface IExportModel
    {
        /// <summary>
        /// Gets the unique id of this export request.
        /// </summary>
        Optional<long> Key { get; }

        /// <summary>
        /// Gets the name of the export request.
        /// </summary>
        Optional<string> Name { get; }

        /// <summary>
        /// Gets the type of data this export request is handling.
        /// </summary>
        Optional<ExportType> Type { get; }

        /// <summary>
        /// Gets the status of the export operation.
        /// </summary>
        Optional<ExportStatus> Status { get; }

        /// <summary>
        /// Gets the date and time the export was requested.
        /// </summary>
        Optional<DateTimeOffset> RequestedAt { get; }

        /// <summary>
        /// Gets the date and time the export was started.
        /// </summary>
        Optional<DateTimeOffset> ExecutedAt { get; }

        /// <summary>
        /// Gets the size in bytes of the export.
        /// </summary>
        long Size { get; }
    }
}
