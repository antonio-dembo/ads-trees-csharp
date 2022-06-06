using ArvoreAVL;

namespace ArvoreAVL.Utils
{
    public class MockDataService
    {
        private AVLTree _arvoreAvl;

        public MockDataService()
        {
            _arvoreAvl = new AVLTree();
        }

        public void InOrder(Node root)
        {
            _arvoreAvl.Inorder(root);
        }

        public Node CreateBST(int value)
        {
            //Node root = null;

            _arvoreAvl.Root = _arvoreAvl.Insert(_arvoreAvl.Root , value);
            //_arvoreAvl.Insert(root, 50);
            //_arvoreAvl.Insert(root, 30);
            //_arvoreAvl.Insert(root, 20);
            //_arvoreAvl.Insert(root, 40);
            //_arvoreAvl.Insert(root, 70);
            //_arvoreAvl.Insert(root, 60);
            //_arvoreAvl.Insert(root, 80);
            return _arvoreAvl.Root;
        }
    }
}
