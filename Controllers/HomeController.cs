using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;
using sistemaDeAdocaoParaAnimais.Models;

namespace sistemaDeAdocaoParaAnimais.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
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
    public IActionResult Privacy()
    {
        return View();
    }
    public IActionResult EnvioEmail()
    {
        return View();
    }

    public IActionResult Duvidas()
    {
        return View();
    }

    public IActionResult Ongs()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}