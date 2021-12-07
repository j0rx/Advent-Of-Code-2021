using System;
using System.IO;
namespace advent_of_code
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("C:/Users/jolle/Desktop/advent of code/advent of code/input.txt");
            int[] ints = Array.ConvertAll(lines, s => int.Parse(s));
            var incrementsCount = IncrementsCount(ints); //Step 1
            var valuesByThree = SumValuesByThree(ints); //Step 2
            Console.WriteLine("Advent 1!\nPart 1: " + incrementsCount + "\nPart 2: " + IncrementsCount(valuesByThree));
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
                counter += ints[i - 1] < ints[i] ? 1 : 0; 
            }
            return counter;
        }
    }
}
