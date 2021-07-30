using System;
using Xunit;
using TicTacToe.Core;
using TicTacToe.Core.Game;

namespace TicTacToe.Tests
{
    public class TicTacToeEngineTests
    {
        [Theory]
        [InlineData(MarkType.Cross, "a1", "a2", "a3")] // Horizontal Win
        [InlineData(MarkType.Cross, "b1", "b2", "b3")] // Horizontal Win
        [InlineData(MarkType.Cross, "c1", "c2", "c3")] // Horizontal Win
        [InlineData(MarkType.Circle, "a1", "a2", "a3")] // Horizontal Win
        [InlineData(MarkType.Circle, "b1", "b2", "b3")] // Horizontal Win
        [InlineData(MarkType.Circle, "c1", "c2", "c3")] // Horizontal Win
        [InlineData(MarkType.Cross, "a1", "b1", "c1")] // Vertical Win
        [InlineData(MarkType.Cross, "a2", "b2", "c2")] // Vertical Win
        [InlineData(MarkType.Cross, "a3", "b3", "c3")] // Vertical Win
        [InlineData(MarkType.Circle, "a1", "b1", "c1")] // Vertical Win
        [InlineData(MarkType.Circle, "a2", "b2", "c2")] // Vertical Win
        [InlineData(MarkType.Circle, "a3", "b3", "c3")] // Vertical Win
        [InlineData(MarkType.Circle, "a1", "b2", "c3")] // Diagonal Win
        [InlineData(MarkType.Cross, "a1", "b2", "c3")] // Diagonal Win
        [InlineData(MarkType.Circle, "a3", "b2", "c1")] // Diagonal Win
        [InlineData(MarkType.Cross, "a3", "b2", "c1")] // Diagonal Win
        public void IsWin_ShouldReturnTrue(MarkType mark, params string[] positions)
        {
            var board = new Board();

            foreach (var position in positions)
            {
                board[position].Mark = mark;
            }

            var engine = new TicTacToeEngine(board);

            Assert.True(engine.IsWin(mark));
        }

        [Theory]
        [InlineData(MarkType.Cross, null)]
        [InlineData(MarkType.Circle, null)]
        public void IsWin_ShouldReturnFalse(MarkType mark, params string[] positions)
        {
            var board = new Board();

            if (positions != null)
            {
                foreach (var position in positions)
                {
                    board[position].Mark = mark;
                }
            }

            var engine = new TicTacToeEngine(board);

            Assert.False(engine.IsWin(mark));
        }
    }
}
