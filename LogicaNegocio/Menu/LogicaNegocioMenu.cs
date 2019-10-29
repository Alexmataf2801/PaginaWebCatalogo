using AccesoDatos.Menu;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LogicaNegocio.Menu
{
    public class LogicaNegocioMenu
    {

        #region INSERT
        #endregion

        #region SELECT

        public static List<MenuPublico> ObtenerMenuPublico()
        {

            return AccesoDatosMenu.ObtenerMenuPublico();
        }

        public static List<MenuAdministracion> ObtenerMenuAdministracion(int IdUsuario)
        {

            return AccesoDatosMenu.ObtenerMenuAdministracion(IdUsuario);
        }

        #endregion

        #region UPDATE
        #endregion

        #region DELETE
        #endregion



    }
}
