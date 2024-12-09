using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EMA.Data;
using EMA.Models;

namespace EMA.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly DataContext _context;

        public RegistrationController(DataContext context)
        {
            _context = context;
        }

        // GET: Registrations2
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.Registrations.Include(r => r.AppUser).Include(r => r.Event);
            return View(await dataContext.ToListAsync());
        }

        // GET: Registrations2/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registration = await _context.Registrations
                .Include(r => r.AppUser)
                .Include(r => r.Event)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registration == null)
            {
                return NotFound();
            }

            return View(registration);
        }

        // GET: Registrations2/Create
        public IActionResult Create()
        {
            ViewData["AppUserId"] = new SelectList(_context.AppUser, "Id", "Id");
            ViewData["EventId"] = new SelectList(_context.Events, "Id", "Id");
            return View();
        }

        // POST: Registrations2/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EventId,AppUserId,FirstName,LastName,Email,PhoneNumber,Organization,RegistrationType,SpecialRequirements,AcceptTerms")] Registration registration)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registration);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AppUserId"] = new SelectList(_context.AppUser, "Id", "Id", registration.AppUserId);
            ViewData["EventId"] = new SelectList(_context.Events, "Id", "Id", registration.EventId);
            return View(registration);
        }

        // GET: Registrations2/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registration = await _context.Registrations.FindAsync(id);
            if (registration == null)
            {
                return NotFound();
            }
            ViewData["AppUserId"] = new SelectList(_context.AppUser, "Id", "Id", registration.AppUserId);
            ViewData["EventId"] = new SelectList(_context.Events, "Id", "Id", registration.EventId);
            return View(registration);
        }

        // POST: Registrations2/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EventId,AppUserId,FirstName,LastName,Email,PhoneNumber,Organization,RegistrationType,SpecialRequirements,AcceptTerms")] Registration registration)
        {
            if (id != registration.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registration);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistrationExists(registration.Id))
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
            ViewData["AppUserId"] = new SelectList(_context.AppUser, "Id", "Id", registration.AppUserId);
            ViewData["EventId"] = new SelectList(_context.Events, "Id", "Id", registration.EventId);
            return View(registration);
        }

        // GET: Registrations2/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registration = await _context.Registrations
                .Include(r => r.AppUser)
                .Include(r => r.Event)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registration == null)
            {
                return NotFound();
            }

            return View(registration);
        }

        // POST: Registrations2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var registration = await _context.Registrations.FindAsync(id);
            if (registration != null)
            {
                _context.Registrations.Remove(registration);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegistrationExists(int id)
        {
            return _context.Registrations.Any(e => e.Id == id);
        }
    }
}
