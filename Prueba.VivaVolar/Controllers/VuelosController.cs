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
    /// Controlador para la configuracion y administración de vuelos
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VuelosController : ControllerBase
    {
        private IConfiguration _config;
        private UserCRUD _userCRUD;
        private VuelosCRUD _vuelosCRUD;

        public VuelosController(IConfiguration config, UserCRUD userCRUD, VuelosCRUD vuelosCRUD)
        {
            _config = config;
            _userCRUD = userCRUD;
            _vuelosCRUD = vuelosCRUD;
        }
        /// <summary>
        /// Crea vuelos con permisos de administrador
        /// </summary>
        /// <param name="requestVuelos"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("CrearVuelos")]
        public string CreateFlys(RequestVuelos requestVuelos) 
        {
            if (ModelState.IsValid)
            {
                if (_userCRUD.AdminUser(requestVuelos.usuario))
                {
                    return _vuelosCRUD.CreateFlys(requestVuelos.Vuelos);
                }
                else 
                {
                    return Constanst.UsuarioNoValido;
                }
            }
            else 
            {
                return Constanst.VueloModelError;
            }
        }
        /// <summary>
        /// Edita vuelos con permisos de administrador
        /// </summary>
        /// <param name="requestVuelos"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("EditarVuelos")]
        public string EditFlys(RequestVuelos requestVuelos)
        {
            if (ModelState.IsValid)
            {
                if (_userCRUD.AdminUser(requestVuelos.usuario))
                {
                    return _vuelosCRUD.EditFlys(requestVuelos.Vuelos);
                }
                else
                {
                    return Constanst.UsuarioNoValido;
                }
            }
            else
            {
                return Constanst.VueloModelError;
            }
        }
        /// <summary>
        /// Puede ver una lista de vuelos con filtros si el usuario está creado en el sistema
        /// </summary>
        /// <param name="requestVuelos"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("ListarVuelos")]
        public ActionResult<List<Vuelos>> ListFlys(Usuarios usuario)
        {
            if (ModelState.IsValid)
            {
                if (_userCRUD.LoginUser(usuario))
                {
                    return Ok(_vuelosCRUD.ListFlys());
                }
                else
                {
                    return NotFound(); ;
                }
            }
            else
            {
                return BadRequest();
            }
        }
        /// <summary>
        /// Puede ver lista de vuelos si se encuentra creado en el sistema
        /// </summary>
        /// <param name="requestVuelos"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("ListVuelosParaUsuarios")]
        public ActionResult<List<Vuelos>> ListFlysForUsers(RequestVuelos requestVuelos)
        {
            if (ModelState.IsValid)
            {
                if (!_userCRUD.AdminUser(requestVuelos.usuario))
                {
                    return  Ok(_vuelosCRUD.ListFlysUser(requestVuelos.Vuelos));
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return BadRequest(); ;
            }
        }
    }
}
