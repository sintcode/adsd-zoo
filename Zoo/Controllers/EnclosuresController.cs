using System;
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
    public class EnclosuresController : Controller
    {
        private readonly ZooContext _context;

        public EnclosuresController(ZooContext context)
        {
            _context = context;
        }

        // GET: Enclosures
        public async Task<IActionResult> Index()
        {
            var zooContext = _context.Enclosure.Include(e => e.PredatorSpecies).Include(e => e.Zoo);
            return View(await zooContext.ToListAsync());
        }

        // GET: Enclosures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var enclosure = await _context.Enclosure
                .Include(e => e.PredatorSpecies)
                .Include(e => e.Zoo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if(enclosure == null)
            {
                return NotFound();
            }

            return View(enclosure);
        }

        // GET: Enclosures/Create
        public IActionResult Create()
        {
            ViewData["PredatorSpeciesId"] = new SelectList(_context.Species, "Id", "Id");
            ViewData["ZooId"] = new SelectList(_context.Set<ZooModel>(), "Id", "Id");
            return View();
        }

        // POST: Enclosures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Size,PredatorEnclosure,PredatorSpeciesId,Climate,Habitat,SecurityRequired,ZooId")] Enclosure enclosure)
        {
            if(ModelState.IsValid)
            {
                _context.Add(enclosure);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PredatorSpeciesId"] = new SelectList(_context.Species, "Id", "Id", enclosure.PredatorSpeciesId);
            ViewData["ZooId"] = new SelectList(_context.Set<ZooModel>(), "Id", "Id", enclosure.ZooId);
            return View(enclosure);
        }

        // GET: Enclosures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var enclosure = await _context.Enclosure.FindAsync(id);
            if(enclosure == null)
            {
                return NotFound();
            }
            ViewData["PredatorSpeciesId"] = new SelectList(_context.Species, "Id", "Id", enclosure.PredatorSpeciesId);
            ViewData["ZooId"] = new SelectList(_context.Set<ZooModel>(), "Id", "Id", enclosure.ZooId);
            return View(enclosure);
        }

        // POST: Enclosures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Size,PredatorEnclosure,PredatorSpeciesId,Climate,Habitat,SecurityRequired,ZooId")] Enclosure enclosure)
        {
            if(id != enclosure.Id)
            {
                return NotFound();
            }

            if(ModelState.IsValid)
            {
                try
                {
                    _context.Update(enclosure);
                    await _context.SaveChangesAsync();
                }
                catch(DbUpdateConcurrencyException)
                {
                    if(!EnclosureExists(enclosure.Id))
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
            ViewData["PredatorSpeciesId"] = new SelectList(_context.Species, "Id", "Id", enclosure.PredatorSpeciesId);
            ViewData["ZooId"] = new SelectList(_context.Set<ZooModel>(), "Id", "Id", enclosure.ZooId);
            return View(enclosure);
        }

        // GET: Enclosures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var enclosure = await _context.Enclosure
                .Include(e => e.PredatorSpecies)
                .Include(e => e.Zoo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if(enclosure == null)
            {
                return NotFound();
            }

            return View(enclosure);
        }

        // POST: Enclosures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enclosure = await _context.Enclosure.FindAsync(id);
            if(enclosure != null)
            {
                _context.Enclosure.Remove(enclosure);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnclosureExists(int id)
        {
            return _context.Enclosure.Any(e => e.Id == id);
        }
    }
}
