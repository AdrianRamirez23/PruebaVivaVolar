using Prueba.VivaVolar.Data;
using Prueba.VivaVolar.Models;
using Prueba.VivaVolar.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba.VivaVolar.Services
{
    public class UserCRUD
    {
        private readonly AppDBContext _appDBContext;
        private readonly MapperUser _mapperUser;

        public UserCRUD(AppDBContext appDBContext, MapperUser mapperUser) 
        {
            _appDBContext = appDBContext;
            _mapperUser = mapperUser;
        }

        public string CreateUser(Usuarios usuario) 
        {
            try
            {
                _appDBContext.Usuario.Add(usuario);
                _appDBContext.SaveChanges();
                return Constanst.UsuarioCreado;
            }
            catch (Exception ex)
            {
                return Constanst.UsuarioErrorCrear+ex.Message;
                
            }
        
        }
        public string EditUser(Usuarios usuario)
        {
            try
            {
                var userId = (from a in _appDBContext.Usuario where a.idUsuario == usuario.idUsuario select a).FirstOrDefault();
                userId = _mapperUser.MapperUsuarios(usuario, userId);
                _appDBContext.SaveChanges();
                return Constanst.UsuarioEditado;
            }
            catch (Exception ex)
            {
                return Constanst.UsuarioErrorEditar + ex.Message;

            }

        }

        public bool LoginUser(Usuarios usuario)
        {
            try
            {
                var userId = (from a in _appDBContext.Usuario where a.Usuario == usuario.Usuario && a.PassUser == usuario.PassUser select a).FirstOrDefault();

                if (userId != null)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;

            }

        }
        public bool AdminUser(Usuarios usuario)
        {
            try
            {
                var userId = (from a in _appDBContext.Usuario where a.Usuario == usuario.Usuario && a.PassUser == usuario.PassUser select a).FirstOrDefault();

                if (userId.idTipoUser == 1)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;

            }
        }
        public Usuarios ConsultarUsuario(Reservas reserva) 
        {
            try
            {
              var userResult = _appDBContext.Usuario.Where(u => u.idUsuario == reserva.idUsuario).FirstOrDefault();
                return userResult;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
