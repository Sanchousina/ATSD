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

        public void AddUnsorted(T item)
        {
            arr[last + 1] = item;
            last++;
        }

        public int SearchForIndex(T item)
        {
            int k = -1;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].CompareTo(item) == 0)
                    k = i;
            }
            return k;
        }

        public object Delete(T item)
        {
            if (!isEmpty())
            {
                int k = SearchForIndex(item);

                if (k == -1) Console.WriteLine("The element was not found");
                else
                {
                    object dataReturned = arr[k];

                    arr[k] = arr[last--];
                    for (int i = k + 1; i < last + 1; i++)
                    {
                        T temp = arr[i];
                        arr[i] = arr[k];
                        arr[k] = temp;
                        k++;
                    }

                    return dataReturned;
                }
            }
            else

                Console.WriteLine("List is empty");
            return -1000;

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

        public void HeapSort()
        {
            int n = arr.Length;

            for (int i = n / 2 - 1; i >= 0; i--)
            {
                Heapify(arr, n, i);
            }

            for (int i = n - 1; i > 0; i--)
            {
                T temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;

                Heapify(arr, i, 0);
            }
        }

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

        public T DeleteTop()
        {

        }
    }
}
