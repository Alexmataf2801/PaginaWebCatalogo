﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Entidades
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class PaginaWebCatalogosEntities : DbContext
    {
        public PaginaWebCatalogosEntities()
            : base("name=PaginaWebCatalogosEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
    
        public virtual ObjectResult<paObtenerTipoProductosActivos_Result> paObtenerTipoProductosActivos()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<paObtenerTipoProductosActivos_Result>("paObtenerTipoProductosActivos");
        }
    
        public virtual ObjectResult<paObtenerMenuPublicoActivo_Result> paObtenerMenuPublicoActivo()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<paObtenerMenuPublicoActivo_Result>("paObtenerMenuPublicoActivo");
        }
    
        public virtual ObjectResult<paObtenerImagenesXTipoSubtipo_Result> paObtenerImagenesXTipoSubtipo(Nullable<int> idTipoProducto, Nullable<int> idSubTipo)
        {
            var idTipoProductoParameter = idTipoProducto.HasValue ?
                new ObjectParameter("IdTipoProducto", idTipoProducto) :
                new ObjectParameter("IdTipoProducto", typeof(int));
    
            var idSubTipoParameter = idSubTipo.HasValue ?
                new ObjectParameter("IdSubTipo", idSubTipo) :
                new ObjectParameter("IdSubTipo", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<paObtenerImagenesXTipoSubtipo_Result>("paObtenerImagenesXTipoSubtipo", idTipoProductoParameter, idSubTipoParameter);
        }
    
        public virtual ObjectResult<paObtenerDetalleProducto_Result> paObtenerDetalleProducto(Nullable<int> idProducto)
        {
            var idProductoParameter = idProducto.HasValue ?
                new ObjectParameter("IdProducto", idProducto) :
                new ObjectParameter("IdProducto", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<paObtenerDetalleProducto_Result>("paObtenerDetalleProducto", idProductoParameter);
        }
    
        public virtual ObjectResult<paObtenerProductoPorTipo_Result> paObtenerProductoPorTipo(Nullable<int> idTipoProducto, Nullable<int> idSubTipo)
        {
            var idTipoProductoParameter = idTipoProducto.HasValue ?
                new ObjectParameter("IdTipoProducto", idTipoProducto) :
                new ObjectParameter("IdTipoProducto", typeof(int));
    
            var idSubTipoParameter = idSubTipo.HasValue ?
                new ObjectParameter("IdSubTipo", idSubTipo) :
                new ObjectParameter("IdSubTipo", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<paObtenerProductoPorTipo_Result>("paObtenerProductoPorTipo", idTipoProductoParameter, idSubTipoParameter);
        }
    
        public virtual ObjectResult<paObtenerProductosRandom_Result> paObtenerProductosRandom()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<paObtenerProductosRandom_Result>("paObtenerProductosRandom");
        }
    
        public virtual ObjectResult<paObtenerInformacionEmpresa_Result> paObtenerInformacionEmpresa()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<paObtenerInformacionEmpresa_Result>("paObtenerInformacionEmpresa");
        }
    
        public virtual int paInsertarUsuario(string identificacion, string nombre, string primerApellido, string segundoApellido, string correoElectronico, Nullable<int> telefono, string direccion, Nullable<bool> genero, string usuarioCreacion, ObjectParameter respuesta, ObjectParameter idUsuario)
        {
            var identificacionParameter = identificacion != null ?
                new ObjectParameter("Identificacion", identificacion) :
                new ObjectParameter("Identificacion", typeof(string));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var primerApellidoParameter = primerApellido != null ?
                new ObjectParameter("PrimerApellido", primerApellido) :
                new ObjectParameter("PrimerApellido", typeof(string));
    
            var segundoApellidoParameter = segundoApellido != null ?
                new ObjectParameter("SegundoApellido", segundoApellido) :
                new ObjectParameter("SegundoApellido", typeof(string));
    
            var correoElectronicoParameter = correoElectronico != null ?
                new ObjectParameter("CorreoElectronico", correoElectronico) :
                new ObjectParameter("CorreoElectronico", typeof(string));
    
            var telefonoParameter = telefono.HasValue ?
                new ObjectParameter("Telefono", telefono) :
                new ObjectParameter("Telefono", typeof(int));
    
            var direccionParameter = direccion != null ?
                new ObjectParameter("Direccion", direccion) :
                new ObjectParameter("Direccion", typeof(string));
    
            var generoParameter = genero.HasValue ?
                new ObjectParameter("Genero", genero) :
                new ObjectParameter("Genero", typeof(bool));
    
            var usuarioCreacionParameter = usuarioCreacion != null ?
                new ObjectParameter("UsuarioCreacion", usuarioCreacion) :
                new ObjectParameter("UsuarioCreacion", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("paInsertarUsuario", identificacionParameter, nombreParameter, primerApellidoParameter, segundoApellidoParameter, correoElectronicoParameter, telefonoParameter, direccionParameter, generoParameter, usuarioCreacionParameter, respuesta, idUsuario);
        }
    
        public virtual int paInsertarLogin(Nullable<int> idUsuario, string usuario, string contrasena, ObjectParameter respuesta)
        {
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(int));
    
            var usuarioParameter = usuario != null ?
                new ObjectParameter("Usuario", usuario) :
                new ObjectParameter("Usuario", typeof(string));
    
            var contrasenaParameter = contrasena != null ?
                new ObjectParameter("Contrasena", contrasena) :
                new ObjectParameter("Contrasena", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("paInsertarLogin", idUsuarioParameter, usuarioParameter, contrasenaParameter, respuesta);
        }
    
        public virtual int paValidarLogueo(string usuario, string contrasena, ObjectParameter correcto)
        {
            var usuarioParameter = usuario != null ?
                new ObjectParameter("Usuario", usuario) :
                new ObjectParameter("Usuario", typeof(string));
    
            var contrasenaParameter = contrasena != null ?
                new ObjectParameter("Contrasena", contrasena) :
                new ObjectParameter("Contrasena", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("paValidarLogueo", usuarioParameter, contrasenaParameter, correcto);
        }
    
        public virtual ObjectResult<paObtenerInfoUsuario_Result> paObtenerInfoUsuario(string usuario)
        {
            var usuarioParameter = usuario != null ?
                new ObjectParameter("Usuario", usuario) :
                new ObjectParameter("Usuario", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<paObtenerInfoUsuario_Result>("paObtenerInfoUsuario", usuarioParameter);
        }
    
        public virtual int paInsertarProductoCarrito(Nullable<int> idProducto, Nullable<int> idUsuario, ObjectParameter respuesta)
        {
            var idProductoParameter = idProducto.HasValue ?
                new ObjectParameter("IdProducto", idProducto) :
                new ObjectParameter("IdProducto", typeof(int));
    
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("paInsertarProductoCarrito", idProductoParameter, idUsuarioParameter, respuesta);
        }
    
        public virtual ObjectResult<paObtenerCarrito_Result> paObtenerCarrito(Nullable<int> idUsuario)
        {
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<paObtenerCarrito_Result>("paObtenerCarrito", idUsuarioParameter);
        }
    
        public virtual int paEliminarProductoCarro(Nullable<int> idProducto, Nullable<int> idUsuario)
        {
            var idProductoParameter = idProducto.HasValue ?
                new ObjectParameter("IdProducto", idProducto) :
                new ObjectParameter("IdProducto", typeof(int));
    
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("paEliminarProductoCarro", idProductoParameter, idUsuarioParameter);
        }
    
        public virtual ObjectResult<paObtenerMenuXUsuario_Result> paObtenerMenuXUsuario(Nullable<int> idUsuario)
        {
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<paObtenerMenuXUsuario_Result>("paObtenerMenuXUsuario", idUsuarioParameter);
        }
    
        public virtual ObjectResult<paObtenerIconos_Result> paObtenerIconos()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<paObtenerIconos_Result>("paObtenerIconos");
        }
    
        public virtual ObjectResult<paObtenerIconosRedes_Result> paObtenerIconosRedes()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<paObtenerIconosRedes_Result>("paObtenerIconosRedes");
        }
    
        public virtual int paInsertarRedSocial(string nombre, string descripcion, string url, string icono, string usuarioCreacion, string color, ObjectParameter respuesta)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("Descripcion", descripcion) :
                new ObjectParameter("Descripcion", typeof(string));
    
            var urlParameter = url != null ?
                new ObjectParameter("Url", url) :
                new ObjectParameter("Url", typeof(string));
    
            var iconoParameter = icono != null ?
                new ObjectParameter("Icono", icono) :
                new ObjectParameter("Icono", typeof(string));
    
            var usuarioCreacionParameter = usuarioCreacion != null ?
                new ObjectParameter("UsuarioCreacion", usuarioCreacion) :
                new ObjectParameter("UsuarioCreacion", typeof(string));
    
            var colorParameter = color != null ?
                new ObjectParameter("Color", color) :
                new ObjectParameter("Color", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("paInsertarRedSocial", nombreParameter, descripcionParameter, urlParameter, iconoParameter, usuarioCreacionParameter, colorParameter, respuesta);
        }
    
        public virtual ObjectResult<paObtenerRedesSociales_Result> paObtenerRedesSociales()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<paObtenerRedesSociales_Result>("paObtenerRedesSociales");
        }
    
        public virtual int paInsertarTipoProducto(string codigo, string nombre, string descripcion, string usuarioCreacion, ObjectParameter respuesta)
        {
            var codigoParameter = codigo != null ?
                new ObjectParameter("Codigo", codigo) :
                new ObjectParameter("Codigo", typeof(string));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("Descripcion", descripcion) :
                new ObjectParameter("Descripcion", typeof(string));
    
            var usuarioCreacionParameter = usuarioCreacion != null ?
                new ObjectParameter("UsuarioCreacion", usuarioCreacion) :
                new ObjectParameter("UsuarioCreacion", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("paInsertarTipoProducto", codigoParameter, nombreParameter, descripcionParameter, usuarioCreacionParameter, respuesta);
        }
    
        public virtual ObjectResult<paObtenerTipoProductoActivo_Result> paObtenerTipoProductoActivo()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<paObtenerTipoProductoActivo_Result>("paObtenerTipoProductoActivo");
        }
    
        public virtual int paInsertarRelacionTipoSubTipo(Nullable<int> idTipo, Nullable<int> idSubTipo)
        {
            var idTipoParameter = idTipo.HasValue ?
                new ObjectParameter("IdTipo", idTipo) :
                new ObjectParameter("IdTipo", typeof(int));
    
            var idSubTipoParameter = idSubTipo.HasValue ?
                new ObjectParameter("IdSubTipo", idSubTipo) :
                new ObjectParameter("IdSubTipo", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("paInsertarRelacionTipoSubTipo", idTipoParameter, idSubTipoParameter);
        }
    
        public virtual int paInsertarSubTipoProducto(string codigo, string nombre, string descripcion, string usuarioCreacion, ObjectParameter respuesta, ObjectParameter idSubTipo)
        {
            var codigoParameter = codigo != null ?
                new ObjectParameter("Codigo", codigo) :
                new ObjectParameter("Codigo", typeof(string));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("Descripcion", descripcion) :
                new ObjectParameter("Descripcion", typeof(string));
    
            var usuarioCreacionParameter = usuarioCreacion != null ?
                new ObjectParameter("UsuarioCreacion", usuarioCreacion) :
                new ObjectParameter("UsuarioCreacion", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("paInsertarSubTipoProducto", codigoParameter, nombreParameter, descripcionParameter, usuarioCreacionParameter, respuesta, idSubTipo);
        }
    
        public virtual int paInsertarMenuPublico(Nullable<int> idTipo, Nullable<int> idSubTipo)
        {
            var idTipoParameter = idTipo.HasValue ?
                new ObjectParameter("IdTipo", idTipo) :
                new ObjectParameter("IdTipo", typeof(int));
    
            var idSubTipoParameter = idSubTipo.HasValue ?
                new ObjectParameter("IdSubTipo", idSubTipo) :
                new ObjectParameter("IdSubTipo", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("paInsertarMenuPublico", idTipoParameter, idSubTipoParameter);
        }
    
        public virtual ObjectResult<paObtenerSubTipoProdActivo_Result> paObtenerSubTipoProdActivo()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<paObtenerSubTipoProdActivo_Result>("paObtenerSubTipoProdActivo");
        }
    
        public virtual int paInsertarImagen(string nombre, string raiz, string url, string usuarioCreacion, ObjectParameter idImagen)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var raizParameter = raiz != null ?
                new ObjectParameter("Raiz", raiz) :
                new ObjectParameter("Raiz", typeof(string));
    
            var urlParameter = url != null ?
                new ObjectParameter("Url", url) :
                new ObjectParameter("Url", typeof(string));
    
            var usuarioCreacionParameter = usuarioCreacion != null ?
                new ObjectParameter("UsuarioCreacion", usuarioCreacion) :
                new ObjectParameter("UsuarioCreacion", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("paInsertarImagen", nombreParameter, raizParameter, urlParameter, usuarioCreacionParameter, idImagen);
        }
    
        public virtual int paInsertarProducto(string codigo, string nombre, string descripcion, string moneda, Nullable<decimal> precioProducto, Nullable<int> tipoProducto, Nullable<int> subTipo, string usuarioCreacion, ObjectParameter idProducto)
        {
            var codigoParameter = codigo != null ?
                new ObjectParameter("Codigo", codigo) :
                new ObjectParameter("Codigo", typeof(string));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("Descripcion", descripcion) :
                new ObjectParameter("Descripcion", typeof(string));
    
            var monedaParameter = moneda != null ?
                new ObjectParameter("Moneda", moneda) :
                new ObjectParameter("Moneda", typeof(string));
    
            var precioProductoParameter = precioProducto.HasValue ?
                new ObjectParameter("PrecioProducto", precioProducto) :
                new ObjectParameter("PrecioProducto", typeof(decimal));
    
            var tipoProductoParameter = tipoProducto.HasValue ?
                new ObjectParameter("TipoProducto", tipoProducto) :
                new ObjectParameter("TipoProducto", typeof(int));
    
            var subTipoParameter = subTipo.HasValue ?
                new ObjectParameter("SubTipo", subTipo) :
                new ObjectParameter("SubTipo", typeof(int));
    
            var usuarioCreacionParameter = usuarioCreacion != null ?
                new ObjectParameter("UsuarioCreacion", usuarioCreacion) :
                new ObjectParameter("UsuarioCreacion", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("paInsertarProducto", codigoParameter, nombreParameter, descripcionParameter, monedaParameter, precioProductoParameter, tipoProductoParameter, subTipoParameter, usuarioCreacionParameter, idProducto);
        }
    
        public virtual int paInsertarRelacionImagenProducto(Nullable<int> idProducto, Nullable<int> idImagen, Nullable<int> idUsuario, ObjectParameter idRelacion)
        {
            var idProductoParameter = idProducto.HasValue ?
                new ObjectParameter("IdProducto", idProducto) :
                new ObjectParameter("IdProducto", typeof(int));
    
            var idImagenParameter = idImagen.HasValue ?
                new ObjectParameter("IdImagen", idImagen) :
                new ObjectParameter("IdImagen", typeof(int));
    
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("paInsertarRelacionImagenProducto", idProductoParameter, idImagenParameter, idUsuarioParameter, idRelacion);
        }
    
        public virtual int paActualizarRedSocial(Nullable<int> idRedSocial, string nombre, string descripcion, string url, string icono, string color, string usuarioUltimaModificacion)
        {
            var idRedSocialParameter = idRedSocial.HasValue ?
                new ObjectParameter("IdRedSocial", idRedSocial) :
                new ObjectParameter("IdRedSocial", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("Descripcion", descripcion) :
                new ObjectParameter("Descripcion", typeof(string));
    
            var urlParameter = url != null ?
                new ObjectParameter("Url", url) :
                new ObjectParameter("Url", typeof(string));
    
            var iconoParameter = icono != null ?
                new ObjectParameter("Icono", icono) :
                new ObjectParameter("Icono", typeof(string));
    
            var colorParameter = color != null ?
                new ObjectParameter("Color", color) :
                new ObjectParameter("Color", typeof(string));
    
            var usuarioUltimaModificacionParameter = usuarioUltimaModificacion != null ?
                new ObjectParameter("UsuarioUltimaModificacion", usuarioUltimaModificacion) :
                new ObjectParameter("UsuarioUltimaModificacion", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("paActualizarRedSocial", idRedSocialParameter, nombreParameter, descripcionParameter, urlParameter, iconoParameter, colorParameter, usuarioUltimaModificacionParameter);
        }
    
        public virtual ObjectResult<paObtenerRedSocial_Result> paObtenerRedSocial(Nullable<int> idRedSocial)
        {
            var idRedSocialParameter = idRedSocial.HasValue ?
                new ObjectParameter("IdRedSocial", idRedSocial) :
                new ObjectParameter("IdRedSocial", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<paObtenerRedSocial_Result>("paObtenerRedSocial", idRedSocialParameter);
        }
    
        public virtual ObjectResult<paObtenerTodasRedesSociales_Result> paObtenerTodasRedesSociales()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<paObtenerTodasRedesSociales_Result>("paObtenerTodasRedesSociales");
        }
    }
}
