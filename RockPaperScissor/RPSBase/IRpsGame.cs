using RPSBase.Model;

namespace RPSBase
{
    public interface IRpsGame
    {
        string Result { get; set; }

        string PlayerOneName { get; }

        string PlayerTwoName { get; }

        double PlayerOneScore { get; }

        double PlayerTwoScore { get; }

        void Game(RPS playerOneMove, RPS playerTwoMove);

        void Reset();
        
    }
}
