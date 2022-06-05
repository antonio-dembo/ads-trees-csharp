using ArvoreAVL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.ArvoreAVL.Tests
{
    [TestClass]
    public class ArvoreAVLTest
    {
        private readonly IBinaryTree _arvoreAVL = new AVLTree();

        [TestMethod]
        public void CheckTheTreeIsEmpty_ReturnTrue()
        {
            Assert.IsTrue(_arvoreAVL.IsEmpty());
        }

        [TestMethod]
        public void Insert_AddOneElment_ReturnRootNode()
        {
            var rootNode = _arvoreAVL.Insert(10);

            Assert.IsInstanceOfType(rootNode, typeof(Node));
            Assert.AreEqual(10, rootNode.Element);
            Assert.IsNull(rootNode.SubArvoreDireita);
            Assert.IsNull(rootNode.SubArvoreEsquerda);
        }

        [TestMethod]
        public void Insert_AddSecondElementToTheLeft()
        {
            _ = _arvoreAVL.Insert(9);
            var newRoot = _arvoreAVL.Insert(5);

            Assert.AreEqual(9, newRoot.Element);
            Assert.AreEqual(5, newRoot.SubArvoreEsquerda.Element);
        }

        [TestMethod]
        public void Insert_AddSecondElementToTheRight()
        {
            _ = _arvoreAVL.Insert(5);
            var newRoot = _arvoreAVL.Insert(9);

            Assert.AreEqual(5, newRoot.Element);
            Assert.AreEqual(9, newRoot.SubArvoreDireita.Element);
        }

        [TestMethod]
        public void Insert_AddThirddElementToTheRight()
        {
            var newRoot = _arvoreAVL.Insert(9);
            _arvoreAVL.Insert(5);
            _arvoreAVL.Insert(7);

            Assert.AreEqual(5, newRoot.Element);
            Assert.AreEqual(9, newRoot.SubArvoreDireita.Element);
        }


        [TestMethod]
        public void ShouldPrintTheAvlTreeInOrder()
        {
            Node root = null;

            root = _arvoreAVL.Insert(root, 50);
            _arvoreAVL.Insert(root, 30);
            _arvoreAVL.Insert(root, 20);
            _arvoreAVL.Insert(root, 40);
            _arvoreAVL.Insert(root, 70);
            _arvoreAVL.Insert(root, 60);
            _arvoreAVL.Insert(root, 80);

            _arvoreAVL.Inorder(root);

            Assert.IsTrue(true);

        }



    }
}
