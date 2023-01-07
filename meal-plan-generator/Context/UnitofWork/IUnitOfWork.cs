using meal_plan_generator.Models.MealPlan;
//using meal_plan_generator.Models.USDA;
using meal_plan_generator.Repository;

namespace meal_plan_generator.Context.UnitofWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Form> FormsRepo { get; }
        IRepository<Food> FakeFoodsRepo { get; }
        IRepository<MealPlan> MealPlanRepo { get; }
        void Save();
    }

}
