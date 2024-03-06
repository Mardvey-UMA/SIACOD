using System;
using System.IO;
using System.Text;
namespace BinarySearchTreeP_R21_I_19
{
    //19. количество узлов, значение которых больше наименьшего четного узла дерева;
    class Program
    {
        public static void FindMinEven(Node<int> Root)
        {
            if (Root != null)
            {
                FindMinEven(Root.Left);
                Console.WriteLine(Root.Left + ", ");
                FindMinEven(Root.Right);
            }
        }
        /*            Node<int> min_node = new Node<int>(100000);
                    Node<int> curr_nodeL = Root.Left;
                    Node<int> curr_nodeR = Root.Right;
                    if (curr_nodeL.Data % 2 == 0 && curr_nodeL.CompareTo(min_node) < 0)
                    {
                        min_node = curr_nodeL;
                        return FindMinEven(min_node);
                    }else if (curr_nodeR.Data % 2 == 0 && curr_nodeR.CompareTo(min_node) < 0)
                    {
                        min_node = curr_nodeR;
                        return FindMinEven(min_node);
                    }else if (min_node.Left == null || min_node.Right == null)
                    {
                        return min_node;
                    }
                    return min_node;*/


        public static void CountGreater(Node<int> node, Node<int> min_node, ref int count) {
        if (node == null) return;
        CountGreater(node.Left, min_node, ref count);
        if (node.Data > min_node.Data)
            {
                count++;
            }
        CountGreater(node.Right, min_node, ref count);
        }
        static void Main(string[] args)
        {
            var tree = new Tree<int>();
            string input_path = "C:\\siacode\\SIACOD\\BinarySearchTreeP_R21_I_19\\input.txt";
            string output_path = "C:\\siacode\\SIACOD\\BinarySearchTreeP_R21_I_19\\output.txt";
            using(StreamReader reader = new StreamReader(input_path)){
                using(StreamWriter writer = new StreamWriter(output_path)){
                    string line;
                    int current;
                    while ((line = reader.ReadLine())!= null)
                    {
                        current = Convert.ToInt32(line);
                        tree.Add(current);
                    }
                foreach(var item in tree.Preorder())
                {
                    writer.Write(item + ", ");
                }
                    int count = 0;
                    FindMinEven(tree.Root);
                    /*CountGreater(tree.Root, mn, ref count);
                    writer.WriteLine($"\nКол-во узлов, больше чем {mn.Data}:");
                    writer.Write(count.ToString());*/
                    //var f = FindMinEven(tree.Root);
                    //Console.WriteLine(f.Data);
                    //Console.WriteLine(f.Left.Data);
                    /// Console.WriteLine(f.Right.Data);
                }
            }
        }
    }
}