using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class aBST
    {
        public int?[] Tree; // массив ключей

        public aBST(int depth)
        {
            int tree_size = Math.Max((1 << depth) - 1, 0);
            Tree = new int?[tree_size];
            for (int i = 0; i < tree_size; i++) Tree[i] = null;
        }

        public int? FindKeyIndex(int key)
        {
            int index = 0;
            while (index < Tree.Length && Tree[index].HasValue)
            {
                if (key == Tree[index].Value)
                {
                    return index;
                }

                if (key < Tree[index].Value)
                {
                    index = 2 * index + 1;
                }
                else
                {
                    index = 2 * index + 2;
                }
            }

            if (index >= Tree.Length)
            {
                return null;
            }

            return -index;
        }

        public int AddKey(int key)
        {
            var index = FindKeyIndex(key);
            if (index == null)
            {
                return -1;
            }

            Tree[Math.Abs(index.Value)] = key;
            return Math.Abs(index.Value);
        }
    }
}