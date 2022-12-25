using System;
using meal_plan_generator.Models;
using Microsoft.EntityFrameworkCore;

namespace meal_plan_generator.Data.Repository
{
    public class DataRepository<T> : IRepository<T> where T : EntityBase
    {
        private readonly ApiDbContext _context;
        private readonly DbSet<T> _dbSet;

        public DataRepository(ApiDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id, string includeProperties = "")
        {
            IQueryable<T> query = _dbSet;
            query = includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries).Aggregate(query
                , (current, prop) => current.Include(prop));

            return await query.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            _dbSet.Remove(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

