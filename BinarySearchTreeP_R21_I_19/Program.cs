using System;

namespace BinarySearchTreeP_R21_I_19
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new Tree<int>();
            string input_path = "C:\\siacode_git\\SIACOD\\BinarySearchTreeP_R21_I_19\\input.txt";
            string output_path = "C:\\siacode_git\\SIACOD\\BinarySearchTreeP_R21_I_19\\output.txt";
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
                }
            }

        }
    }
}