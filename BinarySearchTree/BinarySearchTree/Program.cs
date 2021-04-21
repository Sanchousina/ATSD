using System;

namespace BinarySearchTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree<int> tree = new Tree<int>();
            tree.Add(5);
            tree.Add(2);
            tree.Add(6);
            tree.Add(3);
            tree.Add(0);


            Tree<int> tree2 = new Tree<int>();
            tree2.Add(3);
            tree2.Add(2);
            tree2.Add(5);
            tree2.Add(0);
            tree2.Add(6);


            /* tree2.PrintSorted();

             tree.PrintSorted();*/

            //tree.deleteKey(1);

            //Console.WriteLine(tree.SecondLargest());
            // tree.DeleteEven();
            //tree.PrintSorted();

            //tree.Insert(tree2);

            //Console.WriteLine(tree.Contains(tree2));

            foreach (var item in tree.Preorder())
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            //Tree<int> tree2 = tree.Copy(tree);

            foreach (var item in tree2.Preorder())
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            /* Console.WriteLine(tree.isBalanced());
             Console.WriteLine(tree2.isBalanced());*/


            Console.WriteLine(tree.Equals(tree, tree2));

            //Console.WriteLine(Tree<int>.isBalanced());
        }
    }
}
