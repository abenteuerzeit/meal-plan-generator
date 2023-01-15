using meal_plan_generator.Models.MealPlan;

namespace meal_plan_generator.Services
{
    public interface IService<TEntity> where TEntity : class
    {
        void Add(MealPlan entity);
        MealPlan AddFoodsToMealPlan(List<Food> nutrients);
        float CalculateMSCORE(MealPlan mp);
        float CalculateNutrientContent(Food food);
        void CreateMealPlan();
        Task<TEntity> GetNewMealPlanForFormAsync(Form form);
        IEnumerable<MealPlan> GetAll();
        MealPlan GetById(int id);
        List<Food> GetDefaultNutrientList();
        void LoadNutrientData(string database);
        void Remove(MealPlan entity);
        void SaveChanges();
        void Update(MealPlan entity);
    }

}
