using System;
using System.Collections.Generic;
using AlgorithmsDataStructures2;
using NUnit.Framework;

namespace _09
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Test1()
        {
            var res = new SimpleTreeNode<int>[100];
            for (var i = 1; i <= 10; i++)
            {
                res[i] = new SimpleTreeNode<int>(100+i, null);
            }

            var tree = new SimpleTree<int>(res[1]);
            tree.AddChild(res[1], res[2]);
            tree.AddChild(res[1], res[3]);
            tree.AddChild(res[1], res[6]);
            tree.AddChild(res[2], res[5]);
            tree.AddChild(res[2], res[7]);
            tree.AddChild(res[3], res[4]);
            tree.AddChild(res[6], res[8]);
            tree.AddChild(res[8], res[10]);
            tree.AddChild(res[8], res[9]);

            var result = tree.EvenTrees();
            Check(result, new HashSet<(int, int)>() {(101, 103), (101, 106)});
        }

        [Test]
        public void Test2()
        {
            var res = new SimpleTreeNode<int>[100];
            for (var i = 1; i < 100; i++)
            {
                res[i] = new SimpleTreeNode<int>(i, null);
            }

            var tree = new SimpleTree<int>(res[1]);
            tree.AddChild(res[1], res[2]);

            var result = tree.EvenTrees();
            Check(result, new HashSet<(int, int)> {(1, 2)});
            Check(new SimpleTree<int>(null).EvenTrees(), new HashSet<(int, int)> {});
        }
        
        [Test]
        public void Test3()
        {
            var res = new SimpleTreeNode<int>[100];
            for (var i = 1; i < 100; i++)
            {
                res[i] = new SimpleTreeNode<int>(i, null);
            }

            var tree = new SimpleTree<int>(res[1]);
            tree.AddChild(res[1], res[2]);
            tree.AddChild(res[1], res[3]);
            tree.AddChild(res[1], res[4]);

            var result = tree.EvenTrees();
            Check(result, new HashSet<(int, int)> {});
            Check(tree.EvenTrees(), new HashSet<(int, int)> {});
        }

        void Check(List<int> res, HashSet<(int, int)> set)
        {
            for (var i = 0; i < res.Count; i += 2)
            {
                Assert.True(set.Contains((res[i], res[i + 1])));
            }
        }
    }
}