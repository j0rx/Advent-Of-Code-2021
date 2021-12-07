using System;
using System.IO;
using System.Linq;

namespace Advent_of_Code_7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var lines = File.ReadAllText("C:/Users/jolle/Desktop/advent of code/Advent Of Code 2021/Advent Of Code 7/input.txt");
            var pos = lines.Split(',').Select(p => int.Parse(p)).ToArray();
            Array.Sort(pos);
            //part 1
            int[] fuel = new int[pos[pos.Length-1]];
            for (int i = 0; i < pos[pos.Length-1]; i++)
            {
                    var before = pos.Where(p => p < i).Sum();
                    var after = pos.Where(p => p > i).Sum();
                    var beforePosCount = pos.Where(p => p < i).Count();
                    var afterPosCount = pos.Where(p => p > i).Count();
                    var beforeFuelCount = (beforePosCount * i) - before;
                    var afterFuelCount = after - (afterPosCount * i);
                    fuel[i] = beforeFuelCount + afterFuelCount;
            }
            //part 2
            var leastCost = int.MaxValue;
            for (int i = 0; i < pos[pos.Length - 1]; i++)
            {
                var tempCount = 0;
                for (int j = 0; j < pos.Length; j++)
                {
                    if (pos[j]>i)
                        tempCount += ((pos[j] -i) * ((pos[j] - i) + 1)) / 2;
                    if (pos[j] < i)
                        tempCount += ((i - pos[j]) * ((i - pos[j]) + 1)) / 2;
                }
                if (tempCount<leastCost)
                    leastCost = tempCount;
            }
            Console.WriteLine(leastCost);
            Array.Sort(fuel);
            Console.WriteLine(fuel[0]);
            Console.ReadKey();
        }
    }
}
