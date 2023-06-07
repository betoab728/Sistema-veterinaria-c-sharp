using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class CajaChica
    {
        public int Idcajachica { get; set; }
        public DateTime FechaApertura { get; set; }
        public DateTime FechaCierre { get; set; }
        public int IdTrabajador { get; set; }
        public int Estado { get; set; }
        public double ImporteApertura { get; set; }
        public double ImporteCierra { get; set; }

    }
}
