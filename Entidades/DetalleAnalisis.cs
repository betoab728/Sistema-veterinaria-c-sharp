using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DetalleAnalisis
    {
        public int IdDetalle { get; set; }
        public int IdAnalisis { get; set; }
        public string Detalleanalisis { get; set; }
        public string Resultados { get; set; }
        public string Unidades { get; set; }
        public string ValorReferencial { get; set; }
        public string Metodo { get; set; }
    }
}
