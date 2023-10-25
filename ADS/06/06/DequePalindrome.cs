namespace AlgorithmsDataStructures
{
    public static class DequePalindrome
    {
        public static bool Check(string text)
        {
            Deque<char> deque = new Deque<char>();
            foreach (char symbol in text)
            {
                deque.AddTail(symbol);
            }

            while (deque.Size() > 1)
            {
                if (deque.RemoveFront() != deque.RemoveTail())
                {
                    return false;
                }
            }

            return true;
        }
        
    }
}