function ObtenerTodosTipos() {

    $.ajax({
        type: "POST",
        dataType: "JSON",
        url: "/Mantenimientos/ObtenerTodosTipoProducto/",
        data: {},
        success: function (Info) {


                //var objeto = JSON.parse(Info);

                $('#tbTipos').dataTable().fnDestroy();
                $("#tbTipos").dataTable({

                    autoWidth: false,
                    responsive: true,
                    //dom: 'Bfrtip', // Descomentar para habilitar botones de acciones
                    lengthChange: true, // Habilita combo de opciones para mostrar
                    language: {
                        "url": "../Content/Spanish.json"
                    },
                    data: Info,
                    columns: [
                        {
                            data: null,
                            sortable: false,
                            render: function (data, type, full) {
                                return "<a type='button' class='btn btn-success fa fa-pencil' onclick='ObtenerInfoTipoXId(" + data["IdTipo"] + ")'></a>";
                            }
                        },
                        { data: 'Nombre' },
                        {
                            render: function (data, type, full) {
                                if (full["Estado"]) {
                                    return "<span class='EstadoActivo' >Activo</span>";
                                } else {
                                    return "<span class='EstadoInactivo' >Inactivo</span>";
                                }
                            }
                        },
                        {
                            data: null,
                            sortable: false,
                            render: function (data, type, full) {
                                return "<a type='button' class='btn btn-primary fa fa-power-off' onclick='DesactivarActivarTipo(" + data["IdTipo"] + "," + data["Estado"] + " )'></a>";
                            }
                        },
                        {
                            data: null,
                            sortable: false,
                            render: function (data, type, full) {
                                return "<a type='button' class='btn btn-danger fa fa-trash' onclick='ConfirmarEliminarTipo(" + data["IdTipo"] + ")'></a>";
                            }
                        }

                    ]
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
    $("#msjConf").html("¿Desea eliminar este registro?");
    $('#ModalConfirmacion').modal('show');

}


function EliminarTipo() {
    var Id = $("#IdTipoSeleccionado").val();
    $('#ModalConfirmacion').modal('hide');
    if (Id !== null || Id !== undefined) {
        $.ajax({
            type: "POST",
            dataType: "JSON",
            url: "/Mantenimientos/EliminarTipo/",
            data: { IdRedSocial: Id },
            success: function () {
                $("#msjCorrecto").html("Tipo Eliminado correctamente");
                $('#ModalCorrecto').modal('show');
                ObtenerTodasRedesSociales();
            },
            error: function () {
                $("#msjError").html("Error al eliminar el tipo");
                $('#ModalError').modal('show');
            }
        });

    }
}

function ObtenerInfoTipoXId(IdTipo) {
    location.href = '/Mantenimientos/ObtenerInfoTipo?IdTipoSeleccionado=' + IdTipo;
}


$(document).ready(function () {
    ObtenerTodosTipos();
});