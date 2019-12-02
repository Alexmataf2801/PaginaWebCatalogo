using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Imagen
    {
        public int IdImagen { get; set; }
        public string NombreImagen { get; set; }
        public string Raiz { get; set; }
        public string Url { get; set; }
        public bool? Estado { get; set; }
        public string UsuarioCreacion { get; set; }
        public int IdTipo { get; set; }
        public string NombreTipo { get; set; }
        public int IdSubTipo { get; set; }
        public string NombreSubTipo { get; set; }

    }
}
