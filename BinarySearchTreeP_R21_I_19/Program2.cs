/*using System;
using System.Collections.Generic;
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
            var tree = new Tree<int>();
            string input_path = "C:\\siacode_git\\SIACOD\\BinarySearchTreeP_R21_I_19\\input.txt";
            string output_path = "C:\\siacode_git\\SIACOD\\BinarySearchTreeP_R21_I_19\\output.txt";
            //string input_path = "C:\\siacode\\SIACOD\\BinarySearchTreeP_R21_I_19\\input.txt";
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
                    int k = 3;
                    tree.DeleteBelow(tree.Root, k, 1);

                    writer.Write("\n---------\n");

                    foreach (var item in tree.Preorder())
                    {
                       writer.Write(item + " ");
                    }
                }
            }
        }
    }
}
*/