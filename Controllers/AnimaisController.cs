using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using sistemaDeAdocaoParaAnimais.Helper;
using sistemaDeAdocaoParaAnimais.Models;

namespace sistemaDeAdocaoParaAnimais.Controllers
{
    public class AnimaisController : Controller
    {
        private readonly SistemaDeAdocaoParaAnimaisContext _context;
        private readonly ISessao _sessao;

        public AnimaisController(SistemaDeAdocaoParaAnimaisContext context, ISessao sessao)
        {
            _context = context;
            _sessao = sessao;
        }

        [HttpPost]
        public async Task<IActionResult> Buscar(string sexo, string estado)
        {

            IEnumerable<Animal> petsDisponiveis = new List<Animal>(_context.animals.Where(a => a.EstadoAdocaoPet == "Disponível"));
            if (sexo != "Todos os sexos")
            {
                petsDisponiveis = petsDisponiveis.Where(a => a.Sexo == sexo);
            }
            if (estado != "Todos os estados")
            {
                petsDisponiveis = petsDisponiveis.Where(a => a.Estado == estado);
            }

            return View(petsDisponiveis);
        }

        public async Task<IActionResult> Buscar()
        {
            IEnumerable<Animal> petsDisponiveis = new List<Animal>(_context.animals.Where(a => a.EstadoAdocaoPet == "Disponível"));
            return View(petsDisponiveis);
        }

        // GET: Animais
        public async Task<IActionResult> Index()
        {
            var sistemaDeAdocaoParaAnimaisContext = _context.animals.Include(a => a.Usuarios);
            return View(await sistemaDeAdocaoParaAnimaisContext.ToListAsync());
        }

        // GET: Animais/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.animals == null)
            {
                return NotFound();
            }

            var animal = await _context.animals
                .Include(a => a.Usuarios)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (animal == null)
            {
                return NotFound();
            }

            return View(animal);
        }

        // GET: Animais/Create
        public IActionResult Create()
        {
            ViewData["FkUsuarios"] = new SelectList(_context.usuarios, "UsuarioId", "Nome");
            return View();
        }

        // POST: Animais/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FkUsuarios,Nome,Raca,Cor,Descricao,Porte,Especie,Sexo,Estado,Cidade,Energia,Humor,Apego,Adestramento,Vacinado,Castrado,Vermifugado,EstadoAdocaoPet,ImagensPet")] Animal animal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(animal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkUsuarios"] = new SelectList(_context.usuarios, "UsuarioId", "Nome", animal.FkUsuarios);
            return View(animal);
        }

        // GET: Animais/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.animals == null)
            {
                return NotFound();
            }

            var animal = await _context.animals.FindAsync(id);
            if (animal == null)
            {
                return NotFound();
            }
            ViewData["FkUsuarios"] = new SelectList(_context.usuarios, "UsuarioId", "Bairro", animal.FkUsuarios);
            return View(animal);
        }

        // POST: Animais/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FkUsuarios,Nome,Raca,Cor,Descricao,Porte,Especie,Sexo,Estado,Cidade,Energia,Humor,Apego,Adestramento,Vacinado,Castrado,Vermifugado,EstadoAdocaoPet,ImagensPet")] Animal animal)
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
            ViewData["FkUsuarios"] = new SelectList(_context.usuarios, "UsuarioId", "Bairro", animal.FkUsuarios);
            return View(animal);
        }

        // GET: Animais/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.animals == null)
            {
                return NotFound();
            }

            var animal = await _context.animals
                .Include(a => a.Usuarios)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (animal == null)
            {
                return NotFound();
            }

            return View(animal);
        }

        // POST: Animais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.animals == null)
            {
                return Problem("Entity set 'SistemaDeAdocaoParaAnimaisContext.animals'  is null.");
            }
            var animal = await _context.animals.FindAsync(id);
            if (animal != null)
            {
                _context.animals.Remove(animal);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnimalExists(int id)
        {
            return _context.animals.Any(e => e.Id == id);
        }
    }
}
