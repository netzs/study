using AlgorithmsDataStructures;
using NUnit.Framework;

namespace _05
{
    [TestFixture]
    public class TestsTwoStackQueue
    {
        [Test]
        public void Test0()
        {
            var queue = new TwoStackQueue<int>();
            Assert.True(queue.Size() == 0);
            Assert.True(queue.Dequeue() == default);
            Assert.True(queue.Dequeue() == default);
            for (int i = 0; i < 10; i++)
            {
                queue.Enqueue(i);
            }

            Assert.True(queue.Size() == 10);

            for (int i = 0; i < 10; i++)
            {
                Assert.True(queue.Dequeue() == i);
            }

            Assert.True(queue.Size() == 0);
        }

        [Test]
        public void Test1()
        {
            var queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            Assert.True(queue.Dequeue() == 1);
            Assert.True(queue.Dequeue() == 2);
            queue.Enqueue(4);
            queue.Enqueue(5);
            Assert.True(queue.Dequeue() == 3);
            Assert.True(queue.Dequeue() == 4);
            Assert.True(queue.Dequeue() == 5);
            queue.Enqueue(6);
            queue.Enqueue(7);
            Assert.True(queue.Dequeue() == 6);
            queue.Enqueue(8);
            Assert.True(queue.Dequeue() == 7);
            Assert.True(queue.Dequeue() == 8);
            Assert.True(queue.Dequeue() == default);
            Assert.True(queue.Dequeue() == default);
            Assert.True(queue.Dequeue() == default);
        }

    }
}