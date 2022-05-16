﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Chat_App.Data;
using Chat_App.Models;

namespace Chat_App.Controllers
{
    public class RatesController : Controller
    {
        private readonly Chat_AppContext _context;

        public RatesController(Chat_AppContext context)
        {
            _context = context;
        }

        // GET: Rates
        public async Task<IActionResult> Index()
        {
              return View(await _context.Rate.ToListAsync());
        }

        // GET: Rates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Rate == null)
            {
                return NotFound();
            }

            var rate = await _context.Rate
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rate == null)
            {
                return NotFound();
            }

            return View(rate);
        }

        // GET: Rates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserName,Description,Value")] Rate rate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rate);
        }

        // GET: Rates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Rate == null)
            {
                return NotFound();
            }

            var rate = await _context.Rate.FindAsync(id);
            if (rate == null)
            {
                return NotFound();
            }
            return View(rate);
        }

        // POST: Rates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserName,Description,Value")] Rate rate)
        {
            if (id != rate.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RateExists(rate.Id))
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
            return View(rate);
        }

        // GET: Rates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Rate == null)
            {
                return NotFound();
            }

            var rate = await _context.Rate
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rate == null)
            {
                return NotFound();
            }

            return View(rate);
        }

        // POST: Rates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Rate == null)
            {
                return Problem("Entity set 'Chat_AppContext.Rate'  is null.");
            }
            var rate = await _context.Rate.FindAsync(id);
            if (rate != null)
            {
                _context.Rate.Remove(rate);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RateExists(int id)
        {
          return _context.Rate.Any(e => e.Id == id);
        }
    }
}