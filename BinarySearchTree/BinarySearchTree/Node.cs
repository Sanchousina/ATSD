using System;
using System.Collections.Generic;
using System.Text;

namespace BinarySearchTree
{
    class Node<T>
    {
        public T data { get; set; }
        public Node<T> left { get; set; }
        public Node<T> right { get; set; }

    }
}
