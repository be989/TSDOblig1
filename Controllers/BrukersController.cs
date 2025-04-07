using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TSDOblig1.Data;
using TSDOblig1.Models;

namespace TSDOblig1.Controllers
{
    public class BrukersController : Controller
    {
        private readonly BrukerContext _context;

        public BrukersController(BrukerContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Brukere.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var bruker = await _context.Brukere.FirstOrDefaultAsync(m => m.Id == id);
            if (bruker == null) return NotFound();

            return View(bruker);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Navn,KontaktInfo,AntallSpill")] Bruker bruker)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bruker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bruker);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var bruker = await _context.Brukere.FindAsync(id);
            if (bruker == null) return NotFound();

            return View(bruker);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Navn,KontaktInfo,AntallSpill")] Bruker bruker)
        {
            if (id != bruker.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bruker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BrukerExists(bruker.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(bruker);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var bruker = await _context.Brukere.FirstOrDefaultAsync(m => m.Id == id);
            if (bruker == null) return NotFound();

            return View(bruker);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bruker = await _context.Brukere.FindAsync(id);
            if (bruker != null) _context.Brukere.Remove(bruker);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult IncrementGameCount(string playerName)
        {
            if (string.IsNullOrEmpty(playerName))
            {
                return BadRequest("Må oppgi brukernavn");
            }

            // Søker uavhengig av store/små bokstaver:
            var bruker = _context.Brukere
                .FirstOrDefault(b => b.Navn.ToLower() == playerName.ToLower());

            if (bruker != null)
            {
                bruker.AntallSpill += 1;
                _context.SaveChanges();
                return Ok();
            }

            return NotFound("Bruker ikke funnet");
        }

        private bool BrukerExists(int id)
        {
            return _context.Brukere.Any(e => e.Id == id);
        }
    }
}
