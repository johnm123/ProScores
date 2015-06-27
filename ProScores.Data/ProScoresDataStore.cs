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

        private const string RavenConnectionStringName = "RavenDB";

        private const int ResultsMaxWaitInMs = 500;

        public IEnumerable<ProEvoResult> GetAll()
        {
            using (IDocumentStore store = new DocumentStore { ConnectionStringName = RavenConnectionStringName, DefaultDatabase = DbName })
            {
                store.Initialize();

                using (IDocumentSession session = store.OpenSession()) 
                {
                    //var collection = session.Query<ProEvoResult>().ToList();  

                    // Because of eventual consistency, sometime the newly added result hasn't been saved before requesting them again.
                    var collection = session.Query<ProEvoResult>().
                        Customize(x => x.WaitForNonStaleResultsAsOfNow(TimeSpan.FromMilliseconds(ResultsMaxWaitInMs))).ToList();
                
                    return collection;
                }
            }
        }

        public ProEvoResult CreateOrModify(ProEvoResult result)
        {
            using (IDocumentStore store = new DocumentStore { ConnectionStringName = RavenConnectionStringName, DefaultDatabase = DbName })
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
            using (IDocumentStore store = new DocumentStore { ConnectionStringName = RavenConnectionStringName, DefaultDatabase = DbName })
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
            using (IDocumentStore store = new DocumentStore { ConnectionStringName = RavenConnectionStringName, DefaultDatabase = DbName })
            {
                store.Initialize(); 

                using (IDocumentSession session = store.OpenSession()) 
                {
                    var collection = session.Query<Player>().ToList();
                    return collection;
                }
            }
        }

        public void Delete(int id)
        {
            using (IDocumentStore store = new DocumentStore { ConnectionStringName = RavenConnectionStringName, DefaultDatabase = DbName })
            {
                store.Initialize();

                using (IDocumentSession session = store.OpenSession())
                {
                    string cmd = typeof(ProEvoResult).Name + "s/" + id;
                    session.Delete(cmd);
                    session.SaveChanges();
                }
            }
        }
    }
}
