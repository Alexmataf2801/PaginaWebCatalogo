using AccesoDatos.Producto;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Producto
{
    public class LogicaNegocioProducto
    {

        #region INSERT

        public static int InsertarCarrito(Carrito carrito)
        {

            return AccesoDatosProductos.InsertarCarrito(carrito);
        }

        #endregion

        #region SELECT 

        public static List<Productos> ObtenerProductoPorTipo(int TipoProducto, int SubTipoProducto)
        {
            return AccesoDatosProductos.ObtenerProductoPorTipo(TipoProducto, SubTipoProducto);
        }

        public static List<ImagenesProducto> ObtenerImagenesProductoXTipoSubtipo(int TipoProducto, int SubTipoProducto)
        {
            return AccesoDatosProductos.ObtenerImagenesProductoXTipoSubtipo(TipoProducto, SubTipoProducto);
        }

        public static List<ImagenesProducto> ObtenerDetalleProducto(int IdProducto)
        {

            return AccesoDatosProductos.ObtenerDetalleProducto(IdProducto);
        }

        public static List<ImagenesProducto> ObtenerProductosRandom()
        {

            return AccesoDatosProductos.ObtenerProductosRandom();
        }

        public static List<ImagenesProducto> ObtenerProductosRandomDescuentos()
        {

            return AccesoDatosProductos.ObtenerProductosRandomDescuentos();
        }

        public static List<Carrito> ObtenerCarrito(int IdUsuario)
        {

            return AccesoDatosProductos.ObtenerCarrito(IdUsuario);
        }

        #endregion


        #region UPDATE
        #endregion

        #region DELETE

        public static bool EliminarProductoCarrito(Carrito carrito)
        {

            return AccesoDatosProductos.EliminarProductoCarrito(carrito);
        }

        #endregion









    }
}
