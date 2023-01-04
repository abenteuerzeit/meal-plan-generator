using meal_plan_generator.Models.MealPlan;
using Microsoft.EntityFrameworkCore;

namespace meal_plan_generator.Context
{
    public interface IFakeFoodDbContext
    {
        DbSet<Food> Foods { get; }
    }
}