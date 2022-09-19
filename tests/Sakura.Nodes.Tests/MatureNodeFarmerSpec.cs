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
        public void OnNotHarvested(string error)
        {
            throw new NotImplementedException();
        }
    }

    [TestFixture]
    public class Harvesting_A_Mature_Node
    {
        [Test]
        public void Defined_By_A_Null_Entity_ID_Is_An_Error()
        {
            var matureNode = new SpyMatureNode();
            var nodes = new DummyNodes();
            var farmer = MatureNodeFarmer.Of(
                matureNode,
                nodes);
            string entity = null;
            farmer.Harvest(entity);
            Assert.That(
                matureNode.Error,
                Is.Not.Null);
        }

        [Test]
        public void That_Does_Not_Exist_Is_An_Error()
        {
            var matureNode = new SpyMatureNode();
            var nodes = new NoNodes();
            var farmer = MatureNodeFarmer.Of(
                matureNode,
                nodes);
            var entity = "dff3294e-1ff1-4dac-8a08-849bc786cd3e";
            farmer.Harvest(entity);
            Assert.That(
                matureNode.Error,
                Is.Not.Null);
        }
    }

    internal class SpyMatureNode : MatureNode
    {
        internal string Error { get; private set; }

        public void OnNotHarvested(string error)
        {
            Error = error;
        }
    }

    internal class NoNodes : Nodes
    {
        public Node For(string entity)
        {
            return null;
        }
    }
}
