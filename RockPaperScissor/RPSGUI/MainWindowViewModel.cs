using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RPSBase;
using RPSBase.Model;
using System;

namespace RPSGUI
{
    public class MainWindowViewModel : ViewModelBase
    {
        private IRpsGame rPSGame;
        private string cpuTurns;
        private string result;
        private Random random;
        private string playerOneNameInput;
        private bool isStartViewShown;

        public MainWindowViewModel(IRpsGame rpsGame)
        {
            this.isStartViewShown = true;
            this.rPSGame = rpsGame;
            this.random = new Random();
            this.PlayerOneMoveCommand = new RelayCommand<string>(this.PlayGame);
            this.ResetGameCommand = new RelayCommand(this.ResetGame);
            this.StartGameCommand = new RelayCommand(this.StartGame, this.CanExecuteStartGameCommand);
        }

        public string CpuTurns
        {
            get => cpuTurns;
            set => this.Set(nameof(this.CpuTurns), ref this.cpuTurns, value);
        }

        public string Result
        {
            get => result;
            set => this.Set(nameof(this.Result), ref this.result, value);
        }

        public string PlayerOneNameInput 
        { 
            get => playerOneNameInput;
            set 
            {
                this.Set(nameof(this.playerOneNameInput), ref this.playerOneNameInput, value);
                this.StartGameCommand.RaiseCanExecuteChanged();
            }
        }

        public bool IsStartViewShown
        {
            get => isStartViewShown;
            set => this.Set(nameof(this.isStartViewShown), ref this.isStartViewShown, value);
        }

        public RelayCommand<string> PlayerOneMoveCommand { get; }

        public RelayCommand ResetGameCommand { get; }

        public RelayCommand StartGameCommand { get; }

        public string PlayerOneName => rPSGame.PlayerOneName;

        public string PlayerTwoName => rPSGame.PlayerTwoName;

        public double PlayerOneScore => rPSGame.PlayerOneScore;

        public double PlayerTwoScore => rPSGame.PlayerTwoScore;

        private void StartGame()
        {
            this.ResetGame();
            this.rPSGame.SetPlayerName(this.PlayerOneNameInput);
            this.IsStartViewShown = false;
            this.NameChanged();
        }

        private bool CanExecuteStartGameCommand()
        {
            return !string.IsNullOrEmpty(this.PlayerOneNameInput);
        }

        private void PlayGame(string playerOneMove)
        {
            var cpuMove = this.random.Next(0, 3);
            var cpu = (RPS)cpuMove;
            var playerOne = (RPS)Enum.Parse(typeof(RPS), playerOneMove);
            this.rPSGame.Game(playerOne, cpu);
            this.CpuTurns = $"CPU Move : {cpu}";
            this.Result = this.rPSGame.Result;
            this.ScoreChanged();
        }

        private void ResetGame()
        {
            this.rPSGame.Reset();
            this.CpuTurns = string.Empty;
            this.Result = this.rPSGame.Result;
            this.ScoreChanged();
            this.NameChanged();
        }

        private void NameChanged()
        {
            this.RaisePropertyChanged(nameof(PlayerOneName));
            this.RaisePropertyChanged(nameof(PlayerTwoName));
        }

        private void ScoreChanged()
        {
            this.RaisePropertyChanged(nameof(PlayerOneScore));
            this.RaisePropertyChanged(nameof(PlayerTwoScore));
        }
    }
}
