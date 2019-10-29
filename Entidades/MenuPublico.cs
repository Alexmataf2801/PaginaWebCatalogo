using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class MenuPublico
    {
        public int IdMenu { get; set; }
        public string Nombre { get; set; }
        public int? IdPadre { get; set; }
        public bool Estado { get; set; }
        public bool? IsPadre { get; set; }
        public string Url { get; set; }
        public int? TipoProducto { get; set; }
        public int? SubTipo { get; set; }
    }
}
