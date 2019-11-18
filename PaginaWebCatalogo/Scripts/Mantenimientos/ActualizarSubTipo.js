function ActualizarDatosTipo(IdSubTipo) {
    var SubTipo = {
        IdSubTipo: IdSubTipo,
        Codigo: $("#txtCodigoSubTipoAct").val(),
        Nombre: $("#txtNombreSubTipoAct").val(),
        Descripcion: $("#txtDescripcionSubTipoAct").val(),
        IdTipo: $("#ddlTipoProd").val()
    };
    $.ajax({
        type: "POST",
        datatype: "JSON",
        url: "/Mantenimientos/ActualizarSubTipo/",
        data: { InfoSubTipo: SubTipo },
        success: function (Info) {
            if (Info) {
                $("#msjCorrectoActSubTipo").html("SubTipo actualizado con exito");
                $('#ModalCorrectoActSubTipo').modal('show');
                LimpiarCampos();
            }
        },
        error: function (Error) {
            $("#msjError").html("Error al actualizar el SubTipo");
            $('#ModalError').modal('show');
        }

    });

}

function RedireccionarSubTipos() {
    location.href = '/Mantenimientos/ListaSubTipos/';
}

function LimpiarCampos() {
    $("#txtCodigoSubTipoAct").val("");
    $("#txtNombreSubTipoAct").val("");
    $("#txtDescripcionSubTipoAct").val("");
}
