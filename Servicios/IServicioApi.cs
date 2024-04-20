using appBienesRaices.Models;
using System.ComponentModel;

namespace appBienesRaices.Servicios
{
    public interface IServicioApi
    {
        /**
         GetBoroughs*/
        Task<List<Borough>> obtenerBorough(int idRegion);

        /**
        * GetBoroughsWithProperties
        * https://api-cnvct.azure-api.net/web/v1/info/boroughs-with-properties[?idRegion]
        */
        Task<List<Borough>> obtenerBoroughConPropiedades(int idRegion);

        Task<List<InfoCondominium>> obtenerCondominium(int idSector);

        Task<List<InfoCondominium>> obtenerCondominiumWithProperties(int idSector);
        //Obtener Paises
        Task<List<Country>> obtenerCountries();
        /**Countries con propiedades*/
        Task<List<Country>> obtenerCountriesConPropiedades();
        //Tipos de Currency (Peso, Dolar, etc
        Task<List<InfoCurency>> obtenerCurrency();

        //
        Task<List<InfoPropertyStates>> obtenerInfoPropertyStates();
        //
        Task<List<InfoPropertyType>> obtenerInfoPropertyTypes();
        //
        Task<List<InfoPropertyType>> obtenerInfoPropertyTypesWithProperties();
        /** Obteneer listado de las regiones que tiene la API*/
        Task<List<Region>> obtenerRegions();
        //
        Task<List<Region>> obtenerRegionsWithProperties();
        //
        Task<List<Sector>> obtenerSectores(int idBorough);
        //
        Task<List<Sector>> obtenerSectoresWithProperties(int idBorough);


        //
        Task<InfoBorough> obtenerInforBoroughById(int idProperty);

        //
        Task<List<InfoBorough>> listadoPropiedades();
    }
}
