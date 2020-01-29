using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Productos
    {
        public int IdProducto { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Moneda { get; set; }
        public string PrecioProducto { get; set; }
        public int? TipoProducto { get; set; }
        public int? SubTipoProducto { get; set; }
        public bool Descuento { get; set; }
        public int TipoDescuento { get; set; }
        public decimal CantidadDescuento { get; set; }
        public bool Estado { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string UsuarioUltimaModificacion { get; set; }
        public DateTime? FechaUltimaModificacion { get; set; }
        

    }
}
