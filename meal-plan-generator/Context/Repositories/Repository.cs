using meal_plan_generator.Context;
using meal_plan_generator.Models;
using meal_plan_generator.Models.MealPlan;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace meal_plan_generator.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : EntityBase
    {
        private readonly DbSet<TEntity> _dbSet;
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id, string includeProperties = "")
        {
            IQueryable<TEntity> query = _dbSet;
            query = includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries).Aggregate(query, (current, prop) => current.Include(prop));
            return await query.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task InsertRecordAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }


        public void UpdateAsync(TEntity entity)
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

        //public virtual IQueryable<TEntity> AsQueryable()
        //{
        //    return _dbSet.AsQueryable();
        //}

        //public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        //{
        //    return _dbSet.Where(predicate);
        //}

        //public TEntity Single(Expression<Func<TEntity, bool>> predicate)
        //{
        //    return _dbSet.Single(predicate);
        //}

        //public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        //{
        //    TEntity? entity = _dbSet.SingleOrDefault(predicate);
        //    if (entity == null)
        //    {
        //        throw new InvalidOperationException("No matching entity was found.");
        //    }
        //    return entity;
        //}


        //public TEntity First(Expression<Func<TEntity, bool>> predicate)
        //{
        //    return _dbSet.First(predicate);
        //}

        //public void Attach(TEntity entity)
        //{
        //    _dbSet.Attach(entity);
        //}

    }
}
