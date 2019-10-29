using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Login
    {
        public int IdUsuario { get; set; }
        public string Usuario { get; set; }
        public string Contrasena { get; set; }
        public bool Temporal { get; set; }
        public bool Estado { get; set; }
    }
}
