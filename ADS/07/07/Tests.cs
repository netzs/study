using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using AlgorithmsDataStructures;
using NUnit.Framework;

namespace _07
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void TestClearCount()
        {
            var list = new OrderedList<int>(true);
            Assert.True(list.Count() == 0);
            list.Add(1);
            Assert.True(list.Count() == 1);
            list.Clear(true);
            Assert.True(list.Count() == 0);
        }
        [Test]
        public void TestCmpInt()
        {
            var list = new OrderedList<int>(true);
            Assert.True(list.CompareAsc(1, 2) == -1);
            Assert.True(list.CompareAsc(2, 1) == 1);
            Assert.True(list.CompareAsc(1, 1) == 0);
        }

        [Test]
        public void TestCmpString()
        {
            var list = new OrderedList<string>(true);
            Assert.True(list.CompareAsc("1", "2") == -1);
            Assert.True(list.CompareAsc("2", "1") == 1);
            Assert.True(list.CompareAsc("1", "1") == 0);
            Assert.True(list.CompareAsc(" 1 ", " 2 ") == -1);
            Assert.True(list.CompareAsc("2", "1   ") == 1);
            Assert.True(list.CompareAsc("1", "    1") == 0);
            Assert.True(list.CompareAsc(" a ", " ab") == -1);
            Assert.True(list.CompareAsc("2", "1   ") == 1);
            Assert.True(list.CompareAsc("1", "    1") == 0);
            Assert.True(list.CompareAsc("A", "a") == -1);

            list = new OrderedList<string>(false);
            Assert.True(list.CompareAsc("1", "2") == 1);
            Assert.True(list.CompareAsc("2", "1") == -1);
            Assert.True(list.CompareAsc("1", "1") == 0);
            Assert.True(list.CompareAsc(" 1 ", " 2 ") == 1);
            Assert.True(list.CompareAsc("2", "1   ") == -1);
            Assert.True(list.CompareAsc("1", "    1") == 0);
            Assert.True(list.CompareAsc(" a ", " ab") == 1);
            Assert.True(list.CompareAsc("2", "1   ") == -1);
            Assert.True(list.CompareAsc("1", "    1") == 0);
            Assert.True(list.CompareAsc(" ABCD ", " abcd") == 1);
        }

        [Test]
        public void TestGetAll()
        {
            var list = new OrderedList<int>(true);
            for (var i = 0; i < 10; i++)
            {
                list.Add(i);
                list.Add(-1);
            }

            Assert.True(CmpArray(list.GetAll(), ReverseGetAll(list)));
        }


        [Test]
        public void TestAddDelete0()
        {
            var list = new OrderedList<int>(true);
            list.Add(3);
            Assert.True(Check(list, new int[] {3,}));
            list.Add(4);
            Assert.True(Check(list, new int[] {3, 4}));
            list.Add(2);
            Assert.True(Check(list, new int[] {2, 3, 4}));
            list.Add(1);
            Assert.True(Check(list, new int[] {1, 2, 3, 4}));
            list.Delete(5);
            Assert.True(Check(list, new int[] {1, 2, 3, 4}));
            list.Delete(3);
            Assert.True(Check(list, new int[] {1, 2, 4}));
            list.Delete(4);
            Assert.True(Check(list, new int[] {1, 2}));
            list.Delete(1);
            Assert.True(Check(list, new int[] {2}));
            list.Delete(2);
            Assert.True(Check(list, new int[] { }));
        }

        [Test]
        public void TestAddDelete1()
        {
            var list = new OrderedList<int>(true);
            list.Add(10);
            list.Add(5);
            list.Add(0);
            Assert.True(Check(list, new int[] {0, 5, 10}));
            list.Add(2);
            list.Add(7);
            Assert.True(Check(list, new int[] {0, 2, 5, 7, 10}));
            list.Delete(5);
            Assert.True(Check(list, new int[] {0, 2, 7, 10}));
            list.Delete(10);
            Assert.True(Check(list, new int[] {0, 2, 7}));
        }

        [Test]
        public void TestAddDelete2()
        {
            var list = new OrderedList<int>(true);
            list.Add(10);
            list.Add(10);
            list.Add(10);
            list.Add(10);
            list.Add(5);
            list.Add(10);
            list.Add(10);
            list.Add(0);
            list.Add(0);
            list.Add(0);
            list.Add(100);
            Assert.True(Check(list, new int[] {0, 0, 0, 5, 10, 10, 10, 10, 10, 10, 100}));

            list.Delete(10);
            list.Delete(10);
            list.Delete(10);
            list.Delete(10);
            Assert.True(Check(list, new int[] {0, 0, 0, 5, 10, 10, 100}));
            list.Delete(10);
            list.Delete(10);
            list.Delete(10);
            list.Delete(10);
            list.Delete(10);
            list.Delete(10);
            list.Delete(10);
            list.Delete(10);
            list.Delete(10);
            Assert.True(Check(list, new int[] {0, 0, 0, 5, 100}));
            list.Delete(0);
            list.Delete(5);
            list.Delete(0);
            list.Delete(0);
            list.Delete(0);
            list.Delete(5);
            Assert.True(Check(list, new int[] {100}));
            list.Delete(100);
            list.Delete(100);
        }

        [Test]
        public void TestAddDelete3()
        {
            var list = new OrderedList<int>(false);
            list.Add(1);
            list.Add(10);
            list.Add(5);
            Assert.True(Check(list, new int[] {10, 5, 1}));
            Assert.True(CmpArray(list.GetAll(), ReverseGetAll(list)));
            list.Delete(0);
            list.Delete(5);
            Assert.True(Check(list, new int[] {10, 1}));
        }

        [Test]
        public void TestRandom()
        {
            var list = new OrderedList<int>(true);
            var rnd = new Random();
            for (var i = 0; i < 10000; i++)
            {
                var add = rnd.Next(100);
                list.Add(add);
                var del = rnd.Next(100);
                list.Delete(del);
                Assert.True(CheckSort(list, true));
                Assert.True(CmpArray(list.GetAll(), ReverseGetAll(list)));
            }
        }

        [Test]
        public void TestRandomDesc()
        {
            var list = new OrderedList<int>(false);
            var rnd = new Random();
            for (var i = 0; i < 10000; i++)
            {
                var add = rnd.Next(100);
                list.Add(add);
                var del = rnd.Next(100);
                list.Delete(del);
                Assert.True(CheckSort(list, false));
            }
        }
        
        [Test]
        public void TestFind()
        {
            var list = new OrderedList<int>(true);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            Assert.True(list.Find(2).value == 2);
            Assert.True(list.Find(2) == list.head);
            Assert.True(list.Find(4).value == 4);
            Assert.True(list.Find(4) == list.tail);
            Assert.True(list.Find(3).value == 3);
            Assert.True(list.Find(3) == list.tail.prev);
            Assert.True(list.Find(3) == list.head.next);
        }
        
        [Test]
        public void TestFindDesc()
        {
            var list = new OrderedList<int>(false);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            Assert.True(list.Find(2).value == 2);
            Assert.True(list.Find(2) == list.tail);
            Assert.True(list.Find(4).value == 4);
            Assert.True(list.Find(4) == list.head);
            Assert.True(list.Find(3).value == 3);
            Assert.True(list.Find(3) == list.tail.prev);
            Assert.True(list.Find(3) == list.head.next);
        }


        [Test]
        public void TestFind2()
        {
            var list = new OrderedList<int>(false);
            list.Add(20);
            list.Add(30);
            list.Add(40);
            list.Add(40);
            list.Add(40);
            list.Add(40);
            list.Add(40);
            Assert.True(list.Find(5) == null);
            Assert.True(list.Find(15) == null);
            Assert.True(list.Find(25) == null);
            Assert.True(list.Find(35) == null);
            Assert.True(list.Find(45) == null);
            Assert.True(list.Find(40) != null);
        }

        private bool CmpArray(List<Node<int>> a, List<Node<int>> b)
        {
            if (a.Count != b.Count)
            {
                return false;
            }

            for (int i = 0; i < a.Count; i++)
            {
                if (a[i].value != b[i].value)
                {
                    return false;
                }
            }

            return true;
        }


        private List<Node<int>> ReverseGetAll(OrderedList<int> list)
        {
            List<Node<int>> r = new List<Node<int>>();
            Node<int> node = list.tail;
            while (node != null)
            {
                r.Add(node);
                node = node.prev;
            }

            r.Reverse();
            return r;
        }

        private bool Check(OrderedList<int> list, int[] a)
        {
            if (list.Count() != a.Length)
            {
                return false;
            }

            var cur = list.head;
            var index = 0;
            while (cur != null)
            {
                if (a[index] != cur.value)
                {
                    return false;
                }

                index++;
                cur = cur.next;
            }

            var k = list.GetAll();
            for (var i = 0; i < a.Length; i++)
            {
                if (k[i].value != a[i])
                {
                    return false;
                }
            }

            return true;
        }

        private static bool CheckSort(OrderedList<int> list, bool isAsc)
        {
            var cur = list.head;
            while (cur != null)
            {
                var vl = cur.value;
                cur = cur.next;
                if (cur != null)
                {
                    if (isAsc && vl > cur.value || !isAsc && vl < cur.value)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}