using Entidades;
using LogicaNegocio.Producto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PaginaWebCatalogo.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Productos(int TipoProducto, int SubTipoProducto)
        {
            List<Productos> ListaProducto = LogicaNegocioProducto.ObtenerProductoPorTipo(TipoProducto, SubTipoProducto);
            List<ImagenesProducto> ListaImagenes = LogicaNegocioProducto.ObtenerImagenesProductoXTipoSubtipo(TipoProducto, SubTipoProducto);
            ViewBag.Imagenes = ListaImagenes;

            return View(ListaProducto);
        }


        //public JsonResult ObtenerDetalleProducto(int IdProducto)
        //{
        //    List<ImagenesProducto> ListaDetalleProducto = LogicaNegocioProducto.ObtenerDetalleProducto(IdProducto);

        //    return Json(ListaDetalleProducto, JsonRequestBehavior.AllowGet);

        //}

        public ActionResult DetalleProducto(int IdProducto)
        {
            List<ImagenesProducto> ListaDetalleProducto = LogicaNegocioProducto.ObtenerDetalleProducto(IdProducto);

            return View(ListaDetalleProducto);

        }


        //public ActionResult DetalleProducto(int IdProducto)
        //{

        //    List<ImagenesProducto> ListaDetalleProducto = LogicaNegocioProducto.ObtenerDetalleProducto(IdProducto);

        //    return View("DetalleProducto", ListaDetalleProducto);
        //}

        public JsonResult ObtenerProductosRandom()
        {
            List<ImagenesProducto> ListaDetalleProducto = LogicaNegocioProducto.ObtenerProductosRandom();

            return Json(ListaDetalleProducto, JsonRequestBehavior.AllowGet);

        }

        public JsonResult ObtenerProductosCarrito()
        {
            Usuario usuario = new Usuario();
            usuario = (Usuario)Session["UsuarioLogueado"];

            List<Carrito> ListaCarrito = LogicaNegocioProducto.ObtenerCarrito(usuario.IdUsuario);

            return Json(ListaCarrito, JsonRequestBehavior.AllowGet);

        }



        public JsonResult AgregarProductoCarrito(int IdProducto)
        {
            int respuesta = 0;

            if (Session["UsuarioLogueado"] != null)
            {
                Usuario usuario = new Usuario();
                usuario = (Usuario)Session["UsuarioLogueado"];

                if (usuario.IdPerfil > 1)
                {
                    Carrito carrito = new Carrito();
                    carrito.IdProducto = IdProducto;
                    carrito.IdUsuario = usuario.IdUsuario;

                    respuesta = LogicaNegocioProducto.InsertarCarrito(carrito);
                }
                else
                {
                    respuesta = -1;
                }
            }
            else
            {
                respuesta = -1;
            }

            return Json(respuesta, JsonRequestBehavior.AllowGet);

        }

        public JsonResult EliminarProductoCarrito(int IdProducto)
        {
            bool respuesta = false;

            if (Session["UsuarioLogueado"] != null)
            {
                Usuario usuario = new Usuario();
                usuario = (Usuario)Session["UsuarioLogueado"];

                Carrito carrito = new Carrito();
                carrito.IdProducto = IdProducto;
                carrito.IdUsuario = usuario.IdUsuario;

                respuesta = LogicaNegocioProducto.EliminarProductoCarrito(carrito);
            }
            else
            {
                respuesta = false;
            }

            return Json(respuesta, JsonRequestBehavior.AllowGet);

        }


    }
}