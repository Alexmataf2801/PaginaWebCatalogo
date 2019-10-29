using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AccesoDatos.Menu
{
    public class AccesoDatosMenu
    {

        #region INSERT 
        #endregion

        #region SELECT 

        public static List<MenuPublico> ObtenerMenuPublico()
        {
            PaginaWebCatalogosEntities entities = new PaginaWebCatalogosEntities();
            List<MenuPublico> ListaMenuPublico = new List<MenuPublico>();

            try
            {
                var MenuPublicoActivo = entities.paObtenerMenuPublicoActivo();

                foreach (var item in MenuPublicoActivo)
                {
                    MenuPublico menuPublico = new MenuPublico();
                    menuPublico.IdMenu = item.IdMenu;
                    menuPublico.Nombre = item.Nombre;
                    menuPublico.IdPadre = item.IdPadre;
                    menuPublico.Estado = item.Estado;
                    menuPublico.IsPadre = item.IsPadre;
                    menuPublico.Url = item.Url;
                    menuPublico.TipoProducto = item.TipoProducto;
                    menuPublico.SubTipo = item.SubTipo;

                    ListaMenuPublico.Add(menuPublico);
                }
            }
            catch (Exception ex)
            {

                throw;
            }


            return ListaMenuPublico;
        }

        public static List<MenuAdministracion> ObtenerMenuAdministracion(int IdUsuario)
        {
            PaginaWebCatalogosEntities entities = new PaginaWebCatalogosEntities();
            List<MenuAdministracion> ListaMenuAdministracion = new List<MenuAdministracion>();

            try
            {
                var MenuAdministracion = entities.paObtenerMenuXUsuario(IdUsuario);

                foreach (var item in MenuAdministracion)
                {
                    MenuAdministracion menuAdministracion = new MenuAdministracion();
                    menuAdministracion.IdMenu = item.IdMenu.ToString();
                    menuAdministracion.Nombre = item.Nombre;
                    menuAdministracion.Icono = item.Icono;
                    menuAdministracion.IdPadre = item.IdPadre;
                    menuAdministracion.IdHijo = item.IdHijo;
                    menuAdministracion.Nivel = item.Nivel;
                    menuAdministracion.Orden = item.Orden;
                    menuAdministracion.Estado = item.Estado;
                    menuAdministracion.IsPadre = item.IsPadre.ToString();
                    menuAdministracion.Url = item.Url;



                    ListaMenuAdministracion.Add(menuAdministracion);
                }
            }
            catch (Exception ex)
            {

                throw;
            }


            return ListaMenuAdministracion;
        }

        #endregion

        #region UPDATE
        #endregion

        #region DELETE
        #endregion



    }
}
