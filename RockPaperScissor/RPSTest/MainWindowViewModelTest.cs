using FluentAssertions;
using Moq;
using RPSBase;
using RPSBase.Model;
using RPSGUI;
using Xunit;

namespace RPSTest
{
    public class MainWindowViewModelTest
    {
        private MainWindowViewModel mainWindowViewModel;
        private Mock<IRpsGame> rpsGameMock;

        public MainWindowViewModelTest()
        {
            this.rpsGameMock = new Mock<IRpsGame>();
            this.mainWindowViewModel = new MainWindowViewModel(this.rpsGameMock.Object);
        }

        [Fact]
        public void PlayerOneMove_CpuRandom_ResultDisplayed()
        {
            // Arrange
            this.rpsGameMock.SetupGet(x => x.Result).Returns("Results");
            this.rpsGameMock.SetupGet(x => x.PlayerOneScore).Returns(1);
            this.rpsGameMock.SetupGet(x => x.PlayerTwoScore).Returns(2);

            // Act
            this.mainWindowViewModel.PlayerOneMoveCommand.Execute(RPS.Paper.ToString());

            this.mainWindowViewModel.Result.Should().Be("Results");
            this.mainWindowViewModel.PlayerOneScore.Should().Be(1);
            this.mainWindowViewModel.PlayerTwoScore.Should().Be(2);
        }
    }
}
