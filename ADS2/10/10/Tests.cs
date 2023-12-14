using System;
using System.Collections.Generic;
using AlgorithmsDataStructures2;
using NUnit.Framework;

namespace _10
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void TestAdd()
        {
            var t = new SimpleGraph<int>(3);
            t.AddVertex(1);
            t.AddVertex(2);
            t.AddVertex(3);
            Check(t, new[] {1, 2, 3}, new[] {0, 0, 0, 0, 0, 0, 0, 0, 0});
        }

        [Test]
        public void TestEdges()
        {
            var t = new SimpleGraph<int>(3);
            t.AddVertex(1);
            t.AddVertex(2);
            t.AddVertex(3);
            t.AddEdge(0, 1);
            t.AddEdge(1, 2);
            Check(t, new[] {1, 2, 3}, new[] {0, 1, 0, 1, 0, 1, 0, 1, 0});
            t.AddEdge(2, 0);
            Check(t, new[] {1, 2, 3}, new[] {0, 1, 1, 1, 0, 1, 1, 1, 0});
            t.AddEdge(2, 0);
            Check(t, new[] {1, 2, 3}, new[] {0, 1, 1, 1, 0, 1, 1, 1, 0});
        }

        [Test]
        public void TestEdges2()
        {
            var t = new SimpleGraph<int>(3);
            t.AddVertex(1);
            t.AddVertex(2);
            t.AddVertex(3);
            t.AddEdge(0, 1);
            t.AddEdge(1, 2);
            Check(t, new[] {1, 2, 3}, new[] {0, 1, 0, 1, 0, 1, 0, 1, 0});
            t.AddEdge(2, 0);
            Check(t, new[] {1, 2, 3}, new[] {0, 1, 1, 1, 0, 1, 1, 1, 0});
            t.AddEdge(2, 0);
            Check(t, new[] {1, 2, 3}, new[] {0, 1, 1, 1, 0, 1, 1, 1, 0});
        }

        [Test]
        public void TestRemove()
        {
            var t = new SimpleGraph<int>(3);
            t.AddVertex(1);
            t.AddVertex(2);
            t.AddVertex(3);
            t.AddEdge(0, 1);
            t.AddEdge(1, 2);
            t.AddEdge(2, 0);
            t.RemoveEdge(2, 0);
            Check(t, new[] {1, 2, 3}, new[] {0, 1, 0, 1, 0, 1, 0, 1, 0});
            t.RemoveEdge(1, 0);
            Assert.False(t.IsEdge(1, 0));
            Assert.False(t.IsEdge(0, 1));
            t.RemoveEdge(1, 2);
            Assert.False(t.IsEdge(1, 2));
            Assert.False(t.IsEdge(2, 1));
            Check(t, new[] {1, 2, 3}, new[] {0, 0, 0, 0, 0, 0, 0, 0, 0});
        }

        [Test]
        public void TestRemove2()
        {
            var t = new SimpleGraph<int>(3);
            t.AddVertex(1);
            t.AddVertex(2);
            t.AddVertex(3);
            t.AddEdge(0, 1);
            t.AddEdge(1, 2);
            t.RemoveVertex(1);
            Assert.False(t.IsEdge(1, 0));
            Assert.False(t.IsEdge(0, 1));
            Assert.False(t.IsEdge(1, 2));
            Assert.False(t.IsEdge(2, 1));

            Check(t, new[] {1, -1, 3}, new[] {0, 0, 0, 0, 0, 0, 0, 0, 0});
            t.AddVertex(4);
            Check(t, new[] {1, 4, 3}, new[] {0, 0, 0, 0, 0, 0, 0, 0, 0});
        }


        [Test]
        public void TestDFS()
        {
            var t = new SimpleGraph<int>(10);
            for (var i = 0; i < 10; i++)
            {
                t.AddVertex(i);
            }

            DfsCheck(t.DepthFirstSearch(4, 0), new int[] { });
            DfsCheck(t.DepthFirstSearch(0, 0), new int[] {0});
            t.AddEdge(0, 1);
            t.AddEdge(1, 2);
            t.AddEdge(2, 3);
            t.AddEdge(3, 4);
            t.AddEdge(4, 5);
            DfsCheck(t.DepthFirstSearch(0, 5), new[] {0, 1, 2, 3, 4, 5});
            t.AddEdge(0, 1);
            t.AddEdge(0, 2);
            t.AddEdge(0, 3);
            t.AddEdge(0, 4);
            t.AddEdge(4, 5);
            DfsCheck(t.DepthFirstSearch(0, 5), new[] {0, 1, 2, 3, 4, 5});
            t.AddEdge(1, 5);
            DfsCheck(t.DepthFirstSearch(0, 5), new[] {0, 1, 5});
            DfsCheck(t.DepthFirstSearch(5, 0), new[] {5, 1, 0});
            t.AddEdge(6, 7);
            t.AddEdge(6, 8);
            t.AddEdge(6, 9);
            DfsCheck(t.DepthFirstSearch(6, 0), new int[] { });
            t.AddEdge(6, 5);
            DfsCheck(t.DepthFirstSearch(9, 0), new int[] {9, 6, 5, 1, 0});
        }

        private void DfsCheck(List<Vertex<int>> depthFirstSearch, int[] ints)
        {
            Assert.True(depthFirstSearch.Count == ints.Length);
            for (int i = 0; i < depthFirstSearch.Count; i++)
            {
                Assert.True(depthFirstSearch[i].Value == ints[i]);
            }
        }


        private void Check(SimpleGraph<int> simpleGraph, int[] val, int[] edgs)
        {
            for (var i = 0; i < val.Length; i++)
            {
                if (val[i] == -1)
                {
                    Assert.True(simpleGraph.vertex[i] == null);
                }
                else
                {
                    Assert.True(simpleGraph.vertex[i].Value == val[i]);
                }
            }

            for (var i = 0; i < simpleGraph.max_vertex; i++)
            {
                for (var j = 0; j < simpleGraph.max_vertex; j++)
                {
                    Assert.True(simpleGraph.IsEdge(i, j) == simpleGraph.IsEdge(j, i));
                    Assert.True((simpleGraph.IsEdge(i, j) ? 1 : 0) == edgs[i * simpleGraph.max_vertex + j]);
                    Assert.True(simpleGraph.m_adjacency[i, j] == edgs[i * simpleGraph.max_vertex + j]);
                }
            }
        }
    }
}