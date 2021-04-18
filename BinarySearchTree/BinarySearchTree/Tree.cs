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

        private Node<T> Delete(Node<T> root, T data)
        {
            if (root == null)
            {
                return root;
            }
            if (data.CompareTo(root.data) == -1)
            {
                root.left = Delete(root.left, data);
            }
            else if (data.CompareTo(root.data) == 1)
            {
                root.right = Delete(root.right, data);
            }
            else
            {
                if (root.left == null) return root.right;
                else if (root.right == null) return root.left;

                root.data = minRightValue(root.right);

                root.right = Delete(root.right, root.data);
            }
            return root;
        }

        private T minRightValue(Node<T> node)
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
            Console.WriteLine();
        }


        //It count the number of left son nodes in a BBST.
        public int CountNode()
        {
            int res = 0;
            res += CountNode(root);
            return res;
        }
        private int CountNode(Node<T> current,int res = 0)
        {
            if(current != null)
            {
                if (current.left != null) res += 1;

                if (current.right != null)
                    res = CountNode(current.right, res);

                res = CountNode(current.left, res);
            }
          
            return res;
        }


        //It finds the sum of keys in right son nodes in a BBST.
        public int SumKeys()
        {
            int sum = 0;
            sum += SumKeys(root);
            sum += SumKeys(root.left);
            return sum;
        }
        private int SumKeys(Node<T> root)
        {
            int sum = 0;
            while(root.right != null)
            {
                sum += Convert.ToInt32(root.right.data);   //????
                root = root.right;
            }
            return sum;
        }


        //It deletes all even keys from a BBST
        public void DeleteEven()
        {
            T[] arr = Postorder().ToArray();
            for(int i = 0; i < arr.Length; i++)
            {
                if(!(Convert.ToInt32(arr[i])%2 == 0))
                {
                    Delete(arr[i]);
                }
            }
        }


        //It returns the tree key which is the nearest to the Valuemid = (keymin + keymax) / 2
        public int FindMiddle()
        {
            int keymin = Convert.ToInt32(FindMin(root));
            int keymax = Convert.ToInt32(FindMax(root));
            int valuemid = (keymin + keymax) / 2;
            
            T[] arr = Inorder().ToArray();
            int mid = Convert.ToInt32(arr[0]);
            int temp = Math.Abs(Convert.ToInt32(arr[0]) - valuemid); 
            for(int i = 0; i < arr.Length; i++)
            {
                if (Math.Abs(Convert.ToInt32(arr[i]) - valuemid) <= temp)
                {
                    temp = Math.Abs(Convert.ToInt32(arr[i]) - valuemid);
                    mid = Convert.ToInt32(arr[i]);
                }
                
            }
            return mid;
        }

        private T FindMin(Node<T> root)
        {
            T min = root.data;
            while(root.left != null)
            {
                min = root.left.data;
                root = root.left;
            }
            return min;
        }

        private T FindMax(Node<T> root)
        {
            T max = root.data;
            while (root.right != null)
            {
                max = root.right.data;
                root = root.right;
            }
            return max;
        }
    }
}
