using System;
using System.Collections.Generic;
using System.Linq;
using ProScores.Objects;
using Raven.Client;
using Raven.Client.Document;


namespace ProScores.Data
{
    public class ProScoresDataStore : IProScoresDataStore
    {
        private const string DbName = "scoresDb";

        private const string DbUrl = "http://localhost:8081/";

        public IEnumerable<ProEvoResult> GetAll()
        {
            using (IDocumentStore store = new DocumentStore { Url = DbUrl, DefaultDatabase = DbName })
            {
                store.Initialize(); // initializes document store, by connecting to server and downloading various configurations

                using (IDocumentSession session = store.OpenSession()) // opens a session that will work in context of 'DefaultDatabase'
                {
                    var collection = session.Query<ProEvoResult>().ToList();
                    return collection;
                }
            }
        }

        public ProEvoResult CreateOrModify(ProEvoResult result)
        {
            using (IDocumentStore store = new DocumentStore { Url = DbUrl, DefaultDatabase = DbName })
            {
                store.Initialize();

                using (IDocumentSession session = store.OpenSession())
                {
                    session.Store(result);
                    session.SaveChanges();
                }
            }
            return result;
        }

        public Player Create(Player player)
        {
            using (IDocumentStore store = new DocumentStore { Url = DbUrl, DefaultDatabase = DbName })
            {
                store.Initialize();

                using (IDocumentSession session = store.OpenSession())
                {
                    session.Store(player);
                    session.SaveChanges();
                }
            }
            return player;
        }

        public IEnumerable<Player> GetAllPlayers()
        {
            using (IDocumentStore store = new DocumentStore { Url = DbUrl, DefaultDatabase = DbName })
            {
                store.Initialize(); // initializes document store, by connecting to server and downloading various configurations

                using (IDocumentSession session = store.OpenSession()) // opens a session that will work in context of 'DefaultDatabase'
                {
                    var collection = session.Query<Player>().ToList();
                    return collection;
                }
            }
        }

        public void Delete(int id)
        {
            using (IDocumentStore store = new DocumentStore { Url = DbUrl, DefaultDatabase = DbName })
            {
                store.Initialize();

                using (IDocumentSession session = store.OpenSession())
                {
                    string cmd = "ProEvoResults/" + id;
                    session.Delete(cmd);
                    session.SaveChanges();
                }
            }
        }
    }
}
