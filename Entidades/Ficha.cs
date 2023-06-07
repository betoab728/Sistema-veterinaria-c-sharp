using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ficha
    {
        public int Idficha { get; set; }
        public DateTime Fecha { get; set; }
        public string Hora { get; set; }
        public int Idmascota { get; set; }
        public int Idcliente { get; set; }
        public string Descripcion { get; set; }
        public string Temperatura { get; set; }
        public DateTime Proximacita { get; set; }
        public int Idcita { get; set; }
    }
}
