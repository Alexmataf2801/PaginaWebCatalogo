﻿using AccesoDatos.Mantenimientos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Mantenimientos
{
    public class LogicaNegocioMantenimientos
    {

        #region INSERT 

        public static bool InsertarRedSocial(RedesSociales redSocial)
        {

            return AccesoDatosMantenimientos.InsertarRedSocial(redSocial);
        }

        public static bool InsertarTipoProducto(TipoProducto tipo)
        {

            return AccesoDatosMantenimientos.InsertarTipoProducto(tipo);
        }

        public static bool InsertarSubTipoProducto(SubTipoProducto subTipo, ref int IdSubTipoRef)
        {

            return AccesoDatosMantenimientos.InsertarSubTipoProducto(subTipo, ref IdSubTipoRef);
        }

        public static bool InsertarSubTipoTipoRelacion(SubTipoProducto subTipo)
        {

            return AccesoDatosMantenimientos.InsertarSubTipoTipoRelacion(subTipo);
        }

        public static bool InsertarMenuPublico(SubTipoProducto subTipo)
        {

            return AccesoDatosMantenimientos.InsertarMenuPublico(subTipo);
        }

        public static int InsertarProducto(Productos productos)
        {

            return AccesoDatosMantenimientos.InsertarProducto(productos);
        }

        public static int InsertarImagen(ImagenesProducto Imagen)
        {

            return AccesoDatosMantenimientos.InsertarImagen(Imagen);
        }

        public static int InsertarRelacionImagenProd(ImagenesProducto Imagen)
        {

            return AccesoDatosMantenimientos.InsertarRelacionImagenProd(Imagen);
        }

        public static int InsertarEmpresa(Empresa empresa, string Raiz)
        {

            return AccesoDatosMantenimientos.InsertarEmpresa(empresa, Raiz);
        }

        public static bool InsertarBeneficios(Beneficios beneficios)
        {

            return AccesoDatosMantenimientos.InsertarBeneficios(beneficios);
        }
        public static bool InsertarBanner(Banner banner)
        {

            return AccesoDatosMantenimientos.InsertarBanner(banner);
        }
        #endregion

        #region SELECT 

        public static List<Icono> ObtenerIconos()
        {

            return AccesoDatosMantenimientos.ObtenerIconos();
        }

        public static List<Icono> ObtenerIconosRedes()
        {

            return AccesoDatosMantenimientos.ObtenerIconosRedes();
        }

        public static List<TipoProducto> ObtenerTipoProducto()
        {

            return AccesoDatosMantenimientos.ObtenerTipoProducto();
        }

        public static List<SubTipoProducto> ObtenerSubTipoProducto()
        {

            return AccesoDatosMantenimientos.ObtenerSubTipoProducto();
        }
        public static List<SubTipoProducto> ObtenerSubTipoProductoXTipo(int IdTipo)
        {

            return AccesoDatosMantenimientos.ObtenerSubTipoProductoXTipo(IdTipo);
        }

        public static RedesSociales ObtenerRedSocial(int IdRedSocial)
        {

            return AccesoDatosMantenimientos.ObtenerRedSocial(IdRedSocial);
        }

        public static List<RedesSociales> ObtenerTodasRedesSociales()
        {

            return AccesoDatosMantenimientos.ObtenerTodasRedesSociales();
        }

        public static List<TipoProducto> ObtenerTodosTiposProducto()
        {

            return AccesoDatosMantenimientos.ObtenerTodosTiposProducto();
        }

        public static List<SubTipoProducto> ObtenerTodosSubTiposProducto()
        {

            return AccesoDatosMantenimientos.ObtenerTodosSubTiposProducto();
        }

        public static List<Productos> ObtenerTodosProductos()
        {

            return AccesoDatosMantenimientos.ObtenerTodosProductos();
        }

        public static TipoProducto ObtenerTipoXId(int IdTipo)
        {

            return AccesoDatosMantenimientos.ObtenerTipoXId(IdTipo);
        }

        public static SubTipoProducto ObtenerSubTipoXId(int IdSubTipo)
        {

            return AccesoDatosMantenimientos.ObtenerSubTipoXId(IdSubTipo);
        }

        public static List<ImagenesProducto> ObtenerImagenesXIdProducto(int IdProducto)
        {

            return AccesoDatosMantenimientos.ObtenerImagenesXIdProducto(IdProducto);
        }

        public static Productos ObtenerProductoXId(int IdProducto)
        {

            return AccesoDatosMantenimientos.ObtenerProductoXId(IdProducto);
        }

        public static ImagenesProducto ObtenerImagenXId(int IdImagen)
        {

            return AccesoDatosMantenimientos.ObtenerImagenXId(IdImagen);
        }

        public static Imagen ObtenerRutaImagen(int IdImagen)
        {

            return AccesoDatosMantenimientos.ObtenerRutaImagen(IdImagen);
        }
        public static List<Beneficios> ObtenerTodosLosBeneficios()
        {

            return AccesoDatosMantenimientos.ObtenerTodosLosBeneficios();
        }

        public static Beneficios ObtenerBeneficioXId(int IdBeneficio)
        {

            return AccesoDatosMantenimientos.ObtenerBeneficioXId(IdBeneficio);
        }
        #endregion

        #region UPDATE 

        public static bool DesactivarActivarRedSocial(int IdRedSocial, bool Estado)
        {

            return AccesoDatosMantenimientos.DesactivarActivarRedSocial(IdRedSocial, Estado);
        }

        public static bool DesactivarActivarProducto(int IdProducto, bool Estado)
        {

            return AccesoDatosMantenimientos.DesactivarActivarProducto(IdProducto, Estado);
        }

        public static bool DesactivarActivarSubTipo(int IdSubTipo, bool Estado)
        {

            return AccesoDatosMantenimientos.DesactivarActivarSubTipo(IdSubTipo, Estado);
        }

        public static bool DesactivarActivarTipo(int IdTipo, bool Estado)
        {

            return AccesoDatosMantenimientos.DesactivarActivarTipo(IdTipo, Estado);
        }

        public static bool DesactivarActivarBeneficio(int IdBeneficio, bool Estado)
        {

            return AccesoDatosMantenimientos.DesactivarActivarBeneficio(IdBeneficio, Estado);
        }

        public static bool ActualizarInfoEmpresa(Empresa empresa)
        {

            return AccesoDatosMantenimientos.ActualizarInfoEmpresa(empresa);
        }

        public static bool ActualizarTipo(TipoProducto tipo)
        {

            return AccesoDatosMantenimientos.ActualizarTipo(tipo);
        }

        public static bool ActualizarSubTipo(SubTipoProducto SubTipo)
        {

            return AccesoDatosMantenimientos.ActualizarSubTipo(SubTipo);
        }

        public static bool ActualizarProducto(Productos productos)
        {

            return AccesoDatosMantenimientos.ActualizarProducto(productos);
        }

        public static bool ActualizarRedSocial(RedesSociales redSocial)
        {

            return AccesoDatosMantenimientos.ActualizarRedSocial(redSocial);
        }

        public static bool ActualizarBeneficio(Beneficios beneficio)
        {

            return AccesoDatosMantenimientos.ActualizarBeneficio(beneficio);
        }
        #endregion

        #region DELETE 

        public static bool EliminarRedSocial(int IdRedSocial)
        {

            return AccesoDatosMantenimientos.EliminarRedSocial(IdRedSocial);
        }

        public static bool EliminarTipo(int IdTipo, ref string DescTipo)
        {

            return AccesoDatosMantenimientos.EliminarTipo(IdTipo, ref DescTipo);
        }

        public static bool EliminarSubTipo(int IdSubTipo)
        {

            return AccesoDatosMantenimientos.EliminarSubTipo(IdSubTipo);
        }

        public static bool EliminarProducto(int IdProducto)
        {

            return AccesoDatosMantenimientos.EliminarProducto(IdProducto);
        }

        public static bool EliminarImagenXId(int IdImagen)
        {

            return AccesoDatosMantenimientos.EliminarImagenXId(IdImagen);
        }

        public static bool EliminarBeneficioXId(int IdBeneficio)
        {

            return AccesoDatosMantenimientos.EliminarBeneficioXId(IdBeneficio);
        }
        #endregion









    }
}
