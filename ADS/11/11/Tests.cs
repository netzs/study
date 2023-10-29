using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using AlgorithmsDataStructures;
using NUnit.Framework;

namespace _11
{
    [TestFixture]
    public class Tests
    {
        private string[] _data = new[]
        {
            "0123456789",
            "1234567890",
            "2345678901",
            "3456789012",
            "4567890123",
            "5678901234",
            "6789012345",
            "7890123456",
            "8901234567",
            "9012345678",
        };
        
        [Test]
        public void TestHash()
        {
            var blum = new BloomFilter(128);
            for (int i = 0; i < 1000000; i++)
            {
                Assert.True(blum.Hash1(GetRandom()) < 128);
                Assert.True(blum.Hash2(GetRandom()) < 128);
            }
        }

        [Test]
        public void Test1()
        {
            var blum = new BloomFilter(32);
            blum.Add(_data[0]);
            Assert.True(blum.IsValue(_data[0]));
            for (int i = 1; i < 10; i++)
            {
                blum.Add(_data[i]);
                Assert.True(blum.IsValue(_data[i]));
            }
        }

        [Test]
        public void Test2()
        {
            var blum = new BloomFilter(29);
            var list = new List<string>();
            for (int i = 0; i < 10; i++)
            {
                var str = GetRandom();
                list.Add(str);
                blum.Add(str);
                Assert.True(blum.IsValue(str));
            }

            foreach (var str in list)
            {
                Assert.True(blum.IsValue(str));
            }

            var count = 0;
            var testCount = 100000;
            for (int i = 0; i < testCount; i++)
            {
                count += blum.IsValue(GetRandom()) ? 1 : 0;
            }

            Assert.True(count < testCount * 35 / 100);
        }

        private Random _random = new Random();

        private string GetRandom()
        {
            StringBuilder s = new StringBuilder();
            for (var i = 0; i < 20; i++)
            {
                s.Append((char) ((_random.Next() % 26) + 'a'));
            }

            return s.ToString();
        }
    }
}