using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Prueba.VivaVolar.Models;
using Prueba.VivaVolar.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba.VivaVolar.Controllers
{
    /// <summary>
    /// Controlador para el acceso al módulo de reservas
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ReservaController : ControllerBase
    {
        private IConfiguration _config;
        private UserCRUD _userCRUD;
        private VuelosCRUD _vuelosCRUD;
        private ReservasCRUD _reservasCRUD;

        public ReservaController(IConfiguration config, UserCRUD userCRUD, VuelosCRUD vuelosCRUD, ReservasCRUD reservasCRUD)
        {
            _config = config;
            _userCRUD = userCRUD;
            _vuelosCRUD = vuelosCRUD;
            _reservasCRUD = reservasCRUD;
        }
        /// <summary>
        /// Genera una reserva y envía notificación de creación
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("ReservarVuelo")]
        public ActionResult ReservarVuelo(RequestReservas requestReservas) 
        {
            if (ModelState.IsValid)
            {
                if (_userCRUD.LoginUser(requestReservas.usuario))
                {
                    if (_vuelosCRUD.ValidarDisponibilidad(requestReservas.reserva.idVuelo))
                    {
                        return Ok(_reservasCRUD.CrearReserva(requestReservas.reserva));
                    }
                    else 
                    {
                        return NotFound(Constanst.ReservaNoDisponible);
                    }
                }
                else 
                {
                    return NotFound(Constanst.UsuarioNoValido);
                }
            }
            else 
            {
                return BadRequest(Constanst.ReservaModelNoValido);
            }
        }
        [HttpGet]
        [Route("ListarReservas")]
        public ActionResult ReservList(Usuarios usuario) 
        {
            if (ModelState.IsValid)
            {
                if (_userCRUD.LoginUser(usuario))
                {
                    return Ok(_reservasCRUD.ListReservs());
                }
                else 
                {
                    return NotFound(Constanst.UsuarioNoValido);
                }

            }
            else 
            {
                return BadRequest();
            }
        }
    }
}
