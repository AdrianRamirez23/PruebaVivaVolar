using Prueba.VivaVolar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba.VivaVolar.Utils
{
    public class MapperUser
    {
        public MapperUser() { }
        public Usuarios MapperUsuarios(Usuarios usuarioin, Usuarios usuarioReturn) 
        {
            usuarioReturn.Usuario = usuarioin.Usuario;
            usuarioReturn.NombreUsuario = usuarioin.NombreUsuario;
            usuarioReturn.PassUser = usuarioin.PassUser;
            usuarioReturn.Email = usuarioin.Email;
            usuarioReturn.idTipoUser = usuarioin.idTipoUser;
            usuarioReturn.UsuarioIdentificacion = usuarioin.UsuarioIdentificacion;
            usuarioReturn.TipoIdentificacion = usuarioin.TipoIdentificacion;
            return usuarioReturn;

        }
    }
}
