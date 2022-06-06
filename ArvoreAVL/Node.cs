namespace ArvoreAVL
{
    public class Node
    {
        private readonly int _element;
        private int _height;

        public Node(int element)
        {
            _element = element;
            _height = 1;
        }

        public int Element { get => _element; }
        public int Height { get => _height ; set => _height = value; }
        public int Balanceamento { get; set; }
        public Node SubArvoreDireita { get; set; }
        public Node SubArvoreEsquerda { get; set; }        
    }
}
