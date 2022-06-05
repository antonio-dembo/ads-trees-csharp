namespace ArvoreAVL
{
    public interface IBinaryTree
    {
        Node Root { get; set; }
        Node Insert(int element);
        Node Insert(Node root, int element);        
        bool IsEmpty();
        void Inorder(Node root);
    }
}
