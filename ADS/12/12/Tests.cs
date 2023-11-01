using System;
using System.Diagnostics;
using AlgorithmsDataStructures;
using NUnit.Framework;

namespace _12
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Test0()
        {
            var cache = new NativeCache<int>(2);
            cache.Put("a", 1);
            cache.Put("b", 2);
            cache.Get("b");
            cache.Get("b");
            cache.Get("a");
            cache.Put("c", 3);
            Assert.False(cache.IsKey("a"));
            Assert.True(cache.Get("b") == 2);
            Assert.True(cache.Get("c") == 3);
            Assert.True(cache.Get("c") == 3);
            Assert.True(cache.Get("c") == 3);
            Assert.True(cache.Get("c") == 3);
            cache.Put("d", 4);
            cache.Put("c", 3);
            Assert.False(cache.IsKey("b"));
            Assert.True(cache.IsKey("c"));
            Assert.True(cache.IsKey("d"));
        }

        [Test]
        public void Test2()
        {
            var cache = new NativeCache<int>(1);
            cache.Put("a", 1);
            Assert.True(cache.hits[0] == 0);
            cache.IsKey("a");
            Assert.True(cache.hits[0] == 0);
            cache.Get("a");
            Assert.True(cache.hits[0] == 1);
        }

        [Test]
        public void Test3()
        {
            var cache = new NativeCache<int>(3);
            for (var i = 0; i < 3; i++)
            {
                cache.Put(i.ToString(), i);
            }

            for (var i = 0; i < 3; i++)
            {
                for (var j = i; j < 3; j++)
                {
                    cache.Get(i.ToString());
                }
            }

            cache.Put("4", 4);
            Assert.True(cache.IsKey("4"));
            Assert.False(cache.IsKey("3"));
        }

    }
}