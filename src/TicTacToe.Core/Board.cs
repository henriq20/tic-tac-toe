using System;
using System.Linq;
using System.Collections.Generic;

namespace TicTacToe.Core
{
    /// <summary>
    /// Represents a tic-tac-toe board.
    /// </summary>
    public class Board
    {
        private readonly Square[][] squares;

        /// <summary>
        /// Gets the length of this board.
        /// </summary>
        public int Length { get; init; }
        
        /// <summary>
        /// Gets an square at the specified position.
        /// <para>
        /// The position must be a letter followed by a number.
        /// </para>
        /// </summary>
        /// <exception cref="IndexOutOfRangeException"/>
        /// <exception cref="InvalidOperationException"/>
        public Square this[string position] => GetSquare(position);

        /// <summary>
        /// Gets an square at the specified row and column.
        /// </summary>
        /// <exception cref="IndexOutOfRangeException"/>
        public Square this[int row, int column] => GetSquare(row, column);

        /// <summary>
        /// Initializes a new instance of the <see cref="Board"/> class with the <see cref="Length"/> 3 if not set.
        /// </summary>
        /// <param name="length"></param>
        public Board(int length = 3)
        {
            Length = length;
            squares = new Square[Length][];

            InitializeSquares();
        }

        /// <summary>
        ///Gets all the positions where their corresponding square is empty.
        /// </summary>
        /// <returns>An array with all the available positions.</returns>
        public Position[] GetAvailableMoves()
        {
            return squares.SelectMany(s => s)
                          .Where(s => s.IsEmpty)
                          .Select(s => s.Position)
                          .ToArray();
        }

        /// <summary>
        /// Indicates whether all squares are full (<see cref="Square.Mark"/> is not null).
        /// </summary>
        /// <returns><see langword="true"/> if all squares are; otherwise, <see langword="false"/>.</returns>
        public bool IsFull()
        {
            return squares != null && squares.All(row => row.All(s => !s.IsEmpty));
        }

        /// <summary>
        /// Removes all marks from the squares.
        /// </summary>
        public void Clear()
        {
            for (int row = 0; row < Length; row++)
            {
                for (int column = 0; column < Length; column++)
                {      
                    squares[row][column].Mark = null;
                }
            }
        }

        private Square GetSquare(int row, int column)
        {
            if (row >= Length || column >= Length || row < 0 || column < 0)
            {
                throw new IndexOutOfRangeException("The specified position exceeds the bounds of the board.");
            }

            return squares[row][column];
        }

        private Square GetSquare(string position)
        {
            if (position.Length == 2 && char.IsLetter(position[0]) && char.IsNumber(position[1]))
            {
                return GetSquare((int)(char.GetNumericValue(position[1]) - 1),
                                (char)(position[0] - 'a'));
            }

            throw new InvalidOperationException("The specified position is not valid.");
        }

        private void InitializeSquares()
        {
            for (int row = 0; row < Length; row++)
            {
                squares[row] = new Square[Length];
                
                for (int column = 0; column < Length; column++)
                {
                    var currentPosition = new Position((char)(column + 'a'), row + 1);

                    squares[row][column] = new Square(currentPosition);
                }
            }
        }
    }
}