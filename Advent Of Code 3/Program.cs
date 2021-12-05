using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Advent_Of_Code_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Advent 3!");
            var lines = File.ReadLines("C:/Users/jolle/Desktop/advent of code/Advent Of Code 3/input.txt").ToArray();
            int oxygen = Filter(lines.ToList(), 0, '1');
            int co2 = Filter(lines.ToList(), 0, '0');
            Console.WriteLine("Part 1: " + CalculatePowerConsumtion(lines));
            Console.WriteLine("Part 2: " + oxygen * co2);
            Console.ReadLine();
        }
        static int Filter(List<string> lines, int col, char mostCommon)
        {
            char otherOption = '1';
            if (mostCommon == '1')
                otherOption = '0';
            if (lines.Count ==1)
                return Convert.ToInt32(lines.FirstOrDefault(),2);
            int count = 0;
            for (int i = 0; i < lines.Count; i++)
            {
                if (lines[i][col] == '1')
                    count += 1;
                else
                    count -= 1;
            }
            if (count >= 0) {
                var filteredList = lines.Where(a => a[col] == mostCommon).ToList();
                if (filteredList.Count==0)
                {
                    return (Filter(lines.Where(a => a[col] == otherOption).ToList(), col + 1, mostCommon));
                }
                return( Filter(lines.Where(a => a[col] == mostCommon).ToList(), col + 1, mostCommon));
            }
            else { 
                var filteredList = lines.Where(a => a[col] == otherOption).ToList();
                if (filteredList.Count == 0)
                {
                    return (Filter(lines.Where(a => a[col] == mostCommon).ToList(), col + 1, mostCommon));
                }
                return (Filter(lines.Where(a => a[col] == otherOption).ToList(), col + 1, mostCommon));
            }
        }
        static int CalculatePowerConsumtion(string[] lines)
        {
            string gamma = string.Empty;
            string epsilon = string.Empty;
            for (int i = 0; i < lines.First().Length; i++)
            {
                int count = 0;
                for (int j = 0; j < lines.Length; j++)
                {
                    if (lines[j][i] == '1')
                    {
                        count += 1;
                    }
                    else
                    {
                        count -= 1;
                    }
                }
                if (count < 0)
                {
                    gamma += '0';
                    epsilon += '1';
                }
                else
                {
                    gamma += '1';
                    epsilon += '0';
                }
            }
            int gammaDecimal = Convert.ToInt32(gamma, 2);
            int epsilonDecimal = Convert.ToInt32(epsilon, 2);
            return(gammaDecimal * epsilonDecimal);
        }
    }
}
