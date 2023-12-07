﻿using System;
using System.Collections.Generic;
using AlgorithmsDataStructures2;
using NUnit.Framework;

namespace _03
{
    [TestFixture]
    public class Tests
    {
        private static Random rnd = new Random();

        [Test]
        public void TestAddRnd()
        {
            var tree = new BST(null);
            for (var i = 0; i < 100; i++)
            {
                var key = rnd.Next();
                tree.AddKey(key);
                Assert.True(tree.FindNodeByKey(key).NodeHasKey);
            }
        }

        [Test]
        public void TestAdd0()
        {
            var tree = new BST(null);
            Assert.True(tree.AddKey(0));
            Assert.False(tree.AddKey(0));
        }

        [Test]
        public void TestAdd1()
        {
            var root = new BSTNode(0, null);
            var tree = new BST(root);
            Assert.False(tree.AddKey(0));
            Check(root, new[] {0});
            Assert.True(tree.AddKey(1));
            Assert.True(tree.AddKey(2));
            Assert.True(tree.AddKey(3));
            Check(root, new[] {0, 1, 2, 3});
        }

        [Test]
        public void TestAdd2()
        {
            var root = new BSTNode(8, null);
            var tree = new BST(root);
            Assert.True(tree.AddKey(4));
            Assert.True(tree.AddKey(2));
            Assert.True(tree.AddKey(1));
            Assert.True(tree.AddKey(3));
            Assert.True(tree.AddKey(6));
            Assert.True(tree.AddKey(5));
            Assert.True(tree.AddKey(7));
            Assert.True(tree.AddKey(12));
            Assert.True(tree.AddKey(10));
            Assert.True(tree.AddKey(11));
            Assert.True(tree.AddKey(9));
            Assert.True(tree.AddKey(14));
            Assert.True(tree.AddKey(13));
            Assert.True(tree.AddKey(15));
            Check(root, new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15});
            Assert.True(tree.Count() == 15);
        }

        [Test]
        public void TestAdd3()
        {
            var root = new BSTNode(8, null);
            var tree = new BST(root);
            Assert.True(tree.AddKey(4));
            Assert.True(tree.AddKey(2));
            Assert.True(tree.AddKey(1));
            Assert.True(tree.AddKey(3));
            Assert.True(tree.AddKey(6));
            Assert.True(tree.AddKey(5));
            Assert.True(tree.AddKey(7));
            Assert.True(tree.AddKey(12));
            Assert.True(tree.AddKey(10));
            Assert.True(tree.AddKey(11));
            Assert.True(tree.AddKey(9));
            Assert.True(tree.AddKey(14));
            Assert.True(tree.AddKey(13));
            Assert.True(tree.AddKey(15));
            Assert.False(tree.AddKey(4));
            Assert.False(tree.AddKey(2));
            Assert.False(tree.AddKey(1));
            Assert.False(tree.AddKey(3));
            Assert.False(tree.AddKey(6));
            Assert.False(tree.AddKey(5));
            Assert.False(tree.AddKey(7));
            Assert.False(tree.AddKey(12));
            Assert.False(tree.AddKey(10));
            Assert.False(tree.AddKey(11));
            Assert.False(tree.AddKey(9));
            Assert.False(tree.AddKey(14));
            Assert.False(tree.AddKey(13));
            Assert.False(tree.AddKey(15));
            Check(root, new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15});
            Assert.True(tree.Count() == 15);
        }

        [Test]
        public void TestMinMax0()
        {
            var root = new BSTNode(8, null);
            var tree = new BST(root);
            Assert.True(tree.AddKey(4));
            Assert.True(tree.AddKey(2));
            Assert.True(tree.AddKey(1));
            Assert.True(tree.AddKey(3));
            Assert.True(tree.AddKey(6));
            Assert.True(tree.AddKey(5));
            Assert.True(tree.AddKey(7));
            Assert.True(tree.AddKey(12));
            Assert.True(tree.AddKey(10));
            Assert.True(tree.AddKey(11));
            Assert.True(tree.AddKey(9));
            Assert.True(tree.AddKey(14));
            Assert.True(tree.AddKey(13));
            Assert.True(tree.AddKey(15));
            Assert.True(tree.FinMinMax(root, true).NodeKey == 15);
            Assert.True(tree.FinMinMax(root, false).NodeKey == 1);
            Assert.True(tree.FinMinMax(tree.FindNodeByKey(6).Node, false).NodeKey == 5);
            Assert.True(tree.FinMinMax(tree.FindNodeByKey(6).Node, true).NodeKey == 7);
        }

        [Test]
        public void TestMinMax1()
        {
            var tree = new BST(null);
            Assert.True(tree.FinMinMax(null, true) == null);
            Assert.True(tree.FinMinMax(null, false) == null);
        }

        [Test]
        public void TestRemove0()
        {
            var tree = new BST(null);
            Assert.False(tree.DeleteNodeByKey(0));
            tree.AddKey(10);
            Assert.False(tree.DeleteNodeByKey(0));
            Assert.True(tree.DeleteNodeByKey(10));
            tree.AddKey(10);
            tree.AddKey(11);
            Assert.True(tree.DeleteNodeByKey(10));
            Assert.True(tree.DeleteNodeByKey(11));
            tree.AddKey(10);
            tree.AddKey(11);
            tree.AddKey(9);
            Assert.True(tree.DeleteNodeByKey(10));
            Assert.True(tree.DeleteNodeByKey(9));
            Assert.True(tree.DeleteNodeByKey(11));
            Assert.True(tree.Count() == 0);
        }

        [Test]
        public void TestRemove1()
        {
            var tree = new BST(null);
            tree.AddKey(10);
            tree.AddKey(5);
            tree.AddKey(8);
            tree.AddKey(9);
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
            var tree = new BST(null);
            tree.AddKey(10);
            tree.AddKey(5);
            tree.AddKey(4);
            tree.AddKey(8);
            tree.AddKey(9);
            Check(tree.FindNodeByKey(10).Node, new[] {4, 5, 8, 9, 10});
            Assert.True(tree.DeleteNodeByKey(5));
            Check(tree.FindNodeByKey(10).Node, new[] {4, 8, 9, 10});
            tree.AddKey(12);
            tree.AddKey(11);
            tree.AddKey(13);
            Assert.True(tree.DeleteNodeByKey(10));
            Check(tree.FindNodeByKey(11).Node, new[] {4, 8, 9, 11, 12, 13});
        }

        [Test]
        public void TestRemoveRnd()
        {
            var tree = new BST(null);
            var lst = new HashSet<int>();
            for (int i = 0; i < 10000; i++)
            {
                var key = rnd.Next(10000);
                lst.Add(key);
                tree.AddKey(key);
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
            var tree = new BST(null);
            Assert.True(tree.Count() == 0);
            int count = 0;
            for (int i = 0; i < 100; i++)
            {
                count += tree.AddKey(rnd.Next()) ? 1 : 0;
                Assert.True(tree.Count() == count);
            }
        }

        [Test]
        public void TestCount1()
        {
            var root = new BSTNode(8, null);
            var tree = new BST(root);
            int count = 1;
            Assert.True(tree.Count() == count);
            for (int i = 0; i < 100; i++)
            {
                count += tree.AddKey(rnd.Next()) ? 1 : 0;
                Assert.True(tree.Count() == count);
            }
        }

        private void Check(BSTNode node, int[] cmp)
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

        private void TakeList(BSTNode node, List<int> lst)
        {
            if (node != null)
            {
                TakeList(node.LeftChild, lst);
                lst.Add(node.NodeKey);
                TakeList(node.RightChild, lst);
            }
        }

        private void CheckParent(BSTNode node)
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

        [Test]
        public void TestOrder0()
        {
            var tree = new BST(null);
            int[] lst = new int[] {10, 3, 1, 2, 5, 4, 11, 15, 14, 13, 12, 16, 17};
            foreach (var item in lst)
            {
                tree.AddKey(item);
            }

            var wide = tree.WideAllNodes();
            var wideTest = new int[] {10, 3, 11, 1, 5, 15, 2, 4, 14, 16, 13, 17, 12};
            TestOrderResult(wide, wideTest);
            var inOrder = tree.DeepAllNodes(0);
            var inOrderText = new int[] {1, 2, 3, 4, 5, 10, 11, 12, 13, 14, 15, 16, 17};
            TestOrderResult(inOrder, inOrderText);
            var postOrder = tree.DeepAllNodes(1);
            var postOrderText = new int[] {2, 1, 4, 5, 3, 12, 13, 14, 17, 16, 15, 11, 10};
            TestOrderResult(postOrder, postOrderText);
            var preOrder = tree.DeepAllNodes(2);
            var preOrderText = new int[] {10, 3, 1, 2, 5, 4, 11, 15, 14, 13, 12, 16, 17};
            TestOrderResult(preOrder, preOrderText);
        }

        [Test]
        public void TestOrder1()
        {
            var tree = new BST(null);

            var wide = tree.WideAllNodes();
            var empty = new int[] { };
            TestOrderResult(wide, empty);
            var inOrder = tree.DeepAllNodes(0);
            TestOrderResult(inOrder, empty);
            var postOrder = tree.DeepAllNodes(1);
            TestOrderResult(postOrder, empty);
            var preOrder = tree.DeepAllNodes(2);
            TestOrderResult(preOrder, empty);
        }


        [Test]
        public void TestInvert()
        {
            var tree = new BST(null);
            int[] lst = new int[] {10, 3, 1, 2, 5, 4, 11, 15, 14, 13, 12, 16, 17};
            foreach (var item in lst)
            {
                tree.AddKey(item);
            }

            tree.Invert();
            var wide = tree.WideAllNodes();
            var wideTest = new int[] {10, 11, 3, 15, 5, 1, 16, 14, 4, 2, 17, 13, 12};
            TestOrderResult(wide, wideTest);
        }

        private void TestOrderResult(List<BSTNode> wide, int[] wideTest)
        {
            Assert.True(wide.Count == wideTest.Length);
            for (int i = 0; i < wide.Count; i++)
            {
                Assert.True(wide[i].NodeKey == wideTest[i]);
            }
        }
    }
}