using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DetalleVenta
    {
        public int Iddetalle { get; set; }
        public int Idventa { get; set; }
        public int Idproducto { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }
    }
}
