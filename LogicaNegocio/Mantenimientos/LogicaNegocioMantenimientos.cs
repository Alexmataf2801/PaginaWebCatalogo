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

        #endregion

        #region UPDATE 
        #endregion

        #region DELETE 
        #endregion









    }
}
