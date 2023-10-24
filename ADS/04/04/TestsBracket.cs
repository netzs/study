using AlgorithmsDataStructures;
using NUnit.Framework;

namespace _04
{
    [TestFixture]
    public class TestsBracket
    {
        [Test]
        public void Test()
        {
            Assert.True(Bracket.CheckBracket("()"));
            Assert.False(Bracket.CheckBracket(")"));
            Assert.False(Bracket.CheckBracket("("));
            Assert.False(Bracket.CheckBracket(")("));
            Assert.False(Bracket.CheckBracket("))"));
            Assert.False(Bracket.CheckBracket("(("));
            Assert.False(Bracket.CheckBracket("(()"));
            Assert.True(Bracket.CheckBracket("(())"));
            Assert.True(Bracket.CheckBracket("()()"));
            
            Assert.True(Bracket.CheckBracket("(()((())()))"));
            Assert.False(Bracket.CheckBracket("(()()(()"));
            Assert.False(Bracket.CheckBracket("())("));
            Assert.False(Bracket.CheckBracket("))(("));
            Assert.False(Bracket.CheckBracket("((())"));
        }
        
    }
}