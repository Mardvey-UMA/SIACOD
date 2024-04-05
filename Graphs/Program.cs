using System;
using System.IO;
using System.Xml.Linq;
using System;
using System.Collections.Generic;
namespace ClassG
{
    public class Graph
    {
        private class Node //вложенный класс для скрытия данных и алгоритмов
        {
            private int[,] array; //матрица смежности
            public int this[int i, int j] //индексатор для обращения к матрице смежности
            {
                get
                {
                    return array[i, j];
                }
                set
                {
                    array[i, j] = value;
                }
            }
            public int Size //свойство для получения размерности матрицы смежности
            {
                get
                {
                    return array.GetLength(0);
                }
            }
            private bool[] nov; //вспомогательный массив: если i-ый элемент массива равен
                                //true, то i-ая вершина еще не просмотрена; если i-ый
                                //элемент равен false, то i-ая вершина просмотрена
            public void NovSet() //метод помечает все вершины графа как непросмотреные
            {
                for (int i = 0; i < Size; i++)
                {
                    nov[i] = true;
                }
            }
            //конструктор вложенного класса, инициализирует матрицу смежности и
            // вспомогательный массив
            public Node(int[,] a)
            {
                array = a;
                nov = new bool[a.GetLength(0)];
            }
//реализация алгоритма обхода графа в глубину
public void Dfs(int v)
            {
                Console.Write("{0} ", v); //просматриваем текущую вершину
                nov[v] = false; //помечаем ее как просмотренную
                                // в матрице смежности просматриваем строку с номером v
                for (int u = 0; u < Size; u++)
                {
                    //если вершины v и u смежные, к тому же вершина u не просмотрена,
                    if (array[v, u] != 0 && nov[u])
                    {
                        Dfs(u); // то рекурсивно просматриваем вершину
                    }
                }
            }
            //реализация алгоритма обхода графа в ширину
            public void Bfs(int v)
            {
                Queue<int> q = new Queue<int>(); // инициализируем очередь
                q.Enqueue(v); //помещаем вершину v в очередь
                nov[v] = false; // помечаем вершину v как просмотренную
                while (q.Count != 0) // пока очередь не пуста
                {
                    v = q.Dequeue(); //извлекаем вершину из очереди
                    Console.Write("{0} ", v); //просматриваем ее
                    for (int u = 0; u < Size; u++) //находим все вершины
                    {
                        if (array[v, u] != 0 && nov[u]) // смежные с данной и еще не просмотренные
                        {
                            q.Enqueue(u); //помещаем их в очередь
                            nov[u] = false; //и помечаем как просмотренные
                        }
                    }
                }
            }
            //реализация алгоритма Дейкстры
            public long[] Dijkstr(int v, out int[] p)
            {
                nov[v] = false; // помечаем вершину v как просмотренную
                                //создаем матрицу с
                int[,] c = new int[Size, Size];
                for (int i = 0; i < Size; i++)
                {
                    for (int u = 0; u < Size; u++)
                    {
                        if (array[i, u] == 0 || i == u)
                        {
                            c[i, u] = int.MaxValue;
                        }
                        else
                        {
                            c[i, u] = array[i, u];
                        }
                    }
                }
                //создаем матрицы d и p
                long[] d = new long[Size];
                p = new int[Size];
                for (int u = 0; u < Size; u++)
                {
                    if (u != v)
                    {
                        d[u] = c[v, u];
                        p[u] = v;
                    }
                }
                for (int i = 0; i < Size - 1; i++) // на каждом шаге цикла
                {
                    // выбираем из множества V\S такую вершину w, что D[w] минимально
                    long min = int.MaxValue;
                    int w = 0;
                    for (int u = 0; u < Size; u++)
                    {
                        if (nov[u] && min > d[u])
                        {
                            min = d[u];
                            w = u;
                        }
                    }
                    nov[w] = false; //помещаем w в множество S
                                    //для каждой вершины из множества V\S определяем кратчайший путь от
                                    // источника до этой вершины
                    for (int u = 0; u < Size; u++)
                    {
                        long distance = d[w] + c[w, u];
                        if (nov[u] && d[u] > distance)
                        {
                            d[u] = distance;
                            p[u] = w;
                        }
                    }
                }
                return d; //в качестве результата возвращаем массив кратчайших путей для
            } //заданного источника
              //восстановление пути от вершины a до вершины b для алгоритма Дейкстры
            public void WayDijkstr(int a, int b, int[] p, ref Stack<int> items)
            {
                items.Push(b); //помещаем вершину b в стек
                if (a == p[b]) //если предыдущей для вершины b является вершина а, то
                {
                    items.Push(a); //помещаем а в стек и завершаем восстановление пути
                }
                else //иначе метод рекурсивно вызывает сам себя для поиска пути
                { //от вершины а до вершины, предшествующей вершине b
                    WayDijkstr(a, p[b], p, ref items);
                }
            }

            //реализация алгоритма Флойда
            public long[,] Floyd(out int[,] p)
            {
                int i, j, k;
                //создаем массивы р и а
                long[,] a = new long[Size, Size];
                p = new int[Size, Size];
                for (i = 0; i < Size; i++)
                {
                    for (j = 0; j < Size; j++)
                    {
                        if (i == j)
                        {
                            a[i, j] = 0;
                        }
                        else
                        {
                            if (array[i, j] == 0)
                            {
                                a[i, j] = int.MaxValue;
                            }
                            else
                            {
                                a[i, j] = array[i, j];
                            }
                        }
                        p[i, j] = -1;
                    }
                }
                //осуществляем поиск кратчайших путей
                for (k = 0; k < Size; k++)
                {
                    for (i = 0; i < Size; i++)
                    {
                        for (j = 0; j < Size; j++)
                        {
                            long distance = a[i, k] + a[k, j];
                            if (a[i, j] > distance)
                            {
                                a[i, j] = distance;
                                p[i, j] = k;
                            }
                        }
                    }
                }
                return a;//в качестве результата возвращаем массив кратчайших путей между
            } //всеми парами вершин
              //восстановление пути от вершины a до вершины в для алгоритма Флойда
            public void WayFloyd(int a, int b, int[,] p, ref Queue<int> items)
{
int k = p[a, b];
//если k<> -1, то путь состоит более чем из двух вершин а и b, и проходит через
//вершину k, поэтому
if (k!=-1)
{
// рекурсивно восстанавливаем путь между вершинами а и k
WayFloyd(a, k, p, ref items);
            items.Enqueue(k); //помещаем вершину к в очередь
// рекурсивно восстанавливаем путь между вершинами k и b
WayFloyd(k, b, p, ref items);
        }
    }
} //конец вложенного клаcса
private Node graph; //закрытое поле, реализующее АТД «граф»
public Graph(string name) //конструктор внешнего класса
{
    using (StreamReader file = new StreamReader(name))
    {
        int n = int.Parse(file.ReadLine());
        int[,] a = new int[n, n];
        for (int i = 0; i < n; i++)
        {
            string line = file.ReadLine();
            string[] mas = line.Split(' ');
            for (int j = 0; j < n; j++)
            {
                a[i, j] = int.Parse(mas[j]);
            }
        }
        graph = new Node(a);
    }
}
//метод выводит матрицу смежности на консольное окно
public void Show()
{
    for (int i = 0; i < graph.Size; i++)
    {
        for (int j = 0; j < graph.Size; j++)
        {
            Console.Write("{0,4}", graph[i, j]);
        }
        Console.WriteLine();
    }
}
public void Dfs(int v)
{
    graph.NovSet();//помечаем все вершины графа как непросмотренные
    graph.Dfs(v); //запускаем алгоритм обхода графа в глубину
    Console.WriteLine();
}
public void Bfs(int v)
{
    graph.NovSet();//помечаем все вершины графа как непросмотренные
    graph.Bfs(v); //запускаем алгоритм обхода графа в ширину
    Console.WriteLine();
}
public void Dijkstr(int v)
{
    graph.NovSet();//помечаем все вершины графа как непросмотренные
    int[] p;
    long[] d = graph.Dijkstr(v, out p); //запускаем алгоритм Дейкстры
                                        //анализируем полученные данные и выводим их на экран
    Console.WriteLine("Длина кратчайшие пути от вершины {0} до вершины", v);
    for (int i = 0; i < graph.Size; i++)
    {
        if (i != v)
        {
            Console.Write("{0} равна {1}, ", i, d[i]);
            Console.Write("путь ");
            if (d[i] != int.MaxValue)
            {
                Stack<int> items = new Stack<int>();
                graph.WayDijkstr(v, i, p, ref items);
                while (items.Count() != 0)
                {
                    Console.Write("{0} ", items.Pop());
                }
            }
        }
        Console.WriteLine();
    }
}
public void Floyd()
{
    int[,] p;
    long[,] a = graph.Floyd(out p); //запускаем алгоритм Флойда
    int i, j;
    //анализируем полученные данные и выводим их на экран
    for (i = 0; i < graph.Size; i++)
    {
        for (j = 0; j < graph.Size; j++)
        {
            if (i != j)
            {
                if (a[i, j] == int.MaxValue)
                {
                    Console.WriteLine("Пути из вершины {0} в вершину {1} не существует", i, j);
                }
                else
                {
                    Console.Write("Кратчайший путь от вершины {0} до вершины {1} равен { 2}, ", i, j, a[i,j]);
                Console.Write(" путь ");
                    Queue<int> items = new Queue<int>();
                    items.Enqueue(i);
                    graph.WayFloyd(i, j, p, ref items);
                    items.Enqueue(j);
                    while (items.Count != 0)
                    {
                        Console.Write("{0} ", items.Dequeue());
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
}
}