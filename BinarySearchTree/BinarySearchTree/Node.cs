using System;
using System.Collections.Generic;
using System.Text;

namespace BinarySearchTree
{
    class Node<T> where T: IComparable<T>
    {
        public T data { get; set; }
        public Node<T> left { get; set; }
        public Node<T> right { get; set; }

        public Node(T data)
        {
            this.data = data;
        }

        public void Add(T data)
        {
            Node<T> node = new Node<T>(data);
            
            if(node.data.CompareTo(this.data) == -1)
            {
                if(left == null)
                {
                    left = node;
                }
                else
                {
                    left.Add(data);
                }
            }
            else
            {
                if(right == null)
                {
                    right = node;
                }
                else
                {
                    right.Add(data);
                }
            }

        }

    }
}
