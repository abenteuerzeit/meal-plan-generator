using meal_plan_generator.Models.MealPlan;
using meal_plan_generator.Models.USDA;
using System.Linq.Expressions;

namespace meal_plan_generator.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> AsQueryable();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        TEntity Single(Expression<Func<TEntity, bool>> predicate);
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);
        TEntity First(Expression<Func<TEntity, bool>> predicate);
        TEntity GetById(object id);
        IEnumerable<TEntity> GetAll();
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Attach(TEntity entity);
    }

}
