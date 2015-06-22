using System;
using System.Collections.Generic;
using ProScores.Objects;

namespace ProScores.Models
{
    public class ScoresPageViewModel
    {
        private IEnumerable<Player> players = new[]
                       {
                           new Player() { Name = "Foo" }, 
                           new Player() { Name = "Boo" }
                       };

        public ScoresPageViewModel()
        {
            NewResult = new ProEvoResult()
            {
                Date = DateTime.Now
            };

            NewPlayer = new Player();

            LastResultId = 0;
        }

        public IEnumerable<ProEvoResult> Results { get; set; }

        public IList<PlayerStatistics> Stats { get; set; }

        public ProEvoResult NewResult { get; set; }

        public IEnumerable<Player> Players
        {
            get
            {
                return this.players;
            }
            set
            {
            }
        }

        public Player NewPlayer { get; set; }

        public int LastResultId { get; set; }
    }
}