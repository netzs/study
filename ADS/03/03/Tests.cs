using System;
using System.Linq;
using AlgorithmsDataStructures;
using NUnit.Framework;

namespace _03
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void TestMakeArray0()
        {
            var array = new DynArray<int>();
            Assert.True(array.count == 0);
            Assert.True(array.capacity == 16);
        }

        [Test]
        public void TestMakeArray1()
        {
            var array = new DynArray<int>();
            array.MakeArray(100);
            Assert.True(array.count == 0);
            Assert.True(array.capacity == 100);
        }

        [Test]
        public void TestMakeArray2()
        {
            var array = new DynArray<int>();
            array.MakeArray(5);
            Assert.True(array.count == 0);
            Assert.True(array.capacity == 16);
            array.MakeArray(7);
            Assert.True(array.count == 0);
            Assert.True(array.capacity == 16);
            array.MakeArray(100);
            Assert.True(array.count == 0);
            Assert.True(array.capacity == 100);
            array.MakeArray(20);
            Assert.True(array.count == 0);
            Assert.True(array.capacity == 20);
        }
        
        [Test]
        public void TestMakeArray3()
        {
            var array = new DynArray<int>();
            for (var i = 0; i < 20; i++)
            {
                array.Append(i);
            }
            
            for (var i = 0; i < 4; i++)
            {
                array.Remove(0);
            }
            array.MakeArray(10);
            Assert.True(Cmp(array, new[] {4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19}));
            Assert.True(array.capacity == 16);
        }

        [Test]
        public void TestAppend0()
        {
            var array = new DynArray<int>();
            for (int i = 0; i < 100; i++)
            {
                array.Append(i);
            }

            Assert.True(array.count == 100);
            Assert.True(array.capacity == 128);

            for (int i = 0; i < 100; i++)
            {
                Assert.True(array.GetItem(i) == i);
            }
        }

        [Test]
        public void TestIndex()
        {
            var array = new DynArray<int>();
            for (int i = 0; i < 100; i++)
            {
                array.Append(i);
            }

            Assert.Throws<IndexOutOfRangeException>(() => { array.GetItem(-1); });
            Assert.Throws<IndexOutOfRangeException>(() => { array.GetItem(100); });
            Assert.Throws<IndexOutOfRangeException>(() => { array.GetItem(101); });
            Assert.True(array.GetItem(99) == 99);
        }

        [Test]
        public void TestRemove0()
        {
            var array = new DynArray<int>();
            for (var i = 0; i < 5; i++)
            {
                array.Append(i);
            }

            Assert.True(Cmp(array, new[] {0, 1, 2, 3, 4}));
            array.Remove(1);
            Assert.True(Cmp(array, new[] {0, 2, 3, 4}));
            array.Remove(1);
            Assert.True(Cmp(array, new[] {0, 3, 4}));
            array.Remove(2);
            Assert.True(Cmp(array, new[] {0, 3}));
            Assert.Throws<IndexOutOfRangeException>(() => { array.Remove(2); });
            array.Remove(0);
            Assert.True(Cmp(array, new[] {3}));
            array.Remove(0);

            Assert.True(array.count == 0 && array.capacity == 16);
        }

        [Test]
        public void TestRemove1()
        {
            var array = new DynArray<int>();
            array.MakeArray(50);
            array.Append(1);
            array.Append(2);
            array.Append(3);
            array.Remove(0);
            Assert.True(array.count == 2 && array.capacity == 33);
            array.Remove(0);
            Assert.True(array.count == 1 && array.capacity == 22);
            array.Remove(0);
            Assert.True(array.count == 0 && array.capacity == 16);
        }

        [Test]
        public void TestInsert0()
        {
            var array = new DynArray<int>();
            array.Insert(1, 0);
            Assert.True(Cmp(array, new[] {1}));
            array.Insert(2, 0);
            Assert.True(Cmp(array, new[] {2, 1}));
            array.Insert(3, 0);
            Assert.True(Cmp(array, new[] {3, 2, 1}));
            array.Insert(4, 1);
            Assert.True(Cmp(array, new[] {3, 4, 2, 1}));
            array.Insert(5, 4);
            Assert.True(Cmp(array, new[] {3, 4, 2, 1, 5}));
            Assert.True(array.count == 5);
        }
        
        [Test]
        public void TestInsert1()
        {
            var array = new DynArray<int>();
            for (var i = 0; i < 100; i++)
            {
                array.Insert(i, 0);
            }
            for (var i = 0; i < 100; i++)
            {
                Assert.True(array.GetItem(i) == 99 - i);
            }
        }
        
        [Test]
        public void TestInsert2()
        {
            var array = new DynArray<int>();
            for (var i = 0; i < 100; i++)
            {
                array.Insert(i, array.count);
            }
            for (var i = 0; i < 100; i++)
            {
                Assert.True(array.GetItem(i) == i);
            }
        }

        private bool Cmp(DynArray<int> array, int[] cmp)
        {
            if (cmp.Length != array.count)
            {
                return false;
            }

            for (var i = 0; i < array.count; i++)
            {
                if (array.GetItem(i) != cmp[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}