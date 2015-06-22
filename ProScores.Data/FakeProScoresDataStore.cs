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
            var players = new List<Player>
            {
                new Player() { NickName = "Rimmer", Name = "Shaun" },
                new Player() { NickName = null, Name = "Jabroni" },
                new Player() { NickName = "The King", Name = "John.M" }
            };
            return players;
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