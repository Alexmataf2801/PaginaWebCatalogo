using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ImagenesProducto
    {
        public int? IdImagen { get; set; }
        public string NombreImagen { get; set; }
        public string Raiz { get; set; }
        public string Url { get; set; }
        public bool? Estado { get; set; }
        public string UsuarioCreacion { get; set; }
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public string Descripcion { get; set; }
        public string Moneda { get; set; }
        public string PrecioUnitario { get; set; }
        public string CodigoProducto { get; set; }
        public int IdUsuario { get; set; }

    }
}
