using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.cpe_sunat
{
    public class FacturaXML
    {
        public string serieynumero { get; set; }
        public string fechaemision { get; set; }
        public string horaemision { get; set; }
        public string importeletras { get; set; }
        public string cantidaditems { get; set; }
        public string rucemisor { get; set; }
        public string razonemisor { get; set; }
        public string nombrecomercial { get; set; }
        public string ruccliente { get; set; }
        public string razoncliente { get; set; }
        public string direccion { get; set; }
        public string igv { get; set; }
        public string subtotal { get; set; }
        public string total { get; set; }
    }
}
