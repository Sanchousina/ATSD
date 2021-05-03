using System;
using System.Collections.Generic;
using System.Text;

namespace HeapSort_lb3
{
    class ArrayList<T> where T: IComparable<T>
    {
        private T[] arr;
        private int length;
        
        public ArrayList(T[] arr)
        {
            this.arr = arr;
            length = arr.Length;
        }
    }
}
