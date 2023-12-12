using System;
using System.Collections;

namespace AlgorithmsDataStructures2
{
    public class Heap
    {
        public int[] HeapArray; // хранит неотрицательные числа-ключи
        private int _size;

        public Heap()
        {
            HeapArray = null;
        }

        public void MakeHeap(int[] a, int depth)
        {
            _size = 0;
            HeapArray = new int [(1 << (depth + 1)) - 1];
            foreach (var key in a)
            {
                Add(key);
            }
        }

        public int GetMax()
        {
            if (_size == 0)
            {
                return -1;
            }

            _size--;
            var maxValue = HeapArray[0];
            HeapArray[0] = HeapArray[_size];
            Down(0);

            return maxValue;
        }

        private void Down(int index)
        {
            var maxIndex = GetMaxIndex(index);
            if (maxIndex != index)
            {
                Swap(index, maxIndex);
                Down(maxIndex);
            }
        }

        private int GetMaxIndex(int index)
        {
            int leftIndex = index * 2 + 1;
            int rightIndex = index * 2 + 2;

            if (rightIndex < _size && HeapArray[leftIndex] < HeapArray[rightIndex] && HeapArray[index] < HeapArray[rightIndex])
            {
                return rightIndex;
            }

            if (leftIndex < _size && HeapArray[index] < HeapArray[leftIndex])
            {
                return leftIndex;
            }

            return index;
        }

        private void Swap(int index1, int index2)
        {
            (HeapArray[index1], HeapArray[index2]) = (HeapArray[index2], HeapArray[index1]);
        }

        public bool Add(int key)
        {
            if (_size == HeapArray.Length)
            {
                return false;
            }

            HeapArray[_size] = key;
            Up(_size);
            _size++;

            return true;
        }

        private void Up(int index)
        {
            if (index == 0)
            {
                return;
            }

            var parentIndex = (index - 1) / 2;
            if (HeapArray[parentIndex] < HeapArray[index])
            {
                Swap(parentIndex, index);
                Up(parentIndex);
            }
        }
    }
}