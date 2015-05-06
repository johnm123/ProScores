using System.Collections.Generic;
using ProScores.Objects;

namespace ProScores.Logic
{
    public interface IResultManager
    {
        IEnumerable<ProEvoResult> GetAllResults();

        IEnumerable<Player> GetAllPlayers();

        void AddResultIfValid(ProEvoResult result);

        void AddPlayerIfValid(Player player);

        void RemoveResult(int id);

        IList<PlayerStatistics> GetOrderedPlayerStats();
    }
}