using meal_plan_generator.Context.UnitofWork;
using meal_plan_generator.Models.MealPlan;
using meal_plan_generator.Models.USDA;
using meal_plan_generator.Repository;
using Microsoft.EntityFrameworkCore;

public class UnitOfWork : DbContext, IUnitOfWork
{
    //private readonly IRepository<MealPlan> mealPlanRepository;
    //private readonly IRepository<FoundationFood> foundationFoodRepository;


    //public IRepository<MealPlan> MealPlanRepository => mealPlanRepository;
    //public IRepository<FoundationFood> FoundationFoodRepository => foundationFoodRepository;
    public IRepository<Form> FormRepository { get; set; }


    public DbSet<Form> Forms { get; set; }


    //public DbSet<MealPlan> MealPlans { get; set; }
    //public DbSet<FoundationFood> FoundationFoods { get; set; }
    public UnitOfWork(DbContextOptions<UnitOfWork> options)
        : base(options)
    {
        Forms = Set<Form>();
        FormRepository = new Repository<Form>(Forms);
        //MealPlans = Set<MealPlan>();
        //FoundationFoods = Set<FoundationFood>();
        //mealPlanRepository = new Repository<MealPlan>(MealPlans);
        //foundationFoodRepository = new Repository<FoundationFood>(FoundationFoods);
    }


    public void Save()
    {
        SaveChanges();
    }
}
