using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Advent_of_Code_10
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var lines = File.ReadAllLines("C:/Users/jolle/Desktop/advent of code/Advent Of Code 2021/Advent Of Code 10/input.txt").ToList();
            var syntax = new char[] { ('('), ('['), ('{'), ('<') };
            var score = 0;
            var autoCompleteScores = new List<long>();
            for (int i = 0; i < lines.Count; i++)
            {
                var fail = false;
                var currentSyntax = new List<char>();
                for (int j = 0; j < lines[i].Length; j++)
                {
                    if (!syntax.Contains(lines[i][j]))
                    {
                        var scoreToAdd = LookFor(lines[i][j], currentSyntax);
                        score += scoreToAdd;
                        if (scoreToAdd > 0)
                        {
                            fail = true;
                            break;
                        }
                    }
                    else
                    {
                        currentSyntax.Add(lines[i][j]);
                    }
                }
                long currentACScore = 0;
                if (currentSyntax.Count >0 && fail ==false)
                {
                    for (int j = (currentSyntax.Count - 1); j >= 0; j--)
                    {
                        currentACScore = currentACScore * 5;
                        switch (currentSyntax[j])
                        {
                            case '(':
                                currentACScore += 1;
                                break;
                            case '[':
                                currentACScore += 2;
                                break;
                            case '{':
                                currentACScore += 3;
                                break;
                            case '<':
                                currentACScore += 4;
                                break;
                            default:
                                break;
                        }
                    }
                    if (currentACScore < 0)
                        currentACScore = long.MaxValue;
                    autoCompleteScores.Add(currentACScore);
                }
                
            }
            autoCompleteScores = autoCompleteScores.OrderBy(l => l).ToList();
            int LookFor(char value, List<char> currentSyntax)
            {
                switch (value)
                {
                    case ')':
                        if (currentSyntax[currentSyntax.Count - 1] == '(')
                            currentSyntax.RemoveAt(currentSyntax.Count - 1);
                        else
                            return 3;
                        break;
                    case ']':
                        if (currentSyntax[currentSyntax.Count - 1] == '[')
                            currentSyntax.RemoveAt(currentSyntax.Count - 1);
                        else
                            return 57;
                        break;
                    case '}':
                        if (currentSyntax[currentSyntax.Count - 1] == '{')
                            currentSyntax.RemoveAt(currentSyntax.Count - 1);
                        else
                            return 1197;
                        break;
                    case '>':
                        if (currentSyntax[currentSyntax.Count - 1] == '<')
                            currentSyntax.RemoveAt(currentSyntax.Count - 1);
                        else
                            return 25137;
                        break;
                    default:
                        break;
                }
                return 0;
            }
            foreach (var item in autoCompleteScores)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"Part 1: {score} Part 2: {autoCompleteScores[autoCompleteScores.Count/2]}"); 
            Console.ReadKey();
        }
    }
}
