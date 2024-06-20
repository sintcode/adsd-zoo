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
    public class ZooModelsController : Controller
    {
        private readonly ZooContext _context;

        public ZooModelsController(ZooContext context)
        {
            _context = context;
        }

        // GET: ZooModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.ZooModel.ToListAsync());
        }

        // GET: ZooModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zooModel = await _context.ZooModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zooModel == null)
            {
                return NotFound();
            }

            return View(zooModel);
        }

        // GET: ZooModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ZooModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Country,City")] ZooModel zooModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zooModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zooModel);
        }

        // GET: ZooModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zooModel = await _context.ZooModel.FindAsync(id);
            if (zooModel == null)
            {
                return NotFound();
            }
            return View(zooModel);
        }

        // POST: ZooModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Country,City")] ZooModel zooModel)
        {
            if (id != zooModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zooModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZooModelExists(zooModel.Id))
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
            return View(zooModel);
        }

        // GET: ZooModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zooModel = await _context.ZooModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zooModel == null)
            {
                return NotFound();
            }

            return View(zooModel);
        }

        // POST: ZooModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zooModel = await _context.ZooModel.FindAsync(id);
            if (zooModel != null)
            {
                _context.ZooModel.Remove(zooModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZooModelExists(int id)
        {
            return _context.ZooModel.Any(e => e.Id == id);
        }
    }
}
