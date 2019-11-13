function ActualizarDatosTipo(IdTipo) {
    var Tipo = {
        IdTipo: IdTipo,
        Codigo: $("#txtActCodigoTipo").val(),
        Nombre: $("#txtActNombreTipo").val(),
        Descripcion: $("#txtActDescripcionTIpo").val()
    };
    console.log(Tipo);
    $.ajax({
        type: "POST",
        datatype: "JSON",
        url: "/Mantenimientos/ActualizarTipo/",
        data: { InfoTipo : Tipo },
        success: function (Info) {
            if (Info) {
                $("#msjCorrecto").html("Tipo actualizado con exito");
                $('#ModalCorrecto').modal('show');
                LimpiarCampos();
            }
        },
        error: function (Error) {
            $("#msjError").html("Error al actualizar el tipo");
            $('#ModalError').modal('show');
        }

    });

}

function LimpiarCampos() {
    $("#txtActCodigoTipo").val("");
    $("#txtActNombreTipo").val("");
    $("#txtActDescripcionTIpo").val("");
}
