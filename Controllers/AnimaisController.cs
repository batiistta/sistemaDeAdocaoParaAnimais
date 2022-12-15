using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.ML;
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
        public async Task<IActionResult> Limpar()
        {

            IEnumerable<Animal> petsDisponiveis = new List<Animal>(_context.animals.Where(a => a.EstadoAdocaoPet == "Disponível"));
            return View(petsDisponiveis);
        }

        [HttpPost]
        public async Task<IActionResult> Buscar(string sexo, string estado, string porte)
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

            if (porte != "Todos os Portes")
            {
                petsDisponiveis = petsDisponiveis.Where(a => a.Porte == porte);
            }

            return View(petsDisponiveis);
        }


        public async Task<IActionResult> ExibirPet(int? id)
        {
            var informacoesAnimal = _context.animals.Find(id);
            var inforUser = _context.usuarios.Find(informacoesAnimal.FkUsuarios);
            var user = _context.usuarios.Where(a => a.UsuarioId == inforUser.UsuarioId);
            ViewBag.user = user;

            IEnumerable<Animal> pets = new List<Animal>(_context.animals.Where(a => a.Id == id));
            return View(pets);
        }


        public async Task<IActionResult> Buscar()
        {

            Usuarios usuario1 = _sessao.BuscarSessaoDoUsuario();
            var usuario = _context.usuarios.Find(usuario1.UsuarioId);
            var caracteristicaUsuario = _context.caracteristicaUsuarios.Find(usuario.fkCaracteristica);

            BuscarFkUsuario();

            foreach (var animal in _context.animals)
            {
                string _dataPath = Path.Combine(Environment.CurrentDirectory, "Data", "CaracteristicaAnimal.csv");
                string _modelPath = Path.Combine(Environment.CurrentDirectory, "Data", "IrisClusteringModel.zip");

                var mlContext = new MLContext(seed: 0);

                IDataView dataView = mlContext.Data.LoadFromTextFile<CaracteristicaAnimal>(_dataPath, hasHeader: false, separatorChar: ',');

                string featuresColumnName = "Features";
                var pipeline = mlContext.Transforms
                    .Concatenate(featuresColumnName, "Energia", "Humor", "Apego", "Brincalhao", "Adestramento")
                    .Append(mlContext.Clustering.Trainers.KMeans(featuresColumnName, numberOfClusters: 3));

                var model = pipeline.Fit(dataView);

                using (var fileStream = new FileStream(_modelPath, FileMode.Create, FileAccess.Write, FileShare.Write))
                {
                    mlContext.Model.Save(model, dataView.Schema, fileStream);
                }

                var predictor = mlContext.Model.CreatePredictionEngine<CaracteristicaUsuario, ClusterPrediction>(model);

                CaracteristicaUsuarioTeste.caracteristicaUsuario.Apego = caracteristicaUsuario.Apego;
                CaracteristicaUsuarioTeste.caracteristicaUsuario.Humor = caracteristicaUsuario.Humor;
                CaracteristicaUsuarioTeste.caracteristicaUsuario.Energia = caracteristicaUsuario.Energia;
                CaracteristicaUsuarioTeste.caracteristicaUsuario.Adestramento = caracteristicaUsuario.Adestramento;
                CaracteristicaUsuarioTeste.caracteristicaUsuario.Brincalhao = caracteristicaUsuario.Brincalhao;

                var prediction = predictor.Predict(CaracteristicaUsuarioTeste.caracteristicaUsuario);
                Console.WriteLine($"Cluster: {prediction.PredictedClusterId}");
                Console.WriteLine($"Distances: {string.Join(" ", prediction.Distances)}");

                animal.FkCluster = prediction.PredictedClusterId;
                _context.Update(animal);
            }
            await _context.SaveChangesAsync();
            IEnumerable<Animal> petsDisponiveis = new List<Animal>(_context.animals.Where(a => a.FkCluster == usuario.FkCluster && a.EstadoAdocaoPet == "Disponível"));
            return View(petsDisponiveis);
        }

        public async void BuscarFkUsuario()
        {
            Usuarios usuario1 = _sessao.BuscarSessaoDoUsuario();

            var usuario = _context.usuarios.Find(usuario1.UsuarioId);

            var caracteristicaUsuario = _context.caracteristicaUsuarios.Find(usuario.fkCaracteristica);

            string _dataPath = Path.Combine(Environment.CurrentDirectory, "Data", "CaracteristicaAnimal.csv");
            string _modelPath = Path.Combine(Environment.CurrentDirectory, "Data", "CaracteristicaUsuarioModel.zip");

            var mlContext = new MLContext(seed: 0);

            IDataView dataView = mlContext.Data.LoadFromTextFile<CaracteristicaAnimal>(_dataPath, hasHeader: false, separatorChar: ',');

            string featuresColumnName = "Features";
            var pipeline = mlContext.Transforms
                .Concatenate(featuresColumnName, "Energia", "Humor", "Apego", "Brincalhao", "Adestramento")
                .Append(mlContext.Clustering.Trainers.KMeans(featuresColumnName, numberOfClusters: 3));

            var model = pipeline.Fit(dataView);

            using (var fileStream = new FileStream(_modelPath, FileMode.Create, FileAccess.Write, FileShare.Write))
            {
                mlContext.Model.Save(model, dataView.Schema, fileStream);
            }

            var predictor = mlContext.Model.CreatePredictionEngine<CaracteristicaUsuario, ClusterPrediction>(model);

            CaracteristicaUsuarioTeste.caracteristicaUsuario.Apego = caracteristicaUsuario.Apego;
            CaracteristicaUsuarioTeste.caracteristicaUsuario.Humor = caracteristicaUsuario.Humor;
            CaracteristicaUsuarioTeste.caracteristicaUsuario.Energia = caracteristicaUsuario.Energia;
            CaracteristicaUsuarioTeste.caracteristicaUsuario.Adestramento = caracteristicaUsuario.Adestramento;
            CaracteristicaUsuarioTeste.caracteristicaUsuario.Brincalhao = caracteristicaUsuario.Brincalhao;

            var prediction = predictor.Predict(CaracteristicaUsuarioTeste.caracteristicaUsuario);
            Console.WriteLine($"Cluster: {prediction.PredictedClusterId}");
            Console.WriteLine($"Distances: {string.Join(" ", prediction.Distances)}");

            usuario.FkCluster = prediction.PredictedClusterId;
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAnimalCaracteristica([Bind("Id,FkUsuarios, FkCaracteristicaAnimal, FkCluster, Nome,Raca,Cor,Descricao,Porte,Especie,Sexo,Estado,Cidade,Vacinado,Castrado,Vermifugado,EstadoAdocaoPet,ImagensPet")] Animal animal, float energia, float humor, float apego, float adestramento, float brincalhao)
        {
            if (ModelState.IsValid)
            {
                CaracteristicaAnimal caracteristicaAnimal = new CaracteristicaAnimal();
                caracteristicaAnimal.Energia = energia;
                caracteristicaAnimal.Apego = apego;
                caracteristicaAnimal.Humor = humor;
                caracteristicaAnimal.Adestramento = adestramento;
                caracteristicaAnimal.Brincalhao = brincalhao;
                _context.Add(caracteristicaAnimal);
                await _context.SaveChangesAsync();

                Usuarios usuario1 = _sessao.BuscarSessaoDoUsuario();
                animal.FkUsuarios = usuario1.UsuarioId;

                _context.Add(animal);
                await _context.SaveChangesAsync();

                animal.FkCaracteristicaAnimal = caracteristicaAnimal.Id;
                _context.Update(animal);
                await _context.SaveChangesAsync();

                return RedirectToAction("Profile", "Usuarios");
            }
            ViewData["FkUsuarios"] = new SelectList(_context.usuarios, "UsuarioId", "Nome", animal.FkUsuarios);
            return View(animal);
        }

        public IActionResult CreateAnimalCaracteristica()
        {
            ViewData["FkUsuarios"] = new SelectList(_context.usuarios, "UsuarioId", "Nome");
            return View();
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
        public async Task<IActionResult> Create([Bind("Id,FkUsuarios,Nome,Raca,Cor,Descricao,Porte,Especie,Sexo,Estado,Cidade,Adestramento,Vacinado,Castrado,Vermifugado,EstadoAdocaoPet,ImagensPet")] Animal animal)
        {
            if (ModelState.IsValid)
            {
                Usuarios usuario1 = _sessao.BuscarSessaoDoUsuario();
                animal.FkUsuarios = usuario1.UsuarioId;
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,FkUsuarios,Nome,Raca,Cor,Descricao,Porte,Especie,Sexo,Estado,Cidade,Adestramento,Vacinado,Castrado,Vermifugado,EstadoAdocaoPet,ImagensPet")] Animal animal)
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
