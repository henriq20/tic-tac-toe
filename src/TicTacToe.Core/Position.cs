using System;
using System.Text.RegularExpressions;

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

        /// <summary>
        /// Converts the specified string into a <see cref="Position"/> object.
        /// </summary>
        /// <param name="position">The string to be converted.</param>
        /// <returns>A <see cref="Position"/> object with the specified row and column in the <paramref name="position"/> string.</returns>
        /// <exception cref="FormatException"/>
        public static Position FromString(string position)
        {
            if (IsValid(position))
            {
                return new Position(position[0], (int)char.GetNumericValue(position[1]));
            }

            throw new FormatException("The specified position is not a valid position.");
        }

        /// <summary>
        /// Indicates whether the <paramref name="position"/> is valid.
        /// <para>
        /// A valid position must be only 2 characters long.
        /// The first character must be a letter between 'a' and 'i'.
        /// The second character must be a number between 1 and 9.
        /// </para>
        /// </summary>
        /// <param name="position">The position to be evaluated.</param>
        /// <returns><see langword="true"/> if the <paramref name="position"/> is valid; otherwise, <see langword="false"/>.</returns>
        public static bool IsValid(string position)
        {
            return Regex.IsMatch(position, "^[a-iA-I]{1}[1-9]{1}$");
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
        
        public static bool operator ==(Position left, Position right)
        {
            return left.Row == right.Row && left.Column == right.Column;
        }

        public static bool operator !=(Position left, Position right)
        {
            return left.Row != right.Row || left.Column != right.Column;
        }
    }
}