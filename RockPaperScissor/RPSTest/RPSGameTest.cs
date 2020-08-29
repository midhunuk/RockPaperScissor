using FluentAssertions;
using RPSBase;
using RPSBase.Model;
using Xunit;

namespace RPSTest
{
    public class RPSGameTest 
    {
        private RPSGame rPSGame;
        
        [Theory]
        [InlineData(RPS.Rock, RPS.Rock, Constants.DrawScore, Constants.DrawScore, "Draw")]
        [InlineData(RPS.Rock, RPS.Paper, Constants.LostScore, Constants.WonScore, "Player Y Wins")]
        [InlineData(RPS.Rock, RPS.Scissor, Constants.WonScore, Constants.LostScore, "Player X Wins")]
        [InlineData(RPS.Paper, RPS.Rock, Constants.WonScore, Constants.LostScore, "Player X Wins")]
        [InlineData(RPS.Paper, RPS.Paper, Constants.DrawScore, Constants.DrawScore, "Draw")]
        [InlineData(RPS.Paper, RPS.Scissor, Constants.LostScore, Constants.WonScore, "Player Y Wins")]
        [InlineData(RPS.Scissor, RPS.Rock, Constants.LostScore, Constants.WonScore, "Player Y Wins")]
        [InlineData(RPS.Scissor, RPS.Paper, Constants.WonScore, Constants.LostScore, "Player X Wins")]
        [InlineData(RPS.Scissor, RPS.Scissor, Constants.DrawScore, Constants.DrawScore, "Draw")]

        public void Game(RPS playerOneMove, RPS playerTwoMove, double playerOneScore, double playerTwoScore, string result)
        {
            // Arrange
            rPSGame = new RPSGame("Player X", "Player Y");

            // Act
            rPSGame.Game(playerOneMove, playerTwoMove);

            // Assert
            rPSGame.PlayerOneScore.Should().Be(playerOneScore);
            rPSGame.PlayerTwoScore.Should().Be(playerTwoScore);
            rPSGame.Result.Should().Be(result);
        }
    }
}
