function ObtenerTodosSubTipos() {

    $.ajax({
        type: "POST",
        dataType: "JSON",
        url: "/Mantenimientos/ObtenerTodosSubTiposProducto/",
        data: {},
        success: function (Info) {
            if (Info.length > 0) {

                //var objeto = JSON.parse(Info);

                $('#tbSubTipos').dataTable().fnDestroy();
                $("#tbSubTipos").dataTable({

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
                                return "<button class='btn btn-success fa fa-pencil' onclick='EditarSubTipo(" + data["IdSubTipo"] + ")'></button>";
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
                                return "<button class='btn btn-primary fa fa-power-off' onclick='DesactivarSubTipo(" + data["IdSubTipo"] + ")'></button>";
                            }
                        },
                        {
                            data: null,
                            sortable: false,
                            render: function (data, type, full) {
                                return "<button class='btn btn-danger fa fa-trash' onclick='EliminarSubTipo(" + data["IdSubTipo"] + ")'></button>";
                            }
                        }

                    ]
                });
            }
        },
        error: function () {
            $("#msjError").html("Error al obtener los SubTipos");
            $('#ModalError').modal('show');
        }



    });
}

$(document).ready(function () {
    ObtenerTodosSubTipos();
});