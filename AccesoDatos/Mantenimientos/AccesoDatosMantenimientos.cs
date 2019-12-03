using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Mantenimientos
{
    public class AccesoDatosMantenimientos
    {

        #region INSERT

        public static bool InsertarRedSocial(RedesSociales redSocial)
        {

            PaginaWebCatalogosEntities entities = new PaginaWebCatalogosEntities();
            ObjectParameter respuesta;
            bool Correcto = false;
            try
            {
                respuesta = new ObjectParameter("Respuesta", typeof(int));
                var Iconos = entities.paInsertarRedSocial(redSocial.Nombre, redSocial.Descripcion, redSocial.Url, redSocial.Icono, redSocial.UsuarioCreacion, redSocial.Color, respuesta);

                if (respuesta.Value.ToString() == "1")
                {
                    Correcto = true;
                }

            }
            catch (Exception ex)
            {

                throw;
            }

            return Correcto;
        }

        public static bool InsertarTipoProducto(TipoProducto tipo)
        {

            PaginaWebCatalogosEntities entities = new PaginaWebCatalogosEntities();
            ObjectParameter respuesta;
            bool Correcto = false;
            try
            {
                respuesta = new ObjectParameter("Respuesta", typeof(int));
                var Iconos = entities.paInsertarTipoProducto(tipo.Codigo, tipo.Nombre, tipo.Descripcion, tipo.UsuarioCreacion, respuesta);

                if (respuesta.Value.ToString() == "1")
                {
                    Correcto = true;
                }

            }
            catch (Exception ex)
            {

                throw;
            }

            return Correcto;
        }

        public static bool InsertarSubTipoProducto(SubTipoProducto subTipo, ref int IdSubTipoRef)
        {

            PaginaWebCatalogosEntities entities = new PaginaWebCatalogosEntities();
            ObjectParameter respuesta;
            ObjectParameter IdSubTipo;
            bool Correcto = false;
            try
            {
                respuesta = new ObjectParameter("Respuesta", typeof(int));
                IdSubTipo = new ObjectParameter("IdSubTipo", typeof(int));

                entities.paInsertarSubTipoProducto(subTipo.Codigo, subTipo.Nombre, subTipo.Descripcion, subTipo.UsuarioCreacion, respuesta, IdSubTipo);

                if (respuesta.Value.ToString() == "1" && Convert.ToInt32(IdSubTipo.Value.ToString()) > 0)
                {
                    IdSubTipoRef = Convert.ToInt32(IdSubTipo.Value.ToString());
                    Correcto = true;
                }

            }
            catch (Exception ex)
            {

                throw;
            }

            return Correcto;
        }

        public static bool InsertarSubTipoTipoRelacion(SubTipoProducto subTipo)
        {

            PaginaWebCatalogosEntities entities = new PaginaWebCatalogosEntities();
            ObjectParameter respuesta;
            bool Correcto = false;
            try
            {
                respuesta = new ObjectParameter("Respuesta", typeof(int));
                entities.paInsertarRelacionTipoSubTipo(subTipo.IdTipo, subTipo.IdSubTipo);
                Correcto = true;

            }
            catch (Exception ex)
            {

                throw;
            }

            return Correcto;
        }

        public static bool InsertarMenuPublico(SubTipoProducto subTipo)
        {

            PaginaWebCatalogosEntities entities = new PaginaWebCatalogosEntities();
            bool Correcto = false;
            try
            {
                entities.paInsertarMenuPublico(subTipo.IdTipo, subTipo.IdSubTipo);
                Correcto = true;

            }
            catch (Exception ex)
            {

                throw;
            }

            return Correcto;
        }

        public static int InsertarProducto(Productos productos)
        {

            PaginaWebCatalogosEntities entities = new PaginaWebCatalogosEntities();
            ObjectParameter respuesta;
            int IdProducto = 0;
            try
            {
                respuesta = new ObjectParameter("IdProducto", typeof(int));
                entities.paInsertarProducto(productos.Codigo, productos.Nombre, productos.Descripcion, productos.Moneda, Convert.ToDecimal(productos.PrecioProducto), productos.TipoProducto, productos.SubTipoProducto, productos.UsuarioCreacion, respuesta);
                IdProducto = Convert.ToInt32(respuesta.Value.ToString());

            }
            catch (Exception ex)
            {

                throw;
            }

            return IdProducto;
        }

        public static int InsertarImagen(ImagenesProducto Imagen)
        {

            PaginaWebCatalogosEntities entities = new PaginaWebCatalogosEntities();
            ObjectParameter respuesta;
            int IdImagen = 0;
            try
            {
                respuesta = new ObjectParameter("IdImagen", typeof(int));
                entities.paInsertarImagen(Imagen.NombreImagen, Imagen.Raiz, Imagen.Url, Imagen.UsuarioCreacion, respuesta);
                IdImagen = Convert.ToInt32(respuesta.Value.ToString());

            }
            catch (Exception ex)
            {

                throw;
            }

            return IdImagen;
        }

        public static int InsertarRelacionImagenProd(ImagenesProducto Imagen)
        {

            PaginaWebCatalogosEntities entities = new PaginaWebCatalogosEntities();
            ObjectParameter respuesta;
            int IdRelacion = 0;
            try
            {
                respuesta = new ObjectParameter("IdRelacion", typeof(int));
                entities.paInsertarRelacionImagenProducto(Imagen.IdProducto,Imagen.IdImagen,Imagen.IdUsuario, respuesta);
                IdRelacion = Convert.ToInt32(respuesta.Value.ToString());

            }
            catch (Exception ex)
            {

                throw;
            }

            return IdRelacion;
        }

        public static int InsertarEmpresa(Empresa empresa, string Raiz)
        {

            PaginaWebCatalogosEntities entities = new PaginaWebCatalogosEntities();
            ObjectParameter respuesta;
            int Resultado = 0;
            try
            {
                respuesta = new ObjectParameter("Resultado", typeof(int));
                entities.paInsertarInformacionEmpresa(empresa.Nombre, empresa.Descripcion, empresa.CorreoElectronico, empresa.Telefono, empresa.Direccion,Raiz, respuesta);
                Resultado = Convert.ToInt32(respuesta.Value.ToString());

            }
            catch (Exception ex)
            {

                throw;
            }

            return Resultado;
        }

        #endregion


        #region SELECT 

        public static List<Icono> ObtenerIconos()
        {

            PaginaWebCatalogosEntities entities = new PaginaWebCatalogosEntities();
            List<Icono> ListaIconos = new List<Icono>();

            try
            {
                var Iconos = entities.paObtenerIconos();

                foreach (var item in Iconos)
                {
                    Icono icono = new Icono();
                    icono.IdIcono = item.IdIcono;
                    icono.Codigo = item.Codigo;
                    icono.Nombre = item.Nombre;

                    ListaIconos.Add(icono);

                }

            }
            catch (Exception ex)
            {

                throw;
            }

            return ListaIconos;
        }

        public static List<Icono> ObtenerIconosRedes()
        {

            PaginaWebCatalogosEntities entities = new PaginaWebCatalogosEntities();
            List<Icono> ListaIconos = new List<Icono>();

            try
            {
                var Iconos = entities.paObtenerIconosRedes();

                foreach (var item in Iconos)
                {
                    Icono icono = new Icono();
                    icono.IdIcono = item.IdIconoRedes;
                    icono.Codigo = item.Codigo;
                    icono.Nombre = item.Nombre;

                    ListaIconos.Add(icono);

                }

            }
            catch (Exception ex)
            {

                throw;
            }

            return ListaIconos;
        }

        public static List<TipoProducto> ObtenerTipoProducto()
        {

            PaginaWebCatalogosEntities entities = new PaginaWebCatalogosEntities();
            List<TipoProducto> ListaTipoProducto = new List<TipoProducto>();

            try
            {
                var TipoProd = entities.paObtenerTipoProductoActivo();

                foreach (var item in TipoProd)
                {
                    TipoProducto tipo = new TipoProducto();
                    tipo.IdTipo = item.IdTipo;
                    tipo.Codigo = item.Codigo;
                    tipo.Nombre = item.Nombre;
                    tipo.Descripcion = item.Descripcion;

                    ListaTipoProducto.Add(tipo);

                }

            }
            catch (Exception ex)
            {

                throw;
            }

            return ListaTipoProducto;
        }

        public static List<SubTipoProducto> ObtenerSubTipoProducto()
        {

            PaginaWebCatalogosEntities entities = new PaginaWebCatalogosEntities();
            List<SubTipoProducto> ListaSubTipoProducto = new List<SubTipoProducto>();

            try
            {
                var SubTipoProd = entities.paObtenerSubTipoProdActivo();

                foreach (var item in SubTipoProd)
                {
                    SubTipoProducto subTipo = new SubTipoProducto();
                    subTipo.IdSubTipo = item.IdSubTipo;
                    subTipo.Codigo = item.Codigo;
                    subTipo.Nombre = item.Nombre;
                    subTipo.Descripcion = item.Descripcion;

                    ListaSubTipoProducto.Add(subTipo);
                }

            }
            catch (Exception ex)
            {

                throw;
            }

            return ListaSubTipoProducto;
        }

        public static List<SubTipoProducto> ObtenerSubTipoProductoXTipo(int IdTipo)
        {

            PaginaWebCatalogosEntities entities = new PaginaWebCatalogosEntities();
            List<SubTipoProducto> ListaSubTipoProducto = new List<SubTipoProducto>();

            try
            {
                var SubTipoProd = entities.paObtenerSubTiposXIdTipo(IdTipo);

                foreach (var item in SubTipoProd)
                {
                    SubTipoProducto subTipo = new SubTipoProducto();
                    subTipo.IdSubTipo = item.IdSubTipo;
                    subTipo.Codigo = item.Codigo;
                    subTipo.Nombre = item.Nombre;
                    subTipo.Descripcion = item.Descripcion;

                    ListaSubTipoProducto.Add(subTipo);
                }

            }
            catch (Exception ex)
            {

                throw;
            }

            return ListaSubTipoProducto;
        }

        public static bool ActualizarRedSocial(RedesSociales redSocial)
        {

            PaginaWebCatalogosEntities entities = new PaginaWebCatalogosEntities();
            bool Correcto = false;

            try
            {
                entities.paActualizarRedSocial(redSocial.IdRedSocial,redSocial.Nombre, redSocial.Descripcion, redSocial.Url, redSocial.Icono, redSocial.Color,redSocial.UsuarioUltimaModificacion);
                Correcto = true;

            }
            catch (Exception ex)
            {

                throw;
            }

            return Correcto;
        }
        //
        public static RedesSociales ObtenerRedSocial(int IdRedSocial)
        {
            PaginaWebCatalogosEntities entities = new PaginaWebCatalogosEntities();
            RedesSociales redesSociales = new RedesSociales();

            try
            {
                var RedesSociales = entities.paObtenerRedSocial(IdRedSocial);

                foreach (var item in RedesSociales)
                {
                   
                    redesSociales.IdRedSocial = item.IdRedSocial;
                    redesSociales.Nombre = item.Nombre;
                    redesSociales.Descripcion = item.Descripcion;
                    redesSociales.Url = item.Url;
                    redesSociales.Icono = item.Icono;
                    redesSociales.Color = item.Color;
                    redesSociales.UsuarioCreacion = item.UsuarioCreacion;
                    redesSociales.FechaCreacion = item.FechaCreacion;
                    redesSociales.UsuarioUltimaModificacion = item.UsuarioUltimaModificacion;
                    redesSociales.FechaUltimaModificacion = item.FechaUltimaModificacion;
                    redesSociales.Estado = item.Estado;

                }
            }
            catch (Exception ex)
            {

                throw;
            }


            return redesSociales;
        }

        public static List<RedesSociales> ObtenerTodasRedesSociales()
        {
            PaginaWebCatalogosEntities entities = new PaginaWebCatalogosEntities();
            List<RedesSociales> ListaRedesSociales = new List<RedesSociales>();

            try
            {
                var RedesSociales = entities.paObtenerTodasRedesSociales();

                foreach (var item in RedesSociales)
                {
                    RedesSociales redesSociales = new RedesSociales();
                    redesSociales.IdRedSocial = item.IdRedSocial;
                    redesSociales.Nombre = item.Nombre;
                    redesSociales.Descripcion = item.Descripcion;
                    redesSociales.Url = item.Url;
                    redesSociales.Icono = item.Icono;
                    redesSociales.Color = item.Color;
                    redesSociales.UsuarioCreacion = item.UsuarioCreacion;
                    redesSociales.FechaCreacion = item.FechaCreacion;
                    redesSociales.UsuarioUltimaModificacion = item.UsuarioUltimaModificacion;
                    redesSociales.FechaUltimaModificacion = item.FechaUltimaModificacion;
                    redesSociales.Estado = item.Estado;



                    ListaRedesSociales.Add(redesSociales);
                }
            }
            catch (Exception ex)
            {

                throw;
            }


            return ListaRedesSociales;
        }

        public static List<TipoProducto> ObtenerTodosTiposProducto()
        {

            PaginaWebCatalogosEntities entities = new PaginaWebCatalogosEntities();
            List<TipoProducto> ListaTipoProducto = new List<TipoProducto>();

            try
            {
                var TipoProd = entities.paObtenerTodosTipos();

                foreach (var item in TipoProd)
                {
                    TipoProducto tipo = new TipoProducto();
                    tipo.IdTipo = item.IdTipo;
                    tipo.Codigo = item.Codigo;
                    tipo.Nombre = item.Nombre;
                    tipo.Descripcion = item.Descripcion;
                    tipo.Estado = item.Estado;

                    ListaTipoProducto.Add(tipo);

                }

            }
            catch (Exception ex)
            {

                throw;
            }

            return ListaTipoProducto;
        }

        public static List<SubTipoProducto> ObtenerTodosSubTiposProducto()
        {

            PaginaWebCatalogosEntities entities = new PaginaWebCatalogosEntities();
            List<SubTipoProducto> ListaSubTipos = new List<SubTipoProducto>();

            try
            {
                var SubTipo = entities.paObtenerTodosSubTipos();

                foreach (var item in SubTipo)
                {
                    SubTipoProducto SubTipoProd = new SubTipoProducto();
                    SubTipoProd.IdSubTipo = item.IdSubTipo;
                    SubTipoProd.Codigo = item.Codigo;
                    SubTipoProd.Nombre = item.Nombre;
                    SubTipoProd.Descripcion = item.Descripcion;
                    SubTipoProd.Estado = item.Estado;

                    ListaSubTipos.Add(SubTipoProd);

                }

            }
            catch (Exception ex)
            {

                throw;
            }

            return ListaSubTipos;
        }

        public static List<Productos> ObtenerTodosProductos()
        {

            PaginaWebCatalogosEntities entities = new PaginaWebCatalogosEntities();
            List<Productos> ListaProductos = new List<Productos>();

            try
            {
                var productos = entities.paObtenerTodosProductos();

                foreach (var item in productos)
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


                    ListaProductos.Add(producto);

                }

            }
            catch (Exception ex)
            {

                throw;
            }

            return ListaProductos;
        }
        public static TipoProducto ObtenerTipoXId(int IdTipo)
        {

            PaginaWebCatalogosEntities entities = new PaginaWebCatalogosEntities();
            TipoProducto tipo = new TipoProducto();

            try
            {
                var productos = entities.paObtenerTipoXId(IdTipo);

                foreach (var item in productos)
                {
                    tipo.Codigo = item.Codigo;
                    tipo.Nombre = item.Nombre;
                    tipo.Descripcion = item.Descripcion;
                    tipo.Estado = item.Estado;
                }

            }
            catch (Exception ex)
            {

                throw;
            }

            return tipo;
        }

        public static SubTipoProducto ObtenerSubTipoXId(int IdSubTipo)
        {

            PaginaWebCatalogosEntities entities = new PaginaWebCatalogosEntities();
            SubTipoProducto subTipo = new SubTipoProducto();

            try
            {
                var subTipoInfo = entities.paObtenerSubTipoXId(IdSubTipo);

                foreach (var item in subTipoInfo)
                {
                    subTipo.Codigo = item.Codigo;
                    subTipo.Nombre = item.Nombre;
                    subTipo.Descripcion = item.Descripcion;
                    subTipo.Estado = item.Estado;
                    subTipo.IdTipo = item.IdTipoProducto;
                }

            }
            catch (Exception ex)
            {

                throw;
            }

            return subTipo;
        }

        public static List<ImagenesProducto> ObtenerImagenesXIdProducto(int IdProducto)
        {

            PaginaWebCatalogosEntities entities = new PaginaWebCatalogosEntities();
            List<ImagenesProducto> ListaImagenes = new List<ImagenesProducto>();

            try
            {
                var Imagenes = entities.paObtenerImagenesXIdProducto(IdProducto);

                foreach (var item in Imagenes)
                {
                    ImagenesProducto img = new ImagenesProducto();
                    img.IdImagen = item.IdImagen;
                    img.NombreImagen = item.Nombre;
                    img.Raiz = item.Raiz;
                    img.Url = item.Url;
                    img.Estado = item.Estado;

                    ListaImagenes.Add(img);
                }

            }
            catch (Exception ex)
            {

                throw;
            }

            return ListaImagenes;
        }

        public static Productos ObtenerProductoXId(int IdProducto)
        {

            PaginaWebCatalogosEntities entities = new PaginaWebCatalogosEntities();
            Productos productos = new Productos();

            try
            {
                var Info = entities.paObtenerInfoProductoXId(IdProducto);

                foreach (var item in Info)
                {
                    productos.Codigo = item.Codigo;
                    productos.Nombre = item.Nombre;
                    productos.Descripcion = item.Descripcion;
                    productos.Moneda = item.Moneda;
                    productos.PrecioProducto = item.PrecioProducto.ToString();
                    productos.TipoProducto = item.TipoProducto;
                    productos.SubTipoProducto = item.SubTipo;
                    productos.Estado = item.Estado;
                }

            }
            catch (Exception ex)
            {

                throw;
            }

            return productos;
        }

        public static ImagenesProducto ObtenerImagenXId(int IdImagen)
        {

            PaginaWebCatalogosEntities entities = new PaginaWebCatalogosEntities();
            ImagenesProducto img = new ImagenesProducto();

            try
            {
                var Info = entities.paObtenerImagenXId(IdImagen);

                foreach (var item in Info)
                {
                    img.NombreImagen = item.Nombre;
                    img.Raiz = item.Raiz;
                    img.Url = item.Url;
                    img.Estado = item.Estado;

                }

            }
            catch (Exception ex)
            {

                throw;
            }

            return img;
        }

        public static Imagen ObtenerRutaImagen(int IdImagen)
        {

            PaginaWebCatalogosEntities entities = new PaginaWebCatalogosEntities();
            Imagen img = new Imagen();

            try
            {
                var Info = entities.paObtenerRutaImagen(IdImagen);

                foreach (var item in Info)
                {
                    img.NombreImagen = item.Nombre;
                    img.Raiz = item.Raiz;
                    img.Url = item.Url;
                    img.Estado = item.Estado;
                    img.IdTipo = item.IdTipo;
                    img.NombreTipo = item.Tipo;
                    img.IdSubTipo = item.IdSubTipo;
                    img.NombreSubTipo = item.SubTipo;

                }

            }
            catch (Exception ex)
            {

                throw;
            }

            return img;
        }

        #endregion


        #region UPDATE 

        public static bool DesactivarActivarRedSocial(int IdRedSocial, bool Estado)
        {
            bool Correcto = false;
            PaginaWebCatalogosEntities entities = new PaginaWebCatalogosEntities();

            try
            {
                entities.paDesactivarActivarRedSocial(IdRedSocial, Estado);
                Correcto = true;

            }
            catch (Exception ex)
            {
                Correcto = false;
                throw;
            }

            return Correcto;
        }

        public static bool DesactivarActivarProducto(int IdProducto, bool Estado)
        {
            bool Correcto = false;
            PaginaWebCatalogosEntities entities = new PaginaWebCatalogosEntities();

            try
            {
                entities.paDesactivarActivarProducto(IdProducto, Estado);
                Correcto = true;

            }
            catch (Exception ex)
            {
                Correcto = false;
                throw;
            }

            return Correcto;
        }

        public static bool DesactivarActivarSubTipo(int IdSubTipo, bool Estado)
        {
            bool Correcto = false;
            PaginaWebCatalogosEntities entities = new PaginaWebCatalogosEntities();

            try
            {
                entities.paDesactivarActivarSubTipo(IdSubTipo, Estado);
                Correcto = true;

            }
            catch (Exception ex)
            {
                Correcto = false;
                throw;
            }

            return Correcto;
        }

        public static bool DesactivarActivarTipo(int IdTipo, bool Estado)
        {
            bool Correcto = false;
            PaginaWebCatalogosEntities entities = new PaginaWebCatalogosEntities();

            try
            {
                entities.paDesactivarActivarTipo(IdTipo, Estado);
                Correcto = true;

            }
            catch (Exception ex)
            {
                Correcto = false;
                throw;
            }

            return Correcto;
        }

        public static bool ActualizarInfoEmpresa(Empresa empresa)
        {
            bool Correcto = false;
            PaginaWebCatalogosEntities entities = new PaginaWebCatalogosEntities();

            try
            {
                entities.paActualizarInformacionEmpresa(empresa.IdRegistro , empresa.Nombre, empresa.Descripcion, empresa.CorreoElectronico, empresa.Telefono, empresa.Direccion);
                Correcto = true;

            }
            catch (Exception ex)
            {
                Correcto = false;
                throw;
            }

            return Correcto;
        }

        public static bool ActualizarTipo(TipoProducto tipo)
        {
            bool Correcto = false;
            PaginaWebCatalogosEntities entities = new PaginaWebCatalogosEntities();

            try
            {
                entities.paActualizarTipo(tipo.IdTipo,tipo.Codigo,tipo.Nombre, tipo.Descripcion, tipo.UsuarioUltimaModificacion);
                Correcto = true;

            }
            catch (Exception ex)
            {
                Correcto = false;
                throw;
            }

            return Correcto;
        }

        public static bool ActualizarSubTipo(SubTipoProducto SubTipo)
        {
            bool Correcto = false;
            PaginaWebCatalogosEntities entities = new PaginaWebCatalogosEntities();

            try
            {
                entities.paActualizarSubTipo(SubTipo.IdSubTipo, SubTipo.Codigo, SubTipo.Nombre, SubTipo.Descripcion, SubTipo.UsuarioUltimaModificacion);
                Correcto = true;

            }
            catch (Exception ex)
            {
                Correcto = false;
                throw;
            }

            return Correcto;
        }

        public static bool ActualizarProducto(Productos productos)
        {
            bool Correcto = false;
            PaginaWebCatalogosEntities entities = new PaginaWebCatalogosEntities();

            try
            {
                entities.paActualizarProducto(productos.IdProducto, productos.Codigo, productos.Nombre, productos.Descripcion, productos.Moneda, Convert.ToDecimal(productos.PrecioProducto), productos.TipoProducto, productos.SubTipoProducto, productos.UsuarioUltimaModificacion);
                Correcto = true;

            }
            catch (Exception ex)
            {
                Correcto = false;
                throw;
            }

            return Correcto;
        }

        #endregion


        #region DELETE

        public static bool EliminarRedSocial(int IdRedSocial)
        {
            bool Correcto = false;
            PaginaWebCatalogosEntities entities = new PaginaWebCatalogosEntities();

            try
            {
                entities.paEliminarRedSocial(IdRedSocial);
                Correcto = true;

            }
            catch (Exception ex)
            {
                Correcto = false;
                throw;
            }

            return Correcto;
        }

        public static bool EliminarTipo(int IdTipo)
        {
            bool Correcto = false;
            PaginaWebCatalogosEntities entities = new PaginaWebCatalogosEntities();

            try
            {
                entities.paEliminarTipo(IdTipo);
                Correcto = true;

            }
            catch (Exception ex)
            {
                Correcto = false;
                throw;
            }

            return Correcto;
        }

        public static bool EliminarSubTipo(int IdSubTipo)
        {
            bool Correcto = false;
            PaginaWebCatalogosEntities entities = new PaginaWebCatalogosEntities();

            try
            {
                entities.paEliminarSubTipo(IdSubTipo);
                Correcto = true;

            }
            catch (Exception ex)
            {
                Correcto = false;
                throw;
            }

            return Correcto;
        }

        public static bool EliminarProducto(int IdProducto)
        {
            bool Correcto = false;
            PaginaWebCatalogosEntities entities = new PaginaWebCatalogosEntities();

            try
            {
                entities.paEliminarProducto(IdProducto);
                Correcto = true;

            }
            catch (Exception ex)
            {
                Correcto = false;
                throw;
            }

            return Correcto;
        }

        public static bool EliminarImagenXId(int IdImagen)
        {
            bool Correcto = false;
            PaginaWebCatalogosEntities entities = new PaginaWebCatalogosEntities();

            try
            {
                entities.paEliminarImagenXId(IdImagen);
                Correcto = true;

            }
            catch (Exception ex)
            {
                Correcto = false;
                throw;
            }

            return Correcto;
        }


        #endregion







    }
}
