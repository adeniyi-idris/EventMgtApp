using EMA.Data;
using EMA.Models;
using EMA.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace EMA.Controllers
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
            List<Event> events = _context.Events.ToList();
            return View(events);
        }

        public IActionResult Detail(int id)
        {
            Event events = _context.Events.FirstOrDefault(x => x.Id == id);
            return View(events);
        }

        public IActionResult Create()
        {
            //var ev = new Event();
            return View();
        }

        [HttpPost]
        public IActionResult Create(EventViewModel ev)
        {
            if (ModelState.IsValid)
            {
                var Event = new Event
                {
                    Title = ev.Title,
                    Description = ev.Description,
                    Type = ev.Type,
                    StartDate = ev.StartDate,
                    EndDate = ev.EndDate,
                    Location = ev.Location,
                    FormatType = ev.FormatType,
                };
                _context.Events.Add(Event);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ev);
        }

        public IActionResult Edit(int? id)
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
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,EventViewModel ev)
        {
            if (ModelState.IsValid)
            {
                var Event = new Event
                {
                    Title = ev.Title,
                    Description = ev.Description,
                    Type = ev.Type,
                    StartDate = ev.StartDate,
                    EndDate = ev.EndDate,
                    Location = ev.Location,
                    FormatType = ev.FormatType,
                };
                _context.Events.Update(Event);
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
