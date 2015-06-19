namespace ProScores.Objects
{
    public class PlayerStatistics
    {
        private const int points = 3;

        public string PlayerName { get; set; }

        public int GoalsScored { get; set; }

        public int GoalsConceded { get; set; }

        public int GamesPlayed { get; set; }

        public int Wins { get; set; }

        public int Losses { get; set; }

        public int Draws { get; set; }

        public int TotalPoints
        {
            get
            {
                return Draws + (points * Wins);
            }
        }

        public int GoalDifference
        {
            get { return GoalsScored - GoalsConceded; }
        }
    }
}
