﻿using System;
using System.IO;
using System.Text;
namespace BinarySearchTreeP_R21_I_19
{
    //19. количество узлов, значение которых больше наименьшего четного узла дерева;
    class Program
    {
        public static void Solution(Node<int> Root, ref bool flag, ref int min_val, ref int count)
        {
            if (Root != null)
            {
                if (flag && Root.Data > min_val)
                {
                    count++;
                }
                if (Root.Data % 2 == 0 && flag == false)
                {
                    flag = true;
                    min_val = Root.Data;
                }
                Solution(Root.Left, ref flag, ref min_val, ref count);
                Solution(Root.Right, ref flag, ref min_val, ref count);
            }
        }

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
            string input_path = "C:\\siacode_git\\SIACOD\\BinarySearchTreeP_R21_I_19\\input.txt";
            string output_path = "C:\\siacode_git\\SIACOD\\BinarySearchTreeP_R21_I_19\\output.txt";
            //string input_path = "C:\\siacode\\SIACOD\\BinarySearchTreeP_R21_I_19\\input.txt";
            //string output_path = "C:\\siacode\\SIACOD\\BinarySearchTreeP_R21_I_19\\output.txt";
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
                    writer.WriteLine();
                    int count = 0, min_val = 0;
                    bool flag = false;
                    Solution(tree.Root, ref flag, ref min_val, ref count);
                    writer.Write($"Кол-во больше чем {min_val}:\n");
                    writer.WriteLine(count.ToString());
                }
            }
        }
    }
}