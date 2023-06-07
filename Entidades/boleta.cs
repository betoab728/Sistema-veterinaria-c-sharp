using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Boleta
    {
        public int Idboleta {get;set;}
        public DateTime fecha { get; set;}
        public DateTime hora { get; set; }
        public String serie { get; set;}
        public String serio { get; set; }
        public int numero { get; set; }
        public int Idventa { get; set; }
        public double Total { get; set; }
    }
}
