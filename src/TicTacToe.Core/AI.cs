using System;
using System.Linq;
using TicTacToe.Core.Game;

namespace TicTacToe.Core
{
    public class AI
    {
        public Board Board { get; init; }
        public MarkType Player { get; init; }
        public MarkType Opponent { get; init; }
        
        public AI(Board board, MarkType player, MarkType opponent)
        {
            Board = board;
            Player = player;
            Opponent = opponent;
        }

        public Position FindRandomMove()
        {
            var availableMoves = Board.GetAvailableMoves();    
            return availableMoves[new Random().Next(availableMoves.Length)];
        }

        public Position FindRandomMoveOrBestMove()
        {
            var randomNumber = new Random().Next(0, 2);

            return randomNumber switch
            {
                0 => FindRandomMove(),
                _ => FindBestMove()
            };
        }

        public Position FindBestMove()
        {
            return Board.GetAvailableMoves().OrderByDescending(target =>
            {
                Board[target.ToString()].Mark = Player;
                int score = Minimax(Opponent);
                Board[target.ToString()].Mark = null;

                return score;
            }).First();
        }

        public int GetMoveScore()
        {
            var engine = new TicTacToeEngine(Board);

            if (engine.IsWin(Player))
            {
                return 1;
            }
            if (engine.IsWin(Opponent))
            {
                return -1;
            }
            
            return 0;
        }

        private int Minimax(MarkType currentPlayer)
        {
            int score = GetMoveScore();

            if (score != 0)
            {
                return score;
            }
            if (Board.IsFull())
            {
                return 0;
            }

            var scores = Board.GetAvailableMoves().Select(target =>
            {
                Board[target.ToString()].Mark = currentPlayer;
                int score = Minimax(GetOpponentFor(currentPlayer));
                Board[target.ToString()].Mark = null;

                return score;
            });

            return currentPlayer == Player ? scores.Max() : scores.Min();
        }

        public static MarkType GetOpponentFor(MarkType mark)
        {
            return mark ^ MarkType.Circle;
        }
    }
}