using AlgorithmsDataStructures;
using NUnit.Framework;

namespace _01
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Test1()
        {
            var node = new Node(1);
            var ll = new LinkedList();
            ll.AddInTail(node);
            Assert.True(ll.Count() == 1);
        }
    }
}