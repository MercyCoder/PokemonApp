using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PokemonApp.Models;

namespace PokemonApp.Controllers
{
    public class CatchController : Controller
    {
        private readonly PokeContext _context;

        public CatchController(PokeContext context)
        {
            _context = context;
        }
        

        // GET: Catch
        public async Task<IActionResult> Index()
        {
            var returnstring = await _context.Catch.Include(t => t.Trainer).Include(p => p.Pokemon).ToListAsync();
            return View(returnstring);
        }

        // GET: Catch/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @catch = await _context.Catch
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@catch == null)
            {
                return NotFound();
            }

            return View(@catch);
        }

        // GET: Catch/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Catch/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TrainerId,PokemonId,Name")] Catch @catch)
        {
            if (ModelState.IsValid)
            {
                @catch.TrainerId = @catch.TrainerId;
                _context.Add(@catch);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(@catch);
        }

        // GET: Catch/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @catch = await _context.Catch.FindAsync(id);
            if (@catch == null)
            {
                return NotFound();
            }
            return View(@catch);
        }

        // POST: Catch/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Trainerid,Pokemonid,Name")] Catch @catch)
        {
            if (id != @catch.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@catch);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatchExists(@catch.Id))
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
            return View(@catch);
        }

        // GET: Catch/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @catch = await _context.Catch
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@catch == null)
            {
                return NotFound();
            }

            return View(@catch);
        }

        // POST: Catch/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @catch = await _context.Catch.FindAsync(id);
            _context.Catch.Remove(@catch);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatchExists(int id)
        {
            return _context.Catch.Any(e => e.Id == id);
        }
    }
}
