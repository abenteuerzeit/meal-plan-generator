using meal_plan_generator.Context;
using meal_plan_generator.Models.MealPlan;
using meal_plan_generator.Models.USDA;
using meal_plan_generator.Repository;
using Microsoft.EntityFrameworkCore;

namespace meal_plan_generator.Context.UnitofWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FakeFoodDbContext _context;

        private readonly ApplicationDbContext _context;

        public IRepository<MealManager> MealManagerRepo { get; }

        public UnitOfWork(ApplicationDbContext context, IRepository<MealManager> mealManagerRepo)
        {
            _context = context;
            MealManagerRepo = mealManagerRepo;
        }
        public IRepository<Form> FormRepository { get; }
        public IRepository<Food> FakeFoodsRepo { get; }
        public UnitOfWork(FakeFoodDbContext context, IRepository<Form> formRepo, IRepository<Food> dataRepo)
        {
            _context = context;
            FormRepository = formRepo;
            FakeFoodsRepo = dataRepo;
        }

        public void Save()
        {
            _context.SaveChanges();

        }

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}