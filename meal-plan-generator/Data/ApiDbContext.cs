using System;
using meal_plan_generator.Models.MealPlan;
using Microsoft.EntityFrameworkCore;

namespace meal_plan_generator.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions opts) : base(opts)
        {   }

        public DbSet<Food> Foods { get; set; } = null;
    }
}

