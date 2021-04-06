using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Producto
{
    public class AccesoDatosProductos
    {

        #region INSERT 

        public static int InsertarCarrito(Carrito carrito)
        {
            PaginaWebCatalogosEntities entities = new PaginaWebCatalogosEntities();
            ObjectParameter respuesta;
            int Correcto = 0;

            try
            {
                respuesta = new ObjectParameter("Respuesta", typeof(int));
                entities.paInsertarProductoCarrito(carrito.IdProducto, carrito.IdUsuario, respuesta);

                if (!string.IsNullOrEmpty(respuesta.Value.ToString()))
                {

                    Correcto = Convert.ToInt32(respuesta.Value.ToString());

                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return Correcto;
        }
        public static int InsertarTipoProducto(TipoProducto tipoProducto)
        {
            PaginaWebCatalogosEntities entities = new PaginaWebCatalogosEntities();
            ObjectParameter respuesta;
            int Correcto = 0;

            try
            {
                respuesta = new ObjectParameter("Respuesta", typeof(int));
                entities.paInsertarTipoProducto(tipoProducto.Codigo, tipoProducto.Nombre, tipoProducto.Descripcion, tipoProducto.UsuarioCreacion, respuesta);

                if (!string.IsNullOrEmpty(respuesta.Value.ToString()))
                {

                    Correcto = Convert.ToInt32(respuesta.Value.ToString());

                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return Correcto;
        }
        #endregion


        #region SELECT  

        public static List<Productos> ObtenerProductoPorTipo(int TipoProducto, int SubTipoProducto)
        {
            PaginaWebCatalogosEntities entities = new PaginaWebCatalogosEntities();
            List<Productos> ListaProducto = new List<Productos>();

            try
            {
                var Producto = entities.paObtenerProductoPorTipo(TipoProducto, SubTipoProducto);

                foreach (var item in Producto)
                {
                    Productos producto = new Productos();
                    producto.IdProducto = item.IdProducto;
                    producto.Codigo = item.Codigo;
                    producto.Nombre = item.Nombre;
                    producto.Descripcion = item.Descripcion;
                    producto.Moneda = item.Moneda;
                    producto.PrecioProducto = item.PrecioProducto.ToString("###,###,###,###,###.##");
                    producto.TipoProducto = item.TipoProducto;
                    producto.SubTipoProducto = item.SubTipo;
                    producto.Estado = item.Estado;
                    producto.UsuarioCreacion = item.UsuarioCreacion;
                    producto.FechaCreacion = item.FechaCreacion;
                    producto.UsuarioUltimaModificacion = item.UsuarioUltimaModificacion;
                    producto.FechaUltimaModificacion = item.FechaUltimaModificacion;
                    producto.Descuento = item.Descuento;
                    producto.TipoDescuento = item.TipoDescuento;
                    producto.CantidadDescuento = item.CantidadDescuento;
                    producto.Condicion = item.Condicion;
                    if (Convert.ToBoolean(item.Descuento))
                    {
                        decimal? PrecioConDescuento = 0.0M;
                        if (item.TipoDescuento == 1)
                        {
                            PrecioConDescuento = item.PrecioProducto - item.CantidadDescuento;
                            producto.PrecioConDescuento = Convert.ToDecimal(PrecioConDescuento).ToString("###,###,###,###,###.##");
                        }
                        else
                        {
                            decimal? Descuento = (item.CantidadDescuento / 100);
                            PrecioConDescuento = item.PrecioProducto - (item.PrecioProducto * Descuento);
                            producto.PrecioConDescuento = Convert.ToDecimal(PrecioConDescuento).ToString("###,###,###,###,###.##");
                        }

                    }
                    ListaProducto.Add(producto);
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return ListaProducto;
        }

        public static List<ImagenesProducto> ObtenerImagenesProductoXTipoSubtipo(int TipoProducto, int SubTipoProducto)
        {
            PaginaWebCatalogosEntities entities = new PaginaWebCatalogosEntities();
            List<ImagenesProducto> ListaImagenesProducto = new List<ImagenesProducto>();

            try
            {
                var imagenes = entities.paObtenerImagenesXTipoSubtipo(TipoProducto, SubTipoProducto);

                foreach (var item in imagenes)
                {
                    ImagenesProducto Imagen = new ImagenesProducto();
                    Imagen.IdImagen = item.IdImagen;
                    Imagen.NombreImagen = item.NombreImagen;
                    Imagen.Raiz = item.Raiz;
                    Imagen.Url = item.Url;
                    Imagen.Estado = item.Estado;
                    Imagen.IdProducto = item.IdProducto;
                    Imagen.NombreProducto = item.NombreProducto;

                    ListaImagenesProducto.Add(Imagen);
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return ListaImagenesProducto;
        }

        public static List<ImagenesProducto> ObtenerDetalleProducto(int IdProducto)
        {
            PaginaWebCatalogosEntities entities = new PaginaWebCatalogosEntities();
            List<ImagenesProducto> ListaImagenesProducto = new List<ImagenesProducto>();

            try
            {
                var Producto = entities.paObtenerDetalleProducto(IdProducto);

                foreach (var item in Producto)
                {
                    ImagenesProducto Imagen = new ImagenesProducto();
                    Imagen.IdImagen = item.IdImagen;
                    Imagen.NombreImagen = item.NombreImagen;
                    Imagen.Raiz = item.Raiz;
                    Imagen.Url = item.Url;
                    Imagen.IdProducto = item.IdProducto;
                    Imagen.NombreProducto = item.Nombre;
                    Imagen.CodigoProducto = item.Codigo;
                    Imagen.Descripcion = item.Descripcion;
                    Imagen.Moneda = item.Moneda;
                    Imagen.PrecioUnitario = item.PrecioProducto.ToString("###,###,###,###,###.##");
                    //Imagen.PrecioUnitario = item.PrecioProducto.ToString("###,###,###,###,###");
                    Imagen.Descuento = item.Descuento;
                    Imagen.TipoDescuento = item.TipoDescuento;
                    Imagen.CantidadDescuento = item.CantidadDescuento;

                    if (Convert.ToBoolean(item.Descuento))
                    {
                        decimal? PrecioConDescuento = 0.0M;
                        if (item.TipoDescuento == 1)
                        {
                            PrecioConDescuento = item.PrecioProducto - item.CantidadDescuento;
                            Imagen.PrecioConDescuento = Convert.ToDecimal(PrecioConDescuento).ToString("###,###,###,###,###.##");
                        }
                        else
                        {
                            decimal? Descuento = (item.CantidadDescuento / 100);
                            PrecioConDescuento = item.PrecioProducto - (item.PrecioProducto * Descuento);
                            Imagen.PrecioConDescuento = Convert.ToDecimal(PrecioConDescuento).ToString("###,###,###,###,###.##");
                        }

                    }




                    ListaImagenesProducto.Add(Imagen);
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return ListaImagenesProducto;
        }

        public static List<ImagenesProducto> ObtenerProductosRandom()
        {
            PaginaWebCatalogosEntities entities = new PaginaWebCatalogosEntities();
            List<ImagenesProducto> ListaImagenesProducto = new List<ImagenesProducto>();

            try
            {
                var Producto = entities.paObtenerProductosRandom();

                foreach (var item in Producto)
                {
                    ImagenesProducto Imagen = new ImagenesProducto();
                    Imagen.NombreImagen = item.NombreImagen;
                    Imagen.Raiz = item.Raiz;
                    Imagen.Url = item.Url;
                    Imagen.IdProducto = item.IdProducto;
                    Imagen.NombreProducto = item.Nombre;
                    Imagen.PrecioUnitario = item.PrecioProducto.ToString("###,###,###,###,###.##");
                    Imagen.Moneda = item.Moneda;
                    Imagen.Condicion = item.Condicion;

                    ListaImagenesProducto.Add(Imagen);
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return ListaImagenesProducto;
        }

        public static List<ImagenesProducto> ObtenerProductosRandomDescuentos()
        {
            PaginaWebCatalogosEntities entities = new PaginaWebCatalogosEntities();
            List<ImagenesProducto> ListaImagenesProducto = new List<ImagenesProducto>();

            try
            {
                var Producto = entities.paObtenerProductosDescuentoRandom();

                foreach (var item in Producto)
                {
                    ImagenesProducto Imagen = new ImagenesProducto();
                    Imagen.NombreImagen = item.NombreImagen;
                    Imagen.Raiz = item.Raiz;
                    Imagen.Url = item.Url;
                    Imagen.IdProducto = item.IdProducto;
                    Imagen.NombreProducto = item.Nombre;
                    Imagen.PrecioUnitario = item.PrecioProducto.ToString("###,###,###,###,###.##");
                    Imagen.Moneda = item.Moneda;
                    Imagen.Descuento = item.Descuento;
                    Imagen.TipoDescuento = item.TipoDescuento;
                    Imagen.CantidadDescuento = item.CantidadDescuento;
                    Imagen.Condicion = item.Condicion;

                    if (Convert.ToBoolean(item.Descuento))
                    {
                        decimal? PrecioConDescuento = 0.0M;
                        if (item.TipoDescuento == 1)
                        {
                            PrecioConDescuento = item.PrecioProducto - item.CantidadDescuento;
                            Imagen.PrecioConDescuento = Convert.ToDecimal(PrecioConDescuento).ToString("###,###,###,###,###.##");
                        }
                        else
                        {
                            decimal? Descuento = (item.CantidadDescuento / 100);
                            PrecioConDescuento = item.PrecioProducto - (item.PrecioProducto * Descuento);
                            Imagen.PrecioConDescuento = Convert.ToDecimal(PrecioConDescuento).ToString("###,###,###,###,###.##");
                        }

                    }

                    ListaImagenesProducto.Add(Imagen);
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return ListaImagenesProducto;
        }

        public static List<Carrito> ObtenerCarrito(int IdUsuario)
        {
            PaginaWebCatalogosEntities entities = new PaginaWebCatalogosEntities();
            List<Carrito> ListaCarrito = new List<Carrito>();

            try
            {
                var Producto = entities.paObtenerCarrito(IdUsuario);

                foreach (var item in Producto)
                {
                    Carrito carro = new Carrito();
                    carro.IdProducto = item.IdProducto;
                    carro.Codigo = item.Codigo;
                    carro.NombreProducto = item.NombreProducto;
                    carro.Descripcion = item.Descripcion;
                    carro.Moneda = item.Moneda;
                    carro.PrecioProducto = item.PrecioProducto.ToString();
                    carro.IdTipo = item.IdTipo;
                    carro.NombreTipo = item.NombreTipo;
                    carro.IdSubTipo = item.IdSubTipo;
                    carro.NombreSubTipo = item.NombreSubTipo;
                    carro.CantidadTotal = item.CantTotal;
                    carro.UrlImagen = item.RutaImagen.Remove(0,2);

                    ListaCarrito.Add(carro);
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return ListaCarrito;
        }


        #endregion


        #region UPDATE 
        #endregion


        #region DELETE 

        public static bool EliminarProductoCarrito(Carrito carrito)
        {
            PaginaWebCatalogosEntities entities = new PaginaWebCatalogosEntities();

            bool Correcto = false;

            try
            {
                entities.paEliminarProductoCarro(carrito.IdProducto, carrito.IdUsuario);
                Correcto = true;


            }
            catch (Exception ex)
            {

                throw;
            }

            return Correcto;
        }

        #endregion









    }

}

