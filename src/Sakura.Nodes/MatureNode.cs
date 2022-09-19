
namespace Sakura.Nodes
{
    /// <summary>
    ///     A node that can be harvested for a resource.
    /// </summary>
    public interface MatureNode
    {
        /// <summary>
        ///     Called when this mature node is harvested.
        /// </summary>
        /// <param name="resourceItemID">
        ///     The item ID of the resource harvested from this mature node.
        /// </param>
        void OnHarvest(string resourceItemID);

        /// <summary>
        ///     Called when this mature node could not be harvested.
        /// </summary>
        /// <param name="error">
        ///     The error message.
        /// </param>
        void OnNotHarvested(string error);
    }
}

