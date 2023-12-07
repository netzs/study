using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class BSTNode
    {
        public int NodeKey; // значение в узле
        public BSTNode Parent; // родитель или null для корня
        public BSTNode LeftChild; // левый потомок
        public BSTNode RightChild; // правый потомок	

        public BSTNode(int key, BSTNode parent)
        {
            NodeKey = key;
            Parent = parent;
            LeftChild = null;
            RightChild = null;
        }
    }

    // промежуточный результат поиска
    public class BSTFind
    {
        // null если в дереве вообще нету узлов
        public BSTNode Node;

        // true если узел найден
        public bool NodeHasKey;

        // true, если родительскому узлу надо добавить новый левым
        public bool ToLeft;

        public BSTFind()
        {
            Node = null;
        }
    }


    public partial class BST
    {
        BSTNode Root; // корень дерева, или null

        public BST(BSTNode node)
        {
            Root = node;
        }

        public BSTFind FindNodeByKey(int key)
        {
            if (Root == null)
            {
                BSTFind findResult = new BSTFind
                {
                    Node = null,
                    NodeHasKey = false,
                    ToLeft = false
                };
                return findResult;
            }

            return RoundFindByKey(key, Root);
        }

        private BSTFind RoundFindByKey(int key, BSTNode node)
        {
            if (node.NodeKey == key)
            {
                return new BSTFind()
                {
                    Node = node,
                    NodeHasKey = true,
                    ToLeft = false,
                };
            }

            if (key < node.NodeKey && node.LeftChild == null)
            {
                return new BSTFind()
                {
                    Node = node,
                    NodeHasKey = false,
                    ToLeft = true,
                };
            }

            if (key < node.NodeKey)
            {
                return RoundFindByKey(key, node.LeftChild);
            }

            if (node.RightChild == null)
            {
                return new BSTFind()
                {
                    Node = node,
                    NodeHasKey = false,
                    ToLeft = false,
                };
            }

            return RoundFindByKey(key, node.RightChild);
        }

        public bool AddKey(int key)
        {
            BSTFind findResult = FindNodeByKey(key);
            if (findResult.NodeHasKey)
            {
                return false;
            }

            var addedNode = new BSTNode(key, findResult.Node);
            if (findResult.Node == null)
            {
                Root = addedNode;
                return true;
            }

            if (findResult.ToLeft)
            {
                findResult.Node.LeftChild = addedNode;
            }
            else
            {
                findResult.Node.RightChild = addedNode;
            }

            return true;
        }

        public BSTNode FinMinMax(BSTNode FromNode, bool FindMax)
        {
            if (FromNode == null)
            {
                return null;
            }

            if (FindMax && FromNode.RightChild == null)
            {
                return FromNode;
            }

            if (FindMax && FromNode.RightChild != null)
            {
                return FinMinMax(FromNode.RightChild, FindMax);
            }

            if (FromNode.LeftChild == null)
            {
                return FromNode;
            }

            return FinMinMax(FromNode.LeftChild, FindMax);
        }

        public bool DeleteNodeByKey(int key)
        {
            var findResult = FindNodeByKey(key);
            if (!findResult.NodeHasKey)
            {
                return false;
            }

            DeleteNode(findResult.Node);
            return true;
        }

        private void DeleteNode(BSTNode node)
        {
            var isLeaf = node.LeftChild == null && node.RightChild == null;
            if (isLeaf)
            {
                DeleteLeafNode(node);
                return;
            }

            if (node.LeftChild != null && node.RightChild != null)
            {
                DeleteNodeWithTwoChild(node);
                return;
            }

            if (node.LeftChild != null)
            {
                DeleteNodeWithLeftChild(node);
                return;
            }

            DeleteNodeWithRightChild(node);
        }

        private void DeleteNodeWithRightChild(BSTNode node)
        {
            BSTNode parent = node.Parent;
            BSTNode right = node.RightChild;
            node.RightChild = null;

            if (parent == null)
            {
                Root = right;
                right.Parent = null;
                return;
            }

            SwapParentChild(node, right);
        }

        private void DeleteNodeWithLeftChild(BSTNode node)
        {
            BSTNode parent = node.Parent;
            BSTNode left = node.LeftChild;
            node.LeftChild = null;

            if (parent == null)
            {
                Root = left;
                left.Parent = null;
                return;
            }

            SwapParentChild(node, left);
        }

        private void DeleteNodeWithTwoChild(BSTNode node)
        {
            BSTNode nextValueNode = FinMinMax(node.RightChild, false);
            DeleteNode(nextValueNode);
            nextValueNode.LeftChild = node.LeftChild;
            nextValueNode.RightChild = node.RightChild;
            node.LeftChild = null;
            node.RightChild = null;
            if (nextValueNode.LeftChild != null)
            {
                nextValueNode.LeftChild.Parent = nextValueNode;
            }

            if (nextValueNode.RightChild != null)
            {
                nextValueNode.RightChild.Parent = nextValueNode;
            }

            if (node.Parent == null)
            {
                Root = nextValueNode;
                nextValueNode.Parent = null;
                return;
            }

            SwapParentChild(node, nextValueNode);
        }

        private static void SwapParentChild(BSTNode oldNode, BSTNode newNode)
        {
            BSTNode parent = oldNode.Parent;
            if (parent.LeftChild == oldNode)
            {
                parent.LeftChild = newNode;
            }
            else
            {
                parent.RightChild = newNode;
            }

            oldNode.Parent = null;
            newNode.Parent = parent;
        }

        private void DeleteLeafNode(BSTNode node)
        {
            BSTNode parent = node.Parent;
            node.Parent = null;
            if (parent == null)
            {
                Root = null;
                return;
            }

            if (parent.RightChild == node)
            {
                parent.RightChild = null;
            }
            else
            {
                parent.LeftChild = null;
            }
        }

        public int Count()
        {
            return RoundCount(Root); // количество узлов в дереве
        }

        private int RoundCount(BSTNode node)
        {
            if (node == null)
            {
                return 0;
            }

            return 1 + RoundCount(node.LeftChild) + RoundCount(node.RightChild);
        }

        public List<BSTNode> WideAllNodes()
        {
            List<BSTNode> result = new List<BSTNode>();
            Queue<BSTNode> queue = new Queue<BSTNode>();
            if (Root != null)
            {
                queue.Enqueue(Root);
            }

            while (queue.Count > 0)
            {
                BSTNode top = queue.Dequeue();
                result.Add(top);
                if (top.LeftChild != null)
                {
                    queue.Enqueue(top.LeftChild);
                }

                if (top.RightChild != null)
                {
                    queue.Enqueue(top.RightChild);
                }
            }

            return result;
        }

        public List<BSTNode> DeepAllNodes(int order)
        {
            var result = new List<BSTNode>();
            if (Root == null)
            {
                return result;
            }

            switch (order)
            {
                case 0:
                    RoundInOrder(Root, result);
                    break;
                case 1:
                    RoundPostOrder(Root, result);
                    break;
                case 2:
                    RoundPreOrder(Root, result);
                    break;
            }

            return result;
        }


        private void RoundInOrder(BSTNode node, List<BSTNode> result)
        {
            if (node.LeftChild != null)
            {
                RoundInOrder(node.LeftChild, result);
            }

            result.Add(node);

            if (node.RightChild != null)
            {
                RoundInOrder(node.RightChild, result);
            }
        }

        private void RoundPostOrder(BSTNode node, List<BSTNode> result)
        {
            if (node.LeftChild != null)
            {
                RoundPostOrder(node.LeftChild, result);
            }

            if (node.RightChild != null)
            {
                RoundPostOrder(node.RightChild, result);
            }

            result.Add(node);
        }

        private void RoundPreOrder(BSTNode node, List<BSTNode> result)
        {
            result.Add(node);

            if (node.LeftChild != null)
            {
                RoundPreOrder(node.LeftChild, result);
            }

            if (node.RightChild != null)
            {
                RoundPreOrder(node.RightChild, result);
            }
        }
    }
}