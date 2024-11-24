using EventManagementApp.Data;
using EventManagementApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementApp.Controllers
{
    public class EventController : Controller
    {
        private readonly DataContext _context;

        public EventController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Event> events = new List<Event>();
            return View(events);
        }

        public IActionResult Detail(int id)
        {
            Event events = _context.Events.FirstOrDefault(x => x.Id == id);
            return View(events);
        }

        public IActionResult Create()
        {
            var ev = new Event();
            return View(ev);
        }

        [HttpPost]
        public IActionResult Create(Event ev)
        {
            if (ModelState.IsValid)
            {
                _context.Events.Add(ev);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ev);
        }

        public IActionResult Edit(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var Ev = _context.Events.FirstOrDefault(x => x.Id == id);

            if (Ev == null)
            {
                return NotFound();
            }
            return View(Ev);
        }

        [HttpPost]
        public IActionResult Edit(Event ev)
        {
            if (ModelState.IsValid)
            {
                _context.Events.Update(ev);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ev);
        }

        public IActionResult Delete(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var ev = _context.Events.FirstOrDefault(x => x.Id == id);

            if (ev == null)
            {
                return NotFound();
            }
            return View(ev);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var ev = _context.Events.FirstOrDefault(x => x.Id == id);

            if (ev == null)
            {
                return NotFound();
            }

            _context.Events.Remove(ev);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
