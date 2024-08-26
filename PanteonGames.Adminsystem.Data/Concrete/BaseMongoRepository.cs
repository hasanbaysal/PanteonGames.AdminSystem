using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;
using PanteionGames.AdminSystem.DataAccess.Abstract;
using PanteionGames.AdminSystem.DataAccess.Contexts;
using PanteonGames.AdminSystem.Entity.Entities;

namespace PanteionGames.AdminSystem.DataAccess.Concrete
{
    public class BaseMongoRepository<T> : IMongoRepository<T>
    where T : BaseMongoCollection
    {
        private readonly MongoDbContext _context;
        protected IMongoCollection<T> _collection;
        public BaseMongoRepository(MongoDbContext context, string collectionName)
        {
            _context = context;

            var result = _context.GetCollection<T>(collectionName);
            if (result == null)
                throw new Exception("Collection Not Found Pls Check Collection Name");

            _collection = result;
        }

        public async Task CreateAsync(T entity)
        {
            await _collection.InsertOneAsync(entity);
        }

        public async Task DeleteAsync(ObjectId id)
        {
            await _collection.DeleteOneAsync(g => g.Id == id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _collection.Find(x => true).ToListAsync();
        }

        public async Task<List<T>> GetByFilterAsync(MongoDB.Driver.FilterDefinition<T> filter)
        {
            return await _collection.Find(filter).ToListAsync();
        }

        public async Task<T> GetByIdAsync(ObjectId id)
        {
            return await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(ObjectId id, T entity)
        {
            await _collection.ReplaceOneAsync(p => p.Id == id, entity);
        }
    }

}
