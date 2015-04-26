using System.Collections.Generic;
using System.Linq;
using ProScores.Data;
using ProScores.Objects;

namespace ProScores.Logic
{
    public class ResultManager : IResultManager
    {
        private readonly IProScoresDataStore _resultsDataStore;

        public ResultManager(IProScoresDataStore resultsDataStore)
        {
            _resultsDataStore = resultsDataStore;
        }

        public IEnumerable<ProEvoResult> GetAllResults()
        {
            return _resultsDataStore.GetAll();
        }

        public void AddResult(ProEvoResult result)
        {
            _resultsDataStore.CreateOrModify(result);
        }

        public void AddPlayer(Player player)
        {
            IEnumerable<Player> players =_resultsDataStore.GetAllPlayers();
            
            if (players.Any(p => p.Name == player.Name))
                return;
            
            _resultsDataStore.Create(player);
        }

        public IEnumerable<Player> GetAllPlayers()
        {
            return _resultsDataStore.GetAllPlayers();
        }

        public void RemoveResult(int id)
        {
            _resultsDataStore.Delete(id);
        }

        public IList<PlayerStatistics> GetOrderedPlayerStats()
        {
            var playerNames = new List<string>();
            playerNames.AddRange(_resultsDataStore.GetAll().Select(r => r.PlayerHome).Distinct().ToList());
            playerNames.AddRange(_resultsDataStore.GetAll().Select(r => r.PlayerAway).Distinct().ToList());

            var playerStats = new List<PlayerStatistics>();
            foreach (var playerName in playerNames.Distinct())
            {
                playerStats.Add(GetPlayerStat(playerName));
            }

            return
                playerStats.OrderByDescending(ps => ps.TotalPoints)
                    .ThenByDescending(ps => ps.GoalDifference)
                    .ThenByDescending(ps => ps.GoalsScored)
                    .ThenByDescending(ps => ps.GoalsConceded)
                    .ToList();
        }

        private PlayerStatistics GetPlayerStat(string playerName)
        {
            var playerResults = _resultsDataStore.GetAll().Where(r => r.PlayerHome == playerName || r.PlayerAway == playerName).ToList();

            int gamesPlayed = playerResults.Count();

            int draws = playerResults.Count(pr => pr.GoalsAway == pr.GoalsHome);

            int wins = playerResults.Count(pr => pr.PlayerHome == playerName && pr.GoalsHome > pr.GoalsAway) +
                       playerResults.Count(pr => pr.PlayerAway == playerName && pr.GoalsAway > pr.GoalsHome);

            int losses = gamesPlayed - draws - wins;
            int goalsScored = playerResults.Where(pr => pr.PlayerHome == playerName).Sum(pr => pr.GoalsHome) +
                              playerResults.Where(pr => pr.PlayerAway == playerName).Sum(pr => pr.GoalsAway);

            int goalsConceded = playerResults.Where(pr => pr.PlayerHome == playerName).Sum(pr => pr.GoalsAway) +
                  playerResults.Where(pr => pr.PlayerAway == playerName).Sum(pr => pr.GoalsHome);

            var playerStat = new PlayerStatistics
            {
                PlayerName = playerName,
                GamesPlayed = gamesPlayed,
                Wins = wins,
                Draws = draws,
                Losses = losses,
                GoalsScored = goalsScored,
                GoalsConceded = goalsConceded
            };

            return playerStat;
        }
    }
}
