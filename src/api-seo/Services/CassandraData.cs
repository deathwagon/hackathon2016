using System;
using Cassandra;

namespace api_seo.Services
{
    public class CassandraData : ICassandraData
    {
        private Lazy<ISession> _cassandraSession;
        //private static readonly string[] ContactPoints = { "137.135.48.24" };
        private static readonly string[] ContactPoints = { "cassandra" };
        // private const string User = "cassandra";
        // private const string Password = "80snywhE";
        private const string User = "";
        private const string Password = "";
        private string _keySpace = "seo";

        public CassandraData()
        {
            _cassandraSession = new Lazy<ISession>(CreateSession);
        }

        private ISession CreateSession()
        {
            var cluster = Cluster.Builder()
                    .AddContactPoints(ContactPoints)
                    //.WithCredentials(User, Password)
                    //.WithQueryOptions(new QueryOptions().SetConsistencyLevel(ConsistencyLevel.Quorum)) 
                    .WithRetryPolicy(DowngradingConsistencyRetryPolicy.Instance) 
                    .WithReconnectionPolicy(new ExponentialReconnectionPolicy(100, 10000)) 
                    .Build();
            return cluster.Connect(_keySpace);            
        }

        public ISession ActiveSession 
        {
            get { return _cassandraSession.Value; }
        }
    }
}