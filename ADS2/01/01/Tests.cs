using System.Collections.Generic;
using System.IO;
using System.Linq;
using AlgorithmsDataStructures2;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace _01
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void TestCount()
        {
            var tree = new SimpleTree<int>(null);
            Assert.True(tree.Count() == 0);
            Assert.True(tree.LeafCount() == 0);
            var node = new SimpleTreeNode<int>(0, null);
            tree.AddChild(null, node);
            Assert.True(tree.Count() == 1);
            Assert.True(tree.LeafCount() == 1);
            for (var i = 0; i < 10; i++)
            {
                var node2 = new SimpleTreeNode<int>(i + 1, null);
                tree.AddChild(tree.Root, node2);
            }

            Assert.True(tree.Count() == 11);
            Assert.True(tree.LeafCount() == 10);
            var node3 = new SimpleTreeNode<int>(100, null);
            var node4 = new SimpleTreeNode<int>(101, null);
            tree.AddChild(tree.Root, node3);
            tree.AddChild(node3, node4);
            Assert.True(tree.Count() == 13);
            Assert.True(tree.LeafCount() == 11);
            tree.DeleteNode(node4);
            Assert.True(tree.Count() == 12);
            Assert.True(tree.LeafCount() == 11);
            tree.DeleteNode(node3);
            Assert.True(tree.Count() == 11);
            Assert.True(tree.LeafCount() == 10);
            CheckTree(tree);
        }

        [Test]
        public void TestCount2()
        {
            var tree = CreateTree(new List<(int, List<int>)>()
            {
                (1, new List<int>() {20, 30, 40}),
                (20, new List<int>() {21, 22}),
                (30, new List<int>() {31, 32, 33, 34, 35, 36}),
                (31, new List<int>() {37}),
            }, out _);
            Assert.True(tree.Count() == 13);
            Assert.True(tree.LeafCount() == 9);
            CheckTree(tree);
        }

        [Test]
        public void TestCount3()
        {
            var tree = CreateTree(new List<(int, List<int>)>()
            {
                (9, new List<int>() {4, 17}),
                (4, new List<int>() {3, 6}),
                (6, new List<int>() {5, 7}),
                (17, new List<int>() {22}),
                (22, new List<int>() {20}),
            }, out var nodes);
            Assert.True(tree.Count() == 9);
            CheckTree(tree);
            Assert.True(tree.LeafCount() == 4);
        }

        [Test]
        public void TestAdd()
        {
            var node = new SimpleTreeNode<int>(1, null);
            var tree = new SimpleTree<int>(node);
            Assert.True(node.Parent == null);
            Assert.True(node.Children == null);
            Assert.True(tree.Root == node);
            Assert.True(tree.Root.NodeValue == 1);
            CheckTree(tree);
        }


        [Test]
        public void TestAdd1()
        {
            var node = new SimpleTreeNode<int>(1, null);
            var tree = new SimpleTree<int>(null);
            Assert.True(tree.Root == null);
            tree.AddChild(null, node);
            Assert.True(node.Parent == null);
            Assert.True(node.Children == null);
            Assert.True(tree.Root == node);
            var node2 = new SimpleTreeNode<int>(2, null);
            tree.AddChild(node, node2);
            Assert.True(node.Parent == null);
            Assert.True(node.Children != null);
            Assert.True(node.Children.Contains(node2));
            Assert.True(tree.Root == node);
            Assert.True(node2.Parent == node);

            var node3 = new SimpleTreeNode<int>(3, null);
            tree.AddChild(node, node3);
            Assert.True(node.Parent == null);
            Assert.True(node.Children != null);
            Assert.True(node.Children.Contains(node3));
            Assert.True(node.Children.Count == 2);
            Assert.True(tree.Root == node);
            Assert.True(node3.Parent == node);

            var node4 = new SimpleTreeNode<int>(4, null);
            tree.AddChild(node2, node4);
            Assert.True(node.Parent == null);
            Assert.True(node.Children != null);
            Assert.True(!node.Children.Contains(node4));
            Assert.True(node2.Children.Count == 1);
            Assert.True(node2.Children.Contains(node4));
            Assert.True(tree.Root == node);
            Assert.True(node4.Parent == node2);
            CheckTree(tree);
        }

        [Test]
        public void TestRemove()
        {
            var tree = CreateTree(new List<(int, List<int>)>()
            {
                (9, new List<int>() {4, 17}),
                (4, new List<int>() {3, 6}),
                (6, new List<int>() {5, 7}),
                (17, new List<int>() {22}),
                (22, new List<int>() {20}),
            }, out var nodes);
            tree.DeleteNode(nodes[17]);
            Assert.True(Cmp(tree, CreateTree(new List<(int, List<int>)>()
            {
                (9, new List<int>() {4}),
                (4, new List<int>() {3, 6}),
                (6, new List<int>() {5, 7}),
            }, out _)));

            tree.DeleteNode(nodes[6]);

            Assert.True(Cmp(tree, CreateTree(new List<(int, List<int>)>()
            {
                (9, new List<int>() {4}),
                (4, new List<int>() {3}),
            }, out _)));

            tree.DeleteNode(nodes[3]);

            Assert.True(Cmp(tree, CreateTree(new List<(int, List<int>)>()
            {
                (9, new List<int>() {4}),
            }, out _)));

            tree.DeleteNode(nodes[4]);

            Assert.True(Cmp(tree, CreateTree(new List<(int, List<int>)>()
            {
                (9, new List<int>() { }),
            }, out _)));

            tree.DeleteNode(tree.Root);

            Assert.True(Cmp(tree, CreateTree(new List<(int, List<int>)>()
            {
            }, out _)));
            CheckTree(tree);
        }

        [Test]
        public void TestGetAll()
        {
            var tree = CreateTree(new List<(int, List<int>)>()
            {
                (9, new List<int>() {4, 17}),
                (4, new List<int>() {3, 6}),
                (6, new List<int>() {5, 7}),
                (17, new List<int>() {22}),
                (22, new List<int>() {20}),
            }, out var nodes);
            var all = tree.GetAllNodes();
            foreach (var item in all)
            {
                Assert.True(nodes[item.NodeValue] == item);
            }
            CheckTree(tree);
        }

        [Test]
        public void TestGetAll2()
        {
            var tree = new SimpleTree<int>(null);
            Assert.True(tree.GetAllNodes().Count == 0);
        }

        [Test]
        public void TestFind()
        {
            var tree = CreateTree(new List<(int, List<int>)>()
            {
                (9, new List<int>() {4, 17}),
                (4, new List<int>() {3, 6}),
                (6, new List<int>() {5, 7}),
                (17, new List<int>() {22}),
                (22, new List<int>() {20}),
            }, out var nodes);
            var allValue = new[] {9, 4, 17, 3, 6, 5, 7, 22, 20};
            foreach (var item in allValue)
            {
                Assert.True(nodes[item] == tree.FindNodesByValue(item).First());
            }
        }
        
        [Test]
        public void TestFind3()
        {
            var tree = new SimpleTree<string>(null);
            var node0 = new SimpleTreeNode<string>("aaa", null);
            var node1 = new SimpleTreeNode<string>("bbb", null);
            var node2 = new SimpleTreeNode<string>("ccc", null);
            var node3 = new SimpleTreeNode<string>("aaa", null);
            tree.AddChild(null, node0);
            tree.AddChild(node0, node1);
            tree.AddChild(node1, node2);
            tree.AddChild(node2, node3);

            var fnd = tree.FindNodesByValue("aaa");
            Assert.True(fnd.Contains(node0) && fnd.Contains(node3));
        }

        [Test]
        public void TestFind2()
        {
            var tree = new SimpleTree<int>(null);
            Assert.True(tree.FindNodesByValue(1).Count == 0);
            tree.AddChild(null, new SimpleTreeNode<int>(1, null));
            Assert.True(tree.FindNodesByValue(1).Count == 1 && tree.FindNodesByValue(1).First() == tree.Root);
            tree.AddChild(tree.Root, new SimpleTreeNode<int>(2, null));
            tree.AddChild(tree.Root, new SimpleTreeNode<int>(2, null));
            tree.AddChild(tree.Root, new SimpleTreeNode<int>(2, null));
            tree.AddChild(tree.Root, new SimpleTreeNode<int>(2, null));
            Assert.True(tree.FindNodesByValue(2).Count == 4);
            tree.AddChild(tree.Root.Children[0], new SimpleTreeNode<int>(2, null));
            Assert.True(tree.FindNodesByValue(2).Count == 5);
        }

        [Test]
        public void TestMove()
        {
            var tree = CreateTree(new List<(int, List<int>)>()
            {
                (9, new List<int>() {4, 17}),
                (4, new List<int>() {3, 6}),
                (6, new List<int>() {5, 7}),
                (17, new List<int>() {22}),
                (22, new List<int>() {20}),
            }, out var nodes);
            tree.MoveNode(nodes[6], nodes[17]);
            Assert.True(Cmp(tree,
                CreateTree(new List<(int, List<int>)>()
                {
                    (9, new List<int>() {4, 17}),
                    (4, new List<int>() {3}),
                    (17, new List<int>() {22, 6}),
                    (6, new List<int>() {5, 7}),
                    (22, new List<int>() {20}),
                }, out _)));

            tree.MoveNode(nodes[6], nodes[4]);
            Assert.True(Cmp(tree,
                CreateTree(new List<(int, List<int>)>()
                {
                    (9, new List<int>() {4, 17}),
                    (4, new List<int>() {3, 6}),
                    (6, new List<int>() {5, 7}),
                    (17, new List<int>() {22}),
                    (22, new List<int>() {20}),
                }, out _)));

            tree.MoveNode(nodes[6], nodes[20]);

            Assert.True(Cmp(tree,
                CreateTree(new List<(int, List<int>)>()
                {
                    (9, new List<int>() {4, 17}),
                    (4, new List<int>() {3}),
                    (17, new List<int>() {22}),
                    (22, new List<int>() {20}),
                    (20, new List<int>() {6}),
                    (6, new List<int>() {5, 7}),
                }, out _)));

            tree.MoveNode(nodes[17], nodes[9]);

            Assert.True(Cmp(tree,
                CreateTree(new List<(int, List<int>)>()
                {
                    (9, new List<int>() {4, 17}),
                    (4, new List<int>() {3}),
                    (17, new List<int>() {22}),
                    (22, new List<int>() {20}),
                    (20, new List<int>() {6}),
                    (6, new List<int>() {5, 7}),
                }, out _)));
        }
        
        [Test]
        public void TestLevel()
        {
            var tree = CreateTree(new List<(int, List<int>)>()
            {
                (9, new List<int>() {4, 17}),
                (4, new List<int>() {3, 6}),
                (6, new List<int>() {5, 7}),
                (17, new List<int>() {22}),
                (22, new List<int>() {20}),
            }, out var nodes);
            tree.UpdateNodeLevel();
            foreach (var node in nodes.Values)
            {
                Assert.True(node.Level == node.NoSaveLevel);
            }

            Assert.True(nodes[9].Level == 0);
            Assert.True(nodes[4].Level == 1);
            Assert.True(nodes[17].Level == 1);
            Assert.True(nodes[3].Level == 2);
            Assert.True(nodes[6].Level == 2);
            Assert.True(nodes[22].Level == 2);
            Assert.True(nodes[5].Level == 3);
            Assert.True(nodes[7].Level == 3);
            Assert.True(nodes[20].Level == 3);
        }

        private bool Cmp(SimpleTree<int> a, SimpleTree<int> b)
        {
            CheckTree(a);
            return a.Root == null && b.Root == null || CmpNode(a.Root, b.Root);
        }

        private void CheckTree(SimpleTree<int> tree)
        {
            if (tree.Root == null)
            {
                return;
            }
            
            Assert.True(tree.Root.Parent == null);
            CheckNode(tree.Root);
        }

        private void CheckNode(SimpleTreeNode<int> node)
        {
            if (node.Children == null)
            {
                return;
            }

            foreach (var item in node.Children)
            {
                Assert.True(item.Parent == node);
                CheckNode(item);
            }
        }

        private bool CmpNode(SimpleTreeNode<int> a, SimpleTreeNode<int> b)
        {
            return a.NodeValue == b.NodeValue && (a.Children == null && b.Children == null ||
                                                  a.Children != null && b.Children != null &&
                                                  a.Children.Count == b.Children.Count && NodeChildCmp(a, b));
        }

        private bool NodeChildCmp(SimpleTreeNode<int> a, SimpleTreeNode<int> b)
        {
            var sum = true;
            for (var i = 0; i < a.Children.Count; i++)
            {
                sum = sum && CmpNode(a.Children[i], b.Children[i]);
            }

            return sum;
        }

        private SimpleTree<int> CreateTree(List<(int, List<int>)> data, out Dictionary<int, SimpleTreeNode<int>> dict)
        {
            var tree = new SimpleTree<int>(null);
            dict = new Dictionary<int, SimpleTreeNode<int>>();
            foreach (var (key, list) in data)
            {
                if (!dict.TryGetValue(key, out var parentNode))
                {
                    parentNode = new SimpleTreeNode<int>(key, null);
                    dict.Add(key, parentNode);
                    tree.AddChild(null, parentNode);
                }

                foreach (var item in list)
                {
                    var childNode = new SimpleTreeNode<int>(item, null);
                    tree.AddChild(parentNode, childNode);
                    dict.Add(item, childNode);
                }
            }

            CheckTree(tree);
            return tree;
        }
    }
}