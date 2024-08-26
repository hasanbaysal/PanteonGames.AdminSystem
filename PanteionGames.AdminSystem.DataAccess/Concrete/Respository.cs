using Microsoft.EntityFrameworkCore;
using PanteionGames.AdminSystem.DataAccess.Abstract;
using PanteionGames.AdminSystem.DataAccess.Contexts;
using PanteonGames.AdminSystem.Entity;
using PanteonGames.AdminSystem.Helper.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PanteionGames.AdminSystem.DataAccess.Concrete
{
    public  class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
        }

        public async Task<List<T>> GetAllAsync()
        => await _context.Set<T>().AsNoTracking().ToListAsync();

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter)
        => await _context.Set<T>().AsNoTracking().Where(filter).ToListAsync();


        public async Task<List<T>> GetAllAsync<Tkey>(Expression<Func<T, Tkey>> selector, OrderByTypes orderByTypes = OrderByTypes.ASC)
        {

            return orderByTypes == OrderByTypes.ASC ?
                await _context.Set<T>().AsNoTracking().OrderBy(selector).ToListAsync()
                                                    : await _context.Set<T>().AsNoTracking().OrderByDescending(selector).ToListAsync();

        }

        public async Task<List<T>> GetAllAsync<Tkey>(Expression<Func<T, bool>> filter, Expression<Func<T, Tkey>> selector, OrderByTypes orderByTypes = OrderByTypes.ASC)
        {


            var query = _context.Set<T>().AsNoTracking().Where(filter);

            return orderByTypes == OrderByTypes.ASC ?
                    await query.OrderBy(selector).ToListAsync() :
                                    await query.OrderByDescending(selector).ToListAsync();

        }

        public async Task<T?> FindAsync(object id)
        => await _context.Set<T>().FindAsync(id);
        public async Task<T?> GetbyFilter(Expression<Func<T, bool>> filter, bool asNoTracking = false)
        {

            return !asNoTracking ?
                    await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(filter) :
                                    await _context.Set<T>().FirstOrDefaultAsync(filter);


        }
        public IQueryable<T> GetQueryable()
        => _context.Set<T>().AsQueryable();

        public void Remove(T entity)
        => _context.Set<T>().Remove(entity);

        public void Create(T entity)
        => _context.Set<T>().Add(entity);

        public void Update(T entity, T unchanged)
        => _context.Entry(unchanged).CurrentValues.SetValues(entity);
    }
}
