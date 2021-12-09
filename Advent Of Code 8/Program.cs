using System;
using System.IO;
using System.Linq;

namespace Advent_Of_Code_8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var lines = File.ReadAllLines("C:/Users/jolle/Desktop/advent of code/Advent Of Code 2021/Advent Of Code 8/input.txt");
            var outputData = lines.Select(l => l.Split(" | ")[1]).Select(l=>l.Split(" ")).ToArray();
            var inputData = lines.Select(l => l.Split(" | ")[0]).Select(l => l.Split(" ")).ToArray();
            var lookForValues = new int[] { 2, 4, 3, 7 }; 
            var counter = 0;
            var numbers = new string[outputData.Length, 10];
            var tempCount = 0;
            tempCount = 0; 
            //Step 1:
            foreach (var line in outputData)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    counter += lookForValues.Contains(line[i].Length) ? 1 : 0;
                }
                tempCount += 1;
            }
            //Step 2:
            foreach (var line in inputData)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    switch (line[i].Length)
                    {
                        case 2:
                            numbers[tempCount, 1] = line[i];    // 00 
                            break;                              //6  1
                        case 4:                                 //6  1
                            numbers[tempCount, 4] = line[i];    // 55 
                            break;                              //4  2
                        case 3:                                 //4  2
                            numbers[tempCount, 7] = line[i];    // 33
                            break;
                        case 7:
                            numbers[tempCount, 8] = line[i];
                            break;
                        default:
                            break;
                    }
                }
                tempCount += 1;
            }
            for (int i = 0; i < lines.Length; i++)
            {
                var sides = new char[7];
                sides[0] = Convert.ToChar(SubtractChars(numbers[i, 7], numbers[i, 1]));
                numbers[i, 6] = inputData[i].Where(l => (l.Length == 6 && l.Contains(numbers[i, 1][0]) == false)|| (l.Length == 6 && l.Contains(numbers[i, 1][1]) == false)).FirstOrDefault();
                sides[1] = numbers[i, 6].Contains(numbers[i, 1][0]) ? numbers[i, 1][1] : numbers[i, 1][0];
                sides[2] = (sides[1] == numbers[i, 1][1]) ? numbers[i, 1][0] : numbers[i, 1][1];
                numbers[i, 3] = inputData[i].Where(l => l.Length == 5 && l.Contains(sides[0]) && l.Contains(sides[1]) && l.Contains(sides[2])).FirstOrDefault(); 
                sides[5] = numbers[i, 3].Where(l => numbers[i, 4].Contains(l) && l != sides[0] && l != sides[1] && l != sides[2]).FirstOrDefault();
                sides[3] = Convert.ToChar(SubtractChars(numbers[i, 3], sides[0].ToString() + sides[1] + sides[2] + sides[5]));
                sides[6] = Convert.ToChar(SubtractChars(numbers[i, 4], sides[1].ToString() + sides[2] + sides[5]));
                sides[4] = Convert.ToChar(SubtractChars(numbers[i, 8], sides[0].ToString() + sides[1] + sides[2] + sides[3] + sides[5] + sides[6]));
                numbers[i, 0] = sides[0].ToString() + sides[1] + sides[2] + sides[3] + sides[4] + sides[6];
                numbers[i, 2] = sides[0].ToString() + sides[1] + sides[5] + sides[4] + sides[3];
                numbers[i, 5] = sides[0].ToString() + sides[6] + sides[5] + sides[2] + sides[3];
                numbers[i, 9] = sides[0].ToString() + sides[1] + sides[2] + sides[3] + sides[5] + sides[6];
                for (int j = 0; j <= 9; j++)
                {
                    numbers[i, j] = String.Concat(numbers[i, j].OrderBy(c => c));
                }
            }
            tempCount = 0;
            var sum = 0;
            foreach (var line in outputData)
            {
                var sumTxt = "";
                for (int i = 0; i < line.Length; i++)
                {
                    var lineOrdered = String.Concat(line[i].OrderBy(c => c));
                    for (int j = 0; j < 10; j++)
                    {
                        sumTxt += (lineOrdered == numbers[tempCount, j]) ? j : "";
                    }
                }
                tempCount += 1;
                sum += int.Parse(sumTxt);
            }
            string SubtractChars(string value, string subtract)
            {
                for (int i = 0; i < subtract.Length; i++)
                {
                    value = value.Replace(subtract[i].ToString(), string.Empty);
                }
                return (value);
            }
            Console.WriteLine("Part 1: "+counter);
            Console.WriteLine("Part 2: "+sum);
            Console.ReadKey();
        }
    }
}
