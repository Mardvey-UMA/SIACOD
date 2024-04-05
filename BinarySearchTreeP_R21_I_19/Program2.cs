/*using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//19. удалить из дерева все узлы лежащие ниже k-того уровня так, чтобы дерево осталось
//деревом бинарного поиска;
namespace BinarySearchTreeP_R21_I_19
{
    class Program2
    {
        static void Main(string[] args)
        {
            var memory = 0.0;
            //using (Process proc = Process.GetCurrentProcess())
            //{
            var tree = new Tree<int>();
            string input_path = "C:\\siacode_git\\SIACOD\\BinarySearchTreeP_R21_I_19\\input2.txt";
            string output_path = "C:\\siacode_git\\SIACOD\\BinarySearchTreeP_R21_I_19\\output2.txt";
            //string input_path = "C:\\siacode\\SIACOD\\BinarySearchTreeP_R21_I_19\\input2.txt";
            //string output_path = "C:\\siacode\\SIACOD\\BinarySearchTreeP_R21_I_19\\output.txt";
            using (StreamReader reader = new StreamReader(input_path))
            {
                using (StreamWriter writer = new StreamWriter(output_path))
                {
                    string line;
                    int current;
                    while ((line = reader.ReadLine()) != null)
                    {
                        current = Convert.ToInt32(line);
                        tree.Add(current);
                    }
                    foreach (var item in tree.Preorder())
                    {
                        writer.Write(item + " ");
                    }
                    Console.WriteLine("Memory used before collection:       {0:N0}",
                        GC.GetTotalMemory(false));

                    int k = 2;
                    tree.DeleteBelow(tree.Root, k, 1);
                    writer.Write("\n---------\n");
                    GC.Collect();
                    Console.WriteLine("Memory used after full collection:   {0:N0}",
                        GC.GetTotalMemory(true));
                    foreach (var item in tree.Preorder())
                    {
                        writer.Write(item + " ");
                    }
                }
            }
            //memory = proc.PrivateMemorySize64 / (1024 * 1024);
            //Console.WriteLine("Total used:" + memory.ToString() + " mbyte");
            //System.GC.Collect();
            //memory = proc.PrivateMemorySize64 / (1024 * 1024);
            //Console.WriteLine("Total used:" + memory.ToString() + " mbyte");
            //}

        }
    }


}
*/