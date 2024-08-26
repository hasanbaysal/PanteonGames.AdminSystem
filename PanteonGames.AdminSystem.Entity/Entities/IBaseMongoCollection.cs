using MongoDB.Bson;

namespace PanteonGames.AdminSystem.Entity.Entities
{
    public interface IBaseMongoCollection
    {
        public ObjectId Id { get; set; }
    }
}
