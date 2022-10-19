using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using sistemaDeAdocaoParaAnimais.Helper;
using sistemaDeAdocaoParaAnimais.Models;
using sistemaDeAdocaoParaAnimais.Services;

namespace sistemaDeAdocaoParaAnimais.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly SistemaDeAdocaoParaAnimaisContext _context;
        private readonly IEmail _email;
        private readonly IUsuarioRepositorio _usuarioRepositorio;


        public UsuariosController(SistemaDeAdocaoParaAnimaisContext context, IEmail email, IUsuarioRepositorio usuarioRepositorio)
        {
            _context = context;
            _email = email;
            _usuarioRepositorio = usuarioRepositorio;
        }

        // GET: Usuarios

        public async Task<IActionResult> Index()
        {
            return _context.usuarios != null ?
                        View(await _context.usuarios.ToListAsync()) :
                        Problem("Entity set 'SistemaDeAdocaoParaAnimaisContext.usuarios'  is null.");
        }
        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.usuarios == null)
            {
                return NotFound();
            }

            var usuarios = await _context.usuarios
                .FirstOrDefaultAsync(m => m.UsuarioId == id);
            if (usuarios == null)
            {
                return NotFound();
            }

            return View(usuarios);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UsuarioId,Nome,CPF,Email,ConfirmeEmail,Senha,ConfirmeSenha,DtNascimento,Genero,Celular,Cep,Rua,Bairro,Numero,complemento,Cidade,Estado,TermosCondições")] Usuarios usuarios)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Usuarios usuarios1 = _usuarioRepositorio.BuscarPorUsuario(usuarios.CPF);
                    Usuarios usuarios2 = _usuarioRepositorio.BuscarPorEmail(usuarios.Email);

                    if (usuarios1 == null)
                    {
                        if (usuarios2 == null)
                        {
                            usuarios.SetSenhaHash();
                            _context.Add(usuarios);
                            await _context.SaveChangesAsync();
                            string mensagem = $"Olá, seja bem vindo {usuarios.Nome}. <br> Faça um pet mais feliz!";
                            _email.Enviar(usuarios.Email, "Animal Petz - Bem vindo", mensagem);
                            TempData["MensagemSucesso"] = $"Usuário Cadastrado com sucesso";
                            return RedirectToAction("Login", "Login");
                        }
                        TempData["MensagemErro"] = $"O email informado já está cadastrado";
                        return RedirectToAction("Create");
                    }
                    TempData["MensagemErro"] = $"Ops, já existe um usuário com o CPF cadastrado";
                    return RedirectToAction("Create");
                }
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, aconteceu um erro. Tente novamente mais tarde!";
                return RedirectToAction("Index", "Home");
            }
            return View(usuarios);
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.usuarios == null)
            {
                return NotFound();
            }

            var usuarios = await _context.usuarios.FindAsync(id);
            if (usuarios == null)
            {
                return NotFound();
            }
            return View(usuarios);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UsuarioId,Nome,CPF,Email,ConfirmeEmail,Senha,ConfirmeSenha,DtNascimento,Genero,Celular,Cep,Rua,Bairro,Numero,complemento,Cidade,Estado,TermosCondições")] Usuarios usuarios)
        {
            if (id != usuarios.UsuarioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuarios);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuariosExists(usuarios.UsuarioId))
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
            return View(usuarios);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.usuarios == null)
            {
                return NotFound();
            }

            var usuarios = await _context.usuarios
                .FirstOrDefaultAsync(m => m.UsuarioId == id);
            if (usuarios == null)
            {
                return NotFound();
            }

            return View(usuarios);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.usuarios == null)
            {
                return Problem("Entity set 'SistemaDeAdocaoParaAnimaisContext.usuarios'  is null.");
            }
            var usuarios = await _context.usuarios.FindAsync(id);
            if (usuarios != null)
            {
                _context.usuarios.Remove(usuarios);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuariosExists(int id)
        {
            return (_context.usuarios?.Any(e => e.UsuarioId == id)).GetValueOrDefault();
        }
    }
}
