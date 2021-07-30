using System;
using TicTacToe.Core;

namespace TicTacToe.Demo.ConsoleApp
{
    public class BoardDisplayer
    {
        public Board Board { get; set; }

        public BoardDisplayer(Board board)
        {
            Board = board;
        }

        public void Display()
        {
            for (int row = Board.Length - 1; row >= 0; row--)
            {
                PrintLine();   
                PrintCenterLine(row);
            }
            
            PrintLine();
            PrintColumns();
            Output.WriteLine("");
        }

        private void PrintLine()
        {
            Output.Write("  ");
            
            for (int i = 0; i < Board.Length; i++)
            {
                Output.Write("+---");
            }

            Output.WriteLine("+");
        }

        public void PrintCenterLine(int row)
        {
            Output.Write(row + 1 + " ");

            for (int i = 0; i < Board.Length; i++)
            {
                var currentSquare = Board[row, i];

                Output.Write("| ");

                if (currentSquare.IsEmpty)
                {
                    Output.Write(" ");
                }
                else if (currentSquare.Mark == MarkType.Cross)
                {
                    Output.Write('X', ConsoleColor.Yellow);
                }
                else
                {
                    Output.Write('O', ConsoleColor.Cyan);
                }
                
                Output.Write(" ");
            }

            Output.WriteLine("|");
        }

        public void PrintColumns()
        {
            Output.Write("    ");

            for (var i = 0; i < Board.Length; i++)
            {
                Output.Write((char)('a' + i) + "   ");
            }

            Output.WriteLine("");
        }
    }
}