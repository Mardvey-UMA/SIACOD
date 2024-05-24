using ClassG;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Graphs
{
    internal class Problem1
    {
        public static int CalculateDistance(int[] point1, int[] point2)
        {
            int dx = point2[0] - point1[0];
            int dy = point2[1] - point1[1];
            int sumOfSquares = dx * dx + dy * dy;
            return (int)Math.Round(Math.Sqrt(sumOfSquares));
        }

        static void Main(string[] args)
        {
            string input_path = "P:\\siacode_git\\SIACOD\\Graphs\\matrix2.txt"; // Путь к файлу matrix.txt
            string output_path = "P:\\siacode_git\\SIACOD\\Graphs\\output.txt"; // Путь к файлу output.txt
            int N = 150; // Предел расстояния между городами

            using (StreamReader reader = new StreamReader(input_path))
            using (StreamWriter writer = new StreamWriter(output_path))
            {
                Dictionary<int, Tuple<string, int[]>> Cities = new Dictionary<int, Tuple<string, int[]>>();
                string[] lines = File.ReadAllLines(input_path);
                int n = int.Parse(lines[0]);

                for (int i = 1; i <= n; i++)
                {
                    string[] info = lines[i].Split(' ');
                    string name = info[0];
                    int x = int.Parse(info[1]);
                    int y = int.Parse(info[2]);
                    Cities.Add(i - 1, Tuple.Create(name, new int[] { x, y }));
                }

                int[,] adjacencyMatrix = new int[n, n];
                for (int i = 0; i < n; i++)
                {
                    string[] line = lines[n + 1 + i].Split(' ');
                    for (int j = 0; j < n; j++)
                    {
                        adjacencyMatrix[i, j] = int.Parse(line[j]);
                    }
                }

                int[,] RoadMatrix = new int[n, n];
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (adjacencyMatrix[i, j] == 1)
                        {
                            RoadMatrix[i, j] = CalculateDistance(Cities[i].Item2, Cities[j].Item2);
                        }
                        else
                        {
                            RoadMatrix[i, j] = int.MaxValue;
                        }
                    }
                }

                Graph Roads = new Graph(RoadMatrix);
                List<Tuple<int, int>> addedRoads = new List<Tuple<int, int>>();
                long[,] floydResult = new long[n, n];
                int[,] floydPaths;

                Roads.Floyd(ref floydResult, out floydPaths);

                bool needToAddRoads = false;

                // Проверка связности графа
                if (!Roads.IsConnected())
                {
                    needToAddRoads = true;
                    // Добавление дорог, чтобы сделать граф связным
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            if (i != j && RoadMatrix[i, j] == int.MaxValue)
                            {
                                int distance = CalculateDistance(Cities[i].Item2, Cities[j].Item2);
                                if (distance <= N)
                                {
                                    adjacencyMatrix[i, j] = 1;
                                    adjacencyMatrix[j, i] = 1;
                                    RoadMatrix[i, j] = distance;
                                    RoadMatrix[j, i] = distance;
                                    Roads = new Graph(RoadMatrix); // Обновляем граф
                                    addedRoads.Add(Tuple.Create(i, j));
                                }
                            }
                        }
                    }
                    Roads.Floyd(ref floydResult, out floydPaths); // Пересчитываем Флойда после добавления дорог
                }

                // Проверка минимальных расстояний и добавление дорог, если необходимо
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (i != j && floydResult[i, j] > N)
                        {
                            needToAddRoads = true;
                            int distance = CalculateDistance(Cities[i].Item2, Cities[j].Item2);
                            if (distance <= N)
                            {
                                adjacencyMatrix[i, j] = 1;
                                adjacencyMatrix[j, i] = 1;
                                RoadMatrix[i, j] = distance;
                                RoadMatrix[j, i] = distance;
                                Roads = new Graph(RoadMatrix); // Обновляем граф
                                addedRoads.Add(Tuple.Create(i, j));
                            }
                        }
                    }
                }

                Roads.Floyd(ref floydResult, out floydPaths); // Пересчитываем Флойда после добавления дорог

                if (!needToAddRoads)
                {
                    writer.WriteLine("Условие задачи уже выполнено: граф связный и минимальные расстояния не превышают N км.");
                }
                else
                {
                    // Запись новой матрицы смежности и матрицы Флойда в файл
                    writer.WriteLine("Новая матрица смежности:");
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            writer.Write(adjacencyMatrix[i, j] + " ");
                        }
                        writer.WriteLine();
                    }

                    writer.WriteLine("Матрица Флойда:");
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            if (floydResult[i, j] == 0)
                            {
                                writer.Write("INF ");
                            }
                            else
                            {
                                writer.Write(floydResult[i, j] + " ");
                            }
                        }
                        writer.WriteLine();
                    }

                    // Запись добавленных дорог в файл
                    writer.WriteLine("Добавленные дороги:");
                    HashSet<string> uniqueRoads = new HashSet<string>();
                    foreach (var road in addedRoads)
                    {
                        string city1 = Cities[road.Item1].Item1;
                        string city2 = Cities[road.Item2].Item1;
                        string roadKey = city1 + "-" + city2;
                        string reverseRoadKey = city2 + "-" + city1;
                        if (!uniqueRoads.Contains(roadKey) && !uniqueRoads.Contains(reverseRoadKey))
                        {
                            writer.WriteLine($"{city1} - {city2}");
                            uniqueRoads.Add(roadKey);
                        }
                    }

                    // Запись путей между городами, где расстояние не превышает N, в файл
                    writer.WriteLine("Пути между городами, где расстояние не превышает {0} км:", N);
                    HashSet<string> printedPairs = new HashSet<string>();
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            
                            if (i != j && floydResult[i, j] <= N)
                            {
                                
                                string pairKey = $"{Math.Min(i, j)}-{Math.Max(i, j)}";
                                if (!printedPairs.Contains(pairKey))
                                {
                                    printedPairs.Add(pairKey);
                                    writer.WriteLine($"{Cities[i].Item1} - {Cities[j].Item1}: {floydResult[i, j]} км");

                                    // Запись подробного пути через города в файл
                                    Queue<int> path = new Queue<int>();
                                    Roads.WayFloyd(i, j, floydPaths, ref path);

                                    writer.Write("Путь: ");
                                    while (path.Count > 0)
                                    {
                                        int cityIndex = path.Dequeue();
                                        writer.Write(Cities[cityIndex].Item1);
                                        if (path.Count > 0)
                                        {
                                            writer.Write(" -> ");
                                        }
                                    }
                                    writer.WriteLine();
                                }
                            }else if (floydResult[i, j] > N)
                            {
                                writer.Write("Невозможно решить задачу");
                                writer.Close();
                                Process.GetCurrentProcess().Kill();
                            }
                        }
                    }
                }
            }
        }
    }
}
