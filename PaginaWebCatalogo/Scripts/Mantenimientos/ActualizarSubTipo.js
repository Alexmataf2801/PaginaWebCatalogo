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

function obtenerDatosSubtipo() {
        // hay que cambiar la forma como se carga los
        // datos de la edicion de un subtipo
        // para que se carguen los combos correctamente

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
    ObtenerTipos();
});