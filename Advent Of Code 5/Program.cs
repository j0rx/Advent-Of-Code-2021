using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Advent_Of_Code_5
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadLines("C:/Users/jolle/Desktop/advent of code/Advent Of Code 5/input.txt").ToArray();
            List<Lines> valueList = new List<Lines>();
            List<Lines> valueList2 = new List<Lines>();
            foreach (var line in lines)
            {
                valueList.Add(new Lines(line));
                valueList2.Add(new Lines(line));
            }
            var selectedList = valueList.Where(l => l.fromX == l.toX || l.fromY == l.toY).ToList();
            Console.WriteLine("Advent 5!\nPart 1: " + CountCrossings(selectedList, new int[1000, 1000]));
            Console.WriteLine("Part 2: " + CountCrossings(valueList2, new int[1000, 1000]));
            Console.ReadKey();
        }
        static int CountCrossings(List<Lines> selectedList, int[,] field)
        {
            int counter = 0;

            foreach (var line in selectedList)
            {
                while (line.fromX != line.toX || line.fromY != line.toY)
                {
                    counter += (field[line.fromX, line.fromY] == 1) ? 1 : 0;
                    field[line.fromX, line.fromY] += 1;
                    line.fromY += (line.fromY != line.toY) ? line.directionY : 0;
                    line.fromX += (line.fromX != line.toX) ? line.directionX : 0;
                }
                counter += (field[line.toX, line.toY] == 1) ? 1 : 0;
                field[line.toX, line.toY] += 1;
            }
            return counter;
        }
    }
    public class Lines
    {
        public int fromX { get; set; }
        public int toX { get; set; }
        public int fromY { get; set; }
        public int toY { get; set; }
        public int directionX { get; set; }
        public int directionY { get; set; }
        public Lines(string input)
        {
            var values = input.Split(" -> ");
            var fromValues = values[0].Split(",");
            var toValues = values[1].Split(",");
            fromX = int.Parse(fromValues[0]);
            fromY = int.Parse(fromValues[1]);
            toX = int.Parse(toValues[0]);
            toY = int.Parse(toValues[1]);
            directionX = fromX > toX ? -1 : 1;
            directionY = fromY > toY ? -1 : 1;
        }
    }
}
