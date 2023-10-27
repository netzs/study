using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class NativeDictionary<T>
    {
        public int size;
        public string[] slots;
        public T[] values;

        private const int P1 = 514229;
        private const int P2 = 9369319;

        public int step = 3;

        public NativeDictionary(int sz)
        {
            size = sz;
            slots = new string[size];
            values = new T[size];
        }

        public int HashFun(string key)
        {
            long sum = 0;
            for (var index = 0; index < key.Length; index++)
            {
                char symbol = key[index];
                sum = (sum + P1 * symbol + P2 * index) % size;
            }

            return (int) sum;
        }

        public bool IsKey(string key)
        {
            var index = FindKey(key);
            return index != -1;
        }

        public void Put(string key, T value)
        {
            var index = FindKeyOrEmpty(key);
            if (slots[index] == null)
            {
                slots[index] = key;
            }

            values[index] = value;
        }

        public T Get(string key)
        {
            var index = FindKey(key);

            return index == -1 ? default(T) : values[index];
        }

        private int FindKey(string value)
        {
            var startIndex = HashFun(value);
            var index = startIndex;
            do
            {
                if (slots[index] == null)
                {
                    return -1;
                }

                if (slots[index] == value)
                {
                    return index;
                }

                index = (index + step) % size;
            } while (index != startIndex);

            return -1;
        }

        private int FindKeyOrEmpty(string value)
        {
            var startIndex = HashFun(value);
            var index = startIndex;
            do
            {
                if (slots[index] == value || slots[index] == null)
                {
                    return index;
                }

                index = (index + step) % size;
            } while (index != startIndex);

            return -1;
        }
    }
}