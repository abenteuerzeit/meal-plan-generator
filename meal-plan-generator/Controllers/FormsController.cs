using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using meal_plan_generator.Context;
using meal_plan_generator.Models.MealPlan;
using meal_plan_generator.Context.UnitofWork;

namespace meal_plan_generator.Controllers
{
    public class FormsController : Controller
    {
        private readonly IUnitOfWork _uow;
        public FormsController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: Forms
        public async Task<IActionResult> Index()
        {
            return View(await _uow.FormsRepo.GetAllAsync());
        }

        // GET: Forms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _uow.FormsRepo == null)
            {
                return NotFound();
            }

            var form = await _uow.FormsRepo.GetByIdAsync((int)id);
            if (form == null)
            {
                return NotFound();
            }

            return View(form);
        }

        // GET: Forms/Create
        public IActionResult Create()
        {
            return View(new Form());
        }

        // POST: Forms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] Form form)
        {
            if (ModelState.IsValid)
            {

                await _uow.FormsRepo.InsertRecordAsync(form);
                await _uow.FormsRepo.SaveChangesAsync();

                Form check = await _uow.FormsRepo.GetByIdAsync(form.Id);

                return Content(check.ToString()); //RedirectToAction(nameof(Index));
            }
            return View(form);
        }

        // GET: Forms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _uow.FormsRepo == null)
            {
                return NotFound();
            }

            var form = await _uow.FormsRepo.GetByIdAsync((int)id);
            if (form == null)
            {
                return NotFound();
            }
            return View(form);
        }

        // POST: Forms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] Form form)
        {
            if (id != form.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _uow.FormsRepo.Update(form);
                    await _uow.FormsRepo.SaveChangesAsync();

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FormExists(form.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(form);
        }

        // GET: Forms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _uow.FormsRepo == null)
            {
                return NotFound();
            }

            var form = await _uow.FormsRepo.GetByIdAsync((int)id);
            if (form == null)
            {
                return NotFound();
            }

            return View(form);
        }

        // POST: Forms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_uow.FormsRepo == null)
            {
                return Problem("Entity set 'AppDbContext.Forms'  is null.");
            }
            var form = await _uow.FormsRepo.GetByIdAsync(id);
            if (form != null)
            {
                await _uow.FormsRepo.DeleteAsync(id);
            }

            await _uow.FormsRepo.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FormExists(int id)
        {
            return _uow.FormsRepo.GetByIdAsync(id) != null;
        }
    }
}
