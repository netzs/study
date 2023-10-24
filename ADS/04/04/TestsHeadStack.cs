using AlgorithmsDataStructures;
using NUnit.Framework;

namespace _04
{
    [TestFixture]
    public class TestsHeadStack
    {
        [Test]
        public void TestPush0()
        {
            var stack = new Stack<int>();
            Assert.True(stack.Size() == 0);
            stack.Push(1);
            Assert.True(stack.Size() == 1 && stack.Peek() == 1 && stack.Pop() == 1 && stack.Size() == 0);
        }

        [Test]
        public void TestPush1()
        {
            var stack = new Stack<int>();
            const int size = 10000;
            for (var i = 0; i < size; i++)
            {
                stack.Push(i);
            }

            Assert.True(stack.Size() == size);
            for (var i = size - 1; i >= 0; i--)
            {
                var peek = stack.Peek();
                var pop = stack.Pop();
                Assert.True(pop == i && peek == pop);
            }
        }

        [Test]
        public void TestPeek0()
        {
            var stack = new Stack<int>();
            const int size = 10000;
            for (var i = 0; i < size; i++)
            {
                stack.Push(i);
            }

            for (int i = 0; i < size; i++)
            {
                Assert.True(stack.Peek() == size - 1);
            }

            Assert.True(stack.Size() == size);
            stack.Pop();
            stack.Pop();
            stack.Pop();
            Assert.True(stack.Peek() == size - 4);
        }

        [Test]
        public void TestEmpty()
        {
            var stack = new Stack<int>();
            Assert.True(stack.Peek() == default);
            for (int i = 0; i < 20; i++)
            {
                Assert.True(stack.Pop() == default);
            }

            stack.Push(18);
            stack.Push(19);
            stack.Push(20);
            Assert.True(stack.Pop() == 20);
            Assert.True(stack.Pop() == 19);
            Assert.True(stack.Pop() == 18);
            Assert.True(stack.Peek() == default);
            Assert.True(stack.Pop() == default);
        }
    }
}