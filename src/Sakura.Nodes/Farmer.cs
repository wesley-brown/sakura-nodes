using System;

namespace Sakura.Nodes
{
    /// <summary>
    ///     Tends to a collection of nodes.
    /// </summary>
    internal sealed class Farmer
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
        internal static Farmer Of(
            MatureNode matureNode,
            Nodes nodes)
        {
            if (matureNode == null)
                throw new ArgumentNullException(nameof(matureNode));
            if (nodes == null)
                throw new ArgumentNullException(nameof(nodes));
            throw new NotImplementedException();
        }
    }
}
