using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Mascota
    {
        public int idMascota { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Raza { get; set; }
        public string Especie { get; set; }
        public string Sexo { get; set; }
        public string Capa { get; set; }
        public string Observacion { get; set; }
        public int idcliente { get; set; }
    }
}
