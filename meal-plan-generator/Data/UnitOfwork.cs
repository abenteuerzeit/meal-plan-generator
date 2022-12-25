using System;
using meal_plan_generator.Data.Repository;
using meal_plan_generator.Models.MealPlan;

namespace meal_plan_generator.Data
{
    public class UnitOfwork : IUnitOfWork
    {
        private readonly ApiDbContext _context;

        public IRepository<Food?> FoodRepo { get; }

        public UnitOfwork(ApiDbContext context, IRepository<Food> foodRepo)
        {
            _context = context;
            FoodRepo = foodRepo;
        }

        public virtual void Dispose(bool disposing)
        {
            if (disposing)
                _context.Dispose();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

