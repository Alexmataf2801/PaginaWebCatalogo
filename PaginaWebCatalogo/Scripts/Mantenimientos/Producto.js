function ObtenerTiposProd() {
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

            $("#ddlTipoProdMant").html(Opciones);
            $("#ddlTipoProdMant").trigger("chosen:updated");
            ObtenerSubTiposProd();
        },
        error: function (Error) {
            $("#msjError").html("Error al obtener los tipos");
            $('#ModalError').modal('show');
        }

    });
   
}
function ObtenerSubTiposProd() {

    var Id = $("#ddlTipoProdMant").val();
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

            $("#ddlSubTipoProdMant").html(Opciones);
        },
        error: function (Error) {
            $("#msjError").html("Error al obtener los subtipos");
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

$("#ddlTipoProdMant").change(function () {

    var Id = $("#ddlTipoProdMant").val();
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

            $("#ddlSubTipoProdMant").html(Opciones);
        },
        error: function (Error) {
            $("#msjError").html("Error al obtener los subtipos");
            $('#ModalError').modal('show');
        }

    });
});


$(document).ready(function () {
    ObtenerTiposProd();
});