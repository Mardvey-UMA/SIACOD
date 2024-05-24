using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections;

namespace HaffmanCode
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Ввод строки для кодирования
            Console.WriteLine("Введите строку для кодирования:");
            string input = Console.ReadLine();

            // Создание и построение дерева Хаффмана
            HuffmanTree huffmanTree = new HuffmanTree();
            huffmanTree.Build(input);

            // Вывод частот символов
            Console.WriteLine("Частоты символов:");
            foreach (var symbol in huffmanTree.Frequencies)
            {
                Console.WriteLine($"{symbol.Key}: {symbol.Value}");
            }

            // Вывод кодов символов
            Console.WriteLine("Коды символов:");
            huffmanTree.PrintCodes();

            // Кодирование строки
            BitArray encoded = huffmanTree.Encode(input);

            // Вывод закодированной строки
            Console.WriteLine("Закодированная строка:");
            foreach (bool bit in encoded)
            {
                Console.Write((bit ? 1 : 0) + "");
            }
            Console.WriteLine();

            // Декодирование закодированной строки
            string decoded = huffmanTree.Decode(encoded);
            Console.WriteLine("Декодированная строка:");
            Console.WriteLine(decoded);

            // Ввод закодированной строки для декодирования
            Console.WriteLine("Введите закодированную строку для декодирования (например, 010101):");
            string encodedInput = Console.ReadLine();
            BitArray encodedBits = new BitArray(encodedInput.Select(c => c == '1').ToArray());
            string customDecoded = huffmanTree.Decode(encodedBits);
            Console.WriteLine("Декодированная строка:");
            Console.WriteLine(customDecoded);

            // Печать дерева Хаффмана
            Console.WriteLine("Дерево Хаффмана:");
            huffmanTree.PrintTree(huffmanTree.Root);

            // Прямой обход дерева
            Console.WriteLine("Прямой обход дерева:");
            huffmanTree.PreOrderTraversal(huffmanTree.Root);

            // Симметричный обход дерева
            Console.WriteLine("Симметричный обход дерева:");
            huffmanTree.InOrderTraversal(huffmanTree.Root);
        }
    }


}
