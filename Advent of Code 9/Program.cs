using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Advent_of_Code_9
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var lines = File.ReadAllLines("C:/Users/jolle/Desktop/advent of code/Advent Of Code 2021/Advent Of Code 9/input.txt").ToList();
            var lowPoints = new List<(int,int)>();
            var basins = new List<List<(int,int)>>();
            var stringOfNines = "";
            for (int i = 0; i < lines[0].Length; i++)
            {
                stringOfNines += "9";
            }
            lines.Insert(0, stringOfNines);
            lines.Add(stringOfNines);
            for (int i = 0; i < lines.Count; i++)
            {
                lines[i] = "9" + lines[i] + "9";
            }
            var sum = 0;
            for (int i = 1; i < lines.Count-1; i++)
            {
                for (int j = 1; j < lines[0].Length-1; j++)
                {
                    if (lines[i][j] < lines[i + 1][j] && lines[i][j] < lines[i - 1][j] && lines[i][j] < lines[i][j+1] && lines[i][j] < lines[i][j - 1])
                    {
                        sum += int.Parse(lines[i][j].ToString()) + 1;
                        lowPoints.Add(new (i, j));
                    }
                }
            }
            for (int i = 0; i < lowPoints.Count; i++)
            {
                basins.Add(new List<(int, int)>());
                basins[i].Add(lowPoints[i]);
                CheckCoords(lowPoints[i], basins[i]);
                basins[i]=basins[i].Distinct().ToList();
            }
            basins = basins.OrderByDescending(l => l.Count).ToList();
            Console.WriteLine(sum);
            Console.WriteLine(basins[0].Count * basins[1].Count * basins[2].Count);
            Console.ReadKey();
            void CheckCoords((int,int) coords, List<(int, int)> basin)
            {
                for (int i = 0; i < 4; i++)
                {
                    switch (i)
                    {
                        case 0: //right
                            if (Convert.ToInt32( lines[coords.Item1][coords.Item2]) < Convert.ToInt32(lines[coords.Item1][coords.Item2 + 1]) &&lines[coords.Item1][coords.Item2 + 1] != '9')
                            {
                                basin.Add((coords.Item1, coords.Item2 + 1));
                                CheckCoords((coords.Item1, coords.Item2 + 1), basin);
                            }
                            break;
                        case 1: //up
                            if (Convert.ToInt32(lines[coords.Item1][coords.Item2]) < Convert.ToInt32(lines[coords.Item1 + 1][coords.Item2]) && lines[coords.Item1 + 1][coords.Item2] != '9')
                            {
                                basin.Add((coords.Item1+1, coords.Item2));
                                CheckCoords((coords.Item1 + 1, coords.Item2), basin);
                            }
                            break;
                        case 2://left
                            if (Convert.ToInt32(lines[coords.Item1][coords.Item2]) < Convert.ToInt32(lines[coords.Item1][coords.Item2 - 1]) && lines[coords.Item1][coords.Item2 - 1] != '9')
                            {
                                basin.Add((coords.Item1, coords.Item2 - 1));
                                CheckCoords((coords.Item1, coords.Item2 - 1), basin);
                            }
                            break;
                        case 3://down
                            if (Convert.ToInt32(lines[coords.Item1][coords.Item2]) < Convert.ToInt32(lines[coords.Item1 - 1][coords.Item2]) && lines[coords.Item1 - 1][coords.Item2] != '9')
                            {
                                basin.Add((coords.Item1 - 1, coords.Item2));
                                CheckCoords((coords.Item1 - 1, coords.Item2), basin);
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
