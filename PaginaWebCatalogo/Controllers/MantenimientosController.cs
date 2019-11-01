using Entidades;
using LogicaNegocio.Mantenimientos;
using LogicaNegocio.Menu;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace PaginaWebCatalogo.Controllers
{
    public class MantenimientosController : Controller
    {
        // GET: Mantenimientos
        public ActionResult Index()
        {
            Iniciarlizar();
            return View();
        }

        [HttpGet]
        public ActionResult DatosEmpresa()
        {
            Iniciarlizar();
            return View();

        }

        [HttpGet]
        public ActionResult ListarRedes()
        {

            Iniciarlizar();

            return View("ListaRedes");
        }

        [HttpGet]
        public ActionResult ListaTipos()
        {

            Iniciarlizar();

            return View("ListaTipos");
        }

        [HttpGet]
        public ActionResult ListaSubTipos()
        {

            Iniciarlizar();

            return View("ListaSubTipos");
        }

        [HttpGet]
        public ActionResult ListaProductos()
        {

            Iniciarlizar();

            return View("ListaProductos");
        }

        [HttpGet]
        public ActionResult Tipo()
        {

            Iniciarlizar();
            return View();
        }

        [HttpGet]
        public ActionResult SubTipo()
        {

            Iniciarlizar();
            return View();
        }

        [HttpGet]
        public ActionResult RedesSociales()
        {

            Iniciarlizar();
            return View();
        }

        [HttpGet]
        public ActionResult Productos()
        {

            Iniciarlizar();
            return View();
        }


        public void Iniciarlizar()
        {

            if (Session["UsuarioLogueado"] != null)
            {
                Usuario usuario = new Usuario();
                usuario = (Usuario)Session["UsuarioLogueado"];
                ViewBag.Usuario = usuario.Nombre + " " + usuario.PrimerApellido + " " + usuario.SegundoApellido;
                ViewBag.Menu = ObtenerMenuAdministrativo();
            }
        }

        #region INSERT

        [HttpPost]
        public JsonResult InsertarSubTipoProducto(SubTipoProducto subTipo)
        {
            bool Correcto = false;

            if (Session["UsuarioLogueado"] != null)
            {
                Usuario usuario = new Usuario();
                usuario = (Usuario)Session["UsuarioLogueado"];
                subTipo.UsuarioCreacion = usuario.Nombre + " " + usuario.PrimerApellido + " " + usuario.SegundoApellido;

                int IdSubTipoRef = 0;

                Correcto = LogicaNegocioMantenimientos.InsertarSubTipoProducto(subTipo, ref IdSubTipoRef);

                if (Correcto && IdSubTipoRef > 0)
                {

                    subTipo.IdSubTipo = IdSubTipoRef;
                    Correcto = LogicaNegocioMantenimientos.InsertarSubTipoTipoRelacion(subTipo);

                    if (Correcto)
                    {

                        Correcto = LogicaNegocioMantenimientos.InsertarMenuPublico(subTipo);

                    }

                }
            }

            return Json(Correcto, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult InsertarRedSocial(RedesSociales redSocial)
        {
            bool Correcto = false;

            if (Session["UsuarioLogueado"] != null)
            {
                Usuario usuario = new Usuario();
                usuario = (Usuario)Session["UsuarioLogueado"];

                redSocial.UsuarioCreacion = usuario.Nombre + " " + usuario.PrimerApellido + " " + usuario.SegundoApellido;

                Correcto = LogicaNegocioMantenimientos.InsertarRedSocial(redSocial);

            }

            return Json(Correcto, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult InsertarTipoProducto(TipoProducto tipo)
        {
            bool Correcto = false;

            if (Session["UsuarioLogueado"] != null)
            {
                Usuario usuario = new Usuario();
                usuario = (Usuario)Session["UsuarioLogueado"];
                tipo.UsuarioCreacion = usuario.Nombre + " " + usuario.PrimerApellido + " " + usuario.SegundoApellido;
                Correcto = LogicaNegocioMantenimientos.InsertarTipoProducto(tipo);

            }

            return Json(Correcto, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult InsertarProducto()
        {
            string Codigo = string.Empty;
            string Nombre = string.Empty;
            string Descripcion = string.Empty;
            string Moneda = string.Empty;
            string Precio = string.Empty;
            string TipoProd = string.Empty;
            string SubTipo = string.Empty;
            string TextoTipo = string.Empty;
            string TextoSubTipo = string.Empty;

            if (Session["UsuarioLogueado"] != null)
            {
                Usuario usuario = new Usuario();
                usuario = (Usuario)Session["UsuarioLogueado"];

                if (Request.Files.Count > 0)
                {
                    try
                    {
                        Productos productos = new Productos();

                        productos.Codigo = Request.Form["Codigo"];
                        productos.Nombre = Nombre = Request.Form["Nombre"];
                        productos.Descripcion = Request.Form["Descripcion"];
                        productos.Moneda = Request.Form["Moneda"];
                        productos.PrecioProducto = Request.Form["Precio"];
                        productos.TipoProducto = Convert.ToInt32(Request.Form["TipoProd"]);
                        productos.SubTipoProducto = Convert.ToInt32(Request.Form["SubTipo"]);
                        productos.UsuarioCreacion = usuario.Nombre + " " + usuario.PrimerApellido + " " + usuario.SegundoApellido;

                        int IdProducto = LogicaNegocioMantenimientos.InsertarProducto(productos);

                        HttpFileCollectionBase files = Request.Files;
                        for (int i = 0; i < files.Count; i++)
                        {

                            HttpPostedFileBase file = files[i];
                            string fname;

                            fname = file.FileName;
                            TextoTipo = Request.Form["TextoTipo"];
                            TextoSubTipo = Request.Form["TextoSubTipo"];

                            if (IdProducto > 0)
                            {

                                ImagenesProducto imagen = new ImagenesProducto();
                                imagen.NombreImagen = fname.Split('.')[0];
                                imagen.Raiz = "." + fname.Split('.')[1];
                                imagen.UsuarioCreacion = usuario.Nombre + " " + usuario.PrimerApellido + " " + usuario.SegundoApellido;
                                imagen.Url = "~//Imagenes//" + TextoTipo + "/" + TextoSubTipo + "/";
                                imagen.IdProducto = IdProducto;
                                imagen.IdUsuario = usuario.IdUsuario;

                                int IdImagen = LogicaNegocioMantenimientos.InsertarImagen(imagen);

                                imagen.IdImagen = IdImagen;

                                int Relacion = LogicaNegocioMantenimientos.InsertarRelacionImagenProd(imagen);


                            }

                            string Ruta = Path.Combine(Server.MapPath("~/Imagenes/"), TextoTipo + "/" + TextoSubTipo + "/");

                            if (Directory.Exists(Ruta))
                            {
                                file.SaveAs(Ruta + "/" + fname);
                            }
                            else
                            {
                                Directory.CreateDirectory(Ruta);
                                file.SaveAs(Ruta + "/" + fname);

                            }
                        }

                        return Json("File Uploaded Successfully!");
                    }
                    catch (Exception ex)
                    {
                        return Json("Error occurred. Error details: " + ex.Message);
                    }
                }
                else
                {
                    return Json("No files selected.");
                }
            }
            return Json("No se proceso la peticion");

        }


        #endregion

        #region SELECT 

        public JsonResult ObtenerIconos()
        {
            List<Icono> ListaIconos = LogicaNegocioMantenimientos.ObtenerIconos();

            return Json(ListaIconos, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ObtenerIconosRedes()
        {
            List<Icono> ListaIconos = LogicaNegocioMantenimientos.ObtenerIconosRedes();

            return Json(ListaIconos, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ObtenerTipoProducto()
        {
            List<TipoProducto> ListaTipo = LogicaNegocioMantenimientos.ObtenerTipoProducto();

            return Json(ListaTipo, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ObtenerSubTipoProducto()
        {
            List<SubTipoProducto> ListaTipo = LogicaNegocioMantenimientos.ObtenerSubTipoProducto();

            return Json(ListaTipo, JsonRequestBehavior.AllowGet);
        }

        public string ObtenerMenuAdministrativo()
        {
            List<MenuAdministracion> ListaMenuAdministrativo = new List<MenuAdministracion>();
            StringBuilder menuArmado = new StringBuilder();

            if (Session["UsuarioLogueado"] != null)
            {
                Usuario usuario = new Usuario();
                usuario = (Usuario)Session["UsuarioLogueado"];

                ListaMenuAdministrativo = LogicaNegocioMenu.ObtenerMenuAdministracion(usuario.IdUsuario);


                menuArmado.Append("<ul class='sidebar-menu' data-widget='tree'>");
                menuArmado.Append("<li class='header'>MENU DE NAVEGACIÓN</li>");

                var listaPadres = ListaMenuAdministrativo.Where(p => p.IsPadre == "0").ToList();

                for (int j = 0; j < listaPadres.Count; j++)
                {
                    menuArmado.Append("<li class='treeview'>");
                    menuArmado.Append("<a href='" + listaPadres[j].Url + "'>");
                    menuArmado.Append("<i class='" + listaPadres[j].Icono + "'></i><span>" + listaPadres[j].Nombre + "</span>");
                    menuArmado.Append("<span class='pull-right-container'>");
                    menuArmado.Append("<i class='fa fa-angle-left pull-right'></i>");
                    menuArmado.Append("</span>");
                    menuArmado.Append("</a>");

                    var SegundoNivel = ListaMenuAdministrativo.Where(p => p.IdPadre == listaPadres[j].IdMenu).ToList();

                    if (SegundoNivel.Count > 0)
                    {
                        menuArmado.Append("<ul class='treeview-menu'>");
                    }

                    for (int k = 0; k < SegundoNivel.Count; k++)
                    {
                        var TercerNivel = ListaMenuAdministrativo.Where(p => p.IdPadre == SegundoNivel[k].IdMenu).ToList();

                        if (TercerNivel.Count > 0)
                        {
                            menuArmado.Append("<li class='treeview'>");
                            menuArmado.Append("<a href='" + SegundoNivel[k].Url + "'>");
                            menuArmado.Append("<i class='" + SegundoNivel[k].Icono + "'></i><span>" + SegundoNivel[k].Nombre + "</span>");
                        }
                        else
                        {
                            menuArmado.Append("<li>");
                            menuArmado.Append("<a href='" + SegundoNivel[k].Url + "'>");
                            menuArmado.Append("<i class='" + SegundoNivel[k].Icono + "'></i><span>" + SegundoNivel[k].Nombre + "</span>");
                        }

                        if (TercerNivel.Count > 0)
                        {
                            menuArmado.Append("<i class='fa fa-angle-left pull-right'></i>");
                            menuArmado.Append("</a>");
                            menuArmado.Append("<ul class='treeview-menu'>");
                        }

                        for (int a = 0; a < TercerNivel.Count; a++)
                        {
                            var CuartoNivel = ListaMenuAdministrativo.Where(p => p.IdPadre == TercerNivel[a].IdMenu).ToList();

                            if (CuartoNivel.Count > 0)
                            {
                                menuArmado.Append("<li class='treeview'>");
                                menuArmado.Append("<a href='" + TercerNivel[a].Url + "'>");
                                menuArmado.Append("<i class='" + TercerNivel[a].Icono + "'></i><span>" + TercerNivel[a].Nombre + "</span>");
                                menuArmado.Append("<span class='pull-right-container'>");
                                menuArmado.Append("<i class='fa fa-angle-left pull-right'></i>");
                                menuArmado.Append("</span>");
                                menuArmado.Append("</a>");
                                menuArmado.Append("<ul class='treeview-menu'>");

                                for (int i = 0; i < CuartoNivel.Count; i++)
                                {
                                    menuArmado.Append("<li>");
                                    menuArmado.Append("<a href='" + CuartoNivel[i].Url + "'><i class='" + CuartoNivel[i].Icono + "'>");
                                    menuArmado.Append("</i>" + CuartoNivel[i].Nombre + "</a>");
                                }

                                menuArmado.Append("</ul></li>");
                            }
                            else
                            {
                                menuArmado.Append("<li><a href='" + TercerNivel[a].Url + "'><i class='" + TercerNivel[a].Icono + "'></i>" + TercerNivel[a].Nombre);
                                menuArmado.Append("</a>");
                            }

                        }

                        if (TercerNivel.Count > 0)
                        {
                            menuArmado.Append("</ul></li>");
                        }
                        else
                        {
                            menuArmado.Append("</a>");
                            menuArmado.Append("</li>");
                        }

                    }
                    menuArmado.Append("</ul></li>");

                }
                menuArmado.Append("</ul>");


            }

            return menuArmado.ToString();

        }

        public JsonResult ObtenerRedSocial(int RedSocial)
        {
            RedesSociales redes = new RedesSociales();

            if (Session["UsuarioLogueado"] != null)
            {
                Usuario usuario = new Usuario();
                usuario = (Usuario)Session["UsuarioLogueado"];
                redes = LogicaNegocioMantenimientos.ObtenerRedSocial(RedSocial);

            }

            return Json(redes, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ObtenerTodasRedesSociales()
        {
            List<RedesSociales> ListaRedesSociales = new List<RedesSociales>();

            if (Session["UsuarioLogueado"] != null)
            {
                Usuario usuario = new Usuario();
                usuario = (Usuario)Session["UsuarioLogueado"];
                ListaRedesSociales = LogicaNegocioMantenimientos.ObtenerTodasRedesSociales();

            }

            return Json(ListaRedesSociales, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ObtenerTodosTipoProducto()
        {
            List<TipoProducto> ListaTipoProducto = new List<TipoProducto>();

            if (Session["UsuarioLogueado"] != null)
            {
                Usuario usuario = new Usuario();
                usuario = (Usuario)Session["UsuarioLogueado"];
                ListaTipoProducto = LogicaNegocioMantenimientos.ObtenerTodosTiposProducto();

            }

            return Json(ListaTipoProducto, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ObtenerTodosSubTiposProducto()
        {
            List<SubTipoProducto> ListaSubProducto = new List<SubTipoProducto>();

            if (Session["UsuarioLogueado"] != null)
            {
                Usuario usuario = new Usuario();
                usuario = (Usuario)Session["UsuarioLogueado"];
                ListaSubProducto = LogicaNegocioMantenimientos.ObtenerTodosSubTiposProducto();

            }

            return Json(ListaSubProducto, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ObtenerTodosProductos()
        {
            List<Productos> ListaProductos = new List<Productos>();

            if (Session["UsuarioLogueado"] != null)
            {
                Usuario usuario = new Usuario();
                usuario = (Usuario)Session["UsuarioLogueado"];
                ListaProductos = LogicaNegocioMantenimientos.ObtenerTodosProductos();

            }

            return Json(ListaProductos, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region UPDATE
        #endregion

        #region DELETE
        #endregion













    }
}