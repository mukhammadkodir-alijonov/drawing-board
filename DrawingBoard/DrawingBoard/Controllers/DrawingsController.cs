using DrawingBoard.DbContexts;
using DrawingBoard.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DrawingBoard.Controllers
{
    public class DrawingsController : Controller
    {
        private readonly AppDbContext _context;

        public DrawingsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Drawings
        public async Task<IActionResult> Index()
        {
            return View(await _context.Drawings.ToListAsync());
        }

        // GET: Drawings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drawing = await _context.Drawings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (drawing == null)
            {
                return NotFound();
            }

            return View(drawing);
        }

        // GET: Drawings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Drawings/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Type,Color,Content,BoardId")] Drawing drawing)
        {
            if (ModelState.IsValid)
            {
                _context.Add(drawing);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(drawing);
        }

        // GET: Drawings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drawing = await _context.Drawings.FindAsync(id);
            if (drawing == null)
            {
                return NotFound();
            }
            return View(drawing);
        }

        // POST: Drawings/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Type,Color,Content,BoardId")] Drawing drawing)
        {
            if (id != drawing.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(drawing);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DrawingExists(drawing.Id))
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
            return View(drawing);
        }

        // GET: Drawings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drawing = await _context.Drawings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (drawing == null)
            {
                return NotFound();
            }

            return View(drawing);
        }

        // POST: Drawings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var drawing = await _context.Drawings.FindAsync(id);
            _context.Drawings.Remove(drawing);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DrawingExists(int id)
        {
            return _context.Drawings.Any(e => e.Id == id);
        }
    }
}
