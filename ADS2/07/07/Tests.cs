using System;
using AlgorithmsDataStructures2;
using NUnit.Framework;

namespace _07
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void TestCreate()
        {
            var heap = new Heap();
            heap.MakeHeap(new int[] { }, 2);
            Assert.True(heap.HeapArray.Length == 7);
            heap.MakeHeap(new int[] { }, 3);
            Assert.True(heap.HeapArray.Length == 15);
            heap.MakeHeap(new int[] {1, 2, 3, 4, 5}, 2);
            Check(heap, new int[] {5, 4, 3, 2, 1});
        }

        [Test]
        public void TestCreate2()
        {
            var heap = new Heap();
            heap.MakeHeap(new int[] {1, 2, 3, 4, 5}, 2);
            Check(heap, new int[] {5, 4, 3, 2, 1});
            heap.MakeHeap(new int[] { }, 2);
            for (int i = 0; i < 7; i++)
            {
                Assert.True(heap.Add(1));
            }

            for (int i = 0; i < 7; i++)
            {
                Assert.False(heap.Add(1));
            }

            for (int i = 0; i < 7; i++)
            {
                Assert.True(heap.GetMax() == 1);
            }

            for (int i = 0; i < 7; i++)
            {
                Assert.True(heap.GetMax() == -1);
            }
        }

        [Test]
        public void TestRnd1()
        {
            var heap = new Heap();
            heap.MakeHeap(new int[] { }, 10);
            var random = new Random();

            var rnds = new int[1000];
            for (int i = 0; i < 1000; i++)
            {
                rnds[i] = -random.Next(0, 10000);
                heap.Add(-rnds[i]);
            }

            Array.Sort(rnds);

            for (int i = 0; i < 1000; i++)
            {
                Assert.True(heap.GetMax() == -rnds[i]);
            }
        }

        [Test]
        public void TestRnd2()
        {
            var heap = new Heap();
            var random = new Random();

            var rnds = new int[1000];
            for (int i = 0; i < 1000; i++)
            {
                rnds[i] = random.Next(0, 10000);
            }

            heap.MakeHeap(rnds, 10);

            Array.Sort(rnds);
            Array.Reverse(rnds);

            for (int i = 0; i < 1000; i++)
            {
                Assert.True(heap.GetMax() == rnds[i]);
            }
        }

        [Test]
        public void TestRnd3()
        {
            var heap = new Heap();
            var random = new Random();

            var rnds = new int[1000];
            for (int i = 0; i < 1000; i++)
            {
                rnds[i] = random.Next(9, 10000);
            }

            var rnd2 = new int[500];
            Array.Copy(rnds, rnd2, 500);
            heap.MakeHeap(rnd2, 9);

            for (int i = 500; i < 1000; i++)
            {
                Assert.True(heap.Add(rnds[i]));
            }

            for (int i = 0; i < 23; i++)
            {
                Assert.True(heap.Add(1));
            }

            Assert.False(heap.Add(1));
            
            Array.Sort(rnds);
            Array.Reverse(rnds);

            for (int i = 0; i < 1000; i++)
            {
                Assert.True(heap.GetMax() == rnds[i]);
            }
        }

        [Test]
        public void TestAdd()
        {
            var heap = new Heap();
            heap.MakeHeap(new int[] {}, 3);
            heap.Add(10);
            Assert.True(heap.HeapArray[0] == 10);
            heap.Add(11);
            Assert.True(heap.HeapArray[0] == 11);
            Assert.True(heap.HeapArray[1] == 10);
            heap.Add(12);
            Assert.True(heap.HeapArray[0] == 12);
            Assert.True(heap.HeapArray[1] == 10);
            Assert.True(heap.HeapArray[2] == 11);
            heap.Add(5);
            Assert.True(heap.HeapArray[0] == 12);
            Assert.True(heap.HeapArray[1] == 10);
            Assert.True(heap.HeapArray[2] == 11);
            Assert.True(heap.HeapArray[3] == 5);
            heap.Add(20);
            Assert.True(heap.HeapArray[0] == 20);
            Assert.True(heap.HeapArray[1] == 12);
            Assert.True(heap.HeapArray[2] == 11);
            Assert.True(heap.HeapArray[3] == 5);
            Assert.True(heap.HeapArray[4] == 10);
            Assert.True(heap.GetMax() == 20);
            Assert.True(heap.HeapArray[0] == 12);
            Assert.True(heap.HeapArray[1] == 10);
            Assert.True(heap.HeapArray[2] == 11);
            Assert.True(heap.HeapArray[3] == 5);
        }
        
        [Test]
        public void TestAdd2()
        {
            var heap = new Heap();
            heap.MakeHeap(new int[] {10,11,12,5,20}, 3);
            Assert.True(heap.HeapArray[0] == 20);
            Assert.True(heap.HeapArray[1] == 12);
            Assert.True(heap.HeapArray[2] == 11);
            Assert.True(heap.HeapArray[3] == 5);
            Assert.True(heap.HeapArray[4] == 10);
            Assert.True(heap.GetMax() == 20);
            Assert.True(heap.HeapArray[0] == 12);
            Assert.True(heap.HeapArray[1] == 10);
            Assert.True(heap.HeapArray[2] == 11);
            Assert.True(heap.HeapArray[3] == 5);
        }

        private void Check(Heap heap, int[] ints)
        {
            foreach (var key in ints)
            {
                Assert.True(heap.GetMax() == key);
            }
        }
    }
}