function ObtenerDatosProducto() {
    var Id = sessionStorage.getItem("IdProdEditar");
    $.ajax({
        type: "GET",
        dataType: "JSON",
        url: "/Mantenimientos/ObtenerProductoXId",
        data: { IdProducto: Id },
        success: function (data) {
            $("#txtActCodProd").val(data.productos.Codigo);
            $("#txtActNomProd").val(data.productos.Nombre);
            $("#txtActDescripProd").val(data.productos.Descripcion);
            $("#txtActPrecioUnitProd").val(data.productos.PrecioProducto);
            $("#ddlTipMoneda").val(data.productos.Moneda);
            ObtenerTiposProd(data.productos.TipoProducto);
            $("#ddlActTipoProdMant").val(data.productos.TipoProducto);
            var Imagenes = ObtenerImagenes(data.ListaImagenes);
            $("#ImagenesProductos").html(Imagenes);


        },
        error: function (error) {
            $("#msjError").html("Error al actualizar los datos del producto");
            $('#ModalError').modal('show');
        }
    });

}

function ObtenerTiposProd(IdTipo) {
    var Opciones = '';
    $.ajax({
        type: "GET",
        dataType: "JSON",
        data: {},
        url: "/Mantenimientos/ObtenerTipoProducto/",
        success: function (Info) {

            $.each(Info, function (key, value) {
                Opciones = Opciones + "<option value='" + value.IdTipo + "'>" + value.Nombre + "</option>";
            });

            $("#ddlActTipoProdMant").html(Opciones);
            $("#ddlActTipoProdMant").trigger("chosen:updated");
            ObtenerSubTiposProd(IdTipo);
        },
        error: function (Error) {
            $("#msjError").html("Error al obtener los tipos");
            $('#ModalError').modal('show');
        }

    });

}

function ObtenerImagenes(Imagenes) {
    var Resultado = '';

    if (Imagenes.length > 0) {
        $.each(Imagenes, function (key, value) {
            Resultado = Resultado + "<div id='" + value.IdImagen + "' class='img-wraps'>";
            Resultado = Resultado + "<a onClick='ConfirmarEliminacionImagen(" + value.IdImagen + ")'><img class='closes' src='/Content/Equis.png' /></a>";
            Resultado = Resultado + "<img id='" + value.IdImagen + "' src='" + value.Url.replace('~/', '') + value.NombreImagen + value.Raiz + "' style='max-height: 200px; max-width: 200px' />";
            Resultado = Resultado + " </div>";

        });
    } else {
        Resultado = "<label>No hay imgenes asociadas al producto</label>";
    }



    return Resultado;
}

function ObtenerSubTiposProd(IdTipo) {

    var Opciones = '';
    $.ajax({
        type: "GET",
        dataType: "JSON",
        data: { IdTipoSeleccionado: IdTipo },
        url: "/Mantenimientos/ObtenerSubTipoXTipo/",
        success: function (Info) {
            $.each(Info, function (key, value) {
                Opciones = Opciones + "<option value='" + value.IdSubTipo + "'>" + value.Nombre + "</option>";
            });

            $("#ddlActSubTipoProdMant").html(Opciones);
        },
        error: function (Error) {
            $("#msjError").html("Error al obtener los subtipos");
            $('#ModalError').modal('show');
        }

    });

}

function ConfirmarEliminacionImagen(IdImagen) {
    $("#IdImgSeleccionada").val(IdImagen);
    $("#msjInfoProd").html("¿Desea eliminar esta imagen?<br/> Si continua con la acción no se podra revertir y la imagen no se podra recuperar y deberá subir otra.");
    $('#ModalInformacionProd').modal('show');
}

function EliminarImagenActualizar() {
    var Id = $("#IdImgSeleccionada").val();

    $.ajax({
        type: "GET",
        dataType: "JSON",
        data: { IdImagen: Id },
        url: "/Mantenimientos/EliminarImagen/",
        success: function (Info) {
            if (Info) {
                $("#" + Id).remove();
                $("#msjCorrectoActProd").html("Imagen eliminada correctamente");
                $('#ModalCorrectoActProd').modal('show');
            } else {
                $("#msjError").html("No se pudo eliminar la imagen");
                $('#ModalError').modal('show');
            }
        },
        error: function (Error) {
            $("#msjError").html("Error al eliminar la imagen");
            $('#ModalError').modal('show');
        }

    });
}

$("#ddlActTipoProdMant").change(function () {

    var Id = $("#ddlActTipoProdMant").val();
    var Opciones = '';
    $.ajax({
        type: "GET",
        dataType: "JSON",
        data: { IdTipoSeleccionado: Id },
        url: "/Mantenimientos/ObtenerSubTipoXTipo/",
        success: function (Info) {

            $.each(Info, function (key, value) {
                Opciones = Opciones + "<option value='" + value.IdSubTipo + "'>" + value.Nombre + "</option>";
            });

            $("#ddlActSubTipoProdMant").html(Opciones);
        },
        error: function (Error) {
            $("#msjError").html("Error al obtener los subtipos");
            $('#ModalError').modal('show');
        }

    });
});


$(document).ready(function () {
    ObtenerDatosProducto();
});

