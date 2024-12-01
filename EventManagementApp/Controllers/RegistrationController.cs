using EMA.Data;
using EMA.Models;
using Microsoft.AspNetCore.Mvc;

namespace EMA.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly DataContext _context;

        public RegistrationController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Registration> reg = _context.Registrations.ToList();
            return View(reg);
        }

        public IActionResult Detail(int id)
        {
            Registration reg = _context.Registrations.FirstOrDefault(x => x.Id == id);
            return View(reg);
        }

        public IActionResult Create()
        {
            var reg = new Registration();
            return View(reg);
        }

        [HttpPost]
        public IActionResult Create(Registration reg)
        {
            if (ModelState.IsValid)
            {
                _context.Registrations.Add(reg);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reg);
        }

        public IActionResult Edit(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var reg = _context.Registrations.FirstOrDefault(x =>x.Id == id);

            if (reg == null)
            {
                return NotFound();
            }
            return View(reg);
        }

        [HttpPost]
        public IActionResult Edit(Registration reg)
        {
            if (ModelState.IsValid)
            {
                _context.Registrations.Update(reg);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reg);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var reg = _context.Registrations.FirstOrDefault(x => x.Id == id);

            if (reg == null)
            {
                return NotFound();
            }
            return View(reg);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var reg = _context.Registrations.FirstOrDefault(x => x.Id == id);

            if (reg == null)
            {
                return NotFound();
            }

            _context.Registrations.Remove(reg);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
