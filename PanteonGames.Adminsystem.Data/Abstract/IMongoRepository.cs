using MongoDB.Bson;
using MongoDB.Driver;
using PanteonGames.AdminSystem.Entity.Entities;

namespace PanteionGames.AdminSystem.DataAccess.Abstract
{
    public interface IMongoRepository<T> where T : BaseMongoCollection
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(ObjectId id);
        Task CreateAsync(T entity);
        Task UpdateAsync(ObjectId id, T entity);
        Task DeleteAsync(ObjectId id);
        Task<List<T>> GetByFilterAsync(FilterDefinition<T> filter);
    }

}
