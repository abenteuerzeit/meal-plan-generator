using System;
using System.Collections.Generic;
using System.Linq;
using global::meal_plan_generator.Models.MealPlan;
using meal_plan_generator.Models;
using Microsoft.EntityFrameworkCore;

namespace meal_plan_generator.Context
{
    public static class FakeData
    {
        public static void Initialize(MealPlanDbContext context)
        {
            if (!context.Foods.Any())
            {
                var foods = GenerateFoods();
                context.Foods.AddRange(foods);
                context.SaveChanges();
            }
        }

        private static IEnumerable<Food> GenerateFoods()
        {
            var foods = new List<Food>();

            for (int i = 0; i < 1000; i++)
            {
                var food = new Food
                {
                    // Generate a random string for the name of the food
                    Name = Guid.NewGuid().ToString(),
                    // Generate a random serving size
                    ServingSize = (float)new Random().NextDouble() * 1000,
                    // Generate random values for the nutrients
                    Calories = (float)new Random().NextDouble() * 3000,
                    Protein = (float)new Random().NextDouble() * 100,
                    Carbohydrates = (float)new Random().NextDouble() * 100,
                    Fat = (float)new Random().NextDouble() * 100,
                    Fiber = (float)new Random().NextDouble() * 100,
                    Sugar = (float)new Random().NextDouble() * 100,
                    VitaminA = (float)new Random().NextDouble() * 100,
                    VitaminC = (float)new Random().NextDouble() * 100,
                    Calcium = (float)new Random().NextDouble() * 100,
                    Iron = (float)new Random().NextDouble() * 100
                };

                foods.Add(food);
            }

            return foods;
        }
    }
}

