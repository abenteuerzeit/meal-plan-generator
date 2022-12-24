using meal_plan_generator.Repository;
using Microsoft.EntityFrameworkCore;

namespace meal_plan_generator.UnitofWork
{
    public class UnitOfWork<TEntity> : IUnitOfWork<TEntity> where TEntity : class
    {
        private readonly DbContext _context;
        private readonly IRepository<TEntity> _repository;

        public UnitOfWork(DbContext context, IRepository<TEntity> repository)
        {
            _context = context;
            _repository = repository;
        }

        public IRepository<TEntity> Repository => _repository;

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }

}
