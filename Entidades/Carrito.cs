using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Carrito
    {
        public int IdProducto { get; set; }
        public string Codigo { get; set; }
        public string NombreProducto { get; set; }
        public string Descripcion { get; set; }
        public string Moneda { get; set; }
        public string PrecioProducto { get; set; }
        public int? IdTipo { get; set; }
        public string NombreTipo { get; set; }
        public int? IdSubTipo { get; set; }
        public string NombreSubTipo { get; set; }
        public int? CantidadTotal { get; set; }
        public int? IdUsuario { get; set; }
        public string UrlImagen { get; set; }

    }
}
