using System;

namespace Sakura.Nodes
{
    /// <summary>
    ///     Tends to a collection of nodes.
    /// </summary>
    internal sealed class Farmer
    {
        /// <summary>
        ///     Create a farmer of a given collection of nodes.
        /// </summary>
        /// <param name="nodes">
        ///     The nodes that the created farmer will tend to.
        /// </param>
        /// <returns>
        ///     A farmer that tends to the given collection of nodes.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when the given collection of nodes is <c>null</c>.
        /// </exception>
        internal static Farmer Of(Nodes nodes)
        {
            if (nodes == null)
                throw new ArgumentNullException(nameof(nodes));
            throw new NotImplementedException();
        }
    }
}
