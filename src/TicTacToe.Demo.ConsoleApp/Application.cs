using System;
using TicTacToe.Core;
using TicTacToe.Core.Players;

namespace TicTacToe.Demo.ConsoleApp
{
    public class Application
    {
        public TicTacToeGame Game { get; init; }

        public Application(TicTacToeGame game)
        {
            Game = game;
        }

        public GameOption GetGameOption()
        {
            Game.ShowOptions();

            return Input.Ask("\nChoose an option: ", ConsoleColor.Yellow) switch
            {
                "1" => GameOption.HumanPlayerAgainstComputer,
                "2" => GameOption.HumanPlayerAgainstHumanPlayer,
                _ => GameOption.Exit
            };
        }

        public Difficulty GetDifficulty()
        {
            Game.ShowDifficultyLevels();

            return Input.Ask("\nChoose the computer difficulty: ", ConsoleColor.Yellow) switch
            {
                "1" => Difficulty.Easy,
                "2" => Difficulty.Medium,
                _ => Difficulty.Impossible
            };
        }

        public Position GetMove(Board board, IPlayer currentPlayer)
        {
            if (currentPlayer is Computer computer)
            {
                return computer.GetMove(board);
            }

            var position = Input.AskUntil(Position.IsValid, "\nChoose a target square (e.g: a1): ");

            return Position.FromString(position);
        }
    }
}