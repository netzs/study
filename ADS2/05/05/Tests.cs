using AlgorithmsDataStructures2;
using NUnit.Framework;

namespace _05
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Test1()
        {
            Check(BalancedBST.GenerateBBSTArray(new[] {3, 2, 1}), new[] {2, 1, 3});
            Check(BalancedBST.GenerateBBSTArray(new[] {2, 1, 3}), new[] {2, 1, 3});
            Check(BalancedBST.GenerateBBSTArray(new[] {3, 3, 3}), new[] {3, 3, 3});
            Check(BalancedBST.GenerateBBSTArray(new[] {300, 300, 3}), new[] {300, 3, 300});
            Check(BalancedBST.GenerateBBSTArray(new[] {1}), new[] {1});
            Check(BalancedBST.GenerateBBSTArray(new[] {1, 3, 2, 7, 6, 5, 4}), new[] {4, 2, 6, 1, 3, 5, 7});
            Check(BalancedBST.GenerateBBSTArray(new int [] {}), new int [] {});
        }

        private void Check(int[] a, int[] b)
        {
            Assert.True(a.Length == b.Length);
            for (int i = 0; i < a.Length; i++)
            {
                Assert.True(a[i] == b[i]);
            }
        }
    }
}