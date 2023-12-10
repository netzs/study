using System.Collections.Generic;
using AlgorithmsDataStructures2;
using NUnit.Framework;

namespace _06
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Test1()
        {
            var tree = new BalancedBST();
            tree.GenerateTree(new[] {1});
            Assert.True(tree.IsBalanced(tree.Root));
            Check(tree.Root, new HashSet<int>() {1}, 0);
        }

        [Test]
        public void Test2()
        {
            var tree = new BalancedBST();
            var ar = new[] {1, 2, 3, 4, 5, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27};
            tree.GenerateTree(ar);
            Check(tree.Root, new HashSet<int>(ar), 0);
            Assert.True(tree.IsBalanced(tree.Root));
        }

        [Test]
        public void Test3()
        {
            var tree = new BalancedBST();
            var ar = new[] {3, 2, 1, 4};
            tree.GenerateTree(ar);
            Check(tree.Root, new HashSet<int>(ar), 0);
            Check(tree.Root.LeftChild, new HashSet<int>() {1}, 1);
            Check(tree.Root.RightChild, new HashSet<int>() {3, 4}, 1);
            Assert.True(tree.IsBalanced(tree.Root));
            
        }
        
        [Test]
        public void Test4()
        {
            var tree = new BalancedBST();
            var ar = new[] {3, 2, 1, 4};
            tree.GenerateTree(ar);
            tree.Root.LeftChild = null;
            Assert.False(tree.IsBalanced(tree.Root));
            Assert.True(tree.IsBalanced(tree.Root.RightChild));
            
        }

        private void Check(BSTNode node, HashSet<int> hashSet, int level)
        {
            Assert.True(hashSet.Contains(node.NodeKey));
            Assert.True(node.Level == level);
            hashSet.Remove(node.NodeKey);
            if (node.LeftChild != null)
            {
                Assert.True(node.LeftChild.NodeKey < node.NodeKey);
                Assert.True(node.LeftChild.Parent == node);
                Check(node.LeftChild, hashSet, level + 1);
            }

            if (node.RightChild != null)
            {
                Assert.True(node.NodeKey <= node.RightChild.NodeKey);
                Assert.True(node.RightChild.Parent == node);
                Check(node.RightChild, hashSet, level + 1);
            }
        }
    }
}