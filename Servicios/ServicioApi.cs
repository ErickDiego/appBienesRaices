using appBienesRaices.Models;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Net.Http.Headers;
using System.Text;

namespace appBienesRaices.Servicios
{
    public class ServicioApi : IServicioApi
    {
        private static string _Ocp_Apim_Subscription_Key;
        private static string _key;
        private static string _baseURL;

        public ServicioApi()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            _Ocp_Apim_Subscription_Key = builder.GetSection("ApiConfig:user").Value;
            _key = builder.GetSection("ApiConfig:key").Value;
            _baseURL = builder.GetSection("ApiConfig:baseURL").Value;
        }

        public async Task<List<Borough>> obtenerBorough(int idRegion)
        {
            List<Borough> listaBorough = new List<Borough>();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseURL);
            cliente.DefaultRequestHeaders.Add(_Ocp_Apim_Subscription_Key, _key);

            var response = await cliente.GetAsync($"info/boroughs/{idRegion}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<Borough>>(json_respuesta);

                listaBorough = resultado;
            }
            return listaBorough;
        }

        //Listo y probado
        public async Task<List<Borough>> obtenerBoroughConPropiedades(int idRegion)
        {
            List<Borough> listaBorough = new List<Borough>();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseURL);
            cliente.DefaultRequestHeaders.Add(_Ocp_Apim_Subscription_Key, _key);
            
            var response = await cliente.GetAsync($"info/boroughs-with-properties?idRegion={idRegion}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<Borough>>(json_respuesta);

                listaBorough = resultado;
            }
            return listaBorough;
        }

        public async Task<List<InfoCondominium>> obtenerCondominium(int idSector)
        {
            List<InfoCondominium> listaBorough = new List<InfoCondominium>();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseURL);
            cliente.DefaultRequestHeaders.Add(_Ocp_Apim_Subscription_Key, _key);

            var response = await cliente.GetAsync($"info/condominiums?idSector={idSector}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<InfoCondominium>>(json_respuesta);

                listaBorough = resultado;
            }
            return listaBorough;
        }

        public async  Task<List<InfoCondominium>> obtenerCondominiumWithProperties(int idSector)
        {
            List<InfoCondominium> listaBorough = new List<InfoCondominium>();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseURL);
            cliente.DefaultRequestHeaders.Add(_Ocp_Apim_Subscription_Key, _key);

            var response = await cliente.GetAsync($"info/condominiums-with-properties?idSector={idSector}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<InfoCondominium>>(json_respuesta);

                listaBorough = resultado;
            }
            return listaBorough;
        }


        //Listo y probado
        public async Task<List<Country>> obtenerCountries()
        {
            List<Country> lista = new List<Country>();

            var cliente = new HttpClient();

            cliente.BaseAddress = new Uri(_baseURL);

            cliente.DefaultRequestHeaders.Add(_Ocp_Apim_Subscription_Key, _key);

            var response = await cliente.GetAsync("info/countries");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<Country>>(json_respuesta);

                Console.WriteLine("reesultado ejecutado: " + resultado);

                lista = resultado;
            }

            return lista;
        }

        public async Task<List<Country>> obtenerCountriesConPropiedades()
        {
            List<Country> listaCountry = new List<Country>();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseURL);
            cliente.DefaultRequestHeaders.Add(_Ocp_Apim_Subscription_Key, _key);

            var response = await cliente.GetAsync($"info/countries-with-properties");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<Country>>(json_respuesta);

                listaCountry = resultado;
            }
            return listaCountry;
        }

        public async Task<List<InfoCurency>> obtenerCurrency()
        {
            List<InfoCurency> lista = new List<InfoCurency>();

            var cliente = new HttpClient();

            cliente.BaseAddress = new Uri(_baseURL);

            cliente.DefaultRequestHeaders.Add(_Ocp_Apim_Subscription_Key, _key);

            var response = await cliente.GetAsync("info/currencies");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<InfoCurency>>(json_respuesta);

                lista = resultado;
            }

            return lista;
        }

        public async Task<List<InfoPropertyStates>> obtenerInfoPropertyStates()
        {
            List<InfoPropertyStates> lista = new List<InfoPropertyStates>();

            var cliente = new HttpClient();

            cliente.BaseAddress = new Uri(_baseURL);

            cliente.DefaultRequestHeaders.Add(_Ocp_Apim_Subscription_Key, _key);

            var response = await cliente.GetAsync("info/property-states");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<InfoPropertyStates>>(json_respuesta);

                lista = resultado;
            }

            return lista;
        }

        public async Task<List<InfoPropertyType>> obtenerInfoPropertyTypes()
        {

            List<InfoPropertyType> lista = new List<InfoPropertyType>();

            var cliente = new HttpClient();

            cliente.BaseAddress = new Uri(_baseURL);

            cliente.DefaultRequestHeaders.Add(_Ocp_Apim_Subscription_Key, _key);

            var response = await cliente.GetAsync("info/property-types");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<InfoPropertyType>>(json_respuesta);

                lista = resultado;
            }

            return lista;
        }

        public async Task<List<InfoPropertyType>> obtenerInfoPropertyTypesWithProperties()
        {

            List<InfoPropertyType> lista = new List<InfoPropertyType>();

            var cliente = new HttpClient();

            cliente.BaseAddress = new Uri(_baseURL);

            cliente.DefaultRequestHeaders.Add(_Ocp_Apim_Subscription_Key, _key);

            var response = await cliente.GetAsync("info/property-types-with-properties");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<InfoPropertyType>>(json_respuesta);

                lista = resultado;
            }

            return lista;
        }

        //Listo y probado
        public async Task<List<Region>> obtenerRegions()
        {
            List<Region> lista = new List<Region>();

            var cliente = new HttpClient();

            cliente.BaseAddress = new Uri(_baseURL);

            cliente.DefaultRequestHeaders.Add(_Ocp_Apim_Subscription_Key, _key);

            var response = await cliente.GetAsync("info/regions");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<Region>>(json_respuesta);

                lista = resultado;
            }

            return lista;
        }

        public async Task<List<Region>> obtenerRegionsWithProperties()
        {
            List<Region> lista = new List<Region>();

            var cliente = new HttpClient();

            cliente.BaseAddress = new Uri(_baseURL);

            cliente.DefaultRequestHeaders.Add(_Ocp_Apim_Subscription_Key, _key);

            var response = await cliente.GetAsync("info/regions-with-properties");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<Region>>(json_respuesta);

                lista = resultado;
            }

            return lista;
        }

        public async Task<List<Sector>> obtenerSectores(int idBorough)
        {
            List<Sector> listaBorough = new List<Sector>();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseURL);
            cliente.DefaultRequestHeaders.Add(_Ocp_Apim_Subscription_Key, _key);

            var response = await cliente.GetAsync($"info/sectors?idBorough={idBorough}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<Sector>>(json_respuesta);

                listaBorough = resultado;
            }
            return listaBorough;
        }

        public async Task<List<Sector>> obtenerSectoresWithProperties(int idBorough)
        {
            List<Sector> listaBorough = new List<Sector>();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseURL);
            cliente.DefaultRequestHeaders.Add(_Ocp_Apim_Subscription_Key, _key);

            var response = await cliente.GetAsync($"info/sectors-with-properties?idBorough={idBorough}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<Sector>>(json_respuesta);

                listaBorough = resultado;
            }
            return listaBorough;
        }

        public async Task<InfoBorough> obtenerInforBoroughById(int idProperty)
        {
            InfoBorough infoBorough = new InfoBorough();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseURL);
            cliente.DefaultRequestHeaders.Add(_Ocp_Apim_Subscription_Key, _key);

            var response = await cliente.GetAsync($"properties/{idProperty}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                infoBorough = JsonConvert.DeserializeObject<InfoBorough>(json_respuesta);

            }
            return infoBorough;
        }

    }
}
