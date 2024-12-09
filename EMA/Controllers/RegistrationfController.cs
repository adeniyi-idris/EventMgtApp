using EMA.Data;
using EMA.Models;
using EMA.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EMA.Controllers
{
    public class RegistrationfController : Controller
    {
        private readonly DataContext _context;

        public RegistrationfController(DataContext context)
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
            //var reg = new Registration();
            var events = _context.Events
            .Select(e => new { e.Id, e.Title }).ToList();
            ViewData["EventId"] = new SelectList(events, "Id", "Title");
            return View();
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,EventId,AppUserId,FirstName,LastName,Email,PhoneNumber,Organization,RegistrationType,SpecialRequirements,AcceptTerms")] Registration registration)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(registration);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    //ViewData["AppUserId"] = new SelectList(_context.AppUser, "Id", "Id", registration.AppUserId);
        //    ViewData["EventId"] = new SelectList(_context.Events, "Id", "Id", registration.EventId);
        //    return View(registration);
        //}
        public IActionResult Create(RegistrationViewModel reg)
        {
            if (ModelState.IsValid)
            {
                var Registration = new Registration
                {
                    EventId = reg.EventId,
                    FirstName = reg.FirstName,
                    LastName = reg.LastName,
                    Email = reg.Email,
                    PhoneNumber = reg.PhoneNumber,
                    Organization = reg.Organization,
                    RegistrationType = reg.RegistrationType,
                    SpecialRequirements = reg.SpecialRequirements,
                    AcceptTerms = reg.AcceptTerms,
                };
                //var eventExists = _context.Events.Any(e => e.Id == reg.EventId);
                //if (!eventExists)
                //{
                //    ModelState.AddModelError("EventId", "Selected event does not exist.");
                //    ViewData["EventId"] = new SelectList(_context.Events, "Id", "EventTitle", reg.EventId);
                //    return View(reg);
                //}
                _context.Registrations.Add(Registration);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            var events = _context.Events
           .Select(e => new { e.Id, e.Title }).ToList();
            ViewData["EventId"] = new SelectList(events, "Id", "Title", reg.EventId);
            return View(reg);
        }

        public IActionResult Edit(int? id)
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
            var events = _context.Events
           .Select(e => new { e.Id, e.Title }).ToList();
            ViewData["EventId"] = new SelectList(events, "Id", "Title");
            return View(reg);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,RegistrationViewModel reg)
        {
            if (ModelState.IsValid)
            {
                var Registration = new Registration
                {
                    EventId = reg.EventId,
                    FirstName = reg.FirstName,
                    LastName = reg.LastName,
                    Email = reg.Email,
                    PhoneNumber = reg.PhoneNumber,
                    Organization = reg.Organization,
                    RegistrationType = reg.RegistrationType,
                    SpecialRequirements = reg.SpecialRequirements,
                    AcceptTerms = reg.AcceptTerms,
                };

                _context.Registrations.Update(Registration);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            var events = _context.Events
           .Select(e => new { e.Id, e.Title }).ToList();
            ViewData["EventId"] = new SelectList(events, "Id", "Title", reg.EventId);
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
