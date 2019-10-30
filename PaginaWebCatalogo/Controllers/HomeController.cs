using Entidades;
using LogicaNegocio.Administracion;
using LogicaNegocio.Menu;
using LogicaNegocio.Producto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PaginaWebCatalogo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Usuario usuario = new Usuario();
            usuario = (Usuario)Session["UsuarioLogueado"];

            Index index = new Index();
            index.ListaProductos = LogicaNegocioProducto.ObtenerProductosRandom();



            return View("Index", index);
        }

        public ActionResult About()
        {
            return View();
        }

        #region INSERT

        public JsonResult RegistrarUsuario(Usuario usuario)
        {

            int Respuesta = LogicaNegocioAdministracion.InsertarUsuario(usuario);

            return Json(Respuesta, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region SELECT 

        public JsonResult ObtenerMenuPublico()
        {

            List<MenuPublico> ListaMenuPublico = LogicaNegocioMenu.ObtenerMenuPublico();

            return Json(ListaMenuPublico, JsonRequestBehavior.AllowGet);

        }

        public JsonResult ObtenerRedesSociales()
        {

            List<RedesSociales> ListaRedesSociales = LogicaNegocioAdministracion.ObtenerRedesSociales();

            return Json(ListaRedesSociales, JsonRequestBehavior.AllowGet);

        }

        public JsonResult ObtenerInformacionEmpresa()
        {

            Empresa Empresa = LogicaNegocioAdministracion.ObtenerInformacionEmpresa();

            return Json(Empresa, JsonRequestBehavior.AllowGet);

        }

        public JsonResult ValidarLogin(Login login)
        {
            Usuario usuario = new Usuario();

            bool Respuesta = LogicaNegocioAdministracion.ValidarLogin(login, ref usuario);

            if (Respuesta && usuario != null)
            {

                Session["UsuarioLogueado"] = usuario;
            }

            usuario.RespuestaResponse = Respuesta;

            return Json(usuario, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region UPDATE
        #endregion

        #region DELETE
        #endregion








    }
}