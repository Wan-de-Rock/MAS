﻿using System;
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
    public class PassengersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PassengersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Passengers
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Passengers.Include(p => p.Citizenship).Include(p => p.Person);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Passengers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Passengers == null)
            {
                return NotFound();
            }

            var passenger = await _context.Passengers
                .Include(p => p.Citizenship)
                .Include(p => p.Person)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (passenger == null)
            {
                return NotFound();
            }

            return View(passenger);
        }

        // GET: Passengers/Create
        public IActionResult Create()
        {
            ViewData["CountryId"] = new SelectList(_context.Country, "Id", "Id");
            ViewData["PersonId"] = new SelectList(_context.Persons, "Id", "FirstName");
            return View();
        }

        // POST: Passengers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PassportNumber,PersonId,CountryId")] Passenger passenger)
        {
            if (ModelState.IsValid)
            {
                _context.Add(passenger);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CountryId"] = new SelectList(_context.Country, "Id", "Id", passenger.CountryId);
            ViewData["PersonId"] = new SelectList(_context.Persons, "Id", "FirstName", passenger.PersonId);
            return View(passenger);
        }

        // GET: Passengers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Passengers == null)
            {
                return NotFound();
            }

            var passenger = await _context.Passengers.FindAsync(id);
            if (passenger == null)
            {
                return NotFound();
            }
            ViewData["CountryId"] = new SelectList(_context.Country, "Id", "Id", passenger.CountryId);
            ViewData["PersonId"] = new SelectList(_context.Persons, "Id", "FirstName", passenger.PersonId);
            return View(passenger);
        }

        // POST: Passengers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PassportNumber,PersonId,CountryId")] Passenger passenger)
        {
            if (id != passenger.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(passenger);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PassengerExists(passenger.Id))
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
            ViewData["CountryId"] = new SelectList(_context.Country, "Id", "Id", passenger.CountryId);
            ViewData["PersonId"] = new SelectList(_context.Persons, "Id", "FirstName", passenger.PersonId);
            return View(passenger);
        }

        // GET: Passengers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Passengers == null)
            {
                return NotFound();
            }

            var passenger = await _context.Passengers
                .Include(p => p.Citizenship)
                .Include(p => p.Person)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (passenger == null)
            {
                return NotFound();
            }

            return View(passenger);
        }

        // POST: Passengers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Passengers == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Passengers'  is null.");
            }
            var passenger = await _context.Passengers.FindAsync(id);
            if (passenger != null)
            {
                _context.Passengers.Remove(passenger);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PassengerExists(int id)
        {
          return (_context.Passengers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
