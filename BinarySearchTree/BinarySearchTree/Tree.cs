﻿using System;
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
            count = 0;
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

        /* public void Add(T data)
         {
             if (root == null)
             {
                 root = new Node<T>(data);
                 count++;
                 return;
             }

             root.Add(data);
             count++;
         }*/

        public void Add(T data)
        {
            if (!Search(data))
            {
                root = addRec(data, root);
                count++;
            }
            else
            {
                Console.WriteLine(data + " already exists in the tree, so it can not be added");
            }
        }

        private Node<T> addRec(T data, Node<T> p)
        {
            if (p == null)
            {
                p = new Node<T>(data);
            }
            else if (data.CompareTo(p.data) == -1)
            {
                p.left = addRec(data, p.left);
            }
            else
            {
                p.right = addRec(data, p.right);
            }

            p = Balance(p);
            return p;
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


        //extra tasks

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
            return sum;
        }
        private int SumKeys(Node<T> current, int sum = 0)
        {
            if (current != null)
            {
                if (current.right != null)
                    sum += Convert.ToInt32(current.right.data);

                if (current.left != null)
                    sum = SumKeys(current.left, sum);

                sum = SumKeys(current.right, sum);
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


        //It returns the second largest key of a BBST without deleting it.
        public int SecondLargest()
        {
            int res = SecondLargest(root);
            return res;
        }
        private int SecondLargest(Node<T> current)
        {
            Node<T> secondMax = current;
            Node<T> max = current.right;
            while(max.right != null)
            {
                secondMax = max;
                max = max.right;
            }
            if(max.left != null)
            {
                secondMax = max.left;
            }

            return Convert.ToInt32(secondMax.data);
        }


        //It creates and returns a copy of a given BBST.
        public Tree<T> Copy(Tree<T> tree)
        {
            Tree<T> newTree = new Tree<T>();
            T [] arr = tree.Preorder().ToArray();
            for(int i = 0; i < arr.Length; i++)
            {
                newTree.Add(arr[i]);
            }
            return newTree;
        }


        //It inserts al keys of BBST2 into a BBST1
        public void Insert(Tree<T> tree2)
        {
            T[] arr = tree2.Preorder().ToArray();
            for(int i = 0; i < arr.Length; i++)
            {
                if (!Search(arr[i]))
                {
                    Add(arr[i]);
                }
            }
        }


        //It determines if all keys of BBST2 are contained in BBST1. If so it returns true, otherwise false.
        public bool Contains(Tree<T> tree2)
        {
            bool check = true;
            T[] arr = tree2.Preorder().ToArray();

            for(int i = 0; i < arr.Length; i++)
            {
                if (!Search(arr[i]))
                    check = false;
            }

            return check;
        }


        //It returns true if the calling object is a balanced binary search tree, otherwise false.
        public bool isBalanced()
        {
            return Math.Abs(Height(root.left) - Height(root.right)) <= 1;
        }


        private bool isBalanced(Node<T> root)
        {
            return Math.Abs(Height(root.left) - Height(root.right)) <= 1;
        }

        private int Height(Node<T> root)
        {
            if (root == null)
            { 
                return -1; 
            }
            if (root.left == null && root.right == null)
            { 
                return 0;
            }
            else if (root.right == null || Height(root.left) > Height(root.right))
            {
                return Height(root.left) + 1;
            }
            else
                return Height(root.right) + 1;
        }


        private Node<T> RightRotation(Node<T> root)
        {
            if(root.left != null)
            {
                Node<T> newRoot = root.left;
                root.left = newRoot.right;
                newRoot.right = root;
                return newRoot;
            }
            else
            {
                Console.Write("\nThere is no left subtree of given node,so right rotation can not be done!\n");
                return null;
            }
        }

        private Node<T> LeftRotation(Node<T> root)
        {
            if (root.right != null)
            {
                Node<T> newRoot = root.right;
                root.right = newRoot.left;
                newRoot.left = root;
                return newRoot;
            }
            else
            {
                Console.Write("\nThere is no right subtree of given node,so left rotation can not be done!\n");
                return null;
            }
        }

        private Node<T> LeftRightRotation(Node<T> root)
        {
            root.left = LeftRotation(root.left);
            root = RightRotation(root);
            return root;
        }

        private Node<T> RightLeftRotation(Node<T> root)
        {
            root.right = RightRotation(root.right);
            root = LeftRotation(root);
            return root;
        }


        public Node<T> Balance(Node<T> root)
        {
            if (isBalanced(root))
            {
                //Console.WriteLine("The tree is already balanced");
                return root;
            }
              else  if (Height(root.right) > Height(root.left))
                {
                    if (root.right.right != null)
                        return LeftRotation(root);
                    else
                        return RightLeftRotation(root);                   
                }
                else
                {
                    if (root.left.left != null)                
                        return RightRotation(root);                   
                    else
                        return LeftRightRotation(root);                    
                }
        }
    }
}
