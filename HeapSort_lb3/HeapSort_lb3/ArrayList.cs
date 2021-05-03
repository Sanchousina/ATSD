using System;
using System.Collections.Generic;
using System.Text;

namespace HeapSort_lb3
{
    class ArrayList<T> where T: IComparable<T>
    {
        private T[] arr;
        private int max;
        private int last;
        
        public ArrayList(T[] arr)
        {
            this.arr = arr;
            max = arr.Length;
            last = arr.Length - 1;
        }

        public ArrayList(int n)
        {
            max = n;
            last = -1;
            arr = new T[max];
        }

        public bool isEmpty()
        {
            return last == -1;
        }

        public void Print()
        {
            Console.WriteLine("List contents:");
            if (last == -1) Console.WriteLine("Oops! List is empty(");
            else
            {
                for (int i = 0; i <= last; ++i)
                {
                    Console.Write(arr[i] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
