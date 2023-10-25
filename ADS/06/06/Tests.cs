using System;
using AlgorithmsDataStructures;
using NUnit.Framework;

namespace _06
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Test0()
        {
            var deque = new Deque<int>();
            Assert.True(deque.Size() == 0 && deque.RemoveFront() == default && deque.RemoveTail() == default );

            for (var i = 0; i < 10; i++)
            {
                deque.AddTail(i);
            }
            for (var i = 0; i < 10; i++)
            {
                Assert.True(deque.RemoveFront() == i);
            }
            Assert.True(deque.Size() == 0 && deque.RemoveFront() == default && deque.RemoveTail() == default );
            
            for (var i = 0; i < 10; i++)
            {
                deque.AddTail(i);
            }

            Assert.True(deque.Size() == 10);
            
            Assert.True(deque.RemoveFront() == 0);
            Assert.True(deque.RemoveTail() == 9);
            Assert.True(deque.RemoveFront() == 1);
            Assert.True(deque.RemoveTail() == 8);
            Assert.True(deque.RemoveFront() == 2);
            Assert.True(deque.RemoveTail() == 7);
            Assert.True(deque.RemoveFront() == 3);
            Assert.True(deque.RemoveTail() == 6);
            Assert.True(deque.RemoveFront() == 4);
            Assert.True(deque.RemoveTail() == 5);
            
            Assert.True(deque.Size() == 0 && deque.RemoveFront() == default && deque.RemoveTail() == default );
            
            for (var i = 0; i < 10; i++)
            {
                deque.AddTail(i);
                Assert.True(deque.RemoveFront() == i);
            }
            
            for (var i = 0; i < 10; i++)
            {
                deque.AddFront(i);
            }
            for (var i = 0; i < 10; i++)
            {
                Assert.True(deque.RemoveTail() == i);
            }
        }
    }
}