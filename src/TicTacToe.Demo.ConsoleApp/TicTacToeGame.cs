using System;
using TicTacToe.Core;
using TicTacToe.Core.Players;

namespace TicTacToe.Demo.ConsoleApp
{
    public class TicTacToeGame
    {
        public IPlayer Player { get; set; }
        public IPlayer Opponent { get; set; }

        private BoardDisplayer boardDisplayer;


        public void ShowTurn(IPlayer currentPlayer)
        {
            Output.Write("Turn: ");
            PrintMark(currentPlayer.Mark);
            Output.WriteLine();
        }

        public void ShowWinner(TicTacToeMatchResult? matchResult)
        {
            switch (matchResult)
            {
                case TicTacToeMatchResult.Tie:
                    Output.WriteLine("The game ended in a TIE, nobody won.");
                    break;

                case TicTacToeMatchResult.CrossWin:
                    PrintMark(MarkType.Cross);
                    Output.WriteLine(" won!");
                    break;

                case TicTacToeMatchResult.CircleWin:
                    PrintMark(MarkType.Circle);
                    Output.WriteLine(" won!");
                    break;

                default:
                    break;
            }
            
        }

        public void ShowOptions()
        {
            Output.WriteLine("Options:\n");

            Output.Write("1", ConsoleColor.Yellow);
            Output.WriteLine(" - Play against a computer");

            Output.Write("2", ConsoleColor.Yellow);
            Output.WriteLine(" - Play against a friend");

            Output.Write("3", ConsoleColor.Yellow);
            Output.WriteLine(" - Exit");
        }

        public void ShowDifficultyLevels()
        {
            Output.WriteLine("Difficulty levels:\n");

            Output.Write("1", ConsoleColor.Yellow);
            Output.WriteLine(" - Easy");

            Output.Write("2", ConsoleColor.Yellow);
            Output.WriteLine(" - Medium");

            Output.Write("3", ConsoleColor.Yellow);
            Output.WriteLine(" - Impossible");
        }

        public void ShowScore()
        {
            PrintMark(MarkType.Cross);
            Output.Write(" => ");
            Output.WriteLine(Player.Score.Wins, ConsoleColor.Blue);

            PrintMark(MarkType.Circle);
            Output.Write(" => ");
            Output.WriteLine(Opponent.Score.Wins, ConsoleColor.Red);

            Output.WriteLine();
        }

        public void PrintMark(MarkType mark)
        {
            if (mark == MarkType.Cross)
            {
                Output.Write("X", ConsoleColor.Blue);
                return;
            }

            Output.Write("O", ConsoleColor.Red);
        }
    }
}