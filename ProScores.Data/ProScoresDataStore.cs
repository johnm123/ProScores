﻿using System;
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

        public ProEvoResult Get(int id)
        {
            using (IDocumentStore store = new DocumentStore { Url = DbUrl, DefaultDatabase = DbName })
            {
                store.Initialize(); // initializes document store, by connecting to server and downloading various configurations

                using (IDocumentSession session = store.OpenSession()) // opens a session that will work in context of 'DefaultDatabase'
                {
                    var loadedResult = session.Load<ProEvoResult>(id);
                    return loadedResult;
                }
            }
        }

        public IEnumerable<ProEvoResult> GetAll()
        {
            using (IDocumentStore store = new DocumentStore { Url = DbUrl, DefaultDatabase = DbName })
            {
                store.Initialize(); // initializes document store, by connecting to server and downloading various configurations

                using (IDocumentSession session = store.OpenSession()) // opens a session that will work in context of 'DefaultDatabase'
                {
                    var loadedResultCollection = session.Query<ProEvoResult>().ToList();
                    return loadedResultCollection;
                }
            }
        }
    }
}