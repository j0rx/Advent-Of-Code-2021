using System;
using System.IO;

namespace advent_of_code
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Advent 1!");
            var lines = File.ReadAllLines("C:/Users/jolle/Desktop/advent of code/advent of code/input.txt");
            int[] ints = Array.ConvertAll(lines, s => int.Parse(s));
            var incrementsCount = IncrementsCount(ints); //Step 1
            var valuesByThree = SumValuesByThree(ints); //Step 2
            Console.WriteLine("Part 1: " + incrementsCount + " Part 2: " + IncrementsCount(valuesByThree));
            Console.Read();
        }
        static int[] SumValuesByThree(int[] ints)
        {
            int[] threeValuesSumArr = new int[ints.Length - 2];
            for (int i = 0; i < ints.Length - 2; i++)
            {
                threeValuesSumArr[i] = ints[i] + ints[i + 1] + ints[i + 2];
            }
            return threeValuesSumArr;
        }
        static int IncrementsCount(int[] ints)
        {
            int counter = 0;
            for (int i = 1; i < ints.Length; i++)
            {
                if (ints[i - 1] < ints[i])
                {
                    counter++;
                }
            }
            return counter;
        }
    }
}
