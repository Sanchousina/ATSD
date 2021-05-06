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

        public int Size()
        {
            return last + 1;
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

        public void HeapSort() { }

        //algorithm for constructing maxheaps
        private void Heapify(T[] arr, int n, int i)
        {
            int largest = i;
            int l = 2 * i + 1;
            int r = 2 * i + 2;

            if (l < n && arr[l].CompareTo(arr[largest]) == 1)
            {
                largest = l;
            }
            if (r < n && arr[r].CompareTo(arr[largest]) == 1)
            {
                largest = r;
            }
            if (largest != i)
            {
                T swap = arr[i];
                arr[i] = arr[largest];
                arr[largest] = swap;

                Heapify(arr, n, largest);
            }
        }
    }
}
