using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using sistemaDeAdocaoParaAnimais.Models;

namespace sistemaDeAdocaoParaAnimais.Controllers
{
    public class CaracteristicasController : Controller
    {
        private readonly SistemaDeAdocaoParaAnimaisContext _context;

        public CaracteristicasController(SistemaDeAdocaoParaAnimaisContext context)
        {
            _context = context;
        }

        // GET: Caracteristicas
        public async Task<IActionResult> Index()
        {
              return View(await _context.caracteristicas.ToListAsync());
        }

        // GET: Caracteristicas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.caracteristicas == null)
            {
                return NotFound();
            }

            var caracteristica = await _context.caracteristicas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (caracteristica == null)
            {
                return NotFound();
            }

            return View(caracteristica);
        }

        // GET: Caracteristicas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Caracteristicas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Energia,Humor,Apego,Latido,Inteligencia,Brincadeira,Adestramento,Vacinado,Castrado,Vermifugado")] Caracteristica caracteristica)
        {
            if (ModelState.IsValid)
            {
                _context.Add(caracteristica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(caracteristica);
        }

        // GET: Caracteristicas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.caracteristicas == null)
            {
                return NotFound();
            }

            var caracteristica = await _context.caracteristicas.FindAsync(id);
            if (caracteristica == null)
            {
                return NotFound();
            }
            return View(caracteristica);
        }

        // POST: Caracteristicas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Energia,Humor,Apego,Latido,Inteligencia,Brincadeira,Adestramento,Vacinado,Castrado,Vermifugado")] Caracteristica caracteristica)
        {
            if (id != caracteristica.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(caracteristica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CaracteristicaExists(caracteristica.Id))
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
            return View(caracteristica);
        }

        // GET: Caracteristicas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.caracteristicas == null)
            {
                return NotFound();
            }

            var caracteristica = await _context.caracteristicas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (caracteristica == null)
            {
                return NotFound();
            }

            return View(caracteristica);
        }

        // POST: Caracteristicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.caracteristicas == null)
            {
                return Problem("Entity set 'SistemaDeAdocaoParaAnimaisContext.caracteristicas'  is null.");
            }
            var caracteristica = await _context.caracteristicas.FindAsync(id);
            if (caracteristica != null)
            {
                _context.caracteristicas.Remove(caracteristica);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CaracteristicaExists(int id)
        {
          return _context.caracteristicas.Any(e => e.Id == id);
        }
    }
}
