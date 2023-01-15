using System;
using meal_plan_generator.Models.MealPlan;
using Microsoft.EntityFrameworkCore;

namespace meal_plan_generator.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opts) : base(opts)
        {
        }

        // Database of foods
        public DbSet<Food> Foods { get; set; }

        // Database of forms for generating varied meal plans
        public DbSet<Form> Forms { get; set; }
        public DbSet<MealPlan> MealPlans { get; set; }






    }
}

