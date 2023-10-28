using System;
using System.Diagnostics;
using System.Text;
using AlgorithmsDataStructures;
using NUnit.Framework;

namespace _10
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void TestCount0()
        {
            var set = new PowerSet<int>();
            Assert.True(set.Size() == 0);
            set.Put(1);
            Assert.True(set.Size() == 1);
            set.Put(1);
            Assert.True(set.Size() == 1);
            set.Put(2);
            Assert.True(set.Size() == 2);
            set.Put(3);
            Assert.True(set.Size() == 3);
        }

        [Test]
        public void TestCount1()
        {
            var set = new PowerSet<int>();
            for (int i = 0; i < 2000; i++)
            {
                set.Put(i);
            }

            Assert.True(set.Size() == 2000);
            for (int i = 0; i < 2000; i++)
            {
                Assert.True(set.Remove(i));
                Assert.False(set.Remove(i));
            }

            Assert.True(set.Size() == 0);
        }

        [Test]
        public void TestPutGet()
        {
            var set = new PowerSet<int>();
            for (int i = 0; i < 2000; i++)
            {
                set.Put(i);
                Assert.True(set.Get(i));
                Assert.False(set.Get(i + 1));
            }

            Assert.True(set.Size() == 2000);
            for (int i = 0; i < 2000; i++)
            {
                set.Remove(i);
            }

            for (int i = 0; i < 2000; i++)
            {
                Assert.False(set.Get(i));
            }
        }

        [Test]
        public void TestUnion0()
        {
            var set1 = new PowerSet<int>();
            var set2 = new PowerSet<int>();
            for (int i = 0; i < 1000; i++)
            {
                set1.Put(i);
            }

            for (int i = 500; i < 1500; i++)
            {
                set2.Put(i);
            }

            var union = set1.Union(set2);

            for (int i = 0; i < 1500; i++)
            {
                Assert.True(union.Get(i));
            }

            Assert.True(union.Size() == 1500);
        }

        [Test]
        public void TestUnion1()
        {
            var set1 = new PowerSet<string>();
            var set2 = new PowerSet<string>();
            set1.Put("a");
            set1.Put("b");
            set2.Put("b");
            set2.Put("c");

            var union = set1.Union(set2);

            Assert.True(union.Size() == 3);
            Assert.True(union.Get("a"));
            Assert.True(union.Get("b"));
            Assert.True(union.Get("c"));
        }

        [Test]
        public void TestSubset()
        {
            var set1 = new PowerSet<int>();
            var set2 = new PowerSet<int>();
            for (int i = 0; i < 1000; i++)
            {
                set1.Put(i);
            }

            for (int i = 500; i < 1000; i++)
            {
                set2.Put(i);
            }

            Assert.True(set1.IsSubset(set2));
            set2.Put(2000);
            Assert.False(set1.IsSubset(set2));
            set1.Put(2000);
            Assert.True(set1.IsSubset(set2));
            set1.Remove(2000);
            Assert.False(set1.IsSubset(set2));
        }
        
        [Test]
        public void TestIntersection()
        {
            var set1 = new PowerSet<int>();
            var set2 = new PowerSet<int>();
            for (int i = 0; i < 1000; i++)
            {
                set1.Put(i);
            }

            for (int i = 500; i < 1500; i++)
            {
                set2.Put(i);
            }

            var intersection = set1.Intersection(set2);
            for (int i = 500; i < 1000; i++)
            {
                Assert.True(intersection.Get(i));
            }

            Assert.True(intersection.Size() == 500);
        }
        
        [Test]
        public void TestDifference()
        {
            var set1 = new PowerSet<int>();
            var set2 = new PowerSet<int>();
            for (int i = 0; i < 10000; i++)
            {
                set1.Put(i);
            }

            for (int i = 5000; i < 15000; i++)
            {
                set2.Put(i);
            }

            var intersection = set1.Difference(set2);
            for (int i = 0; i < 5000; i++)
            {
                Assert.True(intersection.Get(i));
            }

            Assert.True(intersection.Size() == 5000);
        }

        [Test]
        public void TestSpeed()
        {
            var set1 = new PowerSet<string>();
            var set2 = new PowerSet<string>();

            for (int i = 0; i < 10000; i++)
            {
                set1.Put(GetRandom());
                set2.Put(GetRandom());
                set1.Remove(GetRandom());
                set2.Remove(GetRandom());
            }

            Assert.False(set1.IsSubset(set2));
            Assert.False(set1.Difference(set2).Size() < 0);
            Assert.False(set1.Intersection(set2).Size() < 0);
            Assert.True(set1.Union(set2).Size() <= set1.Size() + set2.Size());

        }

        [Test]
        public void TestLimit()
        {
            var set = new PowerSet<int>();
            for (var i = 0; i < 100; i++)
            {
                for (int j = 0; j < 20000; j++)
                {
                    set.Put(j);
                }
                for (int j = 0; j < 20000; j++)
                {
                    set.Remove(j);
                }
            }
            
        }

        private Random _random = new Random();

        private string GetRandom()
        {
            StringBuilder s = new StringBuilder();
            for (var i = 0; i < 200; i++)
            {
                s.Append((char)((_random.Next() % 26) + 'a'));
            }

            return s.ToString();
        }
    }
}