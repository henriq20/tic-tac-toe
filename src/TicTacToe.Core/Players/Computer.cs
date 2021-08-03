namespace TicTacToe.Core.Players
{
    public class Computer : IPlayer
    {
        public Score Score { get; init; }
        public MarkType Mark { get; set; }
        public Difficulty Difficulty { get; init; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Computer"/> class with the specified mark.
        /// </summary>
        /// <param name="mark">The mark that this player will use in a game.</param>
        public Computer(MarkType mark, Difficulty difficulty)
        {
            Mark = mark;
            Score = new Score();
            Difficulty = difficulty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Computer"/> class with the specified mark.
        /// </summary>
        /// <param name="mark">The mark that this player will use in a game.</param>
        /// <param name="score">The score of this player.</param>
        public Computer(MarkType mark, Score score, Difficulty difficulty)
            : this(mark, difficulty)
        {
            Score = score;
        }

        public Position GetMove(Board board)
        {
            var ai = new AI(board, Mark, AI.GetOpponentFor(Mark));

            return Difficulty switch
            {
                Difficulty.Easy => ai.FindRandomMove(),
                Difficulty.Medium => ai.FindRandomMoveOrBestMove(),
                Difficulty.Impossible => ai.FindBestMove()
            };
        }
    }
}