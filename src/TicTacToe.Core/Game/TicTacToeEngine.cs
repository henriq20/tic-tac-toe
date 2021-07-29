using System.Linq;

namespace TicTacToe.Core.Game
{
    public class TicTacToeEngine
    {
        public Board Board { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TicTacToeEngine"/> class with the specified board.
        /// </summary>
        public TicTacToeEngine(Board board)
        {
            Board = board;
        }

        /// <summary>
        /// Indicates whether the current state of the board is full and there is no chance of winning.
        /// </summary>
        /// <returns><see langword="true"/> if it is a tie; otherwise, <see langword="false"/>.</returns>
        public bool IsTie()
        {
            return Board.IsFull() && !IsWin(MarkType.Cross) && !IsWin(MarkType.Circle);
        }

        /// <summary>
        /// Indicates whether the <paramref name="mark"/> has won.
        /// </summary>
        /// <param name="mark">The mark to be checked.</param>
        /// <returns><see langword="true"/> if it has won; otherwise, <see langword="false"/>.</returns>
        public bool IsWin(MarkType mark)
        {
            var leftDiagonalMarks = new MarkType?[Board.Length];
            var rightDiagonalMarks = new MarkType?[Board.Length];

            for (int row = 0; row < Board.Length; row++)
            {
                var verticalMarks = new MarkType?[Board.Length];
                var horizontalMarks = new MarkType?[Board.Length];

                leftDiagonalMarks[row] = Board[row, row].Mark;
                rightDiagonalMarks[row] = Board[row, Board.Length - row - 1].Mark;

                for (int column = 0; column < Board.Length; column++)
                {
                    verticalMarks[column] = Board[column, row].Mark;
                    horizontalMarks[column] = Board[row, column].Mark;
                }

                if (verticalMarks.All(m => m == mark) || horizontalMarks.All(m => m == mark))
                {
                    return true;
                }
            }

            if (leftDiagonalMarks.All(m => m == mark) || rightDiagonalMarks.All(m => m == mark))
            {
                return true;
            }

            return false;
        }
    }
}