using System.Collections.Generic;
using System;
using System.IO;

namespace AlgorithmsDataStructures
{
    public class BloomFilter
    {
        public int filter_len;
        private int data;

        public BloomFilter(int f_len)
        {
            filter_len = f_len;
        }

        public int Hash1(string str1)
        {
            return Hash(str1, 17);
        }

        public int Hash2(string str1)
        {
            return Hash(str1, 223);
        }

        private int Hash(string str, int random)
        {
            var result = 0;
            for (int i = 0; i < str.Length; i++)
            {
                int code = str[i];
                result = (result * random + code) % filter_len;
            }

            return result;
        }

        public void Add(string str1)
        {
            AddBit(Hash1(str1));
            AddBit(Hash2(str1));
        }

        private void AddBit(int index)
        {
            data |= 1 << (index % 32);
        }
        
        private bool GetBit(int index)
        {
            return (data & (1 << (index % 32))) != 0;
        }

        public bool IsValue(string str1)
        {
            return GetBit(Hash1(str1)) && GetBit(Hash2(str1));
        }
    }
}