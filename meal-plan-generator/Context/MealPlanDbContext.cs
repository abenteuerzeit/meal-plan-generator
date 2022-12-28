using meal_plan_generator.Models.MealPlan;
using meal_plan_generator.Models.USDA;
using Microsoft.EntityFrameworkCore;

namespace meal_plan_generator.Context
{
    public class MealPlanDbContext : DbContext, IMealPlanDbContext
    {
        public MealPlanDbContext(DbContextOptions<MealPlanDbContext> options) : base(options) { }
        public DbSet<MealPlan> MealPlans { get; set; }
        public DbSet<FoundationFood> FoundationFoods { get; set; }
    }
}
