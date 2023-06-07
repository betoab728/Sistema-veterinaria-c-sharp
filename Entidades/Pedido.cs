using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Pedido
    {
        public int idPedido { get; set; }
        public DateTime Fecha { get; set; }
        public string Serie { get; set; }
        public int Numero { get; set; }
        public int idproveedor { get; set; }
        public double Total { get; set; }
    }

}
