function ActualizarDatosTipo(IdTipo) {
    var Tipo = {
        IdTipo: IdTipo,
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
function RedireccionarTipos() {
    location.href = '/Mantenimientos/ListaTipos/';
}

function LimpiarCampos() {
    $("#txtActCodigoTipo").val("");
    $("#txtActNombreTipo").val("");
    $("#txtActDescripcionTIpo").val("");
}
