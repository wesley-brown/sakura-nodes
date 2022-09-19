using System;
using Sakura.Nodes;
using NUnit.Framework;
using Sakura.Nodes.Core;

namespace MatureNodeFarmerSpec
{
    [TestFixture]
    public class Creating
    {
        [Test]
        public void Does_Not_Support_A_Null_Mature_Node()
        {
            MatureNode matureNode = null;
            var nodes = new DummyNodes();
            var creation = () => MatureNodeFarmer.Of(
                matureNode,
                nodes);
            Assert.That(
                creation,
                Throws.Exception.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void Does_Not_Support_A_Null_Nodes()
        {
            var matureNode = new DummyMatureNode();
            Nodes nodes = null;
            var creation = () => MatureNodeFarmer.Of(
                matureNode,
                nodes);
            Assert.That(
                creation,
                Throws.Exception.TypeOf<ArgumentNullException>());
        }
    }

    internal class DummyNodes : Nodes
    {
        public Node For(string entity)
        {
            throw new NotImplementedException();
        }
    }

    internal class DummyMatureNode : MatureNode
    {
    }
}
