using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProyectoCiclo3.App.Persistencia.AppRepositorios;
using ProyectoCiclo3.App.Dominio;
using Microsoft.AspNetCore.Authorization;
namespace ProyectoCiclo3.App.Frontend.Pages
{
    [Authorize]
    public class FormAeropuertoModel : PageModel
    {
        private readonly RepositorioAeropuertos repositorioAeropuertos;
        [BindProperty]
        public Aeropuertos Aeropuerto {get;set;}
    public FormAeropuertoModel(RepositorioAeropuertos repositorioAeropuertos)
       {
            this.repositorioAeropuertos=repositorioAeropuertos;
       }

    public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
           
            Aeropuerto = repositorioAeropuertos.Create(Aeropuerto);
            
                return RedirectToPage("./List");
        }

    }
}
