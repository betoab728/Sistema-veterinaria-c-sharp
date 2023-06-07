using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Receta
    {
        public int Idreceta { get; set; }
        public int Idmascota { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime Hora { get; set; }
        public int Idtrabajador { get; set; }
        public string Descripcion { get; set; }
    }

}
