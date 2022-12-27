using Microsoft.EntityFrameworkCore;
using meal_plan_generator.Models.USDA;

namespace meal_plan_generator
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }
        public DbSet<FoodCategory> FoodCategories { get; set; }
        public DbSet<FoodNutrient> FoodNutrients { get; set; }
        public DbSet<FoodNutrientDerivation> FoodNutrientDerivations { get; set; }
        public DbSet<FoodNutrientSource> FoodNutrientSources { get; set; }
        public DbSet<FoodPortion> FoodPortions { get; set; }
        public DbSet<Nutrient> Nutrients { get; set; }
    }
}