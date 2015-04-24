using System;
using System.Collections.Generic;
using ProScores.Objects;

namespace ProScores.Models
{
    public class ScoresPageViewModel
    {
        public ScoresPageViewModel()
        {
            NewResult = new ProEvoResult()
            {
                Date = DateTime.Now
            };
        }

        public IEnumerable<ProEvoResult> Results { get; set; }

        public IList<PlayerStat> Stats { get; set; }

        public ProEvoResult NewResult { get; set; }
    }
}