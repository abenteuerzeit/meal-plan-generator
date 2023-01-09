using meal_plan_generator.Context.UnitofWork;
using meal_plan_generator.Models.MealPlan;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace meal_plan_generator.Controllers
{
    // http://localhost/Controller/Action

    /*
     * https://learn.microsoft.com/en-us/aspnet/mvc/overview/older-versions-1/controllers-and-routing/aspnet-mvc-controllers-overview-cs
        Action results:  
        View() -> HTML and markup.
        EmptyResult -> no result.
        Redirect() -> a redirection to a new URL.
            - RedirectToAction()
            - RedirectToRoute()
        Json() -> a JavaScript Object Notation result that can be used in an AJAX application.
        JavaScriptResult() -> a JavaScript script.
        Content("Hello Peter!") -> a plain text result, wraps non-action results such as Dates and Integers as a ContentResult, eg.: `return DateTime.Now;`
        File()
            - FileContentResult -> a downloadable file (with the binary content).
            - FilePathResult ->  a downloadable file (with a path).
            - FileStreamResult -> a downloadable file (with a file stream).
     */
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
            Form form = new Form();
            return View(form);
        }

        // POST: MealPlansController/GenerateMealPlan
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GenerateMealPlan(Form form)
        {
            try
            {
                // Generate the meal plan using the form data and save it to the database
                // using the unit of work instance

                // Redirect to the Index action to display the generated meal plan
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                // If an error occurred, display an error message to the user
                return View("Error");
            }
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
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}