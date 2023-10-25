using AlgorithmsDataStructures;
using NUnit.Framework;

namespace _05
{
    [TestFixture]
    public class TestRotateQueue
    {
        [Test]
        public void Test0()
        {
            var queue = new Queue<int>();
            for (int i = 0; i < 5; i++)
            {
                queue.Enqueue(i);
            }

            RotateQueue.Rotate(queue, 2);

            Assert.True(queue.Dequeue() == 2);
            Assert.True(queue.Dequeue() == 3);
            Assert.True(queue.Dequeue() == 4);
            Assert.True(queue.Dequeue() == 0);
            Assert.True(queue.Dequeue() == 1);
        }

        [Test]
        public void Test1()
        {
            var queue = new Queue<int>();
            RotateQueue.Rotate(queue, 2);
            Assert.True(queue.Size() == 0);
        }

        [Test]
        public void Test2()
        {
            var queue = new Queue<int>();
            queue.Enqueue(100);
            RotateQueue.Rotate(queue, 2);
            Assert.True(queue.Size() == 1 && queue.Dequeue() == 100);
        }

        [Test]
        public void Test3()
        {
            var queue = new Queue<int>();
            for (int i = 0; i < 5; i++)
            {
                queue.Enqueue(i);
            }

            RotateQueue.Rotate(queue, 2);
            RotateQueue.Rotate(queue, 3);
            for (int i = 0; i < 5; i++)
            {
                Assert.True(queue.Dequeue() == i);
            }
        }
        
        [Test]
        public void Test4()
        {
            var queue = new Queue<int>();
            for (int i = 0; i < 100; i++)
            {
                queue.Enqueue(i);
            }

            RotateQueue.Rotate(queue, 600);
            for (int i = 0; i < 100; i++)
            {
                Assert.True(queue.Dequeue() == i);
            }
        }
    }
}