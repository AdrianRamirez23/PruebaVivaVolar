using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba.VivaVolar.Models
{
    public class Usuarios
    {
        [Key]
        public int idUsuario { get; set; }
        public string Usuario { get; set; }
        public string NombreUsuario { get; set; }
        public string PassUser { get; set; }
        public string Email { get; set; }
        public int idTipoUser { get; set; }
        public string UsuarioIdentificacion { get; set; }
        public int TipoIdentificacion { get; set; }

    }
}
