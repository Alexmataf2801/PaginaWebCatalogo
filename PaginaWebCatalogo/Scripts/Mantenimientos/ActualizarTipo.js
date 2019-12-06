function ActualizarDatosTipo() {
    var Id = sessionStorage.getItem("IdTipo");
    var Tipo = {
        IdTipo: Id,
        Codigo: $("#txtActCodigoTipo").val(),
        Nombre: $("#txtActNombreTipo").val(),
        Descripcion: $("#txtActDescripcionTIpo").val()
    };
    $.ajax({
        type: "POST",
        datatype: "JSON",
        url: "/Mantenimientos/ActualizarTipo/",
        data: { InfoTipo : Tipo },
        success: function (Info) {
            if (Info) {
                $("#msjCorrectoActTipo").html("Tipo actualizado con exito");
                $('#ModalCorrectoActTipo').modal('show');
                LimpiarCampos();
                
            }
        },
        error: function (Error) {
            $("#msjError").html("Error al actualizar el tipo");
            $('#ModalError').modal('show');
        }

    });

}

function ObtenerDatosTipo() {
    var Id = sessionStorage.getItem("IdTipo");
    $.ajax({
        type: "POST",
        datatype: "JSON",
        url: "/Mantenimientos/ObtenerInfoTipo/",
        data: { IdTipoSeleccionado: Id },
        success: function (Info) {
            if (Info) {
                $("#txtActCodigoTipo").val(Info.Codigo);
                $("#txtActNombreTipo").val(Info.Nombre);
                $("#txtActDescripcionTIpo").val(Info.Descripcion);

            }
        },
        error: function (Error) {
            $("#msjError").html("Error al actualizar el SubTipo");
            $('#ModalError').modal('show');
        }

    });


}


function RedireccionarTipos() {
    location.href = '/Mantenimientos/ListaTipos/';
}

function LimpiarCampos() {
    $("#txtActCodigoTipo").val("");
    $("#txtActNombreTipo").val("");
    $("#txtActDescripcionTIpo").val("");
}


$(document).ready(function () {
    ObtenerDatosTipo();
});