using Cassandra;

namespace api_seo.Services
{
    public interface ICassandraData
    {
        ISession ActiveSession { get; }
    }
}
