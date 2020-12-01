using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Administracion
{
    public class AccesoDatosAdministracion
    {
        #region INSERT

        public static int InsertarUsuario(Usuario usuario, ref int Usuario)
        {
            PaginaWebCatalogosEntities entities = new PaginaWebCatalogosEntities();
            int Correcto = 0;
            ObjectParameter respuesta;
            ObjectParameter idUsuario;

            try
            {
                respuesta = new ObjectParameter("Respuesta", typeof(int));
                idUsuario = new ObjectParameter("IdUsuario", typeof(int));

                entities.paInsertarUsuario(usuario.Identificacion, usuario.Nombre, usuario.PrimerApellido, usuario.SegundoApellido, usuario.CorreoElectronico, usuario.Telefono, usuario.Direccion, usuario.Genero, usuario.UsuarioCreacion, respuesta, idUsuario);

                Correcto = Convert.ToInt32(respuesta.Value.ToString());

                if (!string.IsNullOrEmpty(idUsuario.Value.ToString()))
                {
                    Usuario = Convert.ToInt32(idUsuario.Value.ToString());
                }




            }
            catch (Exception ex)
            {
                Correcto = -1;

                throw;
            }


            return Correcto;
        }

        public static bool InsertarLogin(Login login)
        {
            PaginaWebCatalogosEntities entities = new PaginaWebCatalogosEntities();
            ObjectParameter respuesta;
            bool Correcto = false;
            try
            {
                respuesta = new ObjectParameter("respuesta", typeof(int));
                entities.paInsertarLogin(login.IdUsuario, login.Usuario, login.Contrasena, respuesta);

                if (Convert.ToInt32(respuesta.Value.ToString()) == 1)
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
        

        #endregion

        #region SELECT

        public static List<RedesSociales> ObtenerRedesSociales()
        {
            PaginaWebCatalogosEntities entities = new PaginaWebCatalogosEntities();
            List<RedesSociales> ListaRedesSociales = new List<RedesSociales>();

            try
            {
                var RedesSociales = entities.paObtenerRedesSociales();

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

        public static Empresa ObtenerInformacionEmpresa()
        {
            PaginaWebCatalogosEntities entities = new PaginaWebCatalogosEntities();
            Empresa empresa = new Empresa();

            try
            {
                var Informacion = entities.paObtenerInformacionEmpresa();

                foreach (var item in Informacion)
                {
                    empresa.IdRegistro = item.IdRegistro;
                    empresa.Nombre = item.Nombre;
                    empresa.Descripcion = item.Descripcion;
                    empresa.CorreoElectronico = item.CorreoElectronico;
                    empresa.Telefono = item.Telefono;
                    empresa.Url = item.Url;
                    empresa.NombreImagen = item.NombreImagen;
                    empresa.Raiz = item.Raiz;
                    empresa.Direccion = item.Direccion;

                }
            }
            catch (Exception ex)
            {

                throw;
            }


            return empresa;
        }

        public static bool ValidarLogin(Login login)
        {
            PaginaWebCatalogosEntities entities = new PaginaWebCatalogosEntities();
            ObjectParameter respuesta;
            bool Correcto = false;
            try
            {
                respuesta = new ObjectParameter("Correcto", typeof(int));
                entities.paValidarLogueo(login.Usuario, login.Contrasena, respuesta);

                Correcto = Convert.ToBoolean(respuesta.Value.ToString());

            }
            catch (Exception ex)
            {

                throw;
            }


            return Correcto;
        }

        public static Usuario ObtenerInfoUsuario(string Usuario)
        {
            PaginaWebCatalogosEntities entities = new PaginaWebCatalogosEntities();
            Usuario usuario = new Usuario();

            try
            {

                var info = entities.paObtenerInfoUsuario(Usuario);

                foreach (var item in info)
                {
                    usuario.IdUsuario = item.IdUsuario;
                    usuario.Identificacion = item.Identificacion;
                    usuario.Nombre = item.Nombre;
                    usuario.PrimerApellido = item.PrimerApellido;
                    usuario.SegundoApellido = item.SegundoApellido;
                    usuario.CorreoElectronico = item.CorreoElectronico;
                    usuario.Telefono = item.Telefono;
                    usuario.Direccion = item.Direccion;
                    usuario.IdPerfil = item.IdPerfil;
                    usuario.Genero = item.Genero;
                    usuario.Estado = item.Estado;

                }

            }
            catch (Exception ex)
            {

                throw;
            }


            return usuario;
        }

        public static List<Banner> ObtenerBannersActivos()
        {
            PaginaWebCatalogosEntities entities = new PaginaWebCatalogosEntities();
            List<Banner> ListaBanners = new List<Banner>();
            try
            {
                var Informacion = entities.paObtenerBannersActivos();

                foreach (var item in Informacion)
                {
                    Banner banner = new Banner();
                    banner.IdBanner = item.IdBanner;
                    banner.NombreBanner = item.Nombre;
                    banner.Raiz = item.Raiz;
                    banner.Url = item.Url;
                    banner.Titulo = item.Titulo;
                    banner.Detalle = item.Detalle;
                    banner.UsuarioCreacionBanner = item.UsuarioCreacion;
                    banner.FechaCreacionBanner = item.FechaCreacion;

                    ListaBanners.Add(banner);

                }

            }
            catch (Exception ex)
            {

                throw;
            }

            return ListaBanners;
        }

        public static List<Beneficios> ObtenerBeneficiosActivos()
        {

            PaginaWebCatalogosEntities entities = new PaginaWebCatalogosEntities();
            List<Beneficios> ListaBeneficios = new List<Beneficios>();

            try
            {
                var info = entities.paObtenerBeneficiosActivos();

                foreach (var item in info)
                {
                    Beneficios beneficio = new Beneficios();
                    beneficio.Id = item.Id;
                    beneficio.Nombre = item.Nombre;
                    beneficio.Descripcion = item.Descripcion;
                    beneficio.Icono = item.Icono;
                    beneficio.UsuarioCreacion = item.UsuarioCreacion;
                    beneficio.FechaCreacion = item.FechaCreacion;
                    beneficio.UsuarioUltimaModificacion = item.UsuarioUltimaModificacion;
                    beneficio.FechaUltimaModificacion = item.FechaUltimaModificacion;

                    ListaBeneficios.Add(beneficio);
                }

            }
            catch (Exception ex)
            {

                throw;
            }

            return ListaBeneficios;

        }
        
        #endregion

        #region UPDATE

        #endregion

        #region DELETE
       
        #endregion








    }
}
