using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

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