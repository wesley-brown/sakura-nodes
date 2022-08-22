using NUnit.Framework;
using Sakura.Nodes.Core;

namespace NodeSpec
{
    [TestFixture]
    public class Creating
    {
        [Test]
        public void Does_Not_Support_A_Null_Resource_Item_ID()
        {
            var entity = "945186bf-ba80-43bc-b41b-6aa542b88c63";
            string resourceItemID = null;
            var errors = Node.TryParse(
                entity,
                resourceItemID,
                out var node);
            Assert.IsNotEmpty(errors);
            Assert.IsNull(node);
        }
    }
}
