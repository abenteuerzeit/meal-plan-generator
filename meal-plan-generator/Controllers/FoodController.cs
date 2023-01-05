using meal_plan_generator.Context.UnitofWork;
using meal_plan_generator.Models.MealPlan;
using meal_plan_generator.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace meal_plan_generator.Controllers
{
    public class FoodController : Controller
    {
        //private readonly IService<Food> _foodService;
        private readonly IUnitOfWork _uow;

        public FoodController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<IActionResult> Index()
        {
            var foods = await _uow.FakeFoodsRepo.GetAllAsync();
            return View(foods);
        }


        //public ActionResult AddFood(Food food)
        //{
        //    // Add the food to the meal plan using the service layer
        //    _foodService.Add(food);

        //    // Save changes to the database using the service layer
        //    _foodService.SaveChanges();

        //    // Display the updated list of foods in the meal plan to the user in the view
        //    var foods = _foodService.GetAll();
        //    return View("Index", foods);
        //}

    }
}
