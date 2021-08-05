using System;
using TicTacToe.Core;
using TicTacToe.Core.Game;
using TicTacToe.Core.Players;
using static System.Console;

namespace TicTacToe.Demo.ConsoleApp
{
    class Program
    {
        static void Main()
        {
            Clear();

            while (true)
            {
                Clear();

                var game = new TicTacToeGame();
                var app = new Application(game);

                game.Player =  new HumanPlayer(MarkType.Cross);

                switch (app.GetGameOption())
                {
                    case GameOption.HumanPlayerAgainstComputer:
                        Clear();
                        game.Opponent = new Computer(MarkType.Circle, app.GetDifficulty());
                        break;
                    
                    case GameOption.HumanPlayerAgainstHumanPlayer:
                        game.Opponent = new HumanPlayer(MarkType.Circle);
                        break;

                    default:
                        return;
                }
                
                do
                {
                    var match = new TicTacToeMatch(game.Player, game.Opponent);
                    var boardDisplayer = new BoardDisplayer(match.Board);
   
                    while (!match.IsFinished())
                    {
                        try
                        {
                            Clear();
                            
                            game.ShowScore();
                            boardDisplayer.Display();
                            game.ShowTurn(match.GetCurrentPlayer());

                            var target = app.GetMove(match.Board, match.GetCurrentPlayer());

                            match.MakeMove(target);
                        }
                        catch (IndexOutOfRangeException)
                        {
                            Output.DisplayError("The specified target is invalid.");
                        }
                    }  

                    Clear();
                    game.ShowScore();
                    boardDisplayer.Display();
                    game.ShowWinner(match.GetResult());
                }
                while (Input.Ask("\nPress [ 1 ] to play again, or [ 2 ] to go back to options: ") == "1");
            }
        }
    }
}
