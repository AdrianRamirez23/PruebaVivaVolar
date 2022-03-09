using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba.VivaVolar.Models
{
    public class Vuelos
    {
        [Key]
        public int idVuelo { get; set; }
        public string NumeroVuelo { get; set; }
        public DateTime FechaDisponibilidad { get; set; }
        public int CantidadSilla { get; set; }
        public string CiudadOrigen { get; set; }
        public string CiudadDestino { get; set; }
        public double Precio { get; set; }
    }
}
