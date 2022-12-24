using meal_plan_generator.Models.MealPlan;

namespace meal_plan_generator.Services
{
    public interface IService<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        void SaveChanges();
        void AddFood(Food food);
    }

}
