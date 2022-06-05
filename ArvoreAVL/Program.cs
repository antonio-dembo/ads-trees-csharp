using ArvoreAVL.Utils;
using System;

namespace ArvoreAVL
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Let us create following BST
                50
                / \
                30 70
                / \ / \
            20 40 60 80 */

            try
            {
                ProgMenu.ShowProgramMenu();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            

                       

            // Print inorder traversal of the BST
            //arvoreAvl.Inorder(root);
        }
    }
}
