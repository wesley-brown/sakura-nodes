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
        ///     Create an immature Node.
        /// </summary>
        /// <param name="entity">
        ///     The ID of the entity that the Node will represent.
        /// </param>
        /// <param name="resourceItemID">
        ///     The item ID of the resource the Node will contain.
        /// </param>
        /// <returns>
        ///     The created immature Node.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when the given resource item ID is <c>null</c>.
        /// </exception>
        public static Node Immature(
            Guid entity,
            string resourceItemID)
        {
            if (resourceItemID == null)
                throw new ArgumentNullException(nameof(resourceItemID));
            return FullyDefined(
                entity,
                resourceItemID,
                false);
        }

        /// <summary>
        ///     Create a fully defined Node.
        /// </summary>
        /// <param name="entity">
        ///     The ID of the entity that the Node will represent.
        /// </param>
        /// <param name="resourceItemID">
        ///     The item ID of the resource the Node will contain.
        /// </param>
        /// <param name="canBeHarvested">
        ///     Whether or not the Node can be harvested for its resource.
        /// </param>
        /// <returns>
        ///     The created Node.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when the given resource item ID is <c>null</c>.
        /// </exception>
        public static Node FullyDefined(
            Guid entity,
            string resourceItemID,
            bool canBeHarvested)
        {
            if (resourceItemID == null)
                throw new ArgumentNullException(nameof(resourceItemID));
            return new Node(
                entity,
                resourceItemID,
                canBeHarvested);
        }

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
        /// <param name="canBeHarvested">
        ///     Whether or not this Node can be harvested for its resource.
        /// </param>
        /// <returns>
        ///     A list of errors encountered while trying to create a Node, if
        ///     unsuccessful. An empty list if successful.
        /// </returns>
        public static string[] TryParse(
            string entity,
            string resourceItemID,
            bool canBeHarvested,
            out Node node)
        {
            var errors = new List<string>();
            errors.AddRange(ErrorsForEntity(entity));
            errors.AddRange(ErrorsForResourceItemID(resourceItemID));
            if (errors.Count > 0)
                node = null;
            else
                node = FullyDefined(
                    new Guid(entity),
                    resourceItemID,
                    canBeHarvested);
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

        private static string[] ErrorsForResourceItemID(string resourceItemID)
        {
            var errors = new List<string>();
            if (resourceItemID == null)
                errors.Add("The resource item ID of a node cannot be null.");
            return errors.ToArray();
        }

        private Node(
            Guid entity,
            string resourceItemID,
            bool canBeHarvested)
        {
            this.entity = entity;
            this.resourceItemID = resourceItemID;
            this.canBeHarvested = canBeHarvested;
        }

        private readonly Guid entity;
        private readonly string resourceItemID;
        private readonly bool canBeHarvested;

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
        ///     The item ID of the resource that this Node produces.
        /// </summary>
        public string ResourceItemID
        {
            get
            {
                return resourceItemID;
            }
        }

        /// <summary>
        ///     Whether or not this node can be harvested for its resource or
        ///     not.
        /// </summary>
        public bool CanBeHarvested
        {
            get
            {
                return canBeHarvested;
            }
        }

        /// <summary>
        ///     The string representation of this Node.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Entity={Entity}"
                + $", Resource Item ID={ResourceItemID}"
                + $", Can be Harvested={CanBeHarvested}";
        }
    }
}
