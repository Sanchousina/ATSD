using System;
using System.Collections.Generic;
using System.Text;

namespace BinarySearchTree
{
    class Tree<T> where T: IComparable<T>
    {
        private Node<T> root;
        private int count;

        public Tree()
        {
            root = null;
            count = 0;
        }

        public bool isFull()
        {
            return false;
        }

        public void MakeEmpty()
        {
            root = null;
        }

        public bool isEmpty()
        {
            return root == null;
        }

        public int Size()
        {
            return count;
        }

        public bool Search(T data)
        {
            if(root != null)
            {
                if (data.CompareTo(root.data) == 0) return true;
                else return Search(root, data);
            }
            return false;
        }

        private bool Search(Node<T> node, T data)
        {
            if(node != null)
            {
                if (data.CompareTo(node.data) == 0) return true;
                else if(data.CompareTo(node.data) == -1)
                {
                    return Search(node.left, data);
                }
                else
                {
                   return  Search(node.right, data);
                }
            }
            return false;
        }

        public void Add(T data)
        {
            if(root == null)
            {
                root = new Node<T>(data);
                count++;
                return;
            }

            root.Add(data);
            count++;
        }

        public List<T> Preorder()
        {         
            if(root == null)
            {
                return new List<T>();
            }

            return Preorder(root);
        }

        public List<T> Postorder()
        {
            if (root == null)
            {
                return new List<T>();
            }

            return Postorder(root);
        }

        public List<T> Inorder()
        {
            if (root == null)
            {
                return new List<T>();
            }

            return Inorder(root);
        }

        private List<T> Preorder(Node<T> node)
        {
            List<T> list = new List<T>();

            if(node != null)
            {
                list.Add(node.data);

                if(node.left != null)
                {
                    list.AddRange(Preorder(node.left));
                }

                if(node.right != null)
                {
                    list.AddRange(Preorder(node.right));
                }
            }
            return list;
        }

        private List<T> Postorder(Node<T> node)
        {
            List<T> list = new List<T>();

            if (node != null)
            {
                if (node.left != null)
                {
                    list.AddRange(Postorder(node.left));
                }

                if (node.right != null)
                {
                    list.AddRange(Postorder(node.right));
                }

                list.Add(node.data);
            }
            return list;
        }

        private List<T> Inorder(Node<T> node)
        {
            List<T> list = new List<T>();

            if (node != null)
            {
                if (node.left != null)
                {
                    list.AddRange(Inorder(node.left));
                }

                list.Add(node.data);

                if (node.right != null)
                {
                    list.AddRange(Inorder(node.right));
                }
            }
            return list;
        }

        public void Delete(T data)
        {
            root = Delete(root, data);
        }

        private Node<T> Delete (Node<T> root, T data)
        {
            if (root == null)
            {
                return root;
            }
            if(data.CompareTo(root.data) == -1)
            {
                root.left = Delete(root.left, data);
            }
            if (data.CompareTo(root.data) == 1)
            {
                root.right = Delete(root.right, data);
            }
            else
            {
                if (root.left == null) return root.right;
                else if (root.right == null) return root.left;

                root.data = minValue(root.right);

                root.right = Delete(root.right, root.data);
            }
            return root;
        }

        private T minValue(Node<T> node)
        {
            T min = node.data;
            while(node.left != null)
            {
                min = node.left.data;
                node = node.left;
            }
            return min;
        }

        public void PrintSorted()
        {
            T[] arr= Inorder().ToArray();
            for(int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();

            Array.Reverse(arr);
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
        }
    }
}
