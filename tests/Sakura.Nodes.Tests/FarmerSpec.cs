using System;
using Sakura.Nodes;
using NUnit.Framework;

namespace FarmerSpec
{
    [TestFixture]
    public class Creating
    {
        [Test]
        public void Does_Not_Support_A_Null_Nodes()
        {
            Nodes nodes = null;
            var creation = () => Farmer.Of(nodes);
            Assert.That(
                creation,
                Throws.Exception.TypeOf<ArgumentNullException>());
        }
    }
}
