using meal_plan_generator.Models;
using meal_plan_generator.Models.MealPlan;
//using meal_plan_generator.Models.USDA;
using System.Linq.Expressions;

namespace meal_plan_generator.Repository
{
    public interface IRepository<TEntity> where TEntity : EntityBase
    {
        //IQueryable<TEntity> AsQueryable();
        //IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        //TEntity Single(Expression<Func<TEntity, bool>> predicate);
        //TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);
        //TEntity First(Expression<Func<TEntity, bool>> predicate);


        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id, string includeProperties = "");
        Task<IEnumerable<Food>> GetTopAsync(string nutrientName);
        Task InsertRecordAsync(TEntity entity);
        void Update(TEntity entity);
        Task DeleteAsync(int id);
        Task SaveChangesAsync();
        //void Attach(TEntity entity);
    }

}
