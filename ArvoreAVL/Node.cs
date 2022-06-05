namespace ArvoreAVL
{
    public class Node
    {
        private readonly int element;

        public Node(int element)
        {
            this.element = element;
        }

        public int Element { get => element; }
        public int FatorBalanceamento { get; set; }
        public Node SubArvoreDireita { get; set; }
        public Node SubArvoreEsquerda { get; set; }        
    }
}
