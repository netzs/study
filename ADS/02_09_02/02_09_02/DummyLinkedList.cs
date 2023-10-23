using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class Node
    {
        public int value;
        public Node next => _next is DummyNode ? null : _next;
        public Node prev => _prev is DummyNode ? null : _prev;
        
        public Node _next, _prev;

        public Node(int _value)
        {
            value = _value;
            _next = null;
            _prev = null;
        }
    }
    
    public class DummyNode : Node
    {
        public DummyNode() : base(-1)
        {
        }
    }

    public class LinkedList2
    {
        public Node head => IsEmpty() ? null : _dummy._next;
        public Node tail => IsEmpty() ? null : _dummy._prev;

        private bool IsEmpty()
        {
            return _dummy._next == _dummy;
        }
        
        private readonly DummyNode _dummy = new DummyNode();

        public LinkedList2()
        {
            _dummy._next = _dummy;
            _dummy._prev = _dummy;
        }

        public void AddInTail(Node _item)
        {
            var prev = _dummy._prev;
            prev._next = _item;
            _item._next = _dummy;
            _item._prev = prev;
            _dummy._prev = _item;
        }

        public Node Find(int _value)
        {
            var node = _dummy._next;
            while (node != _dummy)
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
            var node = _dummy._next;
            while (node != _dummy)
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
            var node = _dummy._next;
            while (node != _dummy)
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
            var node = _dummy._next;
            while (node != _dummy)
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
            _dummy._prev = _dummy;
            _dummy._next = _dummy;
        }

        public int Count()
        {
            var node = _dummy._next;
            var count = 0;
            while (node != _dummy)
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
                _nodeAfter = _dummy;
            }

            var nextNode = _nodeAfter._next;
            nextNode._prev = _nodeToInsert;
            _nodeAfter._next = _nodeToInsert;
            _nodeToInsert._next = nextNode;
            _nodeToInsert._prev = _nodeAfter;
        }
    }
}
