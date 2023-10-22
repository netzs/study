using AlgorithmsDataStructures;
using NUnit.Framework;

namespace _01
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void TestCount0()
        {
            var list = new LinkedList();
            Assert.True(list.Count() == 0);
            list = CreateList(new[] {1, 2, 3});
            Assert.True(list.Count() == 3);
            list = CreateList(new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 0});
            Assert.True(list.Count() == 10);
        }

        [Test]
        public void TestFindAll0()
        {
            var list = CreateList(new[] {1, 2, 3, 3, 3, 3, 3, 2, 1, 3, 0});
            Assert.True(list.FindAll(-1).Count == 0);
            Assert.True(list.FindAll(0).Count == 1);
            Assert.True(list.FindAll(1).Count == 2);
            Assert.True(list.FindAll(2).Count == 2);
            Assert.True(list.FindAll(3).Count == 6);
        }

        [Test]
        public void TestFindAll1()
        {
            var list = new LinkedList();
            var node0 = new Node(5);
            var node1 = new Node(10);
            var node2 = new Node(5);
            list.AddInTail(node0);
            list.AddInTail(node1);
            list.AddInTail(node2);

            var find = list.FindAll(5);
            Assert.True(find.Count == 2 && find[0] == node0 && find[1] == node2);
        }

        [Test]
        public void TestRemove0()
        {
            var list = new LinkedList();
            Assert.True(!list.Remove(1));
        }

        [Test]
        public void TestRemove1()
        {
            var list = CreateList(new[] {1, 2, 3, 4, 5});
            Assert.True(list.Remove(3));
            Assert.True(Cmp(list, new[] {1, 2, 4, 5}));
            Assert.True(list.Remove(1));
            Assert.True(Cmp(list, new[] {2, 4, 5}));
            Assert.True(list.Remove(5));
            Assert.True(Cmp(list, new[] {2, 4}));
            Assert.True(list.Remove(2));
            Assert.True(Cmp(list, new[] {4}));
            Assert.True(!list.Remove(6));
            Assert.True(list.Remove(4));
            Assert.True(Cmp(list, new int[] { }));
            Assert.True(list.Count() == 0);
        }

        [Test]
        public void TestRemoveAll1()
        {
            var list = CreateList(new[] {1, 1, 1, 2, 3, 4, 5, 5, 4, 4, 4, 3, 2, 1});
            list.RemoveAll(3);
            Assert.True(Cmp(list, new[] {1, 1, 1, 2, 4, 5, 5, 4, 4, 4, 2, 1}));
            list.RemoveAll(1);
            Assert.True(Cmp(list, new[] {2, 4, 5, 5, 4, 4, 4, 2}));
            list.RemoveAll(5);
            Assert.True(Cmp(list, new[] {2, 4, 4, 4, 4, 2}));
            list.RemoveAll(2);
            Assert.True(Cmp(list, new[] {4, 4, 4, 4}));
            list.RemoveAll(6);
            list.RemoveAll(4);
            Assert.True(Cmp(list, new int[] { }));
            Assert.True(list.Count() == 0);
        }

        [Test]
        public void TestRemoveAll2()
        {
            var list = CreateList(new[] {1, 1, 1, 4});
            list.RemoveAll(4);
            Assert.True(Cmp(list, new[] {1, 1, 1}));

            list = CreateList(new[] {1, 1, 1, 4});
            list.RemoveAll(1);
            Assert.True(Cmp(list, new[] {4}));
        }

        [Test]
        public void TestClear()
        {
            var list = CreateList(new[] {1, 1, 1, 4});
            list.Clear();
            Assert.True(Cmp(list, new int [] {}));
        }

        [Test]
        public void TestInsert()
        {
            var list = new LinkedList();
            Assert.True(Cmp(list, new int[] { }));
            list.InsertAfter(list.head, new Node(1));
            Assert.True(Cmp(list, new int[] {1}));
            list.InsertAfter(list.head, new Node(2));
            Assert.True(Cmp(list, new int[] {1, 2}));
            list.InsertAfter(list.head, new Node(3));
            Assert.True(Cmp(list, new int[] {1, 3, 2}));
            list.InsertAfter(null, new Node(4));
            Assert.True(Cmp(list, new int[] {4, 1, 3, 2}));
            list.InsertAfter(null, new Node(5));
            Assert.True(Cmp(list, new int[] {5, 4, 1, 3, 2}));
            list.InsertAfter(list.tail, new Node(8));
            Assert.True(Cmp(list, new int[] {5, 4, 1, 3, 2, 8}));
        }
        
        [Test]
        public void TestSum0()
        {
            var listA = CreateList(new[] {1, 2, 3, 4});
            var listB = CreateList(new[] {10, 20, 30, 40});
            var sum = Sum.SumValueLinkedList(listA, listB);
            Assert.True(Cmp(sum, new int[] {11,22,33,44}));
        }
        
        [Test]
        public void TestSum1()
        {
            var listA = CreateList(new[] {1, 2, 3, 4});
            var listB = CreateList(new[] {20, 30, 40});
            var sum = Sum.SumValueLinkedList(listA, listB);
            Assert.True(sum == null);
        }

        private LinkedList CreateList(int[] array)
        {
            var list = new LinkedList();
            foreach (var item in array)
            {
                var node = new Node(item);
                list.AddInTail(node);
            }

            return list;
        }

        private bool Cmp(LinkedList list, int[] array)
        {
            if (list.Count() == 0 && (list.head != list.tail || list.head != null && list.tail != null))
            {
                return false;
            }

            if (list.Count() != array.Length)
            {
                return false;
            }

            var cur = list.head;
            for (var index = 0; index < array.Length; index++)
            {
                var item = array[index];
                if (item != cur.value)
                {
                    return false;
                }

                if (index == array.Length - 1 && cur != list.tail)
                {
                    return false;
                }

                cur = cur.next;
            }

            return true;
        }
    }
}