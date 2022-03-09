using Prueba.VivaVolar.Data;
using Prueba.VivaVolar.Models;
using Prueba.VivaVolar.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba.VivaVolar.Services
{
    public class ReservasCRUD
    {
        private readonly AppDBContext _appDBContext;
        private readonly Notificaciones _notificaciones;
        public ReservasCRUD(AppDBContext appDBContext, Notificaciones notificaciones)
        {
            _appDBContext = appDBContext;
            _notificaciones = notificaciones;
        }
        public string CrearReserva(Reservas reservas) 
        {
            try
            {
                _appDBContext.Reservas.Add(reservas);
                _appDBContext.SaveChanges();
                _notificaciones.EnviarNotificacion(reservas);
                return Constanst.ReservaCreada;
            }
            catch (Exception ex)
            {
                return Constanst.ReservaErrorCrear + ex.Message;
                throw;
            }
        }
        public object ListReservs() 
        {
            try
            {
                var result = (from d in _appDBContext.Reservas
                              join a in _appDBContext.Usuario on d.idUsuario equals a.idUsuario
                              join v in _appDBContext.Vuelos on d.idVuelo equals v.idVuelo
                              select new
                              {
                                  a.NombreUsuario, v.FechaDisponibilidad, v.CiudadOrigen, v.CiudadDestino, v.NumeroVuelo
                              }).ToList();
                return result;
            }
            catch (Exception ex)
            {
                return Constanst.ReservasListaError+ ex.Message;
                throw;
            }
        }
    }
}
