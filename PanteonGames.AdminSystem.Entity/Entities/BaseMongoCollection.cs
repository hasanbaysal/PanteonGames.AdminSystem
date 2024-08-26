using MongoDB.Bson;

namespace PanteonGames.AdminSystem.Entity.Entities
{
    public class BaseMongoCollection : IBaseMongoCollection
    {
        public ObjectId Id { get; set; }
    }
}
