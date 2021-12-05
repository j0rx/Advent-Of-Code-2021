using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Advent_Of_Code_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Advent 2!");
            var lines = File.ReadLines("C:/Users/jolle/Desktop/advent of code/Advent Of Code 2/input.txt");
            Console.WriteLine("Part 1: " + CalculateLocation(lines));
            Console.WriteLine("Part 2: " + AdvancedCalculation(lines));
            Console.ReadLine();
        }
        static int AdvancedCalculation(IEnumerable<string> lines)
        {
            string[][] values = lines.Select(line => line.Split(' ')).ToArray();
            int aim = 0;
            int forward = 0;
            int depth = 0;
            for (int i = 0; i < values.Length; i++)
            {
                var value = int.Parse(values[i][1]);
                switch (values[i][0])
                {
                    case "up":
                        aim -= value;
                        break;
                    case "down":
                        aim += value;
                        break;
                    case "forward":
                        forward += value;
                        depth += aim * value;
                        break;
                    default:
                        break;
                }
            }
            return(depth * forward);
        }
        static int CalculateLocation(IEnumerable<string> lines)
        {
            var values = lines.Select(line => line.Split(' ')).ToLookup(line => line[0], line => int.Parse(line[1]));
            int up = 0;
            int down = 0;
            int forward = 0;
            foreach (var kvp in values)
            {
                switch (kvp.Key)
                {
                    case "up":
                        up += kvp.Sum();
                        break;
                    case "down":
                        down += kvp.Sum();
                        break;
                    case "forward":
                        forward += kvp.Sum();
                        break;
                    default:
                        break;
                }
            }
            int depth = down - up;
            return depth * forward;
        }
    }
}
