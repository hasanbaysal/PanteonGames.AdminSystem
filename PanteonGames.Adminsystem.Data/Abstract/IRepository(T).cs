using PanteonGames.AdminSystem.Entity;
using PanteonGames.AdminSystem.Helper.Enums;
using System.Linq.Expressions;

namespace PanteionGames.AdminSystem.DataAccess.Abstract
{
    public interface IRepository<T> : IRepository where T : BaseEntity
    {
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllAsync<Tkey>(Expression<Func<T, Tkey>> selector, OrderByTypes orderByTypes = OrderByTypes.ASC);
        Task<List<T>> GetAllAsync<Tkey>(Expression<Func<T, bool>> filter, Expression<Func<T, Tkey>> selector, OrderByTypes orderByTypes = OrderByTypes.ASC);
        Task<T?> FindAsync(object id);
        Task<T?> GetbyFilter(Expression<Func<T, bool>> filter, bool asNoTracking = false);
        IQueryable<T> GetQueryable();
        void Remove(T entity);
        void Create(T entity);
        void Update(T entity, T unchanged);

    }

    public interface IRepository
    {

    }
}
