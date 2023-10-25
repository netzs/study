using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class TwoStackQueue<T>
    {
        private readonly Stack<T> _inputStack = new Stack<T>();
        private readonly Stack<T> _outputStack = new Stack<T>();

        public void Enqueue(T item)
        {
            _inputStack.Push(item);
        }

        public T Dequeue()
        {
            if (_outputStack.Count > 0)
            {
                return _outputStack.Pop();
            }

            if (_inputStack.Count == 0)
            {
                return default;
            }

            while (_inputStack.Count > 0)
            {
                _outputStack.Push(_inputStack.Pop());
            }

            return _outputStack.Pop();
        }

        public int Size()
        {
            return _inputStack.Count + _outputStack.Count;
        }
    }
}