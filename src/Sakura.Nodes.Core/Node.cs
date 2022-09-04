﻿using System;
using System.Collections.Generic;

namespace Sakura.Nodes.Core
{
    /// <summary>
    ///     Something that can contain a resource.
    /// </summary>
    public sealed class Node
    {
        /// <summary>
        ///     Try and create a Node with a given entity ID and resource item
        ///     ID.
        /// </summary>
        /// <param name="entity">
        ///     The ID of the entity that will be represented by the created
        ///     Node, if successful.
        /// </param>
        /// <param name="ID">
        ///     The ID of the resource item that the created Node will have, if
        ///     successful.
        /// </param>
        /// <param name="node">
        ///     The created Node, if there is one.
        /// </param>
        /// <returns>
        ///     A list of errors encountered while trying to create a Node, if
        ///     unsuccessful. An empty list if successful.
        /// </returns>
        public static string[] TryParse(
            string entity,
            string resourceItemID,
            out Node node)
        {
            var errors = new List<string>();
            errors.AddRange(ErrorsForEntity(entity));
            if (resourceItemID == null)
                errors.Add("The resource item ID of a node cannot be null.");
            if (errors.Count > 0)
                node = null;
            else
                node = new Node(
                    new Guid(entity),
                    resourceItemID);
            return errors.ToArray();
        }

        private static string[] ErrorsForEntity(string entity)
        {
            var errors = new List<string>();
            if (entity == null)
                errors.Add("The entity ID of a node cannot be null.");
            var isGuid = Guid.TryParse(
                entity,
                out _);
            if (!isGuid)
                errors.Add(
                    "The entity ID of a node must be in the form of a GUID.");
            return errors.ToArray();
        }

        private Node(
            Guid entity,
            string resourceItemID)
        {
            this.entity = entity;

        }

        private readonly Guid entity;

        /// <summary>
        ///     The entity that this Node represents.
        /// </summary>
        public Guid Entity
        {
            get
            {
                return entity;
            }
        }

        /// <summary>
        ///     The string representation of this Node.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Entity={Entity}";
        }
    }
}
