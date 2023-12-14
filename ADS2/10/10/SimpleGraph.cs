using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace AlgorithmsDataStructures2
{
    public class Vertex<T>
    {
        public bool Hit;
        public T Value;

        public Vertex(T val)
        {
            Value = val;
            Hit = false;
        }
    }

    public class SimpleGraph<T>
    {
        public Vertex<T>[] vertex;
        public int[,] m_adjacency;
        public int max_vertex;

        public SimpleGraph(int size)
        {
            max_vertex = size;
            m_adjacency = new int [size, size];
            vertex = new Vertex<T> [size];
        }

        public void AddVertex(T value)
        {
            var index = GetFreeIndex();
            vertex[index] = new Vertex<T>(value);
        }

        private int GetFreeIndex()
        {
            for (int i = 0; i < max_vertex; i++)
            {
                if (vertex[i] == null)
                {
                    return i;
                }
            }

            return 0;
        }

        public void RemoveVertex(int v)
        {
            for (var i = 0; i < max_vertex; i++)
            {
                m_adjacency[v, i] = 0;
                m_adjacency[i, v] = 0;
            }

            vertex[v] = null;
        }

        public bool IsEdge(int v1, int v2)
        {
            return m_adjacency[v1, v2] == 1;
        }

        public void AddEdge(int v1, int v2)
        {
            m_adjacency[v1, v2] = 1;
            m_adjacency[v2, v1] = 1;
        }

        public void RemoveEdge(int v1, int v2)
        {
            m_adjacency[v1, v2] = 0;
            m_adjacency[v2, v1] = 0;
        }

        public List<Vertex<T>> DepthFirstSearch(int VFrom, int VTo)
        {
            Clear();

            var path = new Stack<int>();
            vertex[VFrom].Hit = true;
            path.Push(VFrom);

            while (path.Count > 0 && path.Peek() != VTo)
            {
                var x = path.Peek();
                if (IsEdge(x, VTo))
                {
                    vertex[VTo].Hit = true;
                    path.Push(VTo);
                    break;
                }

                var nextPoint = GetNextPoint(x);
                if (nextPoint == -1)
                {
                    path.Pop();
                }
                else
                {
                    vertex[nextPoint].Hit = true;
                    path.Push(nextPoint);
                }
            }

            return path.Select(item => vertex[item]).Reverse().ToList();
        }

        private void Clear()
        {
            foreach (var item in vertex)
            {
                if (item != null)
                {
                    item.Hit = false;
                }
            }
        }

        private int GetNextPoint(int x)
        {
            for (var i = 0; i < max_vertex; i++)
            {
                if (IsEdge(x, i) && !vertex[i].Hit)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}