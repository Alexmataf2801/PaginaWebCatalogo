function ObtenerTodosSubTipos() {

    $.ajax({
        type: "POST",
        dataType: "JSON",
        url: "/Mantenimientos/ObtenerTodosSubTiposProducto/",
        data: {},
        success: function (Info) {


                //var objeto = JSON.parse(Info);

                $('#tbSubTipos').dataTable().fnDestroy();
                $("#tbSubTipos").dataTable({

                    autoWidth: false,
                    responsive: true,
                    //dom: 'Bfrtip', // Descomentar para habilitar botones de acciones
                    lengthChange: true, // Habilita combo de opciones para mostrar
                    language: {
                        "url": "../../Content/Spanish.json"
                    },
                    data: Info,
                    columns: [
                        {
                            data: null,
                            sortable: false,
                            render: function (data, type, full) {
                                return "<a type='button' class='btn btn-success fa fa-pencil' onclick='ObtenerInfoSubTipoXId(" + data["IdSubTipo"] + ")'></a>";
                            }
                        },
                        { data: 'Codigo' },
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
                                return "<a type='button' class='btn btn-primary fa fa-power-off' onclick='DesactivarActivarSubTipo(" + data["IdSubTipo"] + "," + data["Estado"] + " )'></a>";
                            }
                        },
                        {
                            data: null,
                            sortable: false,
                            render: function (data, type, full) {
                                return "<a type='button' class='btn btn-danger fa fa-trash' onclick='ConfirmarEliminarSubTipo(" + data["IdSubTipo"] + ")'></a>";
                            }
                        }

                    ]
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