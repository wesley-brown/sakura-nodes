using System;

namespace Sakura.Nodes
{
    /// <summary>
    ///     Tends to mature nodes.
    /// </summary>
    internal sealed class MatureNodeFarmer
    {
        /// <summary>
        ///     Create a farmer that harvests mature nodes in a given
        ///     collection of nodes.
        /// </summary>
        /// <param name="matureNode">
        ///     The mature node that the created farmer will harvest.
        /// </param>
        /// <param name="nodes">
        ///     The nodes that the created farmer will harvest from.
        /// </param>
        /// <returns>
        ///     A farmer that will harvest mature nodes in the given collection
        ///     of nodes.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when the given mature node is <c>null</c>.
        ///
        ///     -or-
        /// 
        ///     Thrown when the given collection of nodes is <c>null</c>.
        /// </exception>
        internal static MatureNodeFarmer Of(
            MatureNode matureNode,
            Nodes nodes)
        {
            if (matureNode == null)
                throw new ArgumentNullException(nameof(matureNode));
            if (nodes == null)
                throw new ArgumentNullException(nameof(nodes));
            return new MatureNodeFarmer(
                matureNode,
                nodes);
        }

        private MatureNodeFarmer(
            MatureNode matureNode,
            Nodes nodes)
        {
            this.matureNode = matureNode;
            this.nodes = nodes;
        }

        private readonly MatureNode matureNode;
        private readonly Nodes nodes;

        /// <summary>
        ///     Harvest the mature node represented by a given entity.
        /// </summary>
        /// <param name="entity">
        ///     The entity that represents a mature node.
        /// </param>
        public void Harvest(string entity)
        {
            var node = nodes.For(entity);
            if (node == null)
                matureNode.OnNotHarvested(
                    $"Entity '{node}' is not a node.");
        }
    }
}
