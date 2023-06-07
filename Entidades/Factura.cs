using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Factura
    {
        public int Idfactura { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime Hora { get; set; }
        public string Serie { get; set; }
        public int Numero { get; set; }
        public int Idventa { get; set; }
        public double Total { get; set; }

    }
}
