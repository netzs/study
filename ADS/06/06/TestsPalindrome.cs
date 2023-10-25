using AlgorithmsDataStructures;
using NUnit.Framework;

namespace _06
{
    [TestFixture]
    public class TestsPalindrome
    {
        [Test]
        public void Test0()
        {
            Assert.True(DequePalindrome.Check("a"));
            Assert.True(DequePalindrome.Check("ava"));
            Assert.True(DequePalindrome.Check("avva"));
            Assert.True(DequePalindrome.Check("av1va"));
            Assert.True(DequePalindrome.Check(""));
            Assert.False(DequePalindrome.Check("avv"));
            Assert.False(DequePalindrome.Check("av"));
            Assert.False(DequePalindrome.Check("avba"));
            Assert.True(DequePalindrome.Check("palindromemordnilap"));
        }
    }
}