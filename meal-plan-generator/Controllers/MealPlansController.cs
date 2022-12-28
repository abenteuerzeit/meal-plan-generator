using meal_plan_generator.Context.UnitofWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace meal_plan_generator.Controllers
{
    public class MealPlansController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public MealPlansController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: MealPlansController
        public IActionResult Index()
        {
            var mealPlans = _unitOfWork.MealPlanRepository.GetAll();
            return View(mealPlans);
        }

        // GET: MealPlansController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MealPlansController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MealPlansController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MealPlansController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MealPlansController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MealPlansController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MealPlansController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
