using System;

namespace BinarySearchTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree<int> tree = new Tree<int>();
            tree.Add(5);
            tree.Add(1);
            tree.Add(8);
            tree.Add(4);
            tree.Add(0);
            tree.Add(7);
            tree.Add(9);

            foreach(var item in tree.Preorder())
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();

            /*foreach (var item in tree.Postorder())
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();

            foreach (var item in tree.Inorder())
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();*/

            Console.WriteLine(tree.Search(0));
            Console.WriteLine(tree.Search(10));
        }
    }
}
