namespace ArvoreAVL
{
    public interface IBinaryTree
    {
        Node Root { get; set; }
        Node Insert(int element);
        Node Insert(Node root, int element);        
        void Inorder(Node root);
        void InPreOrder(Node node);
    }
}
