using System;
using System.Linq;

namespace AlgorithmsDataStructures
{
    public class NativeCache<T>
    {
        public int size;
        public String[] slots;
        public T[] values;
        public int[] hits;

        public NativeCache(int sz)
        {
            size = sz;
            slots = new string[size];
            values = new T[size];
            hits = new int[size];
        }

        private const int P1 = 514229;
        private const int P2 = 9369319;

        public int step = 1;

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
            if (index == -1)
            {
                index = GetReleaseSlotIndex();
            }
            slots[index] = key;
            values[index] = value;
            hits[index] = 0;
        }

        private int GetReleaseSlotIndex()
        {
            var minIndex = 0;
            var minValue = hits[minIndex];
            for (var index = 0; index < hits.Length; index++)
            {
                if (hits[index] < minValue)
                {
                    minIndex = index;
                    minValue = hits[index];
                }
            }

            return minIndex;
        }

        public T Get(string key)
        {
            var index = FindKey(key);
            if (index == -1)
            {
                return default;
            }

            hits[index]++;
            return values[index];
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