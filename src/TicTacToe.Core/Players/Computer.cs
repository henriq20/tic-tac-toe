using System;

namespace TicTacToe.Core.Players
{
    public class Computer : IPlayer
    {
        public Score Score { get; init; }
        public MarkType Mark { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Computer"/> class with the specified mark.
        /// </summary>
        /// <param name="mark">The mark that this player will use in a game.</param>
        public Computer(MarkType mark)
        {
            Mark = mark;
            Score = new Score();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Computer"/> class with the specified mark.
        /// </summary>
        /// <param name="mark">The mark that this player will use in a game.</param>
        /// <param name="score">The score of this player.</param>
        public Computer(MarkType mark, Score score)
            : this(mark)
        {
            Score = score;
        }

        public static Position GetMove(Board board)
        {
            var availableMoves = board.GetAvailableMoves();

            return availableMoves[new Random().Next(0, availableMoves.Length)];
        }
    }
}