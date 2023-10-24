﻿using System;
using System.Net.Sockets;
using AlgorithmsDataStructures;
using NUnit.Framework;

namespace _04
{
    [TestFixture]
    public class Tests
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
            for (var i = size - 1; i >= 0 ; i--)
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
    }
}