using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Venta
    {
        public int Idventa { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public int Idcliente { get; set; }
        public int Idtrabajador { get; set; }
        public decimal Total { get; set; }
    }

}
