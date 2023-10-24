using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class HeadStack<T>
    {
        private readonly LinkedList<T> _stack = new LinkedList<T>();

        public HeadStack()
        {
        }

        public int Size()
        {
            return _stack.Count;
        }

        public T Pop()
        {
            if (_stack.Count > 0)
            {
                var first = _stack.First;
                _stack.RemoveFirst();
                return first.Value;
            }

            return default;
        }

        public void Push(T val)
        {
            _stack.AddFirst(val);
        }

        public T Peek()
        {
            return _stack.Count > 0 ? _stack.First.Value : default;
        }
    }
}