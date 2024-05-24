public class Node
{
    public Node Left { get; set; }
    public Node Right { get; set; }
    public int Data { get; set; }
    public int Height { get; set; }

    public Node(int data)
    {
        Data = data;
        Height = 0;
    }
}

public class Tree
{
    public Node Root;

    // ДОБАВЛЕНИЕ УЗЛА ЧТОБЫ ДЕРЕВО ОСТАВАЛОСЬ ДБП
    public void Add(int data)
    {
        if (Root == null)
        {
            Root = new Node(data);
            return;
        }

        Add(Root, data);
    }

    private void Add(Node node, int data)
    {
        if (data < node.Data)
        {
            if (node.Left == null)
            {
                node.Left = new Node(data);
            }
            else
            {
                Add(node.Left, data);
            }
        }
        else
        {
            if (node.Right == null)
            {
                node.Right = new Node(data);
            }
            else
            {
                Add(node.Right, data);
            }
        }

        UpdateHeight(node);
    }

    // ОБНОВИТЬ ВЫСОТУ УЗЛОВ
    private void UpdateHeight(Node node)
    {
        int leftHeight = node.Left == null ? 0 : node.Left.Height;
        int rightHeight = node.Right == null ? 0 : node.Right.Height;

        node.Height = Math.Max(leftHeight, rightHeight) + 1;
    }

    // ПРОВЕРКА НА СБАЛАНСИРОВАННОСТЬ
    public bool IsBalanced()
    {
        return IsBalanced(Root);
    }

    private bool IsBalanced(Node node)
    {
        if (node == null)
        {
            return true;
        }

        int leftHeight = node.Left == null ? 0 : node.Left.Height;
        int rightHeight = node.Right == null ? 0 : node.Right.Height;

        if (Math.Abs(leftHeight - rightHeight) > 1)
        {
            return false;
        }

        return IsBalanced(node.Left) && IsBalanced(node.Right);
    }

    // МЕТОД ПОЛУЧИТЬ СПИСОК НА ССЫЛКИ С ДИСБАЛАНСОМ
    public List<Tuple<Node, Node>> GetUnbalancedSubtrees()
    {
        return GetUnbalancedSubtrees(Root);
    }

    private List<Tuple<Node, Node>> GetUnbalancedSubtrees(Node node)
    {
        List<Tuple<Node, Node>> unbalancedSubtrees = new List<Tuple<Node, Node>>();

        if (node == null)
        {
            return unbalancedSubtrees;
        }

        // Проверяем, что оба поддерева существуют перед сравнением их высот
        if (node.Left != null && node.Right != null)
        {
            int leftHeight = node.Left.Height;
            int rightHeight = node.Right.Height;

            if (Math.Abs(leftHeight - rightHeight) > 1)
            {
                unbalancedSubtrees.Add(Tuple.Create(node.Left, node.Right));
            }
        }

        // Добавляем результаты рекурсивного вызова для левого и правого поддеревьев
        unbalancedSubtrees.AddRange(GetUnbalancedSubtrees(node.Left));
        unbalancedSubtrees.AddRange(GetUnbalancedSubtrees(node.Right));

        return unbalancedSubtrees;
    }

    // МЕТОД ОПРЕДЕЛЕНИЯ ГЛУБИНЫ УЗЛА
    private int GetDepth(Node root, Node node, int depth)
    {
        if (root == null) return -1;
        if (root == node) return depth;

        int left = GetDepth(root.Left, node, depth + 1);
        if (left != -1) return left;

        return GetDepth(root.Right, node, depth + 1);
    }

    // МЕТОД НАЙТИ УЗЕЛ С МИНИМАЛЬНОЙ ГЛУБИНОЙ В ПОДДЕРЕВЕ
    public Node FindMinDepthNode(Node node)
    {
        if (node == null) return null;

        Queue<Node> queue = new Queue<Node>();
        queue.Enqueue(node);
        Node minDepthNode = node;
        int minDepth = int.MaxValue;

        while (queue.Count > 0)
        {
            Node current = queue.Dequeue();
            int depth = GetDepth(Root, current, 0);

            if (depth < minDepth)
            {
                minDepth = depth;
                minDepthNode = current;
            }

            if (current.Left != null) queue.Enqueue(current.Left);
            if (current.Right != null) queue.Enqueue(current.Right);
        }

        return minDepthNode;
    }

    // МЕТОД УДАЛЕНИЯ УЗЛА
    public void Remove(int data)
    {
        Root = Remove(Root, data);
    }

    private Node Remove(Node node, int data)
    {
        if (node == null) return null;

        if (data < node.Data)
        {
            node.Left = Remove(node.Left, data);
        }
        else if (data > node.Data)
        {
            node.Right = Remove(node.Right, data);
        }
        else
        {
            if (node.Left == null) return node.Right;
            if (node.Right == null) return node.Left;

            Node minLargerNode = GetMin(node.Right);
            node.Data = minLargerNode.Data;
            node.Right = Remove(node.Right, minLargerNode.Data);
        }

        UpdateHeight(node);
        return node;
    }

    private Node GetMin(Node node)
    {
        while (node.Left != null) node = node.Left;
        return node;
    }

    // МЕТОД ВЫВЕСТИ ВЫСОТЫ УЗЛОВ
    public void PrintNodesWithHeight()
    {
        PrintNodesWithHeight(Root);
    }

    private void PrintNodesWithHeight(Node node)
    {
        if (node == null)
        {
            return;
        }

        Console.WriteLine($"{node.Data} ({node.Height})");
        PrintNodesWithHeight(node.Left);
        PrintNodesWithHeight(node.Right);
    }
}
