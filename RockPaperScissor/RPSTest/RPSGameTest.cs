using FluentAssertions;
using RPSBase;
using RPSBase.Model;
using Xunit;

namespace RPSTest
{
    public class RPSGameTest 
    {
        private RPSGame rPSGame;

        public RPSGameTest()
        {
            rPSGame = new RPSGame();
        }

        [Fact]
        public void DefaultPlayersSetOnInitialize()
        {
            // Assert
            rPSGame.PlayerOneName.Should().Be(Constants.DefaultPlayerOneName);
            rPSGame.PlayerTwoName.Should().Be(Constants.ComputerPlayerName);
            rPSGame.PlayerOneScore.Should().Be(0);
            rPSGame.PlayerTwoScore.Should().Be(0);
        }

        [Fact]
        public void SinglePlayerNameSet_OtherIsComputerPlayerName()
        {
            // Act
            rPSGame.SetPlayerName("Player X");

            // Assert
            rPSGame.PlayerOneName.Should().Be("Player X");
            rPSGame.PlayerTwoName.Should().Be(Constants.ComputerPlayerName);
            rPSGame.PlayerOneScore.Should().Be(0);
            rPSGame.PlayerTwoScore.Should().Be(0);
        }

        [Fact]
        public void TwoPlayersNameSet()
        {
            // Act
            rPSGame.SetTwoPlayesName("Player X", "Player Y");

            // Assert
            rPSGame.PlayerOneName.Should().Be("Player X");
            rPSGame.PlayerTwoName.Should().Be("Player Y");
            rPSGame.PlayerOneScore.Should().Be(0);
            rPSGame.PlayerTwoScore.Should().Be(0);
        }

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
            rPSGame.SetTwoPlayesName("Player X", "Player Y");

            // Act
            rPSGame.Game(playerOneMove, playerTwoMove);

            // Assert
            rPSGame.PlayerOneScore.Should().Be(playerOneScore);
            rPSGame.PlayerTwoScore.Should().Be(playerTwoScore);
            rPSGame.Result.Should().Be(result);
        }

        [Fact]
        public void ResetGame()
        {
            // Arrange
            rPSGame.SetTwoPlayesName("Player X", "Player Y");
            rPSGame.Game(RPS.Paper, RPS.Paper);

            // Act
            rPSGame.Reset();

            // Assert
            rPSGame.PlayerOneName.Should().Be(Constants.DefaultPlayerOneName);
            rPSGame.PlayerTwoName.Should().Be(Constants.ComputerPlayerName);
            rPSGame.PlayerOneScore.Should().Be(0);
            rPSGame.PlayerTwoScore.Should().Be(0);
            rPSGame.Result.Should().Be(string.Empty);
        }
    }
}
