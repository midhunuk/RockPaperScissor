using RPSBase.Model;

namespace RPSBase
{
    public class RPSGame
    {
        private double drawScore = 0.5;
        private double winScore = 1;
        private double lostScore = 0;
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
                this.playerOne.Score += drawScore;
                this.playerTwo.Score += drawScore;
            }
        }
    }
}
