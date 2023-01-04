//using System.Collections.Generic;
//using System.Linq.Expressions;
//using System.Threading.Tasks;
//using meal_plan_generator.Context.Repositories;
//using meal_plan_generator.Context;
//using meal_plan_generator.Models.MealPlan;
//using meal_plan_generator.Repository;
//using Microsoft.EntityFrameworkCore;

//public class MealPlanFormRepository : Repository<Form>, IFormRepository
//{
//    private readonly MealPlanDbContext _context;
//    public MealPlanFormRepository(MealPlanDbContext context) : base(context)
//    {
//        _context = context;
//    }

//    public async Task<IEnumerable<Form>> GetFormById(int id)
//    {
//        return await _context.Forms
//            .Where(f => f.Id == id)
//            .ToListAsync();
//    }
//}
