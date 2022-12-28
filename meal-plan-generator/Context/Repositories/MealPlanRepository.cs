using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using meal_plan_generator.Context.Repositories;
using meal_plan_generator.Context;
using meal_plan_generator.Models.MealPlan;
using meal_plan_generator.Repository;
using Microsoft.EntityFrameworkCore;

public class MealPlanRepository : Repository<MealPlan>, IMealPlanRepository
{
    private readonly MealPlanDbContext _context;
    public MealPlanRepository(MealPlanDbContext context) : base(context.MealPlans)
    {
        _context = context;
    }

    public async Task<IEnumerable<MealPlan>> GetMealPlanById(int id)
    {
        return await _context.MealPlans
            .Where(mp => mp.Id == id)
            .ToListAsync();
    }
}
