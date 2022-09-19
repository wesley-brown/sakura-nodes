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
        public void OnHarvest(string resourceItemID)
        {
            throw new NotImplementedException();
        }

        public void OnNotHarvested(string error)
        {
            throw new NotImplementedException();
        }
    }

    [TestFixture]
    public class Harvesting_A_Node
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

        [Test]
        public void That_Is_Immature_Is_An_Error()
        {
            var matureNode = new SpyMatureNode();
            var nodes = new OnlyImmatureNodes();
            var farmer = MatureNodeFarmer.Of(
                matureNode,
                nodes);
            var entity = OnlyImmatureNodes.ImmatureNodeID;
            farmer.Harvest(entity);
            Assert.That(
                matureNode.Error,
                Is.Not.Null);
        }

        [Test]
        public void That_Is_Mature_Returns_That_Nodes_Resource()
        {
            var matureNode = new SpyMatureNode();
            var nodes = new OnlyMatureNodes();
            var farmer = MatureNodeFarmer.Of(
                matureNode,
                nodes);
            var entity = OnlyMatureNodes.MatureNodeID;
            farmer.Harvest(entity);
            Assert.That(
                matureNode.Error,
                Is.Null);
            Assert.That(
                matureNode.HarvestedResource,
                Is.EqualTo(OnlyMatureNodes.MatureNodeResource));
        }
    }

    internal class SpyMatureNode : MatureNode
    {
        internal string Error { get; private set; }

        internal string HarvestedResource { get; private set; }

        public void OnHarvest(string resourceItemID)
        {
            HarvestedResource = resourceItemID;
        }

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

    internal class OnlyImmatureNodes : Nodes
    {
        public static string ImmatureNodeID
        {
            get
            {
                return "25a494af-a88e-42ad-82d2-842b89669053";
            }
        }

        public Node For(string entity)
        {
            return Node.Immature(
                new Guid(ImmatureNodeID),
                "resource");
        }
    }

    internal class OnlyMatureNodes : Nodes
    {
        public static string MatureNodeID
        {
            get
            {
                return "02ef2ae5-114f-447a-88b3-8ec363d206da";
            }
        }

        public static string MatureNodeResource
        {
            get
            {
                return "matureNodeResource";
            }
        }

        public Node For(string entity)
        {
            return Node.Mature(
                new Guid(MatureNodeID),
                MatureNodeResource);
        }
    }
}
