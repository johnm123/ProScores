using System.Collections.Generic;
using ProScores.Objects;

namespace ProScores.Data
{
    public interface IProScoresDataStore
    {
        ProEvoResult Get(int id);

        IEnumerable<ProEvoResult> GetAll();

        ProEvoResult CreateOrModify(ProEvoResult result);
    }
}