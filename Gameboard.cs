using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace TicTacToe
{
    public class Gameboard
    {
        private readonly CellState[,] board;

        public Gameboard()
        {
            board = new CellState[3, 3];
        }

        public void PrintGameBoard()
        {
            Console.WriteLine("------");
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    var state = board[i, j] switch
                    {
                        CellState.Empty => "  ",
                        CellState.Circle => "O ",
                        CellState.Cross => "X ",
                        _ => throw new NotImplementedException(),
                    };
                    Console.Write(state);
                }
                Console.WriteLine("|");
            }
            Console.WriteLine();
        }

        public void MakeAPlay(int x, int y, int value)
        {
            if (x > 3 || y > 3 || x < 1 || y < 1)
                throw new ArgumentException("Invalid coordinate");

            else if (value != 1 && value != 2)
                throw new ArgumentException("Value must either be 1 or 2");

            else if (board[x - 1, y - 1] != CellState.Empty)
                throw new ArgumentException("Coordinate has value");

            else
            {
                board[x - 1, y - 1] = value == 1 ? CellState.Circle : CellState.Cross;
            }
        }

        public CellState? IsCompleted()
        {

            for (var i = 0; i < board.GetLength(0); i++)
            {
                int j = 0, columnCount = 0, lineCount = 0;
                CellState firstValue = board[i, j];
                for (j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] == firstValue)
                        columnCount++;
                    if (board[j, i] == firstValue)
                        lineCount++;
                }
                if (columnCount == board.GetLength(0) || lineCount == board.GetLength(1))
                    return firstValue;
            }
            int diagonalCount = 0;
            int secondDiagonalCount = 0;

            for (int j = 0; j < board.GetLength(0); j++)
            {
                CellState firstValue = board[board.GetLength(0) / 2, board.GetLength(1) / 2];
                if (board[j, j] == firstValue)
                    diagonalCount++;
                if (board[board.GetLength(0) - 1 - j, j] == firstValue)
                    secondDiagonalCount++;
                if (diagonalCount == board.GetLength(0) || secondDiagonalCount == board.GetLength(0))
                    return firstValue;
            }
            return null;
        }
    }
}
