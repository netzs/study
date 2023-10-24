using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class DynArray<T>
    {
        public T [] array;
        public int count;
        public int capacity;

        public DynArray()
        {
            count = 0;
            MakeArray(16);
        }

        public void MakeArray(int new_capacity)
        {
            new_capacity = Math.Max(16, new_capacity);
            var newArray = new T[new_capacity];
            if (array != null)
            {
                Array.Copy(array, newArray, count);
            }

            array = newArray;
            capacity = new_capacity;
        }

        public T GetItem(int index)
        {
            CheckIndex(index);

            return array[index];
        }

        public void Append(T itm)
        {
            if (count == capacity)
            {
                IncreaseLen();
            }

            array[count] = itm;
            count++;
        }

        public void Insert(T itm, int index)
        {
            if (index != count)
            {
                CheckIndex(index);
            }

            if (count == capacity)
            {
                IncreaseLen();
            }
            
            Array.Copy(array, index, array, index + 1, count - index);
            array[index] = itm;
            count++;
        }

        public void Remove(int index)
        {
            CheckIndex(index);
            Array.Copy(array, index + 1, array, index, count - index - 1);
            count--;

            var half = capacity % 2 == 0 ? capacity / 2 : capacity / 2 + 1;
            if (count < half)
            {
                DecreaseLen();
            }
        }

        private void CheckIndex(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException();
            }
        }

        private void IncreaseLen()
        {
            var newLen = capacity * 2;
            MakeArray(newLen);
        }
        
        private void DecreaseLen()
        {
            var newLen = (int)(capacity / 1.5f);
            MakeArray(newLen);
        }
    }
}
