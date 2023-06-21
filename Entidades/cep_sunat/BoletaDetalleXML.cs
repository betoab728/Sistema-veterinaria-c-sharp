using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.cpe_sunat
{
   public class BoletaDetalleXML
    {
        public string numeroitem { get; set; }
        public string cantidaditem { get; set; }
        public string valorventa { get; set; }
        public string preciounitario { get; set; }
        public string igv { get; set; }
        public string descripcion { get; set; }
        public string idproducto { get; set; }
    }
}
