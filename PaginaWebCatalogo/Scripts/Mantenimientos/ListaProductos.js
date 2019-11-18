function ObtenerTodosProductos() {

    $.ajax({
        type: "POST",
        dataType: "JSON",
        url: "/Mantenimientos/ObtenerTodosProductos/",
        data: {},
        success: function (Info) {

                //var objeto = JSON.parse(Info);

                $('#tbProductos').dataTable().fnDestroy();
                $("#tbProductos").dataTable({

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
                                return "<a type='button' class='btn btn-success fa fa-pencil' onclick='EditarProducto(" + data["IdProducto"] + ")'></a>";
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
                                return "<a type='button' class='btn btn-primary fa fa-power-off' onclick='DesactivarActivarProducto(" + data["IdProducto"] + "," + data["Estado"] + " )'></a>";
                            }
                        },
                        {
                            data: null,
                            sortable: false,
                            render: function (data, type, full) {
                                return "<a type='button' class='btn btn-danger fa fa-trash' onclick='ConfirmarEliminarProducto(" + data["IdProducto"] + ")'></a>";
                            }
                        }

                    ]
                });
            
        },
        error: function () {
            $("#msjError").html("Error al obtener los productos");
            $('#ModalError').modal('show');
        }



    });
}

function DesactivarActivarProducto(IdProducto, Estado) {

    if (Estado) {
        Estado = false;
    } else {
        Estado = true;
    }

    $.ajax({
        type: "POST",
        dataType: "JSON",
        data: { IdProducto, Estado },
        url: "/Mantenimientos/DesactivarActivarProducto/",
        success: function (Info) {
            if (Info) {
                ObtenerTodosProductos();
            }

        },
        error: function (Error) {
            $("#msjError").html("Error al cambiar el estado");
            $('#ModalError').modal('show');
        }
    });


}

function ConfirmarEliminarProducto(IdProducto) {
    $("#IdProductoSeleccionado").val(IdProducto);
    $("#msjConfProd").html("¿Desea eliminar este registro?");
    $('#ModalConfirmacionProd').modal('show');

}


function EliminarProducto() {
    var Id = $("#IdProductoSeleccionado").val();
    $('#ModalConfirmacionProd').modal('hide');
    if (Id !== null || Id !== undefined) {
        $.ajax({
            type: "POST",
            dataType: "JSON",
            url: "/Mantenimientos/EliminarProducto/",
            data: { IdProducto: Id },
            success: function () {
                $("#msjCorrecto").html("Producto eliminado correctamente");
                $('#ModalCorrecto').modal('show');
                ObtenerTodosProductos();
            },
            error: function () {
                $("#msjError").html("Error al eliminar el producto");
                $('#ModalError').modal('show');
            }
        });

    }
}

$(document).ready(function () {
    ObtenerTodosProductos();
});