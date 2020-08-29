using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RPSBase;
using RPSBase.Model;
using System;
using System.Windows.Input;

namespace RPSGUI
{
    public class MainWindowViewModel : ViewModelBase
    {
        private IRpsGame rPSGame;
        private string cpuTurns;
        private string result;
        private Random random;

        public MainWindowViewModel(IRpsGame rpsGame)
        {
            this.rPSGame = rpsGame;
            this.random = new Random();
            this.PlayerOneMoveCommand = new RelayCommand<string>(this.PlayGame);
            this.ResetGameCommand = new RelayCommand(this.ResetGame);
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

        public RelayCommand<string> PlayerOneMoveCommand { get; }

        public RelayCommand ResetGameCommand { get; }

        public string PlayerOneName => rPSGame.PlayerOneName;

        public string PlayerTwoName => rPSGame.PlayerTwoName;

        public double PlayerOneScore => rPSGame.PlayerOneScore;

        public double PlayerTwoScore => rPSGame.PlayerTwoScore;

        private void PlayGame(string playerOneMove)
        {
            var cpuMove = this.random.Next(0,3);
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
        }

        private void ScoreChanged()
        {
            this.RaisePropertyChanged(nameof(PlayerOneScore));
            this.RaisePropertyChanged(nameof(PlayerTwoScore));
        }
    }
}
