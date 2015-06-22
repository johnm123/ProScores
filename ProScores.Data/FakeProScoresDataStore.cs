using System.Collections.Generic;

using ProScores.Objects;

namespace ProScores.Data
{
    public class FakeProScoresDataStore : IProScoresDataStore
    {
        public IEnumerable<ProEvoResult> GetAll()
        {
            return new List<ProEvoResult>();
        }

        public IEnumerable<Player> GetAllPlayers()
        {
            return new List<Player>();
        }

        public ProEvoResult CreateOrModify(ProEvoResult result)
        {
            return new ProEvoResult();
        }

        public Player Create(Player player)
        {
            return new Player();
        }

        public void Delete(int id)
        {
        }
    }
}