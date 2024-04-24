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
            List<Country> lista = new List<Country>();
            lista = await _serviceAPI.obtenerCountries();


            List<InfoBorough> listaInfoBorough = new List<InfoBorough>();
            listaInfoBorough = await _serviceAPI.listadoPropiedades();

            //HomePageModel es una clase con la finalidad de poder enviar a la pagina Index y que lo pueda leer como
            //un unico Model y que lo pueda maniupular
            var model = new HomePageModel
            {
                Paises = lista,
                InfoBoroughs = listaInfoBorough
            };

            return View(model);

        }

        public async Task<IActionResult> Property(int idProperty)
        {
            InfoBorough infoBorough = new InfoBorough();
            infoBorough = await _serviceAPI.obtenerInforBoroughById(idProperty);

            return View(infoBorough);
        }

        [HttpGet]
        public async Task<IActionResult> GetRegiones(int idCountry)
        {
            // Cargar las regiones según el país seleccionado
            List<Region> regiones = await _serviceAPI.obtenerRegionsByIdCountry(idCountry);

            return Json(regiones);
        }

        [HttpGet]
        public async Task<IActionResult> GetComunas(int idRegion)
        {
            // Cargar las comunas según la región seleccionada
            List<Borough> comunas = await _serviceAPI.obtenerBorough(idRegion);

            return Json(comunas);
        }

        [HttpGet]
        public async Task<List<Sector>> obtenerSectoresWithProperties(int idBorough)
        {
            List<Sector> lista = await _serviceAPI.obtenerSectoresWithProperties(idBorough);

            return lista;
        }
    }
}
