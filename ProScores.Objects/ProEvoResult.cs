using System;
namespace ProScores.Objects
{
    public class ProEvoResult
    {
        public int Id { get; set; }

        public string PlayerHome { get; set; }       

        public string PlayerAway { get; set; }

        public int GoalsHome { get; set; }

        public int GoalsAway { get; set; }

        public DateTime Date { get; set; }
    }
}
