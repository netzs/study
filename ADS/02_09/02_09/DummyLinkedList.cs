using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class Node
    {
        public int value;
        public Node next => _next == null || _next.isDummy ? null : _next;
        public Node prev => _prev == null || _prev.isDummy ? null : _prev;
        
        public bool isDummy;
        
        public Node _next, _prev;

        public Node(int _value)
        {
            value = _value;
            _next = null;
            _prev = null;
            isDummy = false;
        }

        public Node()
        {
            _next = null;
            _prev = null;
            isDummy = true;
        }
    }

    public class LinkedList2
    {
        public Node head => _head._next != _tail ? _head._next : null;
        public Node tail => _head._next != _tail ? _tail._prev : null;
        
        public Node _head;
        public Node _tail;

        public LinkedList2()
        {
            _head = new Node();
            _tail = new Node();
            _head._next = _tail;
            _tail._prev = _head;
        }

        public void AddInTail(Node _item)
        {
            var _prev = _tail._prev;
            _prev._next = _item;
            _item._next = _tail;
            _item._prev = _prev;
            _tail._prev = _item;
        }

        public Node Find(int _value)
        {
            var node = _head._next;
            while (node != _tail)
            {
                if (node.value == _value)
                {
                    return node;
                }

                node = node._next;
            }

            return null;
        }

        public List<Node> FindAll(int _value)
        {
            List<Node> nodes = new List<Node>();
            var node = _head._next;
            while (node != _tail)
            {
                if (node.value == _value)
                {
                    nodes.Add(node);
                }

                node = node._next;
            }

            return nodes;
        }

        public bool Remove(int _value)
        {
            var node = _head._next;
            while (node != _tail)
            {
                if (node.value == _value)
                {
                    RemoveNode(node);
                    return true;
                }

                node = node._next;
            }

            return false; 
        }

        private void RemoveNode(Node node)
        {
            node._prev._next = node._next;
            node._next._prev = node._prev;
        }

        public void RemoveAll(int _value)
        {
            var node = _head._next;
            while (node != _tail)
            {
                if (node.value == _value)
                {
                    RemoveNode(node);
                }

                node = node._next;
            }
        }

        public void Clear()
        {
            _tail._prev = _head;
            _head._next = _tail;
        }

        public int Count()
        {
            var node = _head._next;
            var count = 0;
            while (node != _tail)
            {
                node = node._next;
                count++;
            }

            return count;
        }

        public void InsertAfter(Node _nodeAfter, Node _nodeToInsert)
        {
            if (_nodeAfter == null)
            {
                _nodeAfter = _head;
            }

            var nextNode = _nodeAfter._next;
            nextNode._prev = _nodeToInsert;
            _nodeAfter._next = _nodeToInsert;
            _nodeToInsert._next = nextNode;
            _nodeToInsert._prev = _nodeAfter;
        }
    }
}
