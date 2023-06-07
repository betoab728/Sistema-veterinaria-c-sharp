using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuario
    {
        public int Idusuario { get; set; }
        public string Nombre { get; set; }
        public string Contraseña { get; set; }
        public int Idtrabajador { get; set; }
        public int Idnivelacceso { get; set; }
    }

}
