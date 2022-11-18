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
using Microsoft.ML.Data;
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

        // public static DataTable BuildDataTable<Animal>(IList<Animal> lst)
        // {
        //     //create DataTable Structure
        //     DataTable tbl = CreateTable<Animal>();
        //     Type entType = typeof(Animal);
        //     PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entType);
        //     //get the list item and add into the list
        //     foreach (Animal item in lst)
        //     {
        //         DataRow row = tbl.NewRow();
        //         foreach (PropertyDescriptor prop in properties)
        //         {
        //             // row[prop.Name] = prop.GetValue(item);
        //             row[prop.Name] = prop.GetValue(item);
        //         }
        //         tbl.Rows.Add(row);
        //     }
        //     return tbl;
        // }


        // private static DataTable CreateTable<Animal>()
        // {
        //     Type entType = typeof(Animal);
        //     //set the datatable name as class name
        //     DataTable tbl = new DataTable(entType.Name);
        //     //get the property list
        //     PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entType);
        //     foreach (PropertyDescriptor prop in properties)
        //     {
        //         //add property as column
        //         tbl.Columns.Add(prop.Name, prop.PropertyType);
        //     }
        //     return tbl;
        // }

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
            static DataTable BuildDataTable<Animal>(IList<Animal> lst)
            {
                //create DataTable Structure
                DataTable tbl = CreateTable<Animal>();
                Type entType = typeof(Animal);
                PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entType);
                //get the list item and add into the list
                foreach (Animal item in lst)
                {
                    DataRow row = tbl.NewRow();
                    foreach (PropertyDescriptor prop in properties)
                    {
                        // row[prop.Name] = prop.GetValue(item);
                        row[prop.Name] = prop.GetValue(item);
                    }
                    tbl.Rows.Add(row);
                }
                return tbl;
            }

            static DataTable CreateTable<Animal>()
            {
                Type entType = typeof(Animal);
                //set the datatable name as class name
                DataTable tbl = new DataTable(entType.Name);
                //get the property list
                PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entType);
                foreach (PropertyDescriptor prop in properties)
                {
                    //add property as column
                    tbl.Columns.Add(prop.Name, prop.PropertyType);
                }
                return tbl;
            }

            

            List<Animal> ListOfAnimals = _context.animals.ToList();
            DataTable ListAsDataTable = BuildDataTable<Animal>(ListOfAnimals);
            DataView ListAsDataView = ListAsDataTable.DefaultView;

            //Convertendo de DataTable para IDataView.obs: ainda não foi testado
            IDataView dataView = (IDataView)ListAsDataTable;

            //Provavelmente essa parte não esteja correta, influencia diretamente em var fileStream.
            //string _modelPath = Path.Combine(Environment.CurrentDirectory, "dataView");

            var mlContext = new MLContext(seed: 0);

            string featuresColumnName = "Features";
            var pipeline = mlContext.Transforms
            .Concatenate(featuresColumnName, "id", "Energia", "Humor", "Apego")
            .Append(mlContext.Clustering.Trainers.KMeans(featuresColumnName, numberOfClusters: 5));

            var model = pipeline.Fit(dataView);

            //Cria um arquivo para armazenar o modelo treinado em zip.
            /* 
            using (var fileStream = new FileStream(_modelPath, FileMode.Create, FileAccess.Write, FileShare.Write))
            {
                mlContext.Model.Save(model, dataView.Schema, fileStream);
            }
            */         

            //Adicionei um ClusterPrediction dentro de ClusterPrediction em models.
            //Pega o modelo treinado e fazer a  previsão.
            var predictor = mlContext.Model.CreatePredictionEngine<Animal, ClusterPrediction>(model);


            IEnumerable<Animal> petsDisponiveis = new List<Animal>(_context.animals.Where(a => a.EstadoAdocaoPet == "Disponível"));
            return View(petsDisponiveis);
    }

    // GET: Animais
    public async Task<IActionResult> Index()
    {
        var sistemaDeAdocaoParaAnimaisContext = _context.animals.Include(a => a.Usuarios);
        return View(await sistemaDeAdocaoParaAnimaisContext.ToListAsync());
    }

    public async Task<IActionResult> ExibirPet(int? id)
    {
        var pet = _context.animals.Where(a => a.Id == id);
        ViewBag.pets = pet;
        return View();
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
