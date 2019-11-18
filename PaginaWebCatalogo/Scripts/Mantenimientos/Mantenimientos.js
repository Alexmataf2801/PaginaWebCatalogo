function ObtenerIconos() {
    var Opciones = '';
    $.ajax({
        type: "GET",
        dataType: "JSON",
        data: {},
        url: "/Mantenimientos/ObtenerIconosRedes/",
        success: function (Info) {

            $.each(Info, function (key, value) {
                Opciones = Opciones + "<option value='" + value.Nombre + "'>" + value.Codigo + "</option>";
            });

            $("#Iconos").html(Opciones);
        },
        error: function (Error) {
            $("#msjError").html("Error al obtener los Iconos");
            $('#ModalError').modal('show');
        }

    });
}
function ObtenerTipos() {
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

            $("#ddlTipoProd").html(Opciones);
            $("#ddlTipoProdMant").html(Opciones);
        },
        error: function (Error) {
            $("#msjError").html("Error al obtener los tipos");
            $('#ModalError').modal('show');
        }

    });
}
function ObtenerSubTipos() {
    var Opciones = '';
    $.ajax({
        type: "GET",
        dataType: "JSON",
        data: {},
        url: "/Mantenimientos/ObtenerSubTipoProducto/",
        success: function (Info) {

            $.each(Info, function (key, value) {
                Opciones = Opciones + "<option value='" + value.IdSubTipo + "'>" + value.Nombre + "</option>";
            });

            $("#ddlSubTipoProdMant").html(Opciones);
        },
        error: function (Error) {
            $("#msjError").html("Error al obtener los subtipos");
            $('#ModalError').modal('show');
        }

    });
}


function GuardarRedSocial() {

    var redSocial = {
        Nombre: $("#txtNombreRed").val(),
        Descripcion: $("#txtDescripcionRed").val(),
        Url: $("#txtUrlRed").val(),
        Icono: $("#Iconos").val(),
        Color: $("#txtColor").val()

    };

    $.ajax({
        type: "POST",
        dataType: "JSON",
        url: "/Mantenimientos/InsertarRedSocial/",
        data: { redSocial },
        success: function (Info) {
            if (Info) {
                LimpiarRedSocial();
                $("#msjCorrecto").html("Red Social agregada con exito");
                $('#ModalCorrecto').modal('show');
            }

        },
        error: function (Error) {
            $("#msjError").html("Error al guardar red social");
            $('#ModalError').modal('show');
        }

    });


}

function LimpiarRedSocial() {
    $("#txtNombreRed").val("");
    $("#txtDescripcionRed").val("");
    $("#txtUrlRed").val("");
    $("#txtColor").val("");

}

function LimpiarTipo() {
    $("#txtCodigoTipo").val("");
    $("#txtNombreTipo").val("");
    $("#txtDescripcionTIpo").val("");
}

function GuardarTipoProducto() {

    var tipo = {
        Codigo: $("#txtCodigoTipo").val(),
        Nombre: $("#txtNombreTipo").val(),
        Descripcion: $("#txtDescripcionTIpo").val()

    };

    $.ajax({
        type: "POST",
        dataType: "JSON",
        url: "/Mantenimientos/InsertarTipoProducto/",
        data: { tipo },
        success: function (Info) {

            if (Info) {
                LimpiarTipo();
                $("#msjCorrecto").html("Tipo agregado con exito");
                $('#ModalCorrecto').modal('show');
            }

        },
        error: function (Error) {
            $("#msjError").html("Error al guardar el tipo de producto");
            $('#ModalError').modal('show');
        }

    });


}


function GuardarSubTipoProducto() {

    var subTipo = {
        Codigo: $("#txtCodigoSubTipo").val(),
        Nombre: $("#txtNombreSubTipo").val(),
        Descripcion: $("#txtDescripcionSubTipo").val(),
        IdTipo: $("#ddlTipoProd").val()
    };

    $.ajax({
        type: "POST",
        dataType: "JSON",
        url: "/Mantenimientos/InsertarSubTipoProducto/",
        data: { subTipo },
        success: function (Info) {

            if (Info) {
                $("#msjCorrecto").html("SubTipo agregado con exito");
                $('#ModalCorrecto').modal('show');
            }

        },
        error: function (Error) {
            $("#msjError").html("Error al guardar el subtipo de producto");
            $('#ModalError').modal('show');
        }

    });


}
function GuardarProducto() {

    // Checking whether FormData is available in browser  
    if (window.FormData !== undefined) {


        var fileUpload = $("#Imagenes").get(0);

        var files = fileUpload.files;

        // Create FormData object  
        var fileData = new FormData();

        // Looping over all files and add it to FormData object  
        for (var i = 0; i < files.length; i++) {
            fileData.append(files[i].name, files[i]);
        }

        fileData.append('Codigo', $("#txtCodProd").val());
        fileData.append('Nombre', $("#txtNomProd").val());
        fileData.append('Descripcion', $("#txtDescripProd").val());
        fileData.append('Moneda', $("#ddlTipMoneda").val());
        fileData.append('Precio', $("#txtPrecioUnitProd").val());
        fileData.append('TipoProd', $("#ddlTipoProdMant").val());
        fileData.append('SubTipo', $("#ddlSubTipoProdMant").val());
        fileData.append('TextoTipo', $("#ddlTipoProdMant option:selected").text());
        fileData.append('TextoSubTipo', $("#ddlSubTipoProdMant option:selected").text());


        $.ajax({
            url: '/Mantenimientos/InsertarProducto',
            type: "POST",
            contentType: false, // Not to set any content header  
            processData: false, // Not to process data  
            data: fileData,
            success: function (Info) {

                if (Info) {
                    $("#msjCorrectoAgrProd").html("Producto agregado con exito");
                    $('#ModalCorrectoAgrProd').modal('show');
                } else {
                    $("#msjError").html("No se pudo insertar el producto o no adjunto ninguna imagen.");
                    $('#ModalError').modal('show');
                }

            },
            error: function (Error) {
                $("#msjError").html("Error al guardar producto");
                $('#ModalError').modal('show');
            }
        });
    } else {
        $("#msjError").html("Error al ejecutar la accion solicitada");
        $('#ModalError').modal('show');
    }

}
function RedireccionarProd() {
    location.href = '/Mantenimientos/ListaProductos/';
}

$(document).ready(function () {
    ObtenerIconos();
    ObtenerTipos();
    ObtenerSubTipos();
});