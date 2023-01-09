using meal_plan_generator.Models.MealPlan;
using Microsoft.EntityFrameworkCore;

namespace meal_plan_generator.Context
{
    public class FakeFoodDbContext : DbContext, IFakeFoodDbContext
    {
        public FakeFoodDbContext(DbContextOptions<FoodDbContext> options) : base(options)
        {
        }

        public DbSet<Food> Foods { get; set; }

    }
}
