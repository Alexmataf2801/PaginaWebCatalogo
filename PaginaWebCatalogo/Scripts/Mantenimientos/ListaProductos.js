function ObtenerTodosProductos() {

    $.ajax({
        type: "POST",
        dataType: "JSON",
        url: "/Mantenimientos/ObtenerTodosProductos/",
        data: {},
        success: function (Info) {
            if (Info.length > 0) {

                //var objeto = JSON.parse(Info);

                $('#tbProductos').dataTable().fnDestroy();
                $("#tbProductos").dataTable({

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
                                return "<button class='btn btn-success fa fa-pencil' onclick='EditarProducto(" + data["IdProducto"] + ")'></button>";
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
                                return "<button class='btn btn-primary fa fa-power-off' onclick='DesactivarActivarProducto(" + data["IdProducto"] + "," + data["Estado"] + " )'></button>";
                            }
                        },
                        {
                            data: null,
                            sortable: false,
                            render: function (data, type, full) {
                                return "<button class='btn btn-danger fa fa-trash' onclick='EliminarProducto(" + data["IdProducto"] + ")'></button>";
                            }
                        }

                    ]
                });
            }
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
                // ObtenerTodosProductos();
            }

        },
        error: function (Error) {
            $("#msjError").html("Error al cambiar el estado");
            $('#ModalError').modal('show');
        }
    });


}

$(document).ready(function () {
    ObtenerTodosProductos();
});