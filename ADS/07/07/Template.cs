using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class Node<T>
    {
        public T value;
        public Node<T> next, prev;

        public Node(T _value)
        {
            value = _value;
            next = null;
            prev = null;
        }
    }

    public class OrderedList<T>
    {
        public Node<T> head, tail;
        private bool _ascending;

        public OrderedList(bool asc)
        {
            head = null;
            tail = null;
            _ascending = asc;
        }

        public int Compare(T v1, T v2)
        {
            int result = 0;
            if (typeof(T) == typeof(String))
            {
                string s1 = (v1 as String).Trim();
                string s2 = (v2 as String).Trim();
                result = Math.Sign(string.CompareOrdinal(s1, s2));
            }
            else if (v1 is IComparable cmp1 && v2 is IComparable cmp2)
            {
                result = cmp1.CompareTo(cmp2);
            }

            return result;
        }

        public void Add(T value)
        {
            Node<T> node = new Node<T>(value);
            if (head == null)
            {
                head = node;
                tail = head;
                return;
            }

            int compare = CompareAsc(value, head.value);
            if (compare <= 0)
            {
                node.next = head;
                head.prev = node;
                head = node;
                return;
            }

            compare = CompareAsc(tail.value, value);
            if (compare <= 0)
            {
                node.prev = tail;
                tail.next = node;
                tail = node;
                return;
            }

            Node<T> cur = head;
            while (head != null)
            {
                compare = CompareAsc(value, cur.value);
                if (compare <= 0)
                {
                    node.next = cur;
                    node.prev = cur.prev;
                    cur.prev.next = node;
                    cur.prev = node;
                    return;
                }

                cur = cur.next;
            }
        }

        public int CompareAsc(T a, T b)
        {
            return (_ascending ? 1 : -1) * Compare(a, b);
        }

        public Node<T> Find(T val)
        {
            Node<T> node = head;
            while (node != null)
            {
                int compare = CompareAsc(node.value, val);
                if (compare == 0)
                {
                    return node;
                }

                if (compare == 1)
                {
                    return null;
                }

                node = node.next;
            }

            return null;
        }

        public void Delete(T val)
        {
            var node = head;
            while (node != null)
            {
                var compare = CompareAsc(node.value, val);
                if (compare == 0)
                {
                    RemoveNode(node);
                    return;
                }

                if (compare == 1)
                {
                    return;
                }

                node = node.next;
            }
        }

        private void RemoveNode(Node<T> node)
        {
            if (node.prev == null)
            {
                head = node.next;
            }
            else
            {
                node.prev.next = node.next;
            }

            if (node == tail)
            {
                tail = node.prev;
            }
            else
            {
                node.next.prev = node.prev;
            }
        }

        public void Clear(bool asc)
        {
            _ascending = asc;
            head = null;
            tail = null;
        }

        public int Count()
        {
            Node<T> node = head;
            int count = 0;
            while (node != null)
            {
                node = node.next;
                count++;
            }

            return count;
        }

        public List<Node<T>> GetAll()
        {
            List<Node<T>> r = new List<Node<T>>();
            Node<T> node = head;
            while (node != null)
            {
                r.Add(node);
                node = node.next;
            }

            return r;
        }
    }
}