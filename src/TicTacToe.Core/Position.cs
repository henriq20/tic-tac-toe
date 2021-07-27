using System;

namespace TicTacToe.Core
{
    /// <summary>
    /// Represents a position that is identified by a letter and a number.
    /// </summary>
    public struct Position
    {
        /// <summary>
        /// Gets or sets a number that identifies the Row.
        /// </summary>
        public int Row { readonly get; set; }

        /// <summary>
        /// Gets or sets a letter that identifies the Column.
        /// </summary>
        public char Column { readonly get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Position"/> struct with the specified column and row.
        /// </summary>
        /// <param name="column">A letter that denotes the vertical position.</param>
        /// <param name="row">A number that denotes the horizontal position.</param>
        public Position(char column, int row)
        {
            Row = row;
            Column = column;
        }

        public static bool operator ==(Position left, Position right)
        {
            return left.Row == right.Row && left.Column == right.Column;
        }

        public static bool operator !=(Position left, Position right)
        {
            return left.Row != right.Row || left.Column != right.Column;
        }
        
        public override bool Equals(object obj)
        {
            var otherPosition = obj as Position?;

            if (obj is null)
            {
                return false;
            }

            return otherPosition == this;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Row, Column);
        }

        public override string ToString()
        {
            return string.Concat(Column, Row);
        }
    }
}