using meal_plan_generator.Models.MealPlan;
using meal_plan_generator.Repository;

namespace meal_plan_generator.Context.Repositories
{
    public interface IFormRepository : IRepository<Form>
    {
        Task<IEnumerable<Form>> GetFormById(int id);
    }
}