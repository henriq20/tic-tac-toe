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
                Board[target.ToString()].Mark = Player;
                int score = Minimax(Opponent);
                Board[target.ToString()].Mark = null;

                return score;
            });

            return currentPlayer == Player ? scores.Max() : scores.Min();
        }

        private MarkType GetOpponentFor(MarkType mark)
        {
            return mark == MarkType.Cross ? MarkType.Circle : MarkType.Cross;
        }
    }
}