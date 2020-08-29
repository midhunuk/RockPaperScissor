namespace RPSBase.Model
{
    public class Player
    {
        public Player(string playerName)
        {
            this.Name = playerName;
            this.Score = 0;
        }
        public string Name { get; set; }
        public double Score { get; set; }
    }
}

