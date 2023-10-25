using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    class Deque<T>
    {
        private readonly LinkedList<T> _list = new LinkedList<T>();
        public Deque()
        {
        }

        public void AddFront(T item)
        {
            _list.AddFirst(item);
        }

        public void AddTail(T item)
        {
            _list.AddLast(item);
        }

        public T RemoveFront()
        {
            if (_list.Count > 0)
            {
                var value = _list.First.Value;
                _list.RemoveFirst();
                return value;
            }
            return default(T);
        }

        public T RemoveTail()
        {
            if (_list.Count > 0)
            {
                var value = _list.Last.Value;
                _list.RemoveLast();
                return value;
            }
            return default(T);
        }
        
        public int Size()
        {
            return _list.Count;
        }
    }
}