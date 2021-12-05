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
            int[,] field = new int[1000, 1000];
            foreach (var line in lines)
            {
                valueList.Add(new Lines(line));
            }
            var selectedList = valueList.Where(l => l.fromX == l.toX || l.fromY == l.toY).ToList();
            Console.WriteLine("Advent 5!\nPart 1: " + CountCrossings(selectedList, field)+ "\nPart 2: " + CountCrossings(valueList, field));
            Console.ReadKey();
        }
        static int CountCrossings(List<Lines> selectedList, int[,] field)
        {
            
            foreach (var line in selectedList)
            {
                while (line.fromX != line.toX || line.fromY != line.toY)
                {
                    field[line.fromX, line.fromY] += 1;
                    if (line.fromY != line.toY)
                        line.fromY += line.directionY;
                    if (line.fromX != line.toX)
                        line.fromX += line.directionX;
                }
                field[line.toX, line.toY] += 1;
            }
            int counter = 0;
            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    if (field[i, j] > 1)
                        counter += 1;
                }
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
