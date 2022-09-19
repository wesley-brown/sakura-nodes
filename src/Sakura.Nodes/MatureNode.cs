
namespace Sakura.Nodes
{
    /// <summary>
    ///     A node that can be harvested for a resource.
    /// </summary>
    public interface MatureNode
    {
        /// <summary>
        ///     Called when this mature node could not be harvested.
        /// </summary>
        /// <param name="error">
        ///     The error message.
        /// </param>
        void OnNotHarvested(string error);
    }
}

