using RPSBase;

namespace RPSGUI
{
    public class MainWindowViewModel
    {
        private RPSGame rPSGame;
        public MainWindowViewModel()
        {
            rPSGame = new RPSGame("Player One");
        }

        public string PlayerOneName => rPSGame.GetPlayerOneName();

        public string PlayerTwoName => rPSGame.GetPlayerTwoName();
    }
}
