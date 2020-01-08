using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Banner
    {
        public int IdBanner { get; set; }
        public string NombreBanner { get; set; }
        public string Raiz { get; set; }
        public string Url { get; set; }
        public string Titulo { get; set; }
        public string Detalle { get; set; }
        public string UsuarioCreacionBanner { get; set; }
        public DateTime FechaCreacionBanner { get; set; }
        public bool EstadoBanner { get; set; }
    }
}
