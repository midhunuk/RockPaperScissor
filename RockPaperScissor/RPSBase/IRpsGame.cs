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

        void SetPlayerName(string playerName);

        void SetTwoPlayesName(string playerOneName, string playerTwoName);

        void Game(RPS playerOneMove, RPS playerTwoMove);

        void Reset();
        
    }
}
