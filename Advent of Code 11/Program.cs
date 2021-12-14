using System;
using System.IO;
using System.Linq;

namespace Advent_of_Code_11
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("C:/Users/jolle/Desktop/advent of code/Advent Of Code 2021/Advent Of Code 11/input.txt").ToArray();
            var grid = lines.Select(l => l.ToArray().Select(p => int.Parse(p.ToString())).ToArray()).ToArray();
            var explodeGrid = new int[grid.Length, grid[0].Length];
            bool exploded = true;
            var flashCounter = 0;
            var allFlash = 0;
            for (int k = 0; k < 1000; k++)
            {
                explodeGrid = new int[grid.Length,grid[0].Length];
                exploded = true;
                for (int i = 0; i < grid.Length; i++)
                {
                    for (int j = 0; j < grid[0].Length; j++)
                    {
                        grid[i][j] += 1;
                    }
                }
                while (exploded)
                {
                    exploded = false;
                    for (int y = 0; y < grid.Length; y++)
                    {
                        for (int x = 0; x < grid[0].Length; x++)
                        {
                            if (grid[y][x] > 9 && explodeGrid[y,x] != 1)
                            {
                                if (InsideBorder(y - 1, x - 1))
                                    grid[y - 1][x - 1] += 1;
                                if (InsideBorder(y - 1, x))
                                    grid[y - 1][x] += 1;
                                if (InsideBorder(y - 1, x + 1))
                                    grid[y - 1][x + 1] += 1;
                                if (InsideBorder(y, x + 1))
                                    grid[y][x + 1] += 1;
                                if (InsideBorder(y + 1, x + 1))
                                    grid[y + 1][x + 1] += 1;
                                if (InsideBorder(y + 1, x))
                                    grid[y + 1][x] += 1;
                                if (InsideBorder(y + 1, x - 1))
                                    grid[y + 1][x - 1] += 1;
                                if (InsideBorder(y, x - 1))
                                    grid[y][x - 1] += 1;
                                explodeGrid[y,x] = 1;
                                if (k<=100)
                                    flashCounter += 1;
                                exploded = true;
                            }
                        }
                    }
                }
                var flashes = 0;
                for (int i = 0; i < grid.Length; i++)
                {
                    for (int j = 0; j < grid[0].Length; j++)
                    {
                        if (grid[i][j] > 9)
                        {
                            flashes += 1;
                            grid[i][j] = 0;
                        }
                    }
                }
                if (flashes==grid.Length*grid[0].Length && allFlash==0)
                    allFlash = k+1;
            }
            Console.WriteLine($"Step 1: {flashCounter}");
            Console.WriteLine($"Step 2: {allFlash}");
            Console.ReadKey();
            bool InsideBorder(int y, int x)
            {
                if (x > 9 || x < 0 || y > 9 || y < 0)
                    return false;
                return true;
            }
        }
    }
}


