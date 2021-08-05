using Xunit;
using System;
using TicTacToe.Core;

namespace TicTacToe.Tests
{
    public class PositionTests
    {
        [Theory]
        [InlineData("a1", true)]
        [InlineData("b2", true)]
        [InlineData("c3", true)]
        [InlineData("i1", true)]
        [InlineData("i9", true)]
        [InlineData("a9", true)]
        [InlineData("a0", false)]
        [InlineData("i0", false)]
        [InlineData("aa", false)]
        [InlineData("w2", false)]
        [InlineData("a10", false)]
        [InlineData("22", false)]
        [InlineData("a1 ", false)]
        [InlineData("a ", false)]
        [InlineData("a", false)]
        public void IsValid_ShouldReturnExpected(string position, bool expected)
        {
            bool actual = Position.IsValid(position);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("a0")]
        [InlineData("i0")]
        [InlineData("aa")]
        [InlineData("w2")]
        [InlineData("a10")]
        [InlineData("22")]
        [InlineData("a1 ")]
        [InlineData("a ")]
        [InlineData("a")]
        public void FromString_ShouldThrowFormatException(string position)
        {
            Assert.Throws<FormatException>(() => Position.FromString(position));
        }

        [Theory]
        [InlineData("a1", 1, 'a')]
        [InlineData("b2", 2, 'b')]
        [InlineData("c3", 3, 'c')]
        [InlineData("i1", 1, 'i')]
        [InlineData("i9", 9, 'i')]
        [InlineData("a9", 9, 'a')]
        public void FromString_ShouldReturnExpected(string position, int expectedRow, char expectedColumn)
        {
            var p = Position.FromString(position);

            Assert.Equal(expectedRow, p.Row);
            Assert.Equal(expectedColumn, p.Column);
        }
    }
}