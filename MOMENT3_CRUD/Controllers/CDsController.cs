using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MOMENT3_CRUD.Data;
using MOMENT3_CRUD.Models;

namespace MOMENT3_CRUD.Controllers
{
    public class CDsController : Controller
    {
        private readonly CDContext _context;

        public CDsController(CDContext context)
        {
            _context = context;
        }

        // GET: CDs
        public async Task<IActionResult> Index()
        {
            var cDContext = _context.CDs.Include(c => c.Genres);
            return View(await cDContext.ToListAsync());
        }

        // GET: CDs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cD = await _context.CDs
                .Include(c => c.Genres)
                .FirstOrDefaultAsync(m => m.CdId == id);
            if (cD == null)
            {
                return NotFound();
            }

            return View(cD);
        }

        // GET: CDs/Create
        public IActionResult Create()
        {
            ViewData["GenresId"] = new SelectList(_context.Genres, "GenresId", "Genre_Name");
            return View();
        }

        // POST: CDs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CdId,Artist,Title,Length,Label,GenresId")] CD cD)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cD);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GenresId"] = new SelectList(_context.Genres, "GenresId", "Genre_Name", cD.GenresId);
            return View(cD);
        }

        // GET: CDs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cD = await _context.CDs.FindAsync(id);
            if (cD == null)
            {
                return NotFound();
            }
            ViewData["GenresId"] = new SelectList(_context.Genres, "GenresId", "Genre_Name", cD.GenresId);
            return View(cD);
        }

        // POST: CDs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CdId,Artist,Title,Length,Label,GenresId")] CD cD)
        {
            if (id != cD.CdId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cD);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CDExists(cD.CdId))
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
            ViewData["GenresId"] = new SelectList(_context.Genres, "GenresId", "Genre_Name", cD.GenresId);
            return View(cD);
        }

        // GET: CDs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cD = await _context.CDs
                .Include(c => c.Genres)
                .FirstOrDefaultAsync(m => m.CdId == id);
            if (cD == null)
            {
                return NotFound();
            }

            return View(cD);
        }

        // POST: CDs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cD = await _context.CDs.FindAsync(id);
            _context.CDs.Remove(cD);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CDExists(int id)
        {
            return _context.CDs.Any(e => e.CdId == id);
        }
    }
}
