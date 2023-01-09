using System;
using meal_plan_generator.Data.Repository;
using meal_plan_generator.Models.MealPlan;

namespace meal_plan_generator.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Food> FoodRepo { get; }
        Task SaveChangesAsync();

    }
}

