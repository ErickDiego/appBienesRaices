using appBienesRaices.Models;
using appBienesRaices.Servicios;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
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

            //List<Borough> lista = new List<Borough>();
            //lista = await _serviceAPI.obtenerBoroughConPropiedades(14);
            //return View(lista);

            //InfoBorough infoBorough = new InfoBorough();
            //infoBorough = await _serviceAPI.obtenerInforBoroughById(5206);
            //return View(infoBorough);

            List<InfoBorough> listaInfoBorough = new List<InfoBorough>();
            listaInfoBorough = await _serviceAPI.listadoPropiedades();
            return View(listaInfoBorough);

        }

        public async Task<IActionResult> Property(int idProperty)
        {
            InfoBorough infoBorough = new InfoBorough();
            infoBorough = await _serviceAPI.obtenerInforBoroughById(idProperty);

            return View(infoBorough);
        }
    }
}
