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
    }
}
