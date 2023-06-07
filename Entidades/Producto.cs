using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Producto
    {
        public int Idproducto { get; set; }
        public string Descripcion { get; set; }
        public int Idmarca { get; set; }
        public int Idcategoria { get; set; }
        public double PrecioCosto { get; set; }
        public double PrecioVenta { get; set; }
        public DateTime FechaVencimiento { get; set; }
    }

}
