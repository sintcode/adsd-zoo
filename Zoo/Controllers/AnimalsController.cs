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
    public class AnimalsController : Controller
    {
        private readonly ZooContext _context;

        public AnimalsController(ZooContext context)
        {
            _context = context;
        }

        // GET: Animals
        public async Task<IActionResult> Index()
        {
            var zooContext = _context.Animal.Include(a => a.Enclosure).Include(a => a.Species).Include(a => a.Zoo);
            return View(await zooContext.ToListAsync());
        }

        // GET: Animals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animal = await _context.Animal
                .Include(a => a.Enclosure)
                .Include(a => a.Species)
                .Include(a => a.Zoo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (animal == null)
            {
                return NotFound();
            }

            return View(animal);
        }

        // GET: Animals/Create
        public IActionResult Create()
        {
            ViewData["EnclosureId"] = new SelectList(_context.Enclosure, "Id", "Id");
            ViewData["SpeciesId"] = new SelectList(_context.Species, "Id", "Id");
            ViewData["ZooId"] = new SelectList(_context.Set<ZooModel>(), "Id", "Id");
            return View();
        }

        // POST: Animals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Gender,Weight,Personality,PreferredDiet,SpeciesId,ZooId,EnclosureId")] Animal animal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(animal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EnclosureId"] = new SelectList(_context.Enclosure, "Id", "Id", animal.EnclosureId);
            ViewData["SpeciesId"] = new SelectList(_context.Species, "Id", "Id", animal.SpeciesId);
            ViewData["ZooId"] = new SelectList(_context.Set<ZooModel>(), "Id", "Id", animal.ZooId);
            return View(animal);
        }

        // GET: Animals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animal = await _context.Animal.FindAsync(id);
            if (animal == null)
            {
                return NotFound();
            }
            ViewData["EnclosureId"] = new SelectList(_context.Enclosure, "Id", "Id", animal.EnclosureId);
            ViewData["SpeciesId"] = new SelectList(_context.Species, "Id", "Id", animal.SpeciesId);
            ViewData["ZooId"] = new SelectList(_context.Set<ZooModel>(), "Id", "Id", animal.ZooId);
            return View(animal);
        }

        // POST: Animals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Gender,Weight,Personality,PreferredDiet,SpeciesId,ZooId,EnclosureId")] Animal animal)
        {
            if (id != animal.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(animal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnimalExists(animal.Id))
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
            ViewData["EnclosureId"] = new SelectList(_context.Enclosure, "Id", "Id", animal.EnclosureId);
            ViewData["SpeciesId"] = new SelectList(_context.Species, "Id", "Id", animal.SpeciesId);
            ViewData["ZooId"] = new SelectList(_context.Set<ZooModel>(), "Id", "Id", animal.ZooId);
            return View(animal);
        }

        // GET: Animals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animal = await _context.Animal
                .Include(a => a.Enclosure)
                .Include(a => a.Species)
                .Include(a => a.Zoo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (animal == null)
            {
                return NotFound();
            }

            return View(animal);
        }

        // POST: Animals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var animal = await _context.Animal.FindAsync(id);
            if (animal != null)
            {
                _context.Animal.Remove(animal);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnimalExists(int id)
        {
            return _context.Animal.Any(e => e.Id == id);
        }
    }
}
