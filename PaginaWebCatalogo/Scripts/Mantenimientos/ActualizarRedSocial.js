function ObtenerDatosRedSocial() {
    var Id = sessionStorage.getItem("IdRedSocial");
    $.ajax({
        type: "GET",
        dataType: "JSON",
        url: "/Mantenimientos/ObtenerRedSocial",
        data: { RedSocial: Id },
        success: function (data) {
            ObtenerIconos();
            $("#txtNombreRedAct").val(data.Nombre);
            $("#txtDescripcionRedAct").val(data.Descripcion);
            $("#txtUrlRedAct").val(data.Url);
            sessionStorage.setItem("IdIcono", data.Icono);
            $("#txtColorAct").val(data.Color);

        },
        error: function (error) {
            $("#msjError").html("Error al obtener la información de la red social");
            $('#ModalError').modal('show');
        }
    });
}

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

            $("#ddlIconoRed").html(Opciones);
            $("#ddlIconoRed").val(sessionStorage.getItem("IdIcono"));
            
        },
        error: function (Error) {
            $("#msjError").html("Error al obtener los Iconos");
            $('#ModalError').modal('show');
        }

    });
}

function ActualizarRedes() {
    var Id = sessionStorage.getItem("IdRedSocial");
    var redSocial = {
        IdRedSocial: Id,
        Nombre: $("#txtNombreRedAct").val(),
        Descripcion: $("#txtDescripcionRedAct").val(),
        Url: $("#txtUrlRedAct").val(),
        Icono: $("#ddlIconoRed").val(),
        Color: $("#txtColorAct").val()
    };

    $.ajax({
        type: "POST",
        dataType: "JSON",
        data: { redesSociales: redSocial },
        url: "/Mantenimientos/ActualizarRedesSociales/",
        success: function (Info) {
            if (Info) {
                $("#msjCorrectoActRed").html("Información actualizada correctamente");
                $('#ModalCorrectoRed').modal('show');
            }
        },
        error: function (Error) {
            $("#msjError").html("Error al actualizar la red social");
            $('#ModalError').modal('show');
        }

    });

}

function RedireccionarRedes() {
    location.href = '/Mantenimientos/ListarRedes/';
}


$(document).ready(function () {
    ObtenerDatosRedSocial();
});
