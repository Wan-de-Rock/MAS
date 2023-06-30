using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TicketPurchaseService.Data;
using TicketPurchaseService.Models;

namespace TicketPurchaseService.Controllers
{
    public class TravelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TravelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Travels
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Travel.Include(t => t.Order).Include(t => t.Passenger);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Travels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Travel == null)
            {
                return NotFound();
            }

            var travel = await _context.Travel
                .Include(t => t.Order)
                .Include(t => t.Passenger)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (travel == null)
            {
                return NotFound();
            }

            return View(travel);
        }

        // GET: Travels/Create
        public IActionResult Create()
        {
            ViewData["OrderId"] = new SelectList(_context.Order, "Id", "Id");
            ViewData["PassengerId"] = new SelectList(_context.Set<Passenger>(), "Id", "PassportNumber");
            return View();
        }

        // POST: Travels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DepartureDateTime,ArrivalDateTime,TotalPrice,OrderId,PassengerId")] Travel travel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(travel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderId"] = new SelectList(_context.Order, "Id", "Id", travel.OrderId);
            ViewData["PassengerId"] = new SelectList(_context.Set<Passenger>(), "Id", "PassportNumber", travel.PassengerId);
            return View(travel);
        }

        // GET: Travels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Travel == null)
            {
                return NotFound();
            }

            var travel = await _context.Travel.FindAsync(id);
            if (travel == null)
            {
                return NotFound();
            }
            ViewData["OrderId"] = new SelectList(_context.Order, "Id", "Id", travel.OrderId);
            ViewData["PassengerId"] = new SelectList(_context.Set<Passenger>(), "Id", "PassportNumber", travel.PassengerId);
            return View(travel);
        }

        // POST: Travels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DepartureDateTime,ArrivalDateTime,TotalPrice,OrderId,PassengerId")] Travel travel)
        {
            if (id != travel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(travel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TravelExists(travel.Id))
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
            ViewData["OrderId"] = new SelectList(_context.Order, "Id", "Id", travel.OrderId);
            ViewData["PassengerId"] = new SelectList(_context.Set<Passenger>(), "Id", "PassportNumber", travel.PassengerId);
            return View(travel);
        }

        // GET: Travels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Travel == null)
            {
                return NotFound();
            }

            var travel = await _context.Travel
                .Include(t => t.Order)
                .Include(t => t.Passenger)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (travel == null)
            {
                return NotFound();
            }

            return View(travel);
        }

        // POST: Travels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Travel == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Travel'  is null.");
            }
            var travel = await _context.Travel.FindAsync(id);
            if (travel != null)
            {
                _context.Travel.Remove(travel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TravelExists(int id)
        {
          return (_context.Travel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
