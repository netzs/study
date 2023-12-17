using System;
using System.Collections.Generic;
using AlgorithmsDataStructures2;
using NUnit.Framework;

namespace _12
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

            PathCheck(t.DepthFirstSearch(4, 0), new int[] { });
            PathCheck(t.DepthFirstSearch(0, 0), new int[] {0});
            t.AddEdge(0, 1);
            t.AddEdge(1, 2);
            t.AddEdge(2, 3);
            t.AddEdge(3, 4);
            t.AddEdge(4, 5);
            PathCheck(t.DepthFirstSearch(0, 5), new[] {0, 1, 2, 3, 4, 5});
            t.AddEdge(0, 1);
            t.AddEdge(0, 2);
            t.AddEdge(0, 3);
            t.AddEdge(0, 4);
            t.AddEdge(4, 5);
            PathCheck(t.DepthFirstSearch(0, 5), new[] {0, 1, 2, 3, 4, 5});
            t.AddEdge(1, 5);
            PathCheck(t.DepthFirstSearch(0, 5), new[] {0, 1, 5});
            PathCheck(t.DepthFirstSearch(5, 0), new[] {5, 1, 0});
            t.AddEdge(6, 7);
            t.AddEdge(6, 8);
            t.AddEdge(6, 9);
            PathCheck(t.DepthFirstSearch(6, 0), new int[] { });
            t.AddEdge(6, 5);
            PathCheck(t.DepthFirstSearch(9, 0), new int[] {9, 6, 5, 1, 0});
        }

        [Test]
        public void TestBFS()
        {
            var t = new SimpleGraph<int>(10);
            for (var i = 0; i < 10; i++)
            {
                t.AddVertex(i);
            }

            PathCheck(t.BreadthFirstSearch(4, 0), new int[] { });
            PathCheck(t.BreadthFirstSearch(0, 0), new int[] {0});
            t.AddEdge(0, 1);
            t.AddEdge(1, 2);
            t.AddEdge(2, 3);
            t.AddEdge(3, 4);
            t.AddEdge(4, 5);
            PathCheck(t.BreadthFirstSearch(0, 5), new[] {0, 1, 2, 3, 4, 5});
            t.AddEdge(0, 1);
            t.AddEdge(0, 2);
            t.AddEdge(0, 3);
            t.AddEdge(0, 4);
            t.AddEdge(4, 5);
            PathCheck(t.BreadthFirstSearch(0, 5), new[] {0, 4, 5});
            t.AddEdge(1, 5);
            PathCheck(t.BreadthFirstSearch(0, 5), new[] {0, 1, 5});
            PathCheck(t.BreadthFirstSearch(5, 0), new[] {5, 1, 0});
            t.AddEdge(6, 7);
            t.AddEdge(6, 8);
            t.AddEdge(6, 9);
            PathCheck(t.BreadthFirstSearch(6, 0), new int[] { });
            t.AddEdge(6, 5);
            PathCheck(t.BreadthFirstSearch(9, 0), new int[] {9, 6, 5, 1, 0});
        }

        [Test]
        public void TestBFS2()
        {
            var t = new SimpleGraph<int>(100);
            for (var i = 0; i < 100; i++)
            {
                t.AddVertex(i);
            }

            t.AddEdge(0, 1);
            t.AddEdge(0, 2);
            t.AddEdge(0, 3);
            t.AddEdge(1, 4);
            t.AddEdge(1, 5);
            t.AddEdge(1, 6);
            t.AddEdge(2, 7);
            t.AddEdge(2, 8);
            t.AddEdge(2, 9);
            t.AddEdge(3, 10);
            t.AddEdge(3, 11);
            t.AddEdge(3, 12);
            t.AddEdge(4, 13);
            t.AddEdge(4, 14);
            t.AddEdge(4, 15);
            PathCheck(t.BreadthFirstSearch(0, 15), new int[] {0, 1, 4, 15});
            PathCheck(t.BreadthFirstSearch(15, 0), new int[] {15, 4, 1, 0});
            PathCheck(t.BreadthFirstSearch(15, 12), new int[] {15, 4, 1, 0, 3, 12});
            t.AddEdge(1, 15);
            PathCheck(t.BreadthFirstSearch(0, 15), new int[] {0, 1, 15});
            PathCheck(t.BreadthFirstSearch(15, 12), new int[] {15, 1, 0, 3, 12});
            PathCheck(t.BreadthFirstSearch(12, 15), new int[] {12, 3, 0, 1, 15});
            t.AddEdge(3, 1);
            PathCheck(t.BreadthFirstSearch(12, 15), new int[] {12, 3, 1, 15});
            PathCheck(t.BreadthFirstSearch(15, 12), new int[] {15, 1, 3, 12});
        }

        private void PathCheck(List<Vertex<int>> searchResult, int[] ints)
        {
            Assert.True(searchResult.Count == ints.Length);
            for (int i = 0; i < searchResult.Count; i++)
            {
                Assert.True(searchResult[i].Value == ints[i]);
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

        [Test]
        public void TestWeak()
        {
            var t = new SimpleGraph<int>(10);
            for (var i = 0; i < 10; i++)
            {
                t.AddVertex(i);
            }

            PathCheck(t.WeakVertices(), new[] {0, 1, 2, 3, 4, 5, 6, 7, 8, 9});
            t.AddEdge(0,1);
            t.AddEdge(0,2);
            PathCheck(t.WeakVertices(), new[] {0, 1, 2, 3, 4, 5, 6, 7, 8, 9});
            t.AddEdge(1,2);
            PathCheck(t.WeakVertices(), new[] { 3, 4, 5, 6, 7, 8, 9});
            t.AddEdge(2,3);
            t.AddEdge(2,4);
            t.AddEdge(2,5);
            t.AddEdge(2,6);
            t.AddEdge(2,7);
            t.AddEdge(2,8);
            t.AddEdge(2,9);
            PathCheck(t.WeakVertices(), new[] { 3, 4, 5, 6, 7, 8, 9});
            t.AddEdge(3,4);
            PathCheck(t.WeakVertices(), new[] { 5, 6, 7, 8, 9});
            t.AddEdge(5,6);
            t.AddEdge(7,6);
            PathCheck(t.WeakVertices(), new[] { 8, 9});
            t.RemoveEdge(1,2);
            PathCheck(t.WeakVertices(), new[] { 0,1,8, 9});
            t.AddEdge(0,9);
            PathCheck(t.WeakVertices(), new[] { 1,8});
        }
        [Test]
        public void TestWeak2()
        {
            var t = new SimpleGraph<int>(10);
            for (var i = 0; i < 10; i++)
            {
                t.AddVertex(i);
            }

            PathCheck(t.WeakVertices(), new[] {0, 1, 2, 3, 4, 5, 6, 7, 8, 9});
            t.AddEdge(0,1);
            t.AddEdge(1,2);
            t.AddEdge(2,0);
            t.AddEdge(3,4);
            t.AddEdge(4,5);
            t.AddEdge(5,3);
            t.AddEdge(6,7);
            t.AddEdge(7,8);
            t.AddEdge(8,6);
            PathCheck(t.WeakVertices(), new int [] {9});
            t.AddEdge(8,9);
            t.AddEdge(1,9);
            t.AddEdge(4,9);
            PathCheck(t.WeakVertices(), new int [] {9});
        }
        
        [Test]
        public void TestWeak3()
        {
            var t = new SimpleGraph<int>(9);
            for (var i = 0; i < 9; i++)
            {
                t.AddVertex(i);
            }
            
            t.AddEdge(0,1);
            t.AddEdge(0,2);
            t.AddEdge(0,3);
            t.AddEdge(1,5);
            t.AddEdge(2,4);
            t.AddEdge(2,3);
            t.AddEdge(3,4);
            t.AddEdge(3,5);
            t.AddEdge(5,8);
            t.AddEdge(5,7);
            t.AddEdge(8,7);
            t.AddEdge(6,7);
            t.AddEdge(6,4);
            t.AddEdge(6,1);

            PathCheck(t.WeakVertices(), new int [] {1,6});
        }
    }
}