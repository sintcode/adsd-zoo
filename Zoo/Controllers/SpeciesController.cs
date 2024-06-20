﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Zoo.Data;
using Zoo.Models;

namespace Zoo.Controllers
{
    public class SpeciesController : Controller
    {
        private readonly ZooContext _context;

        public SpeciesController(ZooContext context)
        {
            _context = context;
        }

        // GET: Species
        public async Task<IActionResult> Index()
        {
            return View(await _context.Species.ToListAsync());
        }

        // GET: Species/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var species = await _context.Species
                .FirstOrDefaultAsync(m => m.Id == id);
            if (species == null)
            {
                return NotFound();
            }

            return View(species);
        }

        // GET: Species/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Species/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,LatinName,Size,SpaceRequired,Diet,Predator,Activity,SecurityRequired")] Species species)
        {
            if (ModelState.IsValid)
            {
                _context.Add(species);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(species);
        }

        // GET: Species/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var species = await _context.Species.FindAsync(id);
            if (species == null)
            {
                return NotFound();
            }
            return View(species);
        }

        // POST: Species/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,LatinName,Size,SpaceRequired,Diet,Predator,Activity,SecurityRequired")] Species species)
        {
            if (id != species.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(species);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpeciesExists(species.Id))
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
            return View(species);
        }

        // GET: Species/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var species = await _context.Species
                .FirstOrDefaultAsync(m => m.Id == id);
            if (species == null)
            {
                return NotFound();
            }

            return View(species);
        }

        // POST: Species/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var species = await _context.Species.FindAsync(id);
            if (species != null)
            {
                _context.Species.Remove(species);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpeciesExists(int id)
        {
            return _context.Species.Any(e => e.Id == id);
        }
    }
}
