using Prueba.VivaVolar.Data;
using Prueba.VivaVolar.Models;
using Prueba.VivaVolar.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba.VivaVolar.Services
{
    public class VuelosCRUD
    {
        private readonly AppDBContext _appDBContext;
        private readonly MapperVuelos _mapperVuelos;

        public VuelosCRUD(AppDBContext appDBContext, MapperVuelos mapperVuelos)
        {
            _appDBContext = appDBContext;
            _mapperVuelos = mapperVuelos;
        }
        public string CreateFlys(Vuelos vuelo) 
        {
            try
            {
                _appDBContext.Vuelos.Add(vuelo);
                _appDBContext.SaveChanges();
                return Constanst.VueloCreado;
            }
            catch (Exception ex)
            {
                return Constanst.VueloErrorCrear + ex.Message;
            }
          
        }
        public string EditFlys(Vuelos vuelo)
        {
            try
            {
                var fly = (from b in _appDBContext.Vuelos where b.idVuelo == vuelo.idVuelo select b).FirstOrDefault();
                fly = _mapperVuelos.MapperFlys(vuelo, fly);
                return Constanst.VueloEditado;
            }
            catch (Exception ex)
            {
                return Constanst.VueloEditadoError + ex.Message;
            }

        }
        public List<Vuelos> ListFlysUser(Vuelos vuelo) 
        {
            try
            {
              
                if (vuelo.CantidadSilla > 0)
                {
                    var flys = (from b in _appDBContext.Vuelos where b.FechaDisponibilidad == vuelo.FechaDisponibilidad &&
                                b.CiudadOrigen == vuelo.CiudadOrigen && b.CiudadDestino == vuelo.CiudadDestino && b.CantidadSilla == b.CantidadSilla
                                orderby b.Precio descending
                                select b ).ToList();
                    return flys;
                }
                else 
                {
                     var flys = (from b in _appDBContext.Vuelos where b.FechaDisponibilidad == vuelo.FechaDisponibilidad &&
                                b.CiudadOrigen == vuelo.CiudadOrigen && b.CiudadDestino == vuelo.CiudadDestino
                                 orderby b.Precio descending
                                 select b).ToList();
                    return flys;
                }
              
            }
            catch (Exception)
            {

                throw;
            }
        
        }
        public List<Vuelos> ListFlys()
        {
            try
            {
                var flys = _appDBContext.Vuelos.ToList();
                return flys;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public bool ValidarDisponibilidad(int idVuelo) 
        {
            try
            {
                var fly = _appDBContext.Vuelos.Where(v => v.idVuelo == idVuelo).FirstOrDefault();
                var contReservas = (from r in _appDBContext.Reservas where r.idVuelo == idVuelo select r).Count();

                if (fly.CantidadSilla > contReservas)
                {
                    return true;
                }
                else 
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public Vuelos ConsultarVuelos(Reservas reservas) 
        {
            try
            {
                var flyResult = _appDBContext.Vuelos.Where(v => v.idVuelo == reservas.idVuelo).FirstOrDefault();
                return flyResult;
            }
            catch (Exception)
            {

                throw;
            }
        
        }
    }
}
