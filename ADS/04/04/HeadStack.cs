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
            var last = _stack.Last;
            _stack.RemoveLast();
            return last.Value;
        }
	  
        public void Push(T val)
        {
            _stack.AddLast(val);
        }

        public T Peek()
        {
            return _stack.Last.Value;
        }
    }
}