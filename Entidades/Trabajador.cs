using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Trabajador
    {
        public int Idtrabajador { get; set; }
        public string DNI { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Nombres { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Cargo { get; set; }
    }


}
