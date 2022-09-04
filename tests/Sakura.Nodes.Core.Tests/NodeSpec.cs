using NUnit.Framework;
using Sakura.Nodes.Core;

namespace NodeSpec
{
    [TestFixture]
    public class Creating
    {
        [Test]
        public void Does_Not_Support_A_Null_Entity_ID()
        {
            string entity = null;
            var resourceItemID = "resource";
            var errors = Node.TryParse(
                entity,
                resourceItemID,
                out var node);
            Assert.IsNotEmpty(errors);
            Assert.IsNull(node);
        }

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

    [TestFixture]
    public class The_String_Representation
    {
        [Test]
        public void Includes_The_Entity_ID()
        {
            var entity = "734856d2-e288-4c2f-9862-e62c5ccc69c3";
            var resourceItemID = "resource";
            var errors = Node.TryParse(
                entity,
                resourceItemID,
                out var node);
            Assert.IsEmpty(errors);
            Assert.IsNotNull(node);
            StringAssert.Contains(
                entity,
                node.ToString());
        }
    }
}
