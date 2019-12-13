function ObtenerTodosTipos() {

    $.ajax({
        type: "POST",
        dataType: "JSON",
        url: "/Mantenimientos/ObtenerTodosTipoProducto/",
        data: {},
        success: function (Info) {

            var TablaTipos = $('#tbTipos').DataTable(
                {
                    autoWidth: false,
                    dom: 'frtip',
                    lengthChange: false,
                    "language": {
                        "url": "../../Content/Spanish.json"
                    },
                    retrieve: true,
                    responsive: true,
                    searching: false
                }
            );

            TablaTipos.clear().draw();
            $(Info).each(function (key, value) {
                var estado = '';
                if (value.Estado) {
                    estado = "<span class='EstadoActivo' >Activo</span>";
                } else {
                    estado = "<span class='EstadoInactivo' >Inactivo</span>";
                }
                var Editar = "<a type='button' class='btn btn-success fa fa-pencil' onclick='ObtenerInfoTipoXId(" + value.IdTipo + ")'></a>";
                var CambiarEstado = "<a type='button' class='btn btn-primary fa fa-power-off' onclick='DesactivarActivarTipo(" + value.IdTipo + "," + value.Estado + " )'></a>";
                var Eliminar = "<a type='button' class='btn btn-danger fa fa-trash' onclick='ConfirmarEliminarTipo(" + value.IdTipo + ")'></a>";

                TablaTipos.row.add([Editar, value.Codigo, value.Nombre, estado, CambiarEstado, Eliminar]).draw();
            });
            
        },
        error: function () {
            $("#msjError").html("Error al obtener los Tipos");
            $('#ModalError').modal('show');
        }



    });
}

function DesactivarActivarTipo(IdTipo, Estado) {

    if (Estado) {
        Estado = false;
    } else {
        Estado = true;
    }

    $.ajax({
        type: "POST",
        dataType: "JSON",
        data: { IdTipo, Estado },
        url: "/Mantenimientos/DesactivarActivarTipo/",
        success: function (Info) {
            if (Info) {
                ObtenerTodosTipos();
            }

        },
        error: function (Error) {
            $("#msjError").html("Error al cambiar el estado");
            $('#ModalError').modal('show');
        }
    });


}

function ConfirmarEliminarTipo(IdTipo) {
    $("#IdTipoSeleccionado").val(IdTipo);
    $("#msjConfTipo").html("¿Desea eliminar este registro?");
    $('#ModalConfirmacionTipo').modal('show');

}


function EliminarTipo() {
    var Id = $("#IdTipoSeleccionado").val();
    $('#ModalConfirmacionTipo').modal('hide');
    if (Id !== null || Id !== undefined) {
        $.ajax({
            type: "POST",
            dataType: "JSON",
            url: "/Mantenimientos/EliminarTipo/",
            data: { IdTipo: Id },
            success: function () {
                $("#msjCorrecto").html("Tipo Eliminado correctamente");
                $('#ModalCorrecto').modal('show');
                ObtenerTodosTipos();
            },
            error: function () {
                $("#msjError").html("Error al eliminar el tipo");
                $('#ModalError').modal('show');
            }
        });

    }
}

function ObtenerInfoTipoXId(IdTipo) {
    sessionStorage.setItem("IdTipo", IdTipo);
    location.href = '/Mantenimientos/ActualizarTipo/';
}


$(document).ready(function () {
    ObtenerTodosTipos();
});