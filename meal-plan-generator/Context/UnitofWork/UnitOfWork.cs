using meal_plan_generator.Context;
using meal_plan_generator.Models.MealPlan;
using meal_plan_generator.Models.USDA;
using meal_plan_generator.Repository;
using Microsoft.EntityFrameworkCore;

namespace meal_plan_generator.Context.UnitofWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public IRepository<Form> FormRepository { get; }
        public IRepository<Food> FakeFoodsRepo { get; }
        public IRepository<MealPlan> MealPlanRepo { get; }

        public UnitOfWork(AppDbContext context, IRepository<Form> formRepo, IRepository<Food> dataRepo, IRepository<MealPlan> mealPlan)
        {
            _context = context;
            if (!_context.Foods.Any())
                FakeData.Initialize(_context);
            FormRepository = formRepo;
            FakeFoodsRepo = dataRepo;
            MealPlanRepo = mealPlan;
            

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