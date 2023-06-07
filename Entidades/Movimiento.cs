using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Movimiento
    {
        public int idMovimiento { get; set; }
        public string Tipo { get; set; }
        public DateTime Fecha { get; set; }
        public int Idventa { get; set; }
        public int Idpedido { get; set; }
        public int idcausa { get; set; }
    }

}
