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
    
    public partial class paObtenerCarrito_Result
    {
        public int IdProducto { get; set; }
        public string Codigo { get; set; }
        public string NombreProducto { get; set; }
        public string Descripcion { get; set; }
        public string Moneda { get; set; }
        public decimal PrecioProducto { get; set; }
        public Nullable<int> IdTipo { get; set; }
        public string NombreTipo { get; set; }
        public Nullable<int> IdSubTipo { get; set; }
        public string NombreSubTipo { get; set; }
        public Nullable<int> CantTotal { get; set; }
        public string RutaImagen { get; set; }
    }
}
