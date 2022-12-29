using meal_plan_generator.Models.MealPlan;
using meal_plan_generator.Models.USDA;
using meal_plan_generator.Repository;

namespace meal_plan_generator.Context.UnitofWork
{
    public interface IUnitOfWork : IDisposable
    {
        //IRepository<MealPlan> MealPlanRepository { get; }
        //IRepository<FoundationFood> FoundationFoodRepository { get; }
        IRepository<Form> FormRepository { get; }
        void Save();
    }

}
