using AlgorithmsDataStructures;

namespace _01
{
    public static class Sum
    {
        public static LinkedList SumValueLinkedList(LinkedList a, LinkedList b)
        {
            if (a.Count() != b.Count())
            {
                return null;
            }

            var nodeA = a.head;
            var nodeB = b.head;

            var result = new LinkedList();
            
            while (nodeA != null)
            {
                result.AddInTail(new Node(nodeA.value + nodeB.value));
                nodeA = nodeA.next;
                nodeB = nodeB.next;
            }

            return result;
        }
    }
}