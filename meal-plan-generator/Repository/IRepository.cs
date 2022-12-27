using meal_plan_generator.Models.MealPlan;

namespace meal_plan_generator.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        void Remove(Food food);
        void Add(Food food);
    }

}
