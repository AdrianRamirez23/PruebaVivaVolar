using Prueba.VivaVolar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba.VivaVolar.Utils
{
    public class MapperVuelos
    {
        public MapperVuelos() { }
        public Vuelos MapperFlys(Vuelos vuelosIn, Vuelos vuelosReturn) 
        {
            vuelosReturn.NumeroVuelo = vuelosIn.NumeroVuelo;
            vuelosReturn.FechaDisponibilidad = vuelosIn.FechaDisponibilidad;
            vuelosReturn.CantidadSilla = vuelosIn.CantidadSilla;
            vuelosReturn.CiudadOrigen = vuelosIn.CiudadOrigen;
            vuelosReturn.CiudadDestino = vuelosIn.CiudadDestino;
            vuelosReturn.Precio = vuelosIn.Precio;

            return vuelosReturn;
        }
    }
}
