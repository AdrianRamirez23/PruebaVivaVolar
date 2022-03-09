using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba.VivaVolar.Models
{
    public class Reservas
    {
        [Key]
        public int idReserva { get; set; }
        public int idUsuario { get; set; }
        public int idVuelo { get; set; }
    }
}
