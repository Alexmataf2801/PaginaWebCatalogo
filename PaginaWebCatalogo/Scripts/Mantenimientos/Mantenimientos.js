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
            alert("Error");
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
            alert("Error");
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
            alert("Error");
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
                alert("Correcto");
            }

        },
        error: function (Error) {
            alert("Error");
        }

    });


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
                alert("Correcto");
            }

        },
        error: function (Error) {
            alert("Error");
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
                alert("Correcto");
            }

        },
        error: function (Error) {
            alert("Error");
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
            success: function (result) {
                alert(result);
            },
            error: function (err) {
                alert(err.statusText);
            }
        });
    } else {
        alert("FormData is not supported.");
    }  

}

$(document).ready(function () {
    ObtenerIconos();
    ObtenerTipos();
    ObtenerSubTipos();
});