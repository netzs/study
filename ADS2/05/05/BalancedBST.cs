using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public static class BalancedBST
    {
        public static int[] GenerateBBSTArray(int[] a)
        {
            var c = new int[a.Length];
            for (var i = 0; i < a.Length; i++)
            {
                c[i] = a[i];
            }
            Array.Sort(c);
            var result = new int[a.Length];
            if (result.Length > 0)
            {
                Round(c, result, 0, a.Length - 1, 0);
            }

            return result;
        }

        private static void Round(int[] data, int[] result, int left, int right, int index)
        {
            int center = (right + left) / 2;
            result[index] = data[center];
            if (right == left)
            {
                return;
            }
            
            Round(data, result, left, center - 1, index * 2 + 1);
            Round(data, result, center + 1, right, index * 2 + 2);
        }
    }
}