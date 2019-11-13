﻿function ObtenerTodosTipos() {

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
                                return "<button class='btn btn-primary fa fa-power-off' onclick='DesactivarActivarTipo(" + data["IdTipo"] + "," + data["Estado"] + " )'></button>";
                            }
                        },
                        {
                            data: null,
                            sortable: false,
                            render: function (data, type, full) {
                                return "<a type='button' class='btn btn-danger fa fa-trash' onclick='EliminarTipo(" + data["IdTipo"] + ")'></a>";
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
                //ObtenerTodosTipos();
            }

        },
        error: function (Error) {
            $("#msjError").html("Error al cambiar el estado");
            $('#ModalError').modal('show');
        }
    });


}

function ObtenerInfoTipoXId(IdTipo) {
    location.href = '/Mantenimientos/ObtenerInfoTipo?IdTipoSeleccionado=' + IdTipo;
    //$.ajax({
    //    type: "POST",
    //    dataType: "JSON",
    //    data: { IdTipoSeleccionado: IdTipo },
    //    url: "/Mantenimientos/ObtenerInfoTipo/",
    //    success: function (Info) {
    //    },
    //    error: function (Error) {
    //        $("#msjError").html("Error obtener la informacion del tipo");
    //        $('#ModalError').modal('show');
    //    }
    //});
}


$(document).ready(function () {
    ObtenerTodosTipos();
});