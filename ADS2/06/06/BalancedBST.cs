using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Activation;

namespace AlgorithmsDataStructures2
{
    public class BSTNode
    {
        public int NodeKey; // ключ узла
        public BSTNode Parent; // родитель или null для корня
        public BSTNode LeftChild; // левый потомок
        public BSTNode RightChild; // правый потомок	
        public int Level; // глубина узла

        public BSTNode(int key, BSTNode parent)
        {
            NodeKey = key;
            Parent = parent;
            LeftChild = null;
            RightChild = null;
        }
    }


    public class BalancedBST
    {
        public BSTNode Root; // корень дерева

        public BalancedBST()
        {
            Root = null;
        }

        public void GenerateTree(int[] a)
        {
            int[] c = new int [a.Length];
            Array.Copy(a, c, a.Length);
            Array.Sort(c);
            Root = CreateNode(c, 0, c.Length - 1, 0, null);
        }

        private BSTNode CreateNode(int[] data, int left, int right, int level, BSTNode parent)
        {
            if (left > right)
            {
                return null;
            }

            var center = (left + right) / 2;
            var node = new BSTNode(data[center], parent)
            {
                Level = level
            };

            node.LeftChild = CreateNode(data, left, center - 1, level + 1, node);
            node.RightChild = CreateNode(data, center + 1, right, level + 1, node);
            return node;
        }

        public bool IsBalanced(BSTNode root_node)
        {
            return GetIsBalancedAndDepth(root_node).Item1;
        }

        private (bool, int) GetIsBalancedAndDepth(BSTNode root_node)
        {
            (bool leftBalanced, int leftDepth) = root_node.LeftChild == null ? (true, root_node.Level) : GetIsBalancedAndDepth(root_node.LeftChild);
            (bool rightBalanced, int rightDepth) = root_node.RightChild == null ? (true, root_node.Level) : GetIsBalancedAndDepth(root_node.RightChild);

            return (leftBalanced && rightBalanced && Math.Abs(leftDepth - rightDepth) <= 1, Math.Max(leftDepth, rightDepth));
        }
    }
}