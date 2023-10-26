using System.Collections.Generic;
using AlgorithmsDataStructures;
using NUnit.Framework;

namespace _08
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Test1()
        {
            var hash = new HashTable(17, 3);
            Assert.True(hash.SeekSlot("123") >= 0 && hash.SeekSlot("123") < 17);
            var k = hash.Put("a11");
            var k1 = hash.Put("a11");
            var k2 = hash.Put("a11");
            var k3 = hash.Put("a11");
            Assert.True(k != k1 && k1 != k2 && k2 != k3 && k3 != k && k != k2);
        }

        [Test]
        public void Test2()
        {
            var hash = new HashTable(17, 3);
            var set = new HashSet<int>();
            for (int i = 0; i < 17; i++)
            {
                var k = hash.Put("a11");
                set.Add(k);
                Assert.True(k != -1 && k < 17);
            }

            Assert.True(set.Count == 17);

            Assert.True(hash.Put("a11") == -1);
            Assert.True(hash.Put("a") == -1);
        }

        [Test]
        public void Test3()
        {
            var hash = new HashTable(17, 3);
            for (int i = 0; i < 17; i++)
            {
                var k = hash.Put(i.ToString());
                Assert.True(k != -1 && k < 17);
            }

            for (int i = 0; i < 17; i++)
            {
                var k = hash.Put(i.ToString());
                Assert.True(k == -1);
            }

            var set = new HashSet<int>();
            for (int i = 0; i < 17; i++)
            {
                var k = hash.Find(i.ToString());
                Assert.True(k != -1 && k < 17);
                set.Add(k);
            }

            Assert.True(hash.Find("18") == -1);

            Assert.True(set.Count == 17);
        }

        [Test]
        public void Test4()
        {
            var hash = new HashTable(123123, 123122);
            for (int i = 0; i < 100000; i++)
            {
                var k = hash.Put(i.ToString());
                Assert.True(k != -1 && k < 123123);
            }
        }
        
        [Test]
        public void Test5()
        {
            var hash = new HashTable(17, 3);
            var text0 = "";
            var text1 = "b";
            var text2 = "c";
            var a0 = hash.Put(text0);
            var a1 = hash.Put(text1);
            var a2 = hash.Put(text2);
            Assert.True(hash.Find(text0) == a0);
            Assert.True(hash.Find(text1) == a1);
            Assert.True(hash.Find(text2) == a2);
        }
    }
}