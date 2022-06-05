using System;
using System.Text;

namespace ArvoreAVL
{
    public class AVLTree : IBinaryTree
    {
        private int numElement;

        public AVLTree(){}

        public AVLTree(int element)
        {
            Root = new Node(element);
            numElement++;
        }

        public Node Root { get; set; }

        public bool IsEmpty()
        {
            return numElement == 0 && Root == null;
        }

        public Node Insert(Node root, int value)
        {
            var newNode = new Node(value);

            Node rootCopy = root;

            Node traillingPointerOfTemp = null;

            while (rootCopy != null)
            {
                traillingPointerOfTemp = rootCopy;

                if (value < rootCopy.Element)
                {
                    rootCopy = rootCopy.SubArvoreEsquerda;
                }
                else
                {
                    rootCopy = rootCopy.SubArvoreDireita;
                }
            }

            if (root == null)
            {
                traillingPointerOfTemp = newNode;
            }
            else if (value < traillingPointerOfTemp.Element)
            {
                traillingPointerOfTemp.SubArvoreEsquerda = newNode;
            }
            else
            {
                traillingPointerOfTemp.SubArvoreDireita = newNode;
            }


            numElement++;

            return traillingPointerOfTemp;
        }

        private void InPreOrder (Node root)
        {
            if ( root != null)
            {
                Console.WriteLine(root.Element + " ");
                InPreOrder(root.SubArvoreEsquerda);
                InPreOrder(root.SubArvoreDireita);
            }
        }

        public void Inorder(Node root)
        {
            if (root != null)
            {
                Inorder(root.SubArvoreEsquerda);
                Console.Write(root.Element + " ");
                Inorder(root.SubArvoreDireita);
            }
        }

        public Node Insert(int element)
        {
            throw new NotImplementedException();
        }
    }
}
