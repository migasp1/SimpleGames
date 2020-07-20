using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace TicTacToe
{
    class Program
    {
        public static Play AskForMove()
        {
            Console.WriteLine("Type a coordinate between (1:1) and (3:3)");
            string coordinate = Console.ReadLine();
            coordinate = coordinate.Trim();
            int x = int.Parse(Regex.Match(coordinate, @"\d+").Value);
            int y = int.Parse(Regex.Match(coordinate, @"[:]\d+").Value.Replace(":", ""));
            Console.WriteLine("Type a value (1 or 2)");
            string value = Console.ReadLine();
            return new Play
            {
                coordinateX = x,
                coordinateY = y,
                value = int.Parse(value)
            };
        }
        static void Main(string[] args)
        {

            Console.WriteLine("************************************************");
            Console.WriteLine("*                                              *");
            Console.WriteLine("*                TIC TAC TOE                   *");
            Console.WriteLine("*                                              *");
            Console.WriteLine("************************************************");
            Gameboard gameboard = new Gameboard();
            gameboard.PrintGameBoard();
            while (gameboard.IsCompleted() != CellState.Circle && gameboard.IsCompleted() != CellState.Cross)
            {
                try
                {
                    Play p = AskForMove();
                    gameboard.MakeAPlay(p.coordinateX, p.coordinateY, p.value);
                    gameboard.PrintGameBoard();
                    if (gameboard.IsCompleted() == CellState.Circle)
                        Console.WriteLine("Circles Win!");
                    else if (gameboard.IsCompleted() == CellState.Cross)
                        Console.WriteLine("Crosses Win!");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
}
