using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class HuffmanNode
{
    public char Symbol { get; set; }

    // Частота символа
    public int Frequency { get; set; }

    public HuffmanNode Left { get; set; }

    public HuffmanNode Right { get; set; }

    // Метод для обхода дерева и поиска пути до заданного символа
    public List<bool> Traverse(char symbol, List<bool> data)
    {
        // Если текущий узел листовой (не имеет детей)
        if (Right == null && Left == null)
        {
            // Если символ текущего узла равен искомому
            if (symbol.Equals(Symbol))
            {
                return data;
            }
            else
            {
                return null;
            }
        }
        else
        {
            List<bool> left = null;
            List<bool> right = null;

            // Рекурсивный обход левого поддерева
            if (Left != null)
            {
                List<bool> leftPath = new List<bool>();
                leftPath.AddRange(data);
                leftPath.Add(false);

                left = Left.Traverse(symbol, leftPath);
            }

            // Рекурсивный обход правого поддерева
            if (Right != null)
            {
                List<bool> rightPath = new List<bool>();
                rightPath.AddRange(data);
                rightPath.Add(true);

                right = Right.Traverse(symbol, rightPath);
            }

            // Возврат пути
            if (left != null)
            {
                return left;
            }
            else
            {
                return right;
            }
        }
    }
}
public class HuffmanTree
{
    // Список всех узлов дерева Хаффмана
    private List<HuffmanNode> nodes = new List<HuffmanNode>();

    // Корневой узел дерева
    public HuffmanNode Root { get; set; }

    // Словарь для хранения частот символов
    public Dictionary<char, int> Frequencies = new Dictionary<char, int>();

    // Словарь для хранения кодов символов
    public Dictionary<char, string> Codes = new Dictionary<char, string>();

    // Метод для построения дерева Хаффмана
    public void Build(string source)
    {
        // Подсчет частот каждого символа в исходной строке
        for (int i = 0; i < source.Length; i++)
        {
            if (!Frequencies.ContainsKey(source[i]))
            {
                Frequencies.Add(source[i], 0);
            }

            Frequencies[source[i]]++;
        }

        // Создание узлов для каждого символа
        foreach (KeyValuePair<char, int> symbol in Frequencies)
        {
            nodes.Add(new HuffmanNode() { Symbol = symbol.Key, Frequency = symbol.Value });
        }

        // Построение дерева Хаффмана
        while (nodes.Count > 1)
        {
            // Упорядочивание узлов по частоте
            List<HuffmanNode> orderedNodes = nodes.OrderBy(node => node.Frequency).ToList<HuffmanNode>();

            if (orderedNodes.Count >= 2)
            {
                // Выбор двух узлов с наименьшей частотой
                List<HuffmanNode> taken = orderedNodes.Take(2).ToList<HuffmanNode>();

                // Создание родительского узла для этих двух узлов
                HuffmanNode parent = new HuffmanNode()
                {
                    Symbol = '*',
                    Frequency = taken[0].Frequency + taken[1].Frequency,
                    Left = taken[0],
                    Right = taken[1]
                };

                // Удаление двух узлов и добавление родительского узла
                nodes.Remove(taken[0]);
                nodes.Remove(taken[1]);
                nodes.Add(parent);
            }

            // Обновление корневого узла
            this.Root = nodes.FirstOrDefault();
        }

        // Заполнение словаря кодов символов
        foreach (var symbol in Frequencies.Keys)
        {
            var code = this.Root.Traverse(symbol, new List<bool>());
            Codes[symbol] = string.Join("", code.Select(b => b ? "1" : "0"));
        }
    }

    // Метод для кодирования строки
    public BitArray Encode(string source)
    {
        List<bool> encodedSource = new List<bool>();

        for (int i = 0; i < source.Length; i++)
        {
            List<bool> encodedSymbol = this.Root.Traverse(source[i], new List<bool>());
            encodedSource.AddRange(encodedSymbol);
        }

        BitArray bits = new BitArray(encodedSource.ToArray());
        return bits;
    }

    // Метод для декодирования битовой последовательности
    public string Decode(BitArray bits)
    {
        HuffmanNode current = this.Root;
        string decoded = "";

        foreach (bool bit in bits)
        {
            if (bit)
            {
                if (current.Right != null)
                {
                    current = current.Right;
                }
            }
            else
            {
                if (current.Left != null)
                {
                    current = current.Left;
                }
            }

            if (IsLeaf(current))
            {
                decoded += current.Symbol;
                current = this.Root;
            }
        }

        return decoded;
    }

    // Метод для проверки, является ли узел листом
    public bool IsLeaf(HuffmanNode node)
    {
        return (node.Left == null && node.Right == null);
    }

    // Метод для печати дерева Хаффмана
    public void PrintTree(HuffmanNode node, string indent = "")
    {
        // Проверка, что узел не пустой
        if (node != null)
        {
            // Рекурсивный вызов для правого поддерева с увеличением отступа
            PrintTree(node.Right, indent + "   ");

            // Вывод текущего узла
            Console.WriteLine(indent + node.Symbol + " (" + node.Frequency + ")");

            // Рекурсивный вызов для левого поддерева с увеличением отступа
            PrintTree(node.Left, indent + "   ");
        }
    }

    // Метод для печати кодов символов
    public void PrintCodes()
    {
        foreach (var symbol in Codes)
        {
            Console.WriteLine($"{symbol.Key}: {symbol.Value}");
        }
    }

    // Метод для прямого обхода дерева (префиксный обход)
    public void PreOrderTraversal(HuffmanNode node)
    {
        if (node != null)
        {
            // Вывод текущего узла
            Console.WriteLine(node.Symbol + " (" + node.Frequency + ")");

            // Рекурсивный вызов для левого поддерева
            PreOrderTraversal(node.Left);

            // Рекурсивный вызов для правого поддерева
            PreOrderTraversal(node.Right);
        }
    }

    // Метод для симметричного обхода дерева (инфиксный обход)
    public void InOrderTraversal(HuffmanNode node)
    {
        if (node != null)
        {
            // Рекурсивный вызов для левого поддерева
            InOrderTraversal(node.Left);

            // Вывод текущего узла
            Console.WriteLine(node.Symbol + " (" + node.Frequency + ")");

            // Рекурсивный вызов для правого поддерева
            InOrderTraversal(node.Right);
        }
    }
}
