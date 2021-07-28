namespace TicTacToe.Core.Players
{
    // Represents a tic-tac-toe player.
    public interface IPlayer
    {
        /// <summary>
        /// Gets the score of this player. 
        /// </summary>
        Score Score { get; }

        /// <summary>
        /// Gets or sets the mark that this player will use in a match.
        /// </summary>
        MarkType Mark { get; set; }
    }
}