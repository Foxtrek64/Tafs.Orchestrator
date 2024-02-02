//
//  IFolder.cs
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
using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;

namespace Tafs.Orchestrator.API.Abstractions.API.Objects.Folders
{
    /// <summary>
    /// Describes a folder.
    /// </summary>
    [PublicAPI]
    public interface IFolder
    {
        /// <summary>
        /// Gets the unique id for this folder.
        /// </summary>
        long Id { get; }

        /// <summary>
        /// Gets a unique key for the folder.
        /// </summary>
        Guid Key { get; }

        /// <summary>
        /// Gets the folder's dispaly name.
        /// </summary>
        [StringLength(115, MinimumLength = 1)] string DisplayName { get; }

        /// <summary>
        /// Gets the name of the folder prepended by the name of its ancestors.
        /// </summary>
        string FullyQualifiedName { get; }

        /// <summary>
        /// Gets the folder description.
        /// </summary>
        [StringLength(500)] string Description { get; }

        /// <summary>
        /// Gets the folder type.
        /// </summary>
        FolderType FolderType { get; }

        /// <summary>
        /// Gets a value indicating whether the folder is personal.
        /// </summary>
        bool IsPersonal { get; }

        /// <summary>
        /// Gets the robot provisioning type.
        /// </summary>
        ProvisionType ProvisionType { get; }

        /// <summary>
        /// Gets the folder permissions model.
        /// </summary>
        PermissionModel PermissionModel { get; }

        /// <summary>
        /// Gets the id of the parent folder in the folders heirarchy.
        /// </summary>
        long? ParentId { get; }

        /// <summary>
        /// Gets the unique key for the parent folder.
        /// </summary>
        Guid? ParentKey { get; }

        /// <summary>
        /// Gets the folder feed type.
        /// </summary>
        FeedType FeedType { get; }
    }
}
