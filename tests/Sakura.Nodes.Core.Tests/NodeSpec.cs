using NUnit.Framework;
using Sakura.Nodes.Core;

namespace NodeSpec
{
    [TestFixture]
    public class Parsing
    {
        [Test]
        public void Does_Not_Support_A_Null_Entity_ID()
        {
            string entity = null;
            var resourceItemID = "resource";
            var canBeHarvested = true;
            var errors = Node.TryParse(
                entity,
                resourceItemID,
                canBeHarvested,
                out var node);
            Assert.Multiple(() =>
            {
                Assert.That(
                    errors,
                    Is.Not.Empty);
                Assert.That(
                    node,
                    Is.Null);
            });
        }

        [TestCase("Not a GUID")]
        [TestCase("3509959c 8fdf~450a_8ff8-2ea578a62f74")]
        [TestCase("3509959c-8fdf-450a-8ff8-2ea578a62f7")]
        [TestCase("3509959c-8fdf-450a-8ff8-2ea578a62f745")]
        public void Does_Not_Support_An_Entity_ID_That_Is_Not_In_The_Form_Of_A_Guid(string entity)
        {
            var resourceItemID = "resource";
            var canBeHarvested = false;
            var errors = Node.TryParse(
                entity,
                resourceItemID,
                canBeHarvested,
                out var node);
            Assert.Multiple(() =>
            {
                Assert.That(
                    errors,
                    Is.Not.Empty);
                Assert.That(
                    node,
                    Is.Null);
            });
        }

        [Test]
        public void Does_Not_Support_A_Null_Resource_Item_ID()
        {
            var entity = "945186bf-ba80-43bc-b41b-6aa542b88c63";
            string resourceItemID = null;
            var canBeHarvested = true;
            var errors = Node.TryParse(
                entity,
                resourceItemID,
                canBeHarvested,
                out var node);
            Assert.Multiple(() =>
            {
                Assert.That(
                    errors,
                    Is.Not.Empty);
                Assert.That(
                    node,
                    Is.Null);
            });
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
            var canBeHarvested = false;
            var errors = Node.TryParse(
                entity,
                resourceItemID,
                canBeHarvested,
                out var node);
            Assert.Multiple(() =>
            {
                Assert.That(
                    errors,
                    Is.Empty);
                Assert.That(
                    node,
                    Is.Not.Null);
                Assert.That(
                    node.ToString(),
                    Does.Contain(node.Entity.ToString()));
            });
        }

        [Test]
        public void Includes_The_Resource_Item_ID()
        {
            var entity = "9ba215aa-6536-44b8-88e3-4419f2db8d12";
            var resourceItemID = "resource";
            var canBeHarvested = true;
            var errors = Node.TryParse(
                entity,
                resourceItemID,
                canBeHarvested,
                out var node);
            Assert.Multiple(() =>
            {
                Assert.That(
                    errors,
                    Is.Empty);
                Assert.That(
                    node,
                    Is.Not.Null);
                Assert.That(
                    node.ToString(),
                    Does.Contain(node.ResourceItemID));
            });
        }

        [Test]
        public void Includes_Its_Can_Be_Harvested_Status()
        {
            var entity = "5890a217-d80e-4c0f-bbc6-1096c3076479";
            var resourceItemID = "resource";
            var canBeHarvested = true;
            var errors = Node.TryParse(
                entity,
                resourceItemID,
                canBeHarvested,
                out var node);
            Assert.Multiple(() =>
            {
                Assert.That(
                    errors,
                    Is.Empty);
                Assert.That(
                    node,
                    Is.Not.Null);
                Assert.That(
                    node.ToString(),
                    Does.Contain(node.CanBeHarvested.ToString()));
            });
        }
    }
}
