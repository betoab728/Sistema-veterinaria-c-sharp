using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DetalleFicha
    {
        public int iddetalle { get; set; }
        public int idficha { get; set; }
        public DateTime fecha { get; set; }
        public string descripcion { get; set; }
        public string temperatura { get; set; }
        public DateTime proxcita { get; set; }
        public string registrado { get; set; }
    }
}
