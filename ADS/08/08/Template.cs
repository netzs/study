using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class HashTable
    {
        public int size;
        public int step;
        public string[] slots;

        private const int P1 = 514229;
        private const int P2 = 9369319;

        public HashTable(int sz, int stp)
        {
            size = sz;
            step = stp;
            slots = new string[size];
            for (int i = 0; i < size; i++) slots[i] = null;
        }

        public int HashFun(string value)
        {
            long sum = 0;
            for (var index = 0; index < value.Length; index++)
            {
                char symbol = value[index];
                sum = (sum + P1 * symbol + P2 * index) % size;
            }

            return (int) sum;
        }

        public int SeekSlot(string value)
        {
            var startIndex = HashFun(value);
            var index = startIndex;
            do
            {
                if (slots[index] == null)
                {
                    return index;
                }

                index = (index + step) % size;
            } while (index != startIndex);

            return -1;
        }

        public int Put(string value)
        {
            var index = SeekSlot(value);
            if (index != -1)
            {
                slots[index] = value;
            }

            return index;
        }

        public int Find(string value)
        {
            var startIndex = HashFun(value);
            var index = startIndex;
            do
            {
                if (slots[index] == value)
                {
                    return index;
                }

                index = (index + step) % size;
            } while (index != startIndex);

            return -1;
        }
    }
}