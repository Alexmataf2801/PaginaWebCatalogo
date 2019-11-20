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

$(document).ready(function () {
    ObtenerIconos();
});