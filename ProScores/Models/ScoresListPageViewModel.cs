using System;
using System.Collections.Generic;
using ProScores.Objects;

namespace ProScores.Models
{
    public class ScoresListPageViewModel
    {
        public IEnumerable<ProEvoResult> Results { get; set; }
    }
}