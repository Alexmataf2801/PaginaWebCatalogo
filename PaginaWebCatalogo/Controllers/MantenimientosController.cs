using Entidades;
using LogicaNegocio.Administracion;
using LogicaNegocio.Mantenimientos;
using LogicaNegocio.Menu;
using System;
using System.Collections.Generic;
using System.IO;
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

        public ActionResult ObtenerMenuAdministrativo()
        {
            List<MenuAdministracion> ListaMenuPublico = new List<MenuAdministracion>();

            if (Session["UsuarioLogueado"] != null)
            {
                Usuario usuario = new Usuario();
                usuario = (Usuario)Session["UsuarioLogueado"];
                ViewBag.Usuario = usuario.Nombre + " " + usuario.PrimerApellido + " " + usuario.SegundoApellido;
                ListaMenuPublico = LogicaNegocioMenu.ObtenerMenuAdministracion(usuario.IdUsuario);

            }


            return PartialView("_MenuAdministracion", ListaMenuPublico);

        }

        public void Iniciarlizar()
        {

            if (Session["UsuarioLogueado"] != null)
            {
                Usuario usuario = new Usuario();
                usuario = (Usuario)Session["UsuarioLogueado"];
                ViewBag.Usuario = usuario.Nombre + " " + usuario.PrimerApellido + " " + usuario.SegundoApellido;
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

                        return Json(true, JsonRequestBehavior.AllowGet);
                    }
                    catch (Exception ex)
                    {
                        return Json(false, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(false, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(false, JsonRequestBehavior.AllowGet);

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

        public ActionResult ObtenerInformacionEmpresa()
        {
            Empresa empresa = new Empresa();

            if (Session["UsuarioLogueado"] != null)
            {
                Usuario usuario = new Usuario();
                usuario = (Usuario)Session["UsuarioLogueado"];
                empresa = LogicaNegocioAdministracion.ObtenerInformacionEmpresa();
                ViewBag.Usuario = usuario.Nombre + " " + usuario.PrimerApellido + " " + usuario.SegundoApellido;

            }

            return View("ActualizarDatosEmpresa", empresa);

        }

        public ActionResult ObtenerInfoTipo(int IdTipoSeleccionado)
        {
            TipoProducto tipo = new TipoProducto();

            if (Session["UsuarioLogueado"] != null)
            {
                Usuario usuario = new Usuario();
                usuario = (Usuario)Session["UsuarioLogueado"];
                tipo = LogicaNegocioMantenimientos.ObtenerTipoXId(IdTipoSeleccionado);
                tipo.IdTipo = IdTipoSeleccionado;
                ViewBag.Usuario = usuario.Nombre + " " + usuario.PrimerApellido + " " + usuario.SegundoApellido;

            }

            return View("ActualizarDatosTipo", tipo);

        }

        public ActionResult ObtenerSubTipoXId(int IdSubTipoSeleccionado)
        {
            SubTipoProducto subtipo = new SubTipoProducto();

            if (Session["UsuarioLogueado"] != null)
            {
                Usuario usuario = new Usuario();
                usuario = (Usuario)Session["UsuarioLogueado"];
                subtipo = LogicaNegocioMantenimientos.ObtenerSubTipoXId(IdSubTipoSeleccionado);
                subtipo.IdSubTipo = IdSubTipoSeleccionado;
                ViewBag.Usuario = usuario.Nombre + " " + usuario.PrimerApellido + " " + usuario.SegundoApellido;

            }

            return View("ActualizarDatosSubTipo", subtipo);

        }
        public JsonResult ObtenerSubTipoXTipo(int IdTipoSeleccionado)
        {
            List<SubTipoProducto> ListaSubtipo = new List<SubTipoProducto>();

            if (Session["UsuarioLogueado"] != null)
            {
                Usuario usuario = new Usuario();
                usuario = (Usuario)Session["UsuarioLogueado"];
                ListaSubtipo = LogicaNegocioMantenimientos.ObtenerSubTipoProductoXTipo(IdTipoSeleccionado);
                ViewBag.Usuario = usuario.Nombre + " " + usuario.PrimerApellido + " " + usuario.SegundoApellido;

            }

            return Json(ListaSubtipo, JsonRequestBehavior.AllowGet);

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

        [HttpGet]
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

        public List<ImagenesProducto> ObtenerImagenesXIdProducto(int IdProducto)
        {
            List<ImagenesProducto> ListaImagenes = new List<ImagenesProducto>();

            if (Session["UsuarioLogueado"] != null)
            {
                Usuario usuario = new Usuario();
                usuario = (Usuario)Session["UsuarioLogueado"];
                ListaImagenes = LogicaNegocioMantenimientos.ObtenerImagenesXIdProducto(IdProducto);

            }

            return ListaImagenes;
        }
        #endregion

        #region UPDATE

        public JsonResult DesactivarActivarRedSocial(int IdRedSocial, bool Estado)
        {
            bool Correcto = false;

            if (Session["UsuarioLogueado"] != null)
            {
                Usuario usuario = new Usuario();
                usuario = (Usuario)Session["UsuarioLogueado"];
                Correcto = LogicaNegocioMantenimientos.DesactivarActivarRedSocial(IdRedSocial, Estado);

            }

            return Json(Correcto, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DesactivarActivarProducto(int IdProducto, bool Estado)
        {
            bool Correcto = false;

            if (Session["UsuarioLogueado"] != null)
            {
                Usuario usuario = new Usuario();
                usuario = (Usuario)Session["UsuarioLogueado"];
                Correcto = LogicaNegocioMantenimientos.DesactivarActivarProducto(IdProducto, Estado);

            }

            return Json(Correcto, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DesactivarActivarTipo(int IdTipo, bool Estado)
        {
            bool Correcto = false;

            if (Session["UsuarioLogueado"] != null)
            {
                Usuario usuario = new Usuario();
                usuario = (Usuario)Session["UsuarioLogueado"];
                Correcto = LogicaNegocioMantenimientos.DesactivarActivarTipo(IdTipo, Estado);

            }

            return Json(Correcto, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DesactivarActivarSubTipo(int IdSubTipo, bool Estado)
        {
            bool Correcto = false;

            if (Session["UsuarioLogueado"] != null)
            {
                Usuario usuario = new Usuario();
                usuario = (Usuario)Session["UsuarioLogueado"];
                Correcto = LogicaNegocioMantenimientos.DesactivarActivarSubTipo(IdSubTipo, Estado);

            }

            return Json(Correcto, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ActualizarInfoEmpresa(Empresa DatosEmpresa)
        {

            bool Correcto = false;

            if (Session["UsuarioLogueado"] != null)
            {
                Usuario usuario = new Usuario();
                usuario = (Usuario)Session["UsuarioLogueado"];
                Correcto = LogicaNegocioMantenimientos.ActualizarInfoEmpresa(DatosEmpresa);

            }

            return Json(Correcto, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ActualizarTipo(TipoProducto InfoTipo)
        {

            bool Correcto = false;

            if (Session["UsuarioLogueado"] != null)
            {
                Usuario usuario = new Usuario();
                usuario = (Usuario)Session["UsuarioLogueado"];
                InfoTipo.UsuarioUltimaModificacion = usuario.Nombre + " " + usuario.PrimerApellido + " " + usuario.SegundoApellido;
                Correcto = LogicaNegocioMantenimientos.ActualizarTipo(InfoTipo);

            }

            return Json(Correcto, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ActualizarSubTipo(SubTipoProducto InfoSubTipo)
        {

            bool Correcto = false;

            if (Session["UsuarioLogueado"] != null)
            {
                Usuario usuario = new Usuario();
                usuario = (Usuario)Session["UsuarioLogueado"];
                InfoSubTipo.UsuarioUltimaModificacion = usuario.Nombre + " " + usuario.PrimerApellido + " " + usuario.SegundoApellido;
                Correcto = LogicaNegocioMantenimientos.ActualizarSubTipo(InfoSubTipo);

            }

            return Json(Correcto, JsonRequestBehavior.AllowGet);
        }



        #endregion

        #region DELETE

        public JsonResult EliminarRedSocial(int IdRedSocial)
        {
            bool Correcto = false;

            if (Session["UsuarioLogueado"] != null)
            {
                Usuario usuario = new Usuario();
                usuario = (Usuario)Session["UsuarioLogueado"];
                Correcto = LogicaNegocioMantenimientos.EliminarRedSocial(IdRedSocial);

            }

            return Json(Correcto, JsonRequestBehavior.AllowGet);
        }

        public JsonResult EliminarTipo(int IdTipo)
        {
            bool Correcto = false;

            if (Session["UsuarioLogueado"] != null)
            {
                Usuario usuario = new Usuario();
                usuario = (Usuario)Session["UsuarioLogueado"];
                Correcto = LogicaNegocioMantenimientos.EliminarTipo(IdTipo);

            }


            return Json(Correcto, JsonRequestBehavior.AllowGet);
        }

        public JsonResult EliminarSubTipo(int IdSubTipo)
        {
            bool Correcto = false;

            if (Session["UsuarioLogueado"] != null)
            {
                Usuario usuario = new Usuario();
                usuario = (Usuario)Session["UsuarioLogueado"];
                Correcto = LogicaNegocioMantenimientos.EliminarSubTipo(IdSubTipo);

            }


            return Json(Correcto, JsonRequestBehavior.AllowGet);
        }

        public JsonResult EliminarProducto(int IdProducto)
        {
            bool Correcto = false;
            string rutaCompleta = string.Empty;

            if (Session["UsuarioLogueado"] != null)
            {
                Usuario usuario = new Usuario();
                usuario = (Usuario)Session["UsuarioLogueado"];

                var Imagenes = ObtenerImagenesXIdProducto(IdProducto);

                Correcto = LogicaNegocioMantenimientos.EliminarProducto(IdProducto);

                if (Correcto)
                {
                    if (Imagenes.Count > 0)
                    {
                        var RutaBase = AppDomain.CurrentDomain.BaseDirectory;
                        for (int i = 0; i < Imagenes.Count; i++)
                        {
                            rutaCompleta = RutaBase + Imagenes[i].Url.ToString().Split('~')[1];
                            var Archivo = rutaCompleta + Imagenes[i].NombreImagen + Imagenes[i].Raiz;

                            if (System.IO.File.Exists(Archivo))
                            {
                                System.IO.File.Delete(Archivo);
                            }

                        }

                        if (Directory.Exists(rutaCompleta))
                        {
                            string[] files = System.IO.Directory.GetFiles(rutaCompleta);

                            if (files.Length <= 0)
                            {
                                Directory.Delete(rutaCompleta, true);
                            }
                        }

                    }

                }

            }


            return Json(Correcto, JsonRequestBehavior.AllowGet);
        }
        #endregion













    }
}