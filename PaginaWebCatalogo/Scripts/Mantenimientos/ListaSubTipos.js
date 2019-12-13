function ObtenerTodosSubTipos() {

    $.ajax({
        type: "GET",
        dataType: "JSON",
        url: "/Mantenimientos/ObtenerTodosSubTiposProducto/",
        data: {},
        success: function (Info) {


            var TablaSubTipos = $('#tbSubTipos').DataTable(
                {
                    autoWidth: false,
                    dom: 'frtip',
                    lengthChange: false,
                    "language": {
                        "url": "../../Content/Spanish.json"
                    },
                    retrieve: true,
                    responsive: true,
                    searching: true
                }
            );

            TablaSubTipos.clear().draw();
            $(Info).each(function (key, value) {
                var estado = '';
                if (value.Estado) {
                    estado = "<span class='EstadoActivo' >Activo</span>";
                } else {
                    estado = "<span class='EstadoInactivo' >Inactivo</span>";
                }
                var Editar = "<a type='button' class='btn btn-success fa fa-pencil' onclick='ObtenerInfoSubTipoXId(" + value.IdSubTipo + ")'></a>";
                var CambiarEstado = "<a type='button' class='btn btn-primary fa fa-power-off' onclick='DesactivarActivarSubTipo(" + value.IdSubTipo + "," + value.Estado + " )'></a>";
                var Eliminar = "<a type='button' class='btn btn-danger fa fa-trash' onclick='ConfirmarEliminarSubTipo(" + value.IdSubTipo + ")'></a>";

                TablaSubTipos.row.add([ Editar, value.Codigo, value.Nombre, value.NombreTipo, estado, CambiarEstado, Eliminar]).draw();
            });


        },
        error: function () {
            $("#msjError").html("Error al obtener los SubTipos");
            $('#ModalError').modal('show');
        }



    });
}

function DesactivarActivarSubTipo(IdSubTipo, Estado) {

    if (Estado) {
        Estado = false;
    } else {
        Estado = true;
    }

    $.ajax({
        type: "POST",
        dataType: "JSON",
        data: { IdSubTipo, Estado },
        url: "/Mantenimientos/DesactivarActivarSubTipo/",
        success: function (Info) {
            if (Info) {
                ObtenerTodosSubTipos();
            }

        },
        error: function (Error) {
            $("#msjError").html("Error al cambiar el estado");
            $('#ModalError').modal('show');
        }
    });


}

function ConfirmarEliminarSubTipo(IdSubTipo) {
    $("#IdSubTipoSeleccionado").val(IdSubTipo);
    $("#msjConfSubTipo").html("¿Desea eliminar este registro?");
    $('#ModalConfirmacionSubTipo').modal('show');

}

function EliminarSubTipo() {
    var Id = $("#IdSubTipoSeleccionado").val();
    $('#ModalConfirmacionSubTipo').modal('hide');
    if (Id !== null || Id !== undefined) {
        $.ajax({
            type: "POST",
            dataType: "JSON",
            url: "/Mantenimientos/EliminarSubTipo/",
            data: { IdSubTipo: Id },
            success: function () {
                $("#msjCorrecto").html("SubTipo Eliminado correctamente");
                $('#ModalCorrecto').modal('show');
                ObtenerTodosSubTipos();
            },
            error: function () {
                $("#msjError").html("Error al eliminar el Subtipo");
                $('#ModalError').modal('show');
            }
        });

    }
}

function ObtenerInfoSubTipoXId(IdSubTipo) {
    sessionStorage.setItem("IdSubTipoEditar", IdSubTipo);
    location.href = '/Mantenimientos/ActualizarSubTipo';
}


$(document).ready(function () {
    ObtenerTodosSubTipos();
});