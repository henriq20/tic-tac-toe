namespace TicTacToe.Core.Players
{
    /// <summary>
    /// Represents a human tic-tac-toe player.
    /// </summary>
    public class HumanPlayer : IPlayer
    {
        public Score Score { get; init; }
        public MarkType Mark { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="HumanPlayer"/> class with the specified mark.
        /// </summary>
        /// <param name="mark">The mark that this player will use in a game.</param>
        public HumanPlayer(MarkType mark)
        {
            Mark = mark;
            Score = new Score();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HumanPlayer"/> class with the specified mark.
        /// </summary>
        /// <param name="mark">The mark that this player will use in a game.</param>
        /// <param name="score">The score of this player.</param>
        public HumanPlayer(MarkType mark, Score score)
            : this(mark)
        {
            Score = score;
        }
    }
}