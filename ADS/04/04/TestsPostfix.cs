using AlgorithmsDataStructures;
using NUnit.Framework;

namespace _04
{
    [TestFixture]
    public class TestsPostfix
    {
        [Test]
        public void Test()
        {
            Assert.True(PostfixExpression.Calc("11 =") == 11);
            Assert.False(PostfixExpression.Calc("2 =") == 1);
            Assert.True(PostfixExpression.Calc("1 1 + =") == 2);
            Assert.False(PostfixExpression.Calc("1 1 + =") == 3);
            Assert.True(PostfixExpression.Calc("1 2 + 3 * =") == 9);
            Assert.True(PostfixExpression.Calc("8 2 + 5 * 9 + =") == 59);
            Assert.True(PostfixExpression.Calc("1 1 1 1 + + + =") == 4);
            Assert.True(PostfixExpression.Calc("1 1 1 1 * * + =") == 2);
            Assert.True(PostfixExpression.Calc("1 2 3 4 5 6 7 8 9 10 + + + + + + + + + =") == 55);
            Assert.True(PostfixExpression.Calc("1 2 + 3 4 + 5 6 + 7 8 + 9 10 + + + + + =") == 55);
        }
    }
}