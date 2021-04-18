using System;

namespace BinarySearchTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree<int> tree = new Tree<int>();
            tree.Add(6);
            tree.Add(1);
            tree.Add(8);
            tree.Add(4);
            tree.Add(0);
            tree.Add(7);
            tree.Add(10);
            tree.Add(9);
            tree.Add(3);
            tree.Add(5);
            tree.Add(-2);
            tree.Add(12);




            /* foreach (var item in tree.Preorder())
             {
                 Console.Write(item + " ");
             }

             Console.WriteLine();

             tree.Delete(5);


             foreach (var item in tree.Preorder())
             {
                 Console.Write(item + " ");
             }

             Console.WriteLine();*/

            tree.PrintSorted();

            //tree.deleteKey(1);

            Console.WriteLine(tree.SecondLargest());
           // tree.DeleteEven();
            //tree.PrintSorted();
        }
    }
}
