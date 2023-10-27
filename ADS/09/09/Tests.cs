using System;
using AlgorithmsDataStructures;
using NUnit.Framework;

namespace _09
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Test1()
        {
            var dict = new NativeDictionary<int>(17);
            dict.Put("a", 1);
            Assert.True(dict.IsKey("a"));
            Assert.True(dict.Get("a") == 1);
        }

        [Test]
        public void Test2()
        {
            var dict = new NativeDictionary<int>(27);
            for (var i = 'a'; i < 'z'; i++)
            {
                dict.Put("" + i, i);
            }

            for (var i = 'a'; i < 'z'; i++)
            {
                Assert.True(dict.Get("" + i) == i);
            }
            
            for (var i = 'a'; i < 'z'; i++)
            {
                dict.Put("" + i, i + 100);
                Assert.True(dict.IsKey("" + i));
                Assert.False(dict.IsKey("-" + i));
            }
            
            for (var i = 'a'; i < 'z'; i++)
            {
                Assert.True(dict.Get("" + i) == i + 100);
            }
        }
    }
}