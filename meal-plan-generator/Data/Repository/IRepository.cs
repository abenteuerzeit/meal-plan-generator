using System;
using meal_plan_generator.Models;
namespace meal_plan_generator.Data.Repository
{
    public interface IRepository<T> where T : EntityBase
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(int id, string includeProperties = "");

        Task AddAsync(T entity);

        void Update(T entity);

        Task DeleteAsync(int id);

        Task SaveChangesAsync();
    }
}

