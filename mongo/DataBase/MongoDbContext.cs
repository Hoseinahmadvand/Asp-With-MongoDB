using mongo.Models;
using MongoDB.Driver;

namespace mongo.DataBase
{
    public class MongoDbContext
    {
        private readonly IClientSessionHandle _session;
        private readonly IMongoDatabase _database;
        private readonly IMongoClient _client;
        public MongoDbContext(MongoSettings settings,IMongoClient client)
        {
            _client = client;
            _database=client.GetDatabase(settings.DatabaseName);
            _session = _client.StartSession();
                
        }
        public IClientSessionHandle GetSession()
        {
            return _session ;
        }
        public IMongoDatabase GetDatabase()
        {
            return _database;
        }
        public void StartTransaction()
        {
            _session.StartTransaction();
        }
        public void Commit()
        {
            _session.CommitTransaction();
        }
    }
}
