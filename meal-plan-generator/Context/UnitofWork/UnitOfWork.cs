using meal_plan_generator.Context.UnitofWork;
using meal_plan_generator.Models.MealPlan;
using meal_plan_generator.Models.USDA;
using meal_plan_generator.Repository;
using Microsoft.EntityFrameworkCore;

public class UnitOfWork : DbContext, IUnitOfWork
{
    private readonly IRepository<MealPlan> mealPlanRepository;
    private readonly IRepository<FoundationFood> foundationFoodRepository;
    public DbSet<MealPlan> MealPlans { get; set; }
    public DbSet<FoundationFood> FoundationFoods { get; set; }
    public UnitOfWork(DbContextOptions<UnitOfWork> options)
        : base(options)
    {
        MealPlans = Set<MealPlan>();
        FoundationFoods = Set<FoundationFood>();
        mealPlanRepository = new Repository<MealPlan>(MealPlans);
        foundationFoodRepository = new Repository<FoundationFood>(FoundationFoods);
    }

    public IRepository<MealPlan> MealPlanRepository => mealPlanRepository;
    public IRepository<FoundationFood> FoundationFoodRepository => foundationFoodRepository;

    public void Save()
    {
        SaveChanges();
    }
}
