using meal_plan_generator.Models.MealPlan;
using meal_plan_generator.Repository;

namespace meal_plan_generator.Context.Repositories
{
    public interface IMealPlanRepository : IRepository<MealPlan>
    {
        Task<IEnumerable<MealPlan>> GetMealPlanById(int id);
    }
}