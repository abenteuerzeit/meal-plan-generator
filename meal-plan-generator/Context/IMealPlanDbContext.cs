using meal_plan_generator.Models.MealPlan;
using meal_plan_generator.Models.USDA;
using Microsoft.EntityFrameworkCore;

namespace meal_plan_generator.Context
{
    public interface IMealPlanDbContext
    {
        //DbSet<FoundationFood> FoundationFoods { get; set; }
        //DbSet<MealPlan> MealPlans { get; set; }
        DbSet<Form> Forms { get; }
    }
}