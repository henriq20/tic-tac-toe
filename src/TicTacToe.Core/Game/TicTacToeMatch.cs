using TicTacToe.Core.Players;

namespace TicTacToe.Core.Game
{
    /// <summary>
    /// Represents a tic-tac-toe match.
    /// </summary>
    public class TicTacToeMatch
    {
        /// <summary>
        /// Gets the total number of moves of this match.
        /// </summary>
        public int Moves { get; private set; }
        public Board Board { get; init; }
        public IPlayer Cross { get; init; }
        public IPlayer Circle { get; init; }
        public MarkType Turn { get; private set; }
        public TicTacToeEngine Engine { get; private set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="TicTacToeMatch"/> class with the specified players.
        /// </summary>
        /// <param name="cross">The player that will play with the cross mark.</param>
        /// <param name="circle">The player that will play with the circle mark.</param>
        public TicTacToeMatch(IPlayer cross, IPlayer circle)
        {
            Cross = cross;
            Circle = circle;
            Board = new Board();
            Engine = new TicTacToeEngine(Board);
        }
        
        /// <summary>
        /// Puts a mark on the specified square.
        /// </summary>
        /// <param name="target">The position of the square.</param>
        public void MakeMove(Position target)
        {
            if (Board[target.ToString()].IsEmpty)
            {
                Board[target.ToString()].Mark = GetCurrentPlayer().Mark;
                ChangeTurn();
                Moves++;
            }
        }

        /// <summary>
        /// Gets the result of this match.
        /// </summary>
        /// <returns>An enum with the result if this match is finished; otherwise, <see langword="null"/>.</returns>
        public TicTacToeMatchResult? GetResult()
        {
            if (Engine.IsTie())
            {
                return TicTacToeMatchResult.Tie;
            }
            if (Engine.IsWin(MarkType.Cross))
            {
                return TicTacToeMatchResult.CrossWin;
            }
            if (Engine.IsWin(MarkType.Circle))
            {
                return TicTacToeMatchResult.CircleWin;
            }

            return null;
        }

        /// <summary>
        /// Gets the player that has the same mark as the <see cref="Turn"/>.
        /// </summary>
        /// <returns>The current player.</returns>
        public IPlayer GetCurrentPlayer()
        {
            return Turn == MarkType.Cross ? Cross : Circle;
        }

        /// <summary>
        /// Changes the current <see cref="Turn"/>.
        /// </summary>
        public void ChangeTurn()
        {
            Turn ^= MarkType.Circle;
        }

        /// <summary>
        /// Indicates whether this match has ended or not by checking for a win or a tie.
        /// </summary>
        /// <returns><see langword="true"/> if it is a win or a tie; otherwise, <see langword="false"/>.</returns>
        public bool IsFinished()
        {
            if (Moves <= Board.Length + 1)
            {
                return false;
            }

            return Engine.IsWin(MarkType.Cross) || Engine.IsWin(MarkType.Circle) || Engine.IsTie();
        }
    }
}