using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PanteonGames.AdminSystem.Entity.Entities;
using PanteonGames.AdminSystem.Helper.Options;

namespace PanteionGames.AdminSystem.DataAccess.Contexts
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        private readonly MongoDbConfigOption option = null!;
        public MongoDbContext(IOptions<MongoDbConfigOption> option)
        {

            var client = new MongoClient(option.Value.ConnectionURI);
            _database = client.GetDatabase(option.Value.DatabaseName);
        }
        public IMongoCollection<GameConfig> GameConfigsCollection => _database.GetCollection<GameConfig>(option.CollectionName);

        public IMongoCollection<T> GetCollection<T>(string collectionName) where T : BaseMongoCollection
        {
            var allCollection = _database.ListCollectionNames().ToList();
            var result = allCollection.Contains(collectionName);
            if (result)
                return _database.GetCollection<T>(collectionName);
            else
                return null;
        }
    }

}
