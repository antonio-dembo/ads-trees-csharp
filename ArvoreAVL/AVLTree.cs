using System;
using System.Text;

namespace ArvoreAVL
{
    public class AVLTree : IBinaryTree
    {
        public AVLTree(){}

        public Node Root { get; set; }

        public Node Insert(Node node, int value)
        {
            if(node == null)
            {
                return new Node(value);
            }

            if (value < node.Element)
            {
                node.SubArvoreEsquerda = Insert(node.SubArvoreEsquerda, value);
            }
            else if(value > node.Element)
            {
                node.SubArvoreDireita = Insert(node.SubArvoreDireita, value);
            }
            else
            {
                return node;
            }

            return EnsureBstIsBalanced(node, value);
        }

        private Node EnsureBstIsBalanced(Node ancestorNode, int key)
        {
            ancestorNode.Height = 1 + Max(GetHeight(ancestorNode.SubArvoreEsquerda),
                                GetHeight(ancestorNode.SubArvoreDireita));

            int balance = GetBalanceFactor(ancestorNode);

            if (balance > 1 && key < ancestorNode.SubArvoreEsquerda.Element)
            {
                return RightRotate(ancestorNode);
            }

            if (balance < -1 && key > ancestorNode.SubArvoreDireita.Element)
            { 
                return LeftRotate(ancestorNode); 
            }

            if (balance > 1 && key > ancestorNode.SubArvoreEsquerda.Element)
            {
                ancestorNode.SubArvoreEsquerda = LeftRotate(ancestorNode.SubArvoreEsquerda);
                return RightRotate(ancestorNode);
            }

            if (balance < -1 && key < ancestorNode.SubArvoreDireita.Element)
            {
                ancestorNode.SubArvoreDireita = RightRotate(ancestorNode.SubArvoreDireita);
                return LeftRotate(ancestorNode);
            }

            return ancestorNode;
        }

        public void InPreOrder (Node node)
        {
            if ( node != null)
            {
                Console.Write(node.Element + " ");
                InPreOrder(node.SubArvoreEsquerda);
                InPreOrder(node.SubArvoreDireita);
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

        private static int GetHeight(Node node)
        {
            if (node == null)
                return 0;

            return node.Height;
        }

        private static int Max(int a, int b)
        {
            return (a > b) ? a : b;
        }

        public Node RightRotate(Node nodoDes)
        {
            Node nodoEsquerda = nodoDes.SubArvoreEsquerda;
            Node Temp = nodoEsquerda.SubArvoreDireita;

            // Perform rotation
            nodoEsquerda.SubArvoreEsquerda = nodoDes;
            nodoDes.SubArvoreEsquerda = Temp;

            // Update heights
            nodoDes.Height = Max(GetHeight(nodoDes.SubArvoreEsquerda),
                        GetHeight(nodoDes.SubArvoreDireita)) +1;

            nodoEsquerda.Height = Max(GetHeight(nodoEsquerda.SubArvoreEsquerda),
                        GetHeight(nodoEsquerda.SubArvoreDireita)) + 1;

            return nodoEsquerda;
        }

        private Node LeftRotate(Node nodoDes)
        {
            Node nodoDireita = nodoDes.SubArvoreDireita;
            Node Temp = nodoDireita.SubArvoreEsquerda;

            // Perform rotation
            nodoDireita.SubArvoreEsquerda = nodoDes;
            nodoDes.SubArvoreDireita = Temp;

            // Update heights
            nodoDes.Height = Max(GetHeight(nodoDes.SubArvoreEsquerda),
                        GetHeight(nodoDes.SubArvoreDireita)) + 1;
            nodoDireita.Height = Max(GetHeight(nodoDireita.SubArvoreEsquerda),
                        GetHeight(nodoDireita.SubArvoreDireita)) + 1;

            return nodoDireita;
        }

        public int GetBalanceFactor(Node nodo)
        {
            if (nodo == null)
                return 0;

            return GetHeight(nodo.SubArvoreEsquerda) - GetHeight(nodo.SubArvoreDireita);
        }
    }
}
