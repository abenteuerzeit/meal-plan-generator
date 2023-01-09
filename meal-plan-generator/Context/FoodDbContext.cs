using meal_plan_generator.Models.MealPlan;
using meal_plan_generator.Models.USDA;
using Microsoft.EntityFrameworkCore;


namespace meal_plan_generator.Context
{
    public class FoodDbContext : DbContext
    {
        public DbSet<Food> Foods { get; set; }
        public DbSet<FoodCategory> FoodCategories { get; set; }
        public DbSet<FoodNutrient> FoodNutrients { get; set; }
        public DbSet<FoodNutrientDerivation> FoodNutrientDerivations { get; set; }
        public DbSet<FoodNutrientSource> FoodNutrientSources { get; set; }
        public DbSet<FoundationFood> FoundationFoods { get; set; }
        public DbSet<MealPlan> MealPlans { get; set; }
        public DbSet<Models.USDA.Nutrient> Nutrients { get; set; }

        public FoodDbContext(DbContextOptions<FoodDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FoodNutrientConfiguration());
            modelBuilder.Entity<FoodNutrient>().HasKey(fn => fn.Id);
            base.OnModelCreating(modelBuilder);
        }
    }
}
