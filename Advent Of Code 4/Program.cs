using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Advent_Of_Code_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Advent 4!");
            var lines = File.ReadAllText("C:/Users/jolle/Desktop/advent of code/Advent Of Code 4/input.txt");
            var linesWithoutDoubleSpace = lines.Replace("  ", " ");
            var boards = linesWithoutDoubleSpace.Split("\n\n");
            var numbers = boards[0].Split(',');
            List<BingoBoards> boardList = new List<BingoBoards>();
            var rows = new string[5];
            for (int i = 1; i < boards.Length; i++)
            {
                rows = boards[i].Trim().Split("\n");
                boardList.Add(new BingoBoards(rows));
            }
            Console.WriteLine("Winner value: " + FindWinner(numbers, boardList, false));
            Console.WriteLine("Looser value: " + FindWinner(numbers, boardList, true));
            Console.ReadLine();
        }
        static int FindWinner(string[] numbers, List<BingoBoards> boardList, bool looser)
        {
            int winningBoard = 0;
            int winningNumber = 0;
            int[] winners = new int[boardList.Count];
            foreach (var num in numbers)
            {
                for (int i = 0; i < boardList.Count; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        for (int k = 0; k < 5; k++)
                        {
                            if (boardList[i].grid[k, j] == int.Parse(num))
                            {
                                winningNumber = boardList[i].grid[k, j];
                                winningBoard = i;
                                boardList[i].grid[k, j] = 100;
                                if ((boardList[i].grid[k, 0] == 100 && boardList[i].grid[k, 1] == 100 &&
                                    boardList[i].grid[k, 2] == 100 && boardList[i].grid[k, 3] == 100 &&
                                    boardList[i].grid[k, 4] == 100) || (boardList[i].grid[0, j] == 100 &&
                                    boardList[i].grid[1, j] == 100 && boardList[i].grid[2, j] == 100 &&
                                    boardList[i].grid[3, j] == 100 && boardList[i].grid[4, j] == 100))
                                {
                                    var winnerSum = boardList[i].grid.Cast<int>().Where(l => l != 100).Sum();
                                    if (!looser)
                                        return winnerSum * winningNumber;
                                    winners[i] = 1;
                                }
                            }
                        }
                    }
                    if (winners.Cast<int>().Sum() >=boardList.Count)
                    {
                        var looserSum = boardList[winningBoard].grid.Cast<int>().Where(l => l != 100).Sum();
                        return looserSum * winningNumber;
                    }
                }
            }
            return 0;
        }
    }
    public class BingoBoards
    {
        public string boardInText { get; set; }
        public int[,] grid = new int[5, 5];
        public BingoBoards(string[] rows)
        {
            for (int i = 0; i < rows.Length; i++)
            { 
                var numbers = rows[i].Trim().Split(" ");
                for (int j = 0; j < numbers.Length; j++)
                {
                    this.grid[i, j] = int.Parse(numbers[j]);
                }
            }
        }
    }
    
}
