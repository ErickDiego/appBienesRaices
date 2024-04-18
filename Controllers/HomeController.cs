using appBienesRaices.Models;
using appBienesRaices.Servicios;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace appBienesRaices.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServicioApi _serviceAPI;

      
        public HomeController(IServicioApi serviceAPI) 
        {
            _serviceAPI = serviceAPI;
           
        }


        public async Task<IActionResult> Index()
        {
            //List<Country> lista = new List<Country>();
            //lista = await _serviceAPI.obtenerCountries();
            //return View(lista);

            //List<Region> listaRegion = new List<Region>();
            //listaRegion = await _serviceAPI.obtenerRegions();
            //return View(listaRegion);

            List<Borough> lista = new List<Borough>();
            lista = await _serviceAPI.obtenerBoroughConPropiedades(14);
            return View(lista);

        }
    }
}
