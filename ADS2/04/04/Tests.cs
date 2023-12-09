using System;
using AlgorithmsDataStructures2;
using NUnit.Framework;

namespace _04
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void TestCount()
        {
            var tree = new aBST(1);
            Assert.True(tree.Tree.Length == 1);
            tree = new aBST(2);
            Assert.True(tree.Tree.Length == 3);
            tree = new aBST(3);
            Assert.True(tree.Tree.Length == 7);
            tree = new aBST(4);
            Assert.True(tree.Tree.Length == 15);
        }

        [Test]
        public void TestAdd()
        {
            var tree = new aBST(4);
            Assert.True(tree.AddKey(50) == 0);
            Assert.True(tree.AddKey(25) == 1);
            Assert.True(tree.AddKey(75) == 2);
            Assert.True(tree.AddKey(37) == 4);
            Assert.True(tree.AddKey(31) == 9);
            Assert.True(tree.AddKey(43) == 10);
            Assert.True(tree.AddKey(62) == 5);
            Assert.True(tree.AddKey(55) == 11);
            Assert.True(tree.AddKey(84) == 6);
            Assert.True(tree.AddKey(92) == 14);
            
            Assert.True(tree.FindKeyIndex(50) == 0);
            Assert.True(tree.FindKeyIndex(25) == 1);
            Assert.True(tree.FindKeyIndex(75) == 2);
            Assert.True(tree.FindKeyIndex(37) == 4);
            Assert.True(tree.FindKeyIndex(31) == 9);
            Assert.True(tree.FindKeyIndex(43) == 10);
            Assert.True(tree.FindKeyIndex(62) == 5);
            Assert.True(tree.FindKeyIndex(55) == 11);
            Assert.True(tree.FindKeyIndex(84) == 6);
            Assert.True(tree.FindKeyIndex(92) == 14);
            Assert.True(tree.FindKeyIndex(10) == -3);
            Assert.True(tree.FindKeyIndex(63) == -12);
            Assert.True(tree.FindKeyIndex(83) == -13);
            
            Assert.True(tree.AddKey(92) == 14);
            Assert.True(tree.AddKey(93) == -1);
            Assert.True(tree.AddKey(5) == 3);
            Assert.True(tree.AddKey(4) == 7);
            Assert.True(tree.AddKey(3) == -1);
            
            Assert.True(tree.FindKeyIndex(6) == -8);
            Assert.True(tree.AddKey(6) == 8);
            Assert.True(tree.FindKeyIndex(6) == 8);
            Assert.True(tree.FindKeyIndex(7) == null);
            Assert.True(tree.AddKey(7) == -1);
        }
        [Test]
        public void TestAdd2()
        {
            var tree = new aBST(2);
            Assert.True(tree.FindKeyIndex(50) == 0);
            Assert.True(tree.AddKey(50) == 0);
            Assert.True(tree.AddKey(50) == 0);
            Assert.True(tree.FindKeyIndex(25) == -1);
            Assert.True(tree.FindKeyIndex(24) == -1);
            Assert.True(tree.FindKeyIndex(23) == -1);
            
            Assert.True(tree.AddKey(25) == 1);
            Assert.True(tree.AddKey(25) == 1);
            Assert.True(tree.FindKeyIndex(23) == null);
            
            Assert.True(tree.FindKeyIndex(75) == -2);
            Assert.True(tree.FindKeyIndex(76) == -2);
            Assert.True(tree.FindKeyIndex(76) == -2);
            
            Assert.True(tree.AddKey(75) == 2);
            Assert.True(tree.AddKey(75) == 2);
            Assert.True(tree.FindKeyIndex(74) == null);
            Assert.True(tree.FindKeyIndex(76) == null);
        }
    }
}