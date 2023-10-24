using System.Linq;
using System.Runtime.CompilerServices;

namespace AlgorithmsDataStructures
{
    public static class PostfixExpression
    {
        public static int Calc(string text)
        {
            var stackInput = Parse(text);
            var resultStack = new Stack<int>();

            while (stackInput.Size() > 0)
            {
                var cur = stackInput.Pop();
                switch (cur)
                {
                    case Number num:
                        resultStack.Push(num.Value);
                        break;
                    case IOperation operation:
                        var first = resultStack.Pop();
                        var second = resultStack.Pop();
                        resultStack.Push(operation.Calc(first, second));
                        break;
                    case Result _:
                        return resultStack.Pop();
                }
            }

            return 0;
        }

        private static Stack<IValue> Parse(string text)
        {
            var items = text.Split(' ');
            var stack = new Stack<IValue>();
            foreach (var item in items.Reverse())
            {
                switch (item)
                {
                    case "+":
                        stack.Push(new SumOperation());
                        break;
                    case "*":
                        stack.Push(new MulOperation());
                        break;
                    case "=":
                        stack.Push(new Result());
                        break;
                    case "":
                        break;
                    default:
                        stack.Push(new Number(int.Parse(item)));
                        break;
                }
            }

            return stack;
        }

        private class Number : IValue
        {
            public readonly int Value;

            public Number(int value)
            {
                Value = value;
            }
        }

        private class SumOperation : IOperation
        {
            public int Calc(int a, int b)
            {
                return a + b;
            }
        }

        private class MulOperation : IOperation
        {
            public int Calc(int a, int b)
            {
                return a * b;
            }
        }

        private class Result : IValue
        {
        }

        private interface IOperation : IValue
        {
            int Calc(int a, int b);
        }

        private interface IValue
        {
        }
    }
}