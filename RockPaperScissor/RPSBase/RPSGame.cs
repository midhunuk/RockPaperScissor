using RPSBase.Model;
using System;

namespace RPSBase
{
    public class RPSGame
    {
        private Player playerOne;
        private Player playerTwo;

        public RPSGame()
        {
            this.playerOne = new Player();
            this.playerTwo = new Player();
        }

        public void Game(RPS playerOneMove, RPS playerTwoMove)
        {
            if(playerOneMove == playerTwoMove)
            {
                this.playerOne.Score += Constants.DrawScore;
                this.playerTwo.Score += Constants.DrawScore;
            }

            if((playerOneMove == RPS.Rock && playerTwoMove == RPS.Scissor) ||
                (playerOneMove == RPS.Paper && playerTwoMove == RPS.Rock) ||
                (playerOneMove == RPS.Scissor && playerTwoMove == RPS.Paper))
            {
                this.PlayerOneWins();
            }

            if((playerOneMove == RPS.Rock && playerTwoMove == RPS.Paper) ||
                (playerOneMove == RPS.Paper && playerTwoMove == RPS.Scissor) ||
                (playerOneMove == RPS.Scissor && playerTwoMove == RPS.Rock))
            {
                this.PlayerTwoWins();
            }
        }

        private void PlayerTwoWins()
        {
            this.playerTwo.Score += Constants.WonScore;
            this.playerOne.Score += Constants.LostScore;
        }

        private void PlayerOneWins()
        {
            this.playerOne.Score += Constants.WonScore;
            this.playerTwo.Score += Constants.LostScore;
        }

        public void Reset()
        {
            this.playerTwo.Score = 0;
            this.playerOne.Score = 0;
        }

        public double GetPlayerOneScore()
        {
            return this.playerOne.Score;
        }

        public double GetPlayerTwoScore()
        {
            return this.playerTwo.Score;
        }
    }
}
