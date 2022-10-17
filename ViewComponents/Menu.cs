using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using sistemaDeAdocaoParaAnimais.Models;

namespace sistemaDeAdocaoParaAnimais.ViewComponents
{
    public class Menu : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string sessaoUsuario = HttpContext.Session.GetString("sessaoUsuariologado");

            if(string.IsNullOrEmpty(sessaoUsuario)) return null; 

            Usuarios usuarios = JsonConvert.DeserializeObject<Usuarios>(sessaoUsuario);

            return View(usuarios);
        }
    }
}