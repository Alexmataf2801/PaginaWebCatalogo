function ActualizarDatosTipo(IdSubTipo) {
    var Id = sessionStorage.getItem("IdSubTipoEditar");
    var SubTipo = {
        IdSubTipo: Id,
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

function ObtenerDatosSubtipo() {
    var Id = sessionStorage.getItem("IdSubTipoEditar");
    $.ajax({
        type: "POST",
        datatype: "JSON",
        url: "/Mantenimientos/ObtenerSubTipoXId/",
        data: { IdSubTipoSeleccionado: Id },
        success: function (Info) {
            if (Info) {
                $("#txtCodigoSubTipoAct").val(Info.Codigo);
                $("#txtNombreSubTipoAct").val(Info.Nombre);
                $("#txtDescripcionSubTipoAct").val(Info.Descripcion);
                ObtenerTipos(Info.IdTipo);

            }
        },
        error: function (Error) {
            $("#msjError").html("Error al actualizar el SubTipo");
            $('#ModalError').modal('show');
        }

    });


}

function ObtenerTipos(IdTipo) {
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

            $("#ddlTipoProdActSub").html(Opciones);
            $("#ddlTipoProdActSub").trigger("chosen:updated");
            $("#ddlTipoProdActSub").val(IdTipo);
        },
        error: function (Error) {
            $("#msjError").html("Error al obtener los tipos");
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

$(document).ready(function () {
    ObtenerDatosSubtipo();
});