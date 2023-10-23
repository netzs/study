using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class Node
    {
        public int value;
        public Node next, prev;

        public Node(int _value)
        {
            value = _value;
            next = null;
            prev = null;
        }
    }

    public class LinkedList2
    {
        public Node head;
        public Node tail;

        public LinkedList2()
        {
            head = null;
            tail = null;
        }

        public void AddInTail(Node _item)
        {
            if (head == null)
            {
                head = _item;
                head.next = null;
                head.prev = null;
            }
            else
            {
                tail.next = _item;
                _item.prev = tail;
            }

            tail = _item;
        }

        public Node Find(int _value)
        {
            var node = head;
            while (node != null)
            {
                if (node.value == _value)
                {
                    return node;
                }

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
            while (node != null)
            {
                if (node.value == _value)
                {
                    RemoveNode(node);
                    return true;
                }

                node = node.next;
            }

            return false; 
        }

        private void RemoveNode(Node node)
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

        public void RemoveAll(int _value)
        {
            var node = head;
            while (node != null)
            {
                if (node.value == _value)
                {
                    RemoveNode(node);
                }

                node = node.next;
            }
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
                    head = _nodeToInsert;
                }
                else
                {
                    _nodeToInsert.next = head;
                    head.prev = _nodeToInsert;
                    head = _nodeToInsert;
                }
            }
            else
            {
                _nodeToInsert.next = _nodeAfter.next;
                _nodeAfter.next = _nodeToInsert;
                _nodeToInsert.prev = _nodeAfter;
                if (_nodeToInsert.next == null)
                {
                    tail = _nodeToInsert;
                }
                else
                {
                    _nodeToInsert.next.prev = _nodeToInsert;
                }
            }
        }
    }
}