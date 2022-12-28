using meal_plan_generator.Context;
using meal_plan_generator.Models.MealPlan;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace meal_plan_generator.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbSet<TEntity> _dbSet;
        public Repository(DbSet<TEntity> dbSet)
        {
            _dbSet = dbSet;
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _dbSet;
        }

        public virtual TEntity GetById(object id)
        {
            return _dbSet.Find(id) ?? throw new ArgumentNullException(nameof(id));
        }

        public virtual void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            _dbSet.Attach(entity);
        }

        public virtual void Remove(object id)
        {
            TEntity entity = _dbSet.Find(id) ?? throw new ArgumentNullException(nameof(id));
            Delete(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public virtual IQueryable<TEntity> AsQueryable()
        {
            return _dbSet.AsQueryable();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public TEntity Single(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Single(predicate);
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            TEntity? entity = _dbSet.SingleOrDefault(predicate);
            if (entity == null)
            {
                throw new InvalidOperationException("No matching entity was found.");
            }
            return entity;
        }


        public TEntity First(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.First(predicate);
        }

        public void Attach(TEntity entity)
        {
            _dbSet.Attach(entity);
        }

    }
}
