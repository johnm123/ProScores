using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using ProScores.Data;
using ProScores.Logic;
using ProScores.Objects;

namespace ProScores.UnitTest
{
    [TestFixture]
    public class LogicTests
    {
        private Mock<IProScoresDataStore> _mockProScoresDataStore;

        [SetUp]
        public void SetUp()
        {

        
        }

        [Test]
        public void When_Getting_Players_From_Populated_DataStore_Then_Fields_Are_Populated()
        {
            var manager = new ResultManager(GetMockPopulatedDataStore().Object);
            
            var players = manager.GetAllPlayers();

            Assert.AreEqual("John", players.ElementAt(1).Name);
            Assert.AreEqual("Policeman", players.ElementAt(1).DisplayName);
            Assert.AreEqual("Gary", players.ElementAt(2).DisplayName);
        }

        [Test]
        public void When_Getting_Players_From_Empty_DataStore_Then_No_Error_Is_Thrown()
        {
            var manager = new ResultManager(GetMockEmptyDataStore().Object);

            var players = manager.GetAllPlayers();

            Assert.AreEqual(0, players.Count());
        }

        private static Mock<IProScoresDataStore> GetMockPopulatedDataStore()
        {
           var mockProScoresDataStore = new Mock<IProScoresDataStore>();
          
            var players = new List<Player>
            {
                new Player() {Name = "Shaun", NickName = "Rimmer"},
                new Player() {Name = "John", NickName = "Policeman"},
                new Player() {Name = "Gary", NickName = null}
            };

            mockProScoresDataStore.Setup(x => x.GetAllPlayers()).Returns(players);
            return mockProScoresDataStore;
        }

        private static Mock<IProScoresDataStore> GetMockEmptyDataStore()
        {
            var mockProScoresDataStore = new Mock<IProScoresDataStore>();
            mockProScoresDataStore.Setup(x => x.GetAllPlayers()).Returns(new List<Player>());
            return mockProScoresDataStore;
        }
    }
}
