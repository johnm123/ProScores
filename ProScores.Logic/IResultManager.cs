using System.Collections.Generic;
using ProScores.Objects;

namespace ProScores.Logic
{
    public interface IResultManager
    {
        IEnumerable<ProEvoResult> GetAllResults();

        IEnumerable<Player> GetAllPlayers();

        void AddResult(ProEvoResult result);

        void AddPlayer(Player player);

        void RemoveResult(int id);

        IList<PlayerStatistics> GetOrderedPlayerStats();
    }
}