using System.Collections.Generic;

namespace Sakura.Nodes.Core
{
    /// <summary>
    ///     Something that can contain a resource.
    /// </summary>
    public sealed class Node
    {
        public static string[] TryParse(
            string entity,
            string ID,
            out Node node)
        {
            node = null;
            var errors = new List<string>();
            if (ID == null)
                errors.Add("The resource ID of a node cannot be null.");
            return errors.ToArray();
        }
    }
}
