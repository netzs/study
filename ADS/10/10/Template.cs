using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class PowerSet<T>
    {
        private const int MaxSize = 20201;

        public readonly Slot<T>[] Data = new Slot<T>[MaxSize];
        public readonly int[] UseIndexes = new int[MaxSize];
        public int UseIndexCount = 0;

        private int _count = 0;

        private const int P1 = 514229;
        private const int P2 = 9369319;
        private const int step = 13;

        public PowerSet()
        {
        }

        public int Size()
        {
            return _count;
        }

        public void Put(T value)
        {
            int index = FindKeyOrEmpty(value);
            Slot<T> slot = Data[index];
            if (slot == null)
            {
                _count++;
                AddUsedIndex(index);
                slot = new Slot<T>();
                Data[index] = slot;
            }
            else if (slot.isRemoved)
            {
                _count++;
            }

            slot.value = value;
            slot.isRemoved = false;
        }

        private void AddUsedIndex(int index)
        {
            UseIndexes[UseIndexCount] = index;
            UseIndexCount++;
        }

        public bool Get(T value)
        {
            return FindKey(value) != -1;
        }

        public bool Remove(T value)
        {
            int index = FindKey(value);
            if (index == -1)
            {
                return false;
            }

            var slot = Data[index];
            slot.isRemoved = true;
            slot.value = default;
            _count--;
            return true;
        }

        public PowerSet<T> Intersection(PowerSet<T> set2)
        {
            PowerSet<T> intersectionSet = new PowerSet<T>();
            for (var i = 0; i < set2.UseIndexCount; i++)
            {
                var index = set2.UseIndexes[i];
                var slot = set2.Data[index];
                if (!slot.isRemoved && FindKey(slot.value) != -1)
                {
                    intersectionSet.Put(slot.value);
                }
            }

            return intersectionSet;
        }

        public PowerSet<T> Union(PowerSet<T> set2)
        {
            PowerSet<T> unionSet = new PowerSet<T>();
            AddSetToSet(this, unionSet);
            AddSetToSet(set2, unionSet);

            return unionSet;
        }

        private static void AddSetToSet(PowerSet<T> from, PowerSet<T> to)
        {
            for (var i = 0; i < from.UseIndexCount; i++)
            {
                var index = from.UseIndexes[i];
                var slot = from.Data[index];
                if (!slot.isRemoved)
                {
                    to.Put(slot.value);
                }
            }
        }

        public PowerSet<T> Difference(PowerSet<T> set2)
        {
            PowerSet<T> differenceSet = new PowerSet<T>();
            for (var i = 0; i < UseIndexCount; i++)
            {
                var index = UseIndexes[i];
                var slot = Data[index];
                if (!slot.isRemoved && set2.FindKey(slot.value) == -1)
                {
                    differenceSet.Put(slot.value);
                }
            }

            return differenceSet;
        }

        public bool IsSubset(PowerSet<T> set2)
        {
            for (var i = 0; i < set2.UseIndexCount; i++)
            {
                var index = set2.UseIndexes[i];
                var slot = set2.Data[index];
                if (!slot.isRemoved && FindKey(slot.value) == -1)
                {
                    return false;
                }
            }

            return true;
        }

        private int FindKeyOrEmpty(T value)
        {
            var startIndex = HashFun(value);
            var index = startIndex;
            do
            {
                var slot = Data[index];
                if (slot == null || slot.isRemoved || Compare(slot.value, value) == 0)
                {
                    return index;
                }

                index = (index + step) % MaxSize;
            } while (index != startIndex);

            return -1;
        }

        private int FindKey(T value)
        {
            var startIndex = HashFun(value);
            var index = startIndex;
            do
            {
                var slot = Data[index];

                if (slot == null)
                {
                    return -1;
                }

                if (!slot.isRemoved && Compare(slot.value, value) == 0)
                {
                    return index;
                }

                index = (index + step) % MaxSize;
            } while (index != startIndex);

            return -1;
        }

        private static int Compare(T v1, T v2)
        {
            int result = 0;
            if (typeof(T) == typeof(string))
            {
                string s1 = (v1 as string)?.Trim();
                string s2 = (v2 as string)?.Trim();
                result = Math.Sign(string.CompareOrdinal(s1, s2));
            }
            else if (v1 is IComparable cmp1 && v2 is IComparable cmp2)
            {
                result = cmp1.CompareTo(cmp2);
            }

            return result;
        }

        private static int HashFun(T key)
        {
            switch (key)
            {
                case string s:
                    return HashFunString(s);
                case int i:
                    long t = (long) i * P1 % MaxSize;
                    return (int) t;
                default:
                    return key.GetHashCode() % MaxSize;
            }
        }

        private static int HashFunString(string key)
        {
            long sum = 0;
            for (var index = 0; index < key.Length; index++)
            {
                char symbol = key[index];
                sum = (sum + P1 * symbol + P2 * index) % MaxSize;
            }

            return (int) sum;
        }
    }

    public class Slot<T>
    {
        public T value;
        public bool isRemoved;
    }
}