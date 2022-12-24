using meal_plan_generator.Repository;

namespace meal_plan_generator.UnitofWork
{
    public interface IUnitOfWork<TEntity> where TEntity : class
    {
        IRepository<TEntity> Repository { get; }
        void SaveChanges();
    }

}
