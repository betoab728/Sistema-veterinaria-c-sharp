using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operacion
    {
            public int Idoperacion { get; set; }
            public string Concepto { get; set; }
            public string Tipo { get; set; }
            public int Idmediopago { get; set; }
            public double Importe { get; set; }
            public string Digitostarjeta { get; set; }
            public string Estado { get; set; }
            public int Idventa { get; set; }
            public int Idcajachica { get; set; }
            public DateTime FechaRegistro { get; set; }
    }
}
