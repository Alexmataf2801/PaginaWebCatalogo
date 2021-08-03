using System.Web;
using System.Web.Optimization;

namespace PaginaWebCatalogo
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            //// Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            //// para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryPlantilla").Include("~/Js/Administracion/jquery.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/ManEmpresa").Include("~/Scripts/Mantenimientos/Empresa.js"));
            bundles.Add(new ScriptBundle("~/bundles/ActEmpresa").Include("~/Scripts/Mantenimientos/ActualizarDatosEmpresa.js"));
            bundles.Add(new ScriptBundle("~/bundles/ActBeneficio").Include("~/Scripts/Mantenimientos/ActualizarBeneficio.js"));
            bundles.Add(new ScriptBundle("~/bundles/ActProd").Include("~/Scripts/Mantenimientos/ActualizarDatosProducto.js"));
            bundles.Add(new ScriptBundle("~/bundles/ActSubTipo").Include("~/Scripts/Mantenimientos/ActualizarSubTipo.js"));
            bundles.Add(new ScriptBundle("~/bundles/ActTipo").Include("~/Scripts/Mantenimientos/ActualizarTipo.js"));
            bundles.Add(new ScriptBundle("~/bundles/ActRedSocial").Include("~/Scripts/Mantenimientos/ActualizarRedSocial.js"));
            bundles.Add(new ScriptBundle("~/bundles/MantBeneficio").Include("~/Scripts/Mantenimientos/Beneficio.js"));
            bundles.Add(new ScriptBundle("~/bundles/ListBene").Include("~/Scripts/Mantenimientos/ListaBeneficios.js"));
            bundles.Add(new ScriptBundle("~/bundles/ListProd").Include("~/Scripts/Mantenimientos/ListaProductos.js"));
            bundles.Add(new ScriptBundle("~/bundles/ListRedS").Include("~/Scripts/Mantenimientos/ListarRedesSociales.js"));
            bundles.Add(new ScriptBundle("~/bundles/ListSubTip").Include("~/Scripts/Mantenimientos/ListaSubTipos.js"));
            bundles.Add(new ScriptBundle("~/bundles/ListTip").Include("~/Scripts/Mantenimientos/ListaTipos.js"));
            bundles.Add(new ScriptBundle("~/bundles/Prod").Include("~/Scripts/Mantenimientos/Producto.js"));
            bundles.Add(new ScriptBundle("~/bundles/RedSocial").Include("~/Scripts/Mantenimientos/RedSocial.js"));
            bundles.Add(new ScriptBundle("~/bundles/SubTipo").Include("~/Scripts/Mantenimientos/SubTipo.js"));
            bundles.Add(new ScriptBundle("~/bundles/Tipo").Include("~/Scripts/Mantenimientos/Tipo.js"));

            BundleTable.EnableOptimizations = true;
        }
    }
}
