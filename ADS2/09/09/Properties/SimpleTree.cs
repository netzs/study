using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace AlgorithmsDataStructures2
{
    public class SimpleTreeNode<T>
    {
        public T NodeValue; // значение в узле
        public SimpleTreeNode<T> Parent; // родитель или null для корня
        public List<SimpleTreeNode<T>> Children; // список дочерних узлов или null

        public int Level;

        public int NoSaveLevel =>
            Parent == null ? 0 : Parent.NoSaveLevel + 1;

        public SimpleTreeNode(T val, SimpleTreeNode<T> parent)
        {
            NodeValue = val;
            Parent = parent;
            Children = null;
        }
    }

    public class SimpleTree<T>
    {
        public SimpleTreeNode<T> Root; // корень, может быть null

        public SimpleTree(SimpleTreeNode<T> root)
        {
            Root = root;
        }

        public void AddChild(SimpleTreeNode<T> ParentNode, SimpleTreeNode<T> NewChild)
        {
            if (ParentNode == null)
            {
                Root = NewChild;
                NewChild.Parent = null;
                return;
            }

            if (ParentNode.Children == null)
            {
                ParentNode.Children = new List<SimpleTreeNode<T>>();
            }

            ParentNode.Children.Add(NewChild);
            NewChild.Parent = ParentNode;
        }

        public void DeleteNode(SimpleTreeNode<T> NodeToDelete)
        {
            if (NodeToDelete.Parent == null)
            {
                Root = null;
                return;
            }

            NodeToDelete.Parent.Children.Remove(NodeToDelete);
            if (NodeToDelete.Parent.Children.Count == 0)
            {
                NodeToDelete.Parent.Children = null;
            }

            NodeToDelete.Parent = null;
        }

        public List<SimpleTreeNode<T>> GetAllNodes()
        {
            var result = new List<SimpleTreeNode<T>>();
            if (Root != null)
            {
                RoundGet(Root, result);
            }

            return result;
        }

        private void RoundGet(SimpleTreeNode<T> node, List<SimpleTreeNode<T>> result)
        {
            result.Add(node);
            if (node.Children != null)
            {
                foreach (var child in node.Children)
                {
                    RoundGet(child, result);
                }
            }
        }

        public List<SimpleTreeNode<T>> FindNodesByValue(T val)
        {
            List<SimpleTreeNode<T>> result = new List<SimpleTreeNode<T>>();

            if (Root != null)
            {
                RoundFind(val, Root, result);
            }

            return result;
        }

        private void RoundFind(T val, SimpleTreeNode<T> node, List<SimpleTreeNode<T>> result)
        {
            if (Equals(node.NodeValue, val))
            {
                result.Add(node);
            }

            if (node.Children != null)
            {
                foreach (var child in node.Children)
                {
                    RoundFind(val, child, result);
                }
            }
        }

        public void MoveNode(SimpleTreeNode<T> OriginalNode, SimpleTreeNode<T> NewParent)
        {
            DeleteNode(OriginalNode);
            AddChild(NewParent, OriginalNode);
        }

        public int Count()
        {
            if (Root != null)
            {
                return RoundCount(Root);
            }

            return 0;
        }

        private int RoundCount(SimpleTreeNode<T> node)
        {
            if (node.Children == null)
            {
                return 1;
            }

            int result = 1;
            foreach (SimpleTreeNode<T> child in node.Children)
            {
                result += RoundCount(child);
            }

            return result;
        }

        public int LeafCount()
        {
            if (Root != null)
            {
                return RoundLeaf(Root);
            }

            return 0;
        }

        private int RoundLeaf(SimpleTreeNode<T> node)
        {
            if (node.Children == null)
            {
                return 1;
            }

            int result = 0;
            foreach (SimpleTreeNode<T> child in node.Children)
            {
                result += RoundLeaf(child);
            }

            return result;
        }

        public void UpdateNodeLevel()
        {
            if (Root != null)
            {
                RoundNode(Root, 0);
            }
        }

        private void RoundNode(SimpleTreeNode<T> node, int level)
        {
            node.Level = level;

            if (node.Children == null)
            {
                return;
            }

            foreach (SimpleTreeNode<T> child in node.Children)
            {
                RoundNode(child, level + 1);
            }
        }

        public List<T> EvenTrees()
        {
            var result = new List<T>();
            if (Root != null)
            {
                RoundEvenTrees(Root, result);
            }

            return result;
        }

        private int RoundEvenTrees(SimpleTreeNode<T> node, List<T> result)
        {
            if (node.Children == null)
            {
                return 1;
            }

            var nodeCount = 1 + node.Children.Sum(item => RoundEvenTrees(item, result));
            if (nodeCount % 2 == 0 && node.Parent != null)
            {
                result.Add(node.Parent.NodeValue);
                result.Add(node.NodeValue);
            }

            return nodeCount;
        }
    }
}