using System.Collections.Generic;
using ProScores.Objects;

namespace ProScores.Data
{
    public interface IProScoresDataStore
    {
        IEnumerable<ProEvoResult> GetAll();

        IEnumerable<Player> GetAllPlayers();

        ProEvoResult CreateOrModify(ProEvoResult result);

        Player Create(Player player);

        void Delete(int id);
    }
}