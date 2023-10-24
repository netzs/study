namespace AlgorithmsDataStructures
{
    public static class Bracket
    {
        public static bool CheckBracket(string text)
        {
            var stack = new Stack<bool>();
            foreach (var symbol in text)
            {
                if (symbol == ')' && stack.Size() == 0)
                {
                    return false;
                }
                
                if (symbol == '(')
                {
                    stack.Push(false);
                }
                else
                {
                    stack.Pop();
                }
            }

            return stack.Size() == 0;
        }
    }
}