using System;

namespace HeapSort_lb3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 0, 20, 60, 90, 30, 40, 50, 80 };
            ArrayList<int> list = new ArrayList<int>(arr);
            list.HeapSort();
            list.Print();
        }
    }
}
