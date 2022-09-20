using Sakura.Nodes.Core;

namespace Sakura.Nodes
{
    /// <summary>
    ///     A collection of nodes.
    /// </summary>
    internal interface Nodes
    {
        /// <summary>
        ///     The node being represented by a given entity, if there is one.
        /// </summary>
        /// <param name="entity">
        ///     The entity.
        /// </param>
        /// <returns>
        ///     The node being represented by the given entity if there is one,
        ///     <c>null</c> otherwise.
        /// </returns>
        Node For(string entity);

        /// <summary>
        ///     Add a given node to this collection of nodes. If there is
        ///     already a node representing the same entity, the given node to
        ///     be added will overwrite the previous one.
        /// </summary>
        /// <param name="node">
        ///     The node to add.
        /// </param>
        void Add(Node node);
    }
}
