using AlgorithmsDataStructures;
using NUnit.Framework;

namespace _04
{
    [TestFixture]
    public class TestsPostfix
    {
        [Test]
        public void TestPush0()
        {
            var stack = new Stack<int>();
            Assert.True(stack.Size() == 0);
            stack.Push(1);
            Assert.True(stack.Size() == 1 && stack.Peek() == 1 && stack.Pop() == 1 && stack.Size() == 0);
        }
    }
}