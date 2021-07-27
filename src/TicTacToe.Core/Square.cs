namespace TicTacToe.Core
{
    /// <summary>
    /// Represents a square of a board.
    /// </summary>
    public class Square
    {
        /// <summary>
        /// Gets or sets the mark of this square.
        /// </summary>
        public MarkType? Mark { get; set; }

        /// <summary>
        /// Gets or sets the position of this square.
        /// </summary>
        /// <value></value>
        public Position Position { get; set; }

        /// <summary>
        /// Indicates whether the <see cref="Mark"/> is null.
        /// </summary>
        public bool IsEmpty => Mark == null;

        /// <summary>
        /// Initializes a new instance of the <see cref="Square"/> class with the specified position.
        /// </summary>
        /// <param name="position">The position of this square on the board.</param>
        public Square(Position position)
        {
            Position = position;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Square"/> class with the specified position and mark.
        /// </summary>
        /// <param name="position">The position of this square on the board.</param>
        /// <param name="mark">The mark of this square.</param>
        public Square(Position position, MarkType mark)
            : this(position)
        {
            Mark = mark;
        }
    }
}