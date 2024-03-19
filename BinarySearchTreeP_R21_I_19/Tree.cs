using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTreeP_R21_I_19
{
    class Tree<T>
        where T : IComparable, IComparable<T>
    {
        public Node<T> Root;
        public int Count { get; private set; }

        private Tree(Node<T> r){
            this.Root = r;
        }
        public Tree()
        {
            this.Root = null;
        }
        public void Add(T data)
        {
            if (this.Root == null)
            {
                this.Root = new Node<T>(data);
                Count = 1;
                return;
            }
            this.Root.Add(data);
            Count++;
        }
        public List<T> Preorder()
        {
            if (this.Root == null)
            {
                return new List<T>();
            }

            return Preorder(this.Root);
        }

        private List<T> Preorder(Node<T> node)
        {
            var list = new List<T>();
            if (node != null)
            {
                list.Add(node.Data);
                if (node.Left != null)
                {
                    list.AddRange(Preorder(node.Left));
                }
                if (node.Right != null)
                {
                    list.AddRange(Preorder(node.Right));
                }
            }
            return list;
        }
        private static void Del_Node(Node<T> R, ref Node<T> del_node)
        {
            if (del_node.Right != null)
            {
                Del_Node(R, ref del_node.Right);
            }
            else
            {
                R.Data = del_node.Data;
                del_node = R.Left;
            }
        }
        public static void Del_Value(ref Node<T> R, T key)
        {
            if (R == null)
            {
                throw new Exception("Not exist value");
            }
            else
            {
                if (R.Data.CompareTo(key) > 0)
                {
                    Del_Value(ref R.Left, key);
                }
                else
                {
                    if (R.Data.CompareTo(key) < 0)
                    {
                        Del_Value(ref R.Right, key);
                    }
                    else
                    {
                        if (R.Left == null)
                        {
                            R = R.Right;
                        }
                        else
                        {
                            if (R.Right == null)
                            {
                                R = R.Left;
                            }
                            else
                            {
                                Del_Node(R, ref R.Left);
                            }
                        }
                    }
                }
            }
        }
        ////
        public int GetHeight(Node<T> node)
        {
            if (node == null) return 0;
            return 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));
        }
        ////
        private int GetHeight()
        {
            return this.GetHeight(Root);
        }

        ////
        public void DeleteBelow(Node<T> node, int k, int currentLevel)
        {
            if (node != null)
            {
                if (currentLevel == k)
                {
                    //Console.WriteLine(currentLevel.ToString() + " " + " " + node.Data);
                    node.Right = null;
                    node.Left = null;
                }
                else
                {
                    DeleteBelow(node.Left, k, currentLevel + 1);
                    DeleteBelow(node.Right, k, currentLevel + 1);
                }
            }
        }

        public void JoinTree(ref Tree<T> joinedTree){
            joinedTree = new Tree<T>(Node<T>.JoinTree(this.Root, joinedTree.Root));
        }
        
        public void InsertToRoot(T item){
            Node<T>.InsertToRoot(ref this.Root, item);
        }
    }
        /*public void DeleteBelow(Node<T> node, int k, int treeHeight)
        {
            if (node == null || k < 1)
            {
                return;
            }

            int nodeLevel = treeHeight - GetHeight(node) + 1;
            
            if (nodeLevel == k)
            {
                Console.WriteLine(nodeLevel.ToString() + " " + " " + node.Data);
                node.Right = null;
                node.Left = null;
            }
                DeleteBelow(node.Left, k, treeHeight);
                DeleteBelow(node.Right, k, treeHeight);
        }*/

}
