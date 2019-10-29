using AccesoDatos.Administracion;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LogicaNegocio.Administracion
{
    public class LogicaNegocioAdministracion
    {

        #region INSERT

        public static int InsertarUsuario(Usuario usuario)
        {
            int UsuarioId = 0;
            int respuesta = AccesoDatosAdministracion.InsertarUsuario(usuario, ref UsuarioId);
            Utilerias.Utilerias utilerias = new Utilerias.Utilerias();

            if (respuesta == 1)
            {

                Login login = new Login();
                login.IdUsuario = UsuarioId;
                login.Usuario = usuario.Identificacion;
                login.Contrasena = Utilerias.Utilerias.GenerarPassword(10);

                bool Correcto = AccesoDatosAdministracion.InsertarLogin(login);

                if (Correcto)
                {
                    respuesta = 1;
                }
                else
                {
                    respuesta = -1;
                }

            }

            return respuesta;
        }

        #endregion


        #region SELECT

        public static List<RedesSociales> ObtenerRedesSociales()
        {

            return AccesoDatosAdministracion.ObtenerRedesSociales();
        }

        public static Empresa ObtenerInformacionEmpresa()
        {

            return AccesoDatosAdministracion.ObtenerInformacionEmpresa();
        }

        public static bool ValidarLogin(Login login, ref Usuario usuario)
        {
            bool Correcto = AccesoDatosAdministracion.ValidarLogin(login);
            if (Correcto)
            {

                usuario = AccesoDatosAdministracion.ObtenerInfoUsuario(login.Usuario);

            }


            return Correcto;
        }

        #endregion


        #region UPDATE
        #endregion


        #region DELETE
        #endregion








    }
}
