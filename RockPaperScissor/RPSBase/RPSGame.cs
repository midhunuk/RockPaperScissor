using RPSBase.Model;
using System;

namespace RPSBase
{
    public class RPSGame : IRpsGame
    {
        private Player playerOne;
        private Player playerTwo;

        public RPSGame()
        {
            this.playerOne = new Player(Constants.DefaultPlayerOneName);
            this.playerTwo = new Player(Constants.ComputerPlayerName);
        }

        public string Result { get; set; }

        public string PlayerOneName => this.playerOne.Name;

        public string PlayerTwoName => this.playerTwo.Name;

        public double PlayerOneScore => this.playerOne.Score;

        public double PlayerTwoScore => this.playerTwo.Score;

        public void SetPlayerName(string playerName)
        {
            this.playerOne.Name = playerName;
            this.playerTwo.Name = Constants.ComputerPlayerName;
        }

        public void SetTwoPlayesName(string playerOneName, string playerTwoName)
        {
            this.playerOne.Name = playerOneName;
            this.playerTwo.Name = playerTwoName;
        }

        public void Game(RPS playerOneMove, RPS playerTwoMove)
        {
            if(playerOneMove == playerTwoMove)
            {
                this.playerOne.Score += Constants.DrawScore;
                this.playerTwo.Score += Constants.DrawScore;
                this.Result = "Draw";
            }

            if ((playerOneMove == RPS.Rock && playerTwoMove == RPS.Scissor) ||
                (playerOneMove == RPS.Paper && playerTwoMove == RPS.Rock) ||
                (playerOneMove == RPS.Scissor && playerTwoMove == RPS.Paper))
            {
                this.PlayerOneWins();
            }

            if ((playerOneMove == RPS.Rock && playerTwoMove == RPS.Paper) ||
                (playerOneMove == RPS.Paper && playerTwoMove == RPS.Scissor) ||
                (playerOneMove == RPS.Scissor && playerTwoMove == RPS.Rock))
            {
                this.PlayerTwoWins();
            }

            //this.DetermineWinner(playerOneMove, playerTwoMove);
        }

        

        public void Reset()
        {
            this.playerTwo.Score = 0;
            this.playerOne.Score = 0;
            this.Result = string.Empty;
            this.SetPlayerName(Constants.DefaultPlayerOneName);
        }

    //    public static string RockPaperScissors(string first, string second)
    //            => (first, second) switch
    //{
    //    ("rock", "paper") => "rock is covered by paper. Paper wins.",
    //    ("rock", "scissors") => "rock breaks scissors. Rock wins.",
    //    ("paper", "rock") => "paper covers rock. Paper wins.",
    //    ("paper", "scissors") => "paper is cut by scissors. Scissors wins.",
    //    ("scissors", "rock") => "scissors is broken by rock. Rock wins.",
    //    ("scissors", "paper") => "scissors cuts paper. Scissors wins.",
    //    (_, _) => "tie"
    //};

        private void PlayerTwoWins()
        {
            this.Result = $"{this.playerTwo.Name} Wins";
            this.playerTwo.Score += Constants.WonScore;
            this.playerOne.Score += Constants.LostScore;
        }

        private void PlayerOneWins()
        {
            this.Result = $"{this.playerOne.Name} Wins";
            this.playerOne.Score += Constants.WonScore;
            this.playerTwo.Score += Constants.LostScore;
        }

       
    }
}
