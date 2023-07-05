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
        public double Total { get; set; }
        public double Utilidad { get; set; }
        public string serie { get; set; }
        public int numero { get; set; }
        public int idcajachica { get; set; }
    }

}
