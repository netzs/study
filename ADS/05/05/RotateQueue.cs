namespace AlgorithmsDataStructures
{
    public static class RotateQueue
    {
        public static void Rotate<T>(Queue<T> queue, int count)
        {
            if (queue.Size() == 0) return;
            count %= queue.Size();
            for (var i = 0; i < count; i++)
            {
                var item = queue.Dequeue();
                queue.Enqueue(item);
            }
        }
    }
}