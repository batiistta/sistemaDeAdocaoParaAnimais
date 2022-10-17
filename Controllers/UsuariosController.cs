using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using sistemaDeAdocaoParaAnimais.Models;

namespace sistemaDeAdocaoParaAnimais.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly SistemaDeAdocaoParaAnimaisContext _context;

        public UsuariosController(SistemaDeAdocaoParaAnimaisContext context)
        {
            _context = context;
        }

        // GET: Usuarios
                
        public async Task<IActionResult> Index()
        {
            return _context.usuarios != null ?
                        View(await _context.usuarios.ToListAsync()) :
                        Problem("Entity set 'SistemaDeAdocaoParaAnimaisContext.usuarios'  is null.");
        }

        [HttpPost]
        public ActionResult EnviaEmail()
        {
            string emailDestinatario = Request.Form["txtEmail"];
            SendMail(emailDestinatario);
            return RedirectToAction("Index");
        }

        public bool SendMail(string email)
        {
            try
            {
                // Estancia da Classe de Mensagem
                MailMessage _mailMessage = new MailMessage();
                // Remetente
                _mailMessage.From = new MailAddress("rafael78@ba.estudante.senai.br");

                // Destinatario seta no metodo abaixo

                //Contrói o MailMessage
                _mailMessage.CC.Add(email);
                _mailMessage.Subject = "Teste envio de email";
                _mailMessage.IsBodyHtml = true;
                _mailMessage.Body = "<p>Consegui caralho, 2 noites quase sem dormir kksksksk<p>";

                //CONFIGURAÇÃO COM PORTA
                SmtpClient _smtpClient = new SmtpClient("smtp.gmail.com", Convert.ToInt32("587"));

                //CONFIGURAÇÃO SEM PORTA
                // SmtpClient _smtpClient = new SmtpClient(UtilRsource.ConfigSmtp);

                // Credencial para envio por SMTP Seguro (Quando o servidor exige autenticação)
                _smtpClient.UseDefaultCredentials = false;
                _smtpClient.Credentials = new NetworkCredential("rafael78@ba.estudante.senai.br", "Rafaelsilva19");

                _smtpClient.EnableSsl = true;

                _smtpClient.Send(_mailMessage);

                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
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
            if (ModelState.IsValid)
            {
                usuarios.SetSenhaHash();
                _context.Add(usuarios);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
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
