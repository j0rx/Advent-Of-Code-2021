using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Advent_of_Code_6
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllText("C:/Users/jolle/Desktop/advent of code/Advent Of Code 2021/Advent Of Code 6/input.txt");
            byte[] inputs = lines.Split(',').Select(l=>byte.Parse (l)).ToArray();
            var fishCountPart2 = CountFish(256, inputs, 6 , 8);
            var fishCountPart1 = CountFish(80, inputs, 6, 8);
            Console.WriteLine($"Advent 6!\nPart 1: {fishCountPart1}\nPart 2: {fishCountPart2}");
            Console.ReadKey();

            long CountFish(int days, byte[] inputs, int birthFrequency, int maxAge)
            {
                long[] inputsSum = new long[maxAge+2];
                for (int i = 0; i < inputs.Length; i++)
                {
                    inputsSum[inputs[i]] += 1;
                }
                for (int i = 0; i < days; i++)
                {

                    inputsSum[inputsSum.Length-1] = inputsSum[0];
                    inputsSum[birthFrequency+1] += inputsSum[0];
                    for (int j = 1; j < inputsSum.Length; j++)
                    {
                        inputsSum[j - 1] = inputsSum[j];
                    }
                    inputsSum[inputsSum.Length - 1] = 0;

                }
                return inputsSum.Sum();
            }
        }
    }
}
