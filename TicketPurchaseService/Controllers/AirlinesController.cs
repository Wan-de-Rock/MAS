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
    public class AirlinesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AirlinesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Airlines
        public async Task<IActionResult> Index()
        {
              return _context.Airline != null ? 
                          View(await _context.Airline.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Airline'  is null.");
        }

        // GET: Airlines/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Airline == null)
            {
                return NotFound();
            }

            var airline = await _context.Airline
                .FirstOrDefaultAsync(m => m.Id == id);
            if (airline == null)
            {
                return NotFound();
            }

            return View(airline);
        }

        // GET: Airlines/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Airlines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Airline airline)
        {
            if (ModelState.IsValid)
            {
                _context.Add(airline);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(airline);
        }

        // GET: Airlines/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Airline == null)
            {
                return NotFound();
            }

            var airline = await _context.Airline.FindAsync(id);
            if (airline == null)
            {
                return NotFound();
            }
            return View(airline);
        }

        // POST: Airlines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Airline airline)
        {
            if (id != airline.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(airline);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AirlineExists(airline.Id))
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
            return View(airline);
        }

        // GET: Airlines/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Airline == null)
            {
                return NotFound();
            }

            var airline = await _context.Airline
                .FirstOrDefaultAsync(m => m.Id == id);
            if (airline == null)
            {
                return NotFound();
            }

            return View(airline);
        }

        // POST: Airlines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Airline == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Airline'  is null.");
            }
            var airline = await _context.Airline.FindAsync(id);
            if (airline != null)
            {
                _context.Airline.Remove(airline);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AirlineExists(int id)
        {
          return (_context.Airline?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
