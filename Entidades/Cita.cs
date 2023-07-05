using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cita
    {
        public int Idcita { get; set; }
        public int Idtipo { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime Hora { get; set; }
        public string NombreMascota { get; set; }
        public string Telefono { get; set; }
    }
}
