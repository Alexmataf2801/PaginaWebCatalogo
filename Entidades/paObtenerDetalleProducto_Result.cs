//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Entidades
{
    using System;
    
    public partial class paObtenerDetalleProducto_Result
    {
        public int IdProducto { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Moneda { get; set; }
        public decimal PrecioProducto { get; set; }
        public Nullable<bool> Descuento { get; set; }
        public Nullable<int> TipoDescuento { get; set; }
        public Nullable<decimal> CantidadDescuento { get; set; }
        public int IdImagen { get; set; }
        public string Url { get; set; }
        public string NombreImagen { get; set; }
        public string Raiz { get; set; }
    }
}
