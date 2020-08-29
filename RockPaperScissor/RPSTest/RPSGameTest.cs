using FluentAssertions;
using RPSBase;
using RPSBase.Model;
using System;
using Xunit;

namespace RPSTest
{
    public class RPSGameTest : IDisposable
    {
        private RPSGame rPSGame;
        public RPSGameTest()
        {
            rPSGame = new RPSGame();
        }

        public void Dispose()
        {
            rPSGame.Reset();
        }

        [Theory]
        [InlineData(RPS.Rock, RPS.Rock, Constants.DrawScore, Constants.DrawScore)]
        [InlineData(RPS.Rock, RPS.Paper, Constants.LostScore, Constants.WonScore)]
        [InlineData(RPS.Rock, RPS.Scissor, Constants.WonScore, Constants.LostScore)]
        [InlineData(RPS.Paper, RPS.Rock, Constants.WonScore, Constants.LostScore)]
        [InlineData(RPS.Paper, RPS.Paper, Constants.DrawScore, Constants.DrawScore)]
        [InlineData(RPS.Paper, RPS.Scissor, Constants.LostScore, Constants.WonScore)]
        [InlineData(RPS.Scissor, RPS.Rock, Constants.LostScore, Constants.WonScore)]
        [InlineData(RPS.Scissor, RPS.Paper, Constants.WonScore, Constants.LostScore)]
        [InlineData(RPS.Scissor, RPS.Scissor, Constants.DrawScore, Constants.DrawScore)]

        public void Game(RPS playerOneMove, RPS playerTwoMove, double playerOneScore, double playerTwoScore)
        {
            // Arrange
            rPSGame.Reset();

            // Act
            rPSGame.Game(playerOneMove, playerTwoMove);

            // Assert
            rPSGame.GetPlayerOneScore().Should().Be(playerOneScore);
            rPSGame.GetPlayerTwoScore().Should().Be(playerTwoScore);
        }
    }
}
