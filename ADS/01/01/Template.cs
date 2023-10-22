using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class Node
    {
        public int value;
        public Node next;
        public Node(int _value) { value = _value; }
    }

    public class LinkedList
    {
        public Node head;
        public Node tail;

        public LinkedList()
        {
            head = null;
            tail = null;
        }

        public void AddInTail(Node _item)
        {
            if (head == null) head = _item;
            else              tail.next = _item;
            tail = _item;
        }

        public Node Find(int _value)
        {
            Node node = head;
            while (node != null)
            {
                if (node.value == _value) return node;
                node = node.next;
            }
            return null;
        }

        public List<Node> FindAll(int _value)
        {
            List<Node> nodes = new List<Node>();
            var node = head;
            while (node != null)
            {
                if (node.value == _value)
                {
                    nodes.Add(node);
                }

                node = node.next;
            }

            return nodes;
        }

        public bool Remove(int _value)
        {
            var node = head;
            Node prev = null;
            while (node != null)
            {
                if (node.value == _value)
                {
                    if (prev == null)
                    {
                        head = node.next;
                    }
                    else
                    {
                        prev.next = node.next;
                    }

                    if (node == tail)
                    {
                        tail = prev;
                    }

                    return true;
                }

                prev = node;
                node = node.next;
            }

            return false;
        }

        public void RemoveAll(int _value)
        {
            var node = head;
            Node prev = null;

            while (node != null)
            {
                if (node.value == _value)
                {
                    if (node == head)
                    {
                        head = node.next;
                        node = head;
                    }
                    else
                    {
                        prev.next = node.next;
                        node = node.next;
                    }
                }
                else
                {
                    prev = node;
                    node = node.next;
                }
            }

            tail = prev;
        }

        public void Clear()
        {
            head = null;
            tail = null;
        }

        public int Count()
        {
            var node = head;
            var count = 0;
            while (node != null)
            {
                node = node.next;
                count++;
            }

            return count;
        }

        public void InsertAfter(Node _nodeAfter, Node _nodeToInsert)
        {
            if (_nodeAfter == null)
            {
                if (head == null)
                {
                    tail = _nodeToInsert;
                }

                _nodeToInsert.next = head;
                head = _nodeToInsert;
            }
            else
            {
                _nodeToInsert.next = _nodeAfter.next;
                _nodeAfter.next = _nodeToInsert;
                if (_nodeToInsert.next == null)
                {
                    tail = _nodeToInsert;
                }
            }
        }
    }
}