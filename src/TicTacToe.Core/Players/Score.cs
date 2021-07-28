namespace TicTacToe.Core.Players
{
    /// <summary>
    /// Represents a player's score in a game.
    /// </summary>
    public class Score
    {
        public int Wins { get; set; }
        public int Ties { get; set; }
        public int Losses { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Score"/> class.
        /// </summary>
        public Score()
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Score"/> class with the specified wins, ties, and rows.
        /// </summary>
        /// <param name="wins">The number of wins.</param>
        /// <param name="ties">The number of ties.</param>
        /// <param name="losses">The number of losses.</param>
        public Score(int wins = 0, int ties = 0, int losses = 0)
        {
            Wins = wins;
            Ties = ties;
            Losses = losses;
        }

        /// <summary>
        /// Sets <see cref="Wins"/>, <see cref="Ties"/>, and <see cref="Losses"/> to zero.
        /// </summary>
        public void Reset()
        {
            Wins = 0;
            Ties = 0;
            Losses = 0;
        }
    }
}