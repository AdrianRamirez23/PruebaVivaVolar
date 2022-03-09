using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Prueba.VivaVolar.Middleware;
using Prueba.VivaVolar.Models;
using Prueba.VivaVolar.Services;

namespace Prueba.VivaVolar.Controllers
{
    /// <summary>
    /// Controlador para Usuarios
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IConfiguration _config;
        private UserCRUD _userCRUD;
        private readonly IJWTAuthenticationManager _jwtAuthenticationManager;

        public UsuariosController(IConfiguration config, UserCRUD userCRUD, IJWTAuthenticationManager jWTAuthenticationManager)
        {
            _config = config;
            _userCRUD = userCRUD;
            _jwtAuthenticationManager = jWTAuthenticationManager;
           
        }
        /// <summary>
        /// Crea usuarios de dos tipos Administrador o Usuario Persona Natural o Jurídica
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("CrearUsuario")]
        public string CreateUser(Usuarios usuario )
        {
            if (ModelState.IsValid)
            {
                return _userCRUD.CreateUser(usuario);
            }
            else 
            {
                return Constanst.UsuarioModelError;
            }
        }
        /// <summary>
        /// Edita un usuario creado
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("EditarUsuario")]
        public string EditUser(Usuarios usuario)
        {
            if (ModelState.IsValid)
            {
                return _userCRUD.EditUser(usuario);
            }
            else
            {
                return Constanst.UsuarioModelError;
            }
        }
        /// <summary>
        /// Genera un token para autorización de acceso al sistema
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [Route("IniciarSesion")]
        public string Login(Usuarios usuario)
        {
            if (ModelState.IsValid)
            {
                if (_userCRUD.LoginUser(usuario))
                {

                   var token = _jwtAuthenticationManager.Autheticate(usuario.Usuario);
                    return token;
                }
                else
                {
                    return Constanst.UsuarioNoValido;
                }
            }
            else 
            {
                return Constanst.TokenError;
            }

        }
    }
}
