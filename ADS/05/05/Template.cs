using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class Queue<T>
    {
        private readonly LinkedList<T> _list = new LinkedList<T>();

        public Queue()
        {
        }

        public void Enqueue(T item)
        {
            _list.AddLast(item);
        }

        public T Dequeue()
        {
            if (_list.Count > 0)
            {
                var first = _list.First;
                _list.RemoveFirst();
                return first.Value;
            }

            return default(T);
        }

        public int Size()
        {
            return _list.Count;
        }
    }
}