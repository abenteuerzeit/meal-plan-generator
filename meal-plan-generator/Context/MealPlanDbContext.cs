using meal_plan_generator.Models.MealPlan;
using meal_plan_generator.Models.USDA;
using Microsoft.EntityFrameworkCore;
namespace meal_plan_generator.Context
{
    public class MealPlanDbContext : DbContext, IMealPlanDbContext
    {
        public MealPlanDbContext(DbContextOptions<MealPlanDbContext> options) : base(options) { }
        //public DbSet<MealPlan> MealPlans { get; set; }
        //public DbSet<FoundationFood> FoundationFoods { get; set; }
        public DbSet<Form> Forms { get; set; }
        public DbSet<Food> Foods { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Form>()
                .HasMany(form => form.NutrientData)
                .WithOne()
                .HasForeignKey(nutrientData => nutrientData.FormId);
        }
    }
}
