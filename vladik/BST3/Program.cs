class Program2
{
    static void Main(string[] args)
    {
        var tree = new Tree();
        string input_path = "P:\\siacode_git\\SIACOD\\vladik\\BST3\\input.txt";
        string output_path = "P:\\siacode_git\\SIACOD\\vladik\\BST3\\output.txt";
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
                if (tree.IsBalanced())
                {
                    writer.Write("дерево уже сбалансированно");
                }
                else
                {
                    List<Tuple<Node, Node>> unbalanced_list = tree.GetUnbalancedSubtrees();
                    Tuple<Node, Node> subtree = unbalanced_list[0];

                    Node nodeToRemove = null;
                    if (subtree.Item1.Height > subtree.Item2.Height)
                    {
                        // Удаляем узел с минимальной глубиной в левом поддереве
                        nodeToRemove = tree.FindMinDepthNode(subtree.Item1);
                    }
                    else
                    {
                        // Удаляем узел с минимальной глубиной в правом поддереве
                        nodeToRemove = tree.FindMinDepthNode(subtree.Item2);
                    }

                    if (nodeToRemove != null)
                    {
                        tree.Remove(nodeToRemove.Data);
                        writer.WriteLine($"Для балансировки дерева необходимо удалить элемент {nodeToRemove.Data}");
                    }
                    else
                    {
                        writer.WriteLine("Не удалось найти узел для удаления.");
                    }
                }
            }
        }
    }
}
