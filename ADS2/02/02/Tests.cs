using System;
using AlgorithmsDataStructures2;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization.Configuration;

namespace _02
{
    [TestFixture]
    public class Tests
    {
        private static Random rnd = new Random();

        [Test]
        public void TestAddRnd()
        {
            var tree = new BST<int>(null);
            for (var i = 0; i < 100; i++)
            {
                var key = rnd.Next();
                tree.AddKeyValue(key, key);
                Assert.True(tree.FindNodeByKey(key).NodeHasKey);
            }
        }

        [Test]
        public void TestAdd0()
        {
            var tree = new BST<int>(null);
            Assert.True(tree.AddKeyValue(0, 0));
            Assert.False(tree.AddKeyValue(0, 0));
        }

        [Test]
        public void TestAdd1()
        {
            var root = new BSTNode<int>(0, 0, null);
            var tree = new BST<int>(root);
            Assert.False(tree.AddKeyValue(0, 0));
            Check(root, new[] {0});
            Assert.True(tree.AddKeyValue(1, 1));
            Assert.True(tree.AddKeyValue(2, 2));
            Assert.True(tree.AddKeyValue(3, 3));
            Check(root, new[] {0, 1, 2, 3});
        }

        [Test]
        public void TestAdd2()
        {
            var root = new BSTNode<int>(8, 0, null);
            var tree = new BST<int>(root);
            Assert.True(tree.AddKeyValue(4, 0));
            Assert.True(tree.AddKeyValue(2, 0));
            Assert.True(tree.AddKeyValue(1, 0));
            Assert.True(tree.AddKeyValue(3, 0));
            Assert.True(tree.AddKeyValue(6, 0));
            Assert.True(tree.AddKeyValue(5, 0));
            Assert.True(tree.AddKeyValue(7, 0));
            Assert.True(tree.AddKeyValue(12, 0));
            Assert.True(tree.AddKeyValue(10, 0));
            Assert.True(tree.AddKeyValue(11, 0));
            Assert.True(tree.AddKeyValue(9, 0));
            Assert.True(tree.AddKeyValue(14, 0));
            Assert.True(tree.AddKeyValue(13, 0));
            Assert.True(tree.AddKeyValue(15, 0));
            Check(root, new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15});
            Assert.True(tree.Count() == 15);
        }

        [Test]
        public void TestAdd3()
        {
            var root = new BSTNode<int>(8, 0, null);
            var tree = new BST<int>(root);
            Assert.True(tree.AddKeyValue(4, 0));
            Assert.True(tree.AddKeyValue(2, 0));
            Assert.True(tree.AddKeyValue(1, 0));
            Assert.True(tree.AddKeyValue(3, 0));
            Assert.True(tree.AddKeyValue(6, 0));
            Assert.True(tree.AddKeyValue(5, 0));
            Assert.True(tree.AddKeyValue(7, 0));
            Assert.True(tree.AddKeyValue(12, 0));
            Assert.True(tree.AddKeyValue(10, 0));
            Assert.True(tree.AddKeyValue(11, 0));
            Assert.True(tree.AddKeyValue(9, 0));
            Assert.True(tree.AddKeyValue(14, 0));
            Assert.True(tree.AddKeyValue(13, 0));
            Assert.True(tree.AddKeyValue(15, 0));
            Assert.False(tree.AddKeyValue(4, 0));
            Assert.False(tree.AddKeyValue(2, 0));
            Assert.False(tree.AddKeyValue(1, 0));
            Assert.False(tree.AddKeyValue(3, 0));
            Assert.False(tree.AddKeyValue(6, 0));
            Assert.False(tree.AddKeyValue(5, 0));
            Assert.False(tree.AddKeyValue(7, 0));
            Assert.False(tree.AddKeyValue(12, 0));
            Assert.False(tree.AddKeyValue(10, 0));
            Assert.False(tree.AddKeyValue(11, 0));
            Assert.False(tree.AddKeyValue(9, 0));
            Assert.False(tree.AddKeyValue(14, 0));
            Assert.False(tree.AddKeyValue(13, 0));
            Assert.False(tree.AddKeyValue(15, 0));
            Check(root, new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15});
            Assert.True(tree.Count() == 15);
        }

        [Test]
        public void TestMinMax0()
        {
            var root = new BSTNode<int>(8, 0, null);
            var tree = new BST<int>(root);
            Assert.True(tree.AddKeyValue(4, 4));
            Assert.True(tree.AddKeyValue(2, 2));
            Assert.True(tree.AddKeyValue(1, 1));
            Assert.True(tree.AddKeyValue(3, 3));
            Assert.True(tree.AddKeyValue(6, 6));
            Assert.True(tree.AddKeyValue(5, 5));
            Assert.True(tree.AddKeyValue(7, 7));
            Assert.True(tree.AddKeyValue(12, 12));
            Assert.True(tree.AddKeyValue(10, 10));
            Assert.True(tree.AddKeyValue(11, 11));
            Assert.True(tree.AddKeyValue(9, 9));
            Assert.True(tree.AddKeyValue(14, 14));
            Assert.True(tree.AddKeyValue(13, 13));
            Assert.True(tree.AddKeyValue(15, 15));
            Assert.True(tree.FinMinMax(root, true).NodeKey == 15);
            Assert.True(tree.FinMinMax(root, false).NodeKey == 1);
            Assert.True(tree.FinMinMax(tree.FindNodeByKey(6).Node, false).NodeKey == 5);
            Assert.True(tree.FinMinMax(tree.FindNodeByKey(6).Node, true).NodeKey == 7);
        }

        [Test]
        public void TestMinMax1()
        {
            var tree = new BST<int>(null);
            Assert.True(tree.FinMinMax(null, true) == null);
            Assert.True(tree.FinMinMax(null, false) == null);
        }

        [Test]
        public void TestRemove0()
        {
            var tree = new BST<int>(null);
            Assert.False(tree.DeleteNodeByKey(0));
            tree.AddKeyValue(10, 10);
            Assert.False(tree.DeleteNodeByKey(0));
            Assert.True(tree.DeleteNodeByKey(10));
            tree.AddKeyValue(10, 10);
            tree.AddKeyValue(11, 11);
            Assert.True(tree.DeleteNodeByKey(10));
            Assert.True(tree.DeleteNodeByKey(11));
            tree.AddKeyValue(10, 10);
            tree.AddKeyValue(11, 11);
            tree.AddKeyValue(9, 9);
            Assert.True(tree.DeleteNodeByKey(10));
            Assert.True(tree.DeleteNodeByKey(9));
            Assert.True(tree.DeleteNodeByKey(11));
            Assert.True(tree.Count() == 0);
        }

        [Test]
        public void TestRemove1()
        {
            var tree = new BST<int>(null);
            tree.AddKeyValue(10, 10);
            tree.AddKeyValue(5, 5);
            tree.AddKeyValue(8, 8);
            tree.AddKeyValue(9, 9);
            Assert.True(tree.DeleteNodeByKey(8));
            Check(tree.FindNodeByKey(10).Node, new[] {5, 9, 10});
            Assert.True(tree.DeleteNodeByKey(5));
            Check(tree.FindNodeByKey(10).Node, new[] {9, 10});
            Assert.True(tree.DeleteNodeByKey(10));
            Check(tree.FindNodeByKey(9).Node, new[] {9});
        }

        [Test]
        public void TestRemove2()
        {
            var tree = new BST<int>(null);
            tree.AddKeyValue(10, 10);
            tree.AddKeyValue(5, 5);
            tree.AddKeyValue(4, 4);
            tree.AddKeyValue(8, 8);
            tree.AddKeyValue(9, 9);
            Check(tree.FindNodeByKey(10).Node, new[] {4, 5, 8, 9, 10});
            Assert.True(tree.DeleteNodeByKey(5));
            Check(tree.FindNodeByKey(10).Node, new[] {4, 8, 9, 10});
            tree.AddKeyValue(12, 12);
            tree.AddKeyValue(11, 11);
            tree.AddKeyValue(13, 13);
            Assert.True(tree.DeleteNodeByKey(10));
            Check(tree.FindNodeByKey(11).Node, new[] {4, 8, 9, 11, 12, 13});
        }

        [Test]
        public void TestRemoveRnd()
        {
            var tree = new BST<int>(null);
            var lst = new HashSet<int>();
            for (int i = 0; i < 10000; i++)
            {
                var key = rnd.Next(10000);
                lst.Add(key);
                tree.AddKeyValue(key, 0);
            }

            for (int i = 0; i < 10000; i++)
            {
                var key = rnd.Next(10000);
                if (lst.Contains(key))
                {
                    Assert.True(tree.FindNodeByKey(key).NodeHasKey && (tree.FindNodeByKey(key).Node.NodeKey == key));
                    Assert.True(tree.DeleteNodeByKey(key));
                    lst.Remove(key);
                }
                else
                {
                    Assert.False(tree.FindNodeByKey(key).NodeHasKey);
                    Assert.False(tree.DeleteNodeByKey(key));
                }

                Assert.True(lst.Count == tree.Count());
            }
        }

        [Test]
        public void TestCount0()
        {
            var tree = new BST<int>(null);
            Assert.True(tree.Count() == 0);
            int count = 0;
            for (int i = 0; i < 100; i++)
            {
                count += tree.AddKeyValue(rnd.Next(), 0) ? 1 : 0;
                Assert.True(tree.Count() == count);
            }
        }

        [Test]
        public void TestCount1()
        {
            var root = new BSTNode<int>(8, 0, null);
            var tree = new BST<int>(root);
            int count = 1;
            Assert.True(tree.Count() == count);
            for (int i = 0; i < 100; i++)
            {
                count += tree.AddKeyValue(rnd.Next(), 0) ? 1 : 0;
                Assert.True(tree.Count() == count);
            }
        }

        private void Check(BSTNode<int> node, int[] cmp)
        {
            var lst = new List<int>();
            TakeList(node, lst);
            CheckParent(node);
            Assert.True(node.Parent == null);
            Assert.True(cmp.Length == lst.Count);
            for (var index = 0; index < cmp.Length; index++)
            {
                Assert.True(cmp[index] == lst[index]);
            }
        }

        private void TakeList(BSTNode<int> node, List<int> lst)
        {
            if (node != null)
            {
                TakeList(node.LeftChild, lst);
                lst.Add(node.NodeKey);
                TakeList(node.RightChild, lst);
            }
        }

        private void CheckParent(BSTNode<int> node)
        {
            if (node.LeftChild != null)
            {
                Assert.True(node.LeftChild.Parent == node);
                CheckParent(node.LeftChild);
            }

            if (node.RightChild != null)
            {
                Assert.True(node.RightChild.Parent == node);
                CheckParent(node.RightChild);
            }
        }
    }
}