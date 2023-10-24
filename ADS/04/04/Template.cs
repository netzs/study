using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class Stack<T>
    {
        private readonly LinkedList<T> _stack = new LinkedList<T>();
        public Stack()
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
                var last = _stack.Last;
                _stack.RemoveLast();
                return last.Value;
            }

            return default(T);
        }
	  
        public void Push(T val)
        {
            _stack.AddLast(val);
        }

        public T Peek()
        {
            return _stack.Count > 0 ? _stack.Last.Value : default(T); 
        }
    }
}