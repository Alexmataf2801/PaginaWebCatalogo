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
            index.ListaProductosDescuento = LogicaNegocioProducto.ObtenerProductosRandomDescuentos();


            return View("Index", index);
        }

        public ActionResult About()
        {
            Empresa Empresa = LogicaNegocioAdministracion.ObtenerInformacionEmpresa();

            return View("About", Empresa);
        }

        #region INSERT

        public JsonResult RegistrarUsuario(Usuario usuario)
        {

            int Respuesta = LogicaNegocioAdministracion.InsertarUsuario(usuario);

            return Json(Respuesta, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region SELECT 


        public ActionResult ObtenerMenuPublico()
        {
            List<MenuPublico> ListaMenuPublico = new List<MenuPublico>();
            ListaMenuPublico = LogicaNegocioMenu.ObtenerMenuPublico();
            
            return PartialView("_MenuPublico", ListaMenuPublico);

        }

        public ActionResult ObtenerInfoFooter() {

            Index index = new Index();
            index.ListaRedesSociales = LogicaNegocioAdministracion.ObtenerRedesSociales();
            index.Empresa = LogicaNegocioAdministracion.ObtenerInformacionEmpresa();

            return PartialView("_Footer", index);
        }


        public ActionResult ObtenerRedesSociales()
        {
            List<RedesSociales> ListaRedesSociales = LogicaNegocioAdministracion.ObtenerRedesSociales();
            
            return PartialView("_RedesSociales", ListaRedesSociales);

        }

        public ActionResult ObtenerBanners()
        {
            List<Banner> ListaBanners = LogicaNegocioAdministracion.ObtenerBannersActivos();

            return PartialView("_Banners", ListaBanners);

        }

        public ActionResult ObtenerBeneficios()
        {
            List<Beneficios> ListaBeneficios = LogicaNegocioAdministracion.ObtenerBeneficiosActivos();

            return PartialView("_Beneficios", ListaBeneficios);

        }

        public ActionResult ObtenerInformacionEmpresa()
        {
            Empresa Empresa = LogicaNegocioAdministracion.ObtenerInformacionEmpresa();

            return PartialView("_Encabezado", Empresa);

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