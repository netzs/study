
namespace AlgorithmsDataStructures2
{
    public partial class BST
    {
        public void Invert()
        {
            if (Root == null)
            {
                return;
            }

            RoundInvert(Root);
        }

        private void RoundInvert(BSTNode node)
        {
            (node.LeftChild, node.RightChild) = (node.RightChild, node.LeftChild);
            if (node.LeftChild != null)
            {
                RoundInvert(node.LeftChild);
            }
            if (node.RightChild != null)
            {
                RoundInvert(node.RightChild);
            }
        }
    }
}