function ObtenerTodasRedesSociales() {

    $.ajax({
        type: "POST",
        dataType: "JSON",
        url: "/Mantenimientos/ObtenerTodasRedesSociales/",
        data: {},
        success: function (Info) {
            if (Info.length > 0) {

                //var objeto = JSON.parse(Info);

                $('#tbRedes').dataTable().fnDestroy();
                $("#tbRedes").dataTable({

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
                                return "<button class='btn btn-success fa fa-pencil' onclick='EditarRedSocial(" + data["IdRedSocial"] + ")'></button>";
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
                                return "<button class='btn btn-primary fa fa-power-off' onclick='DesactivarActivarRedSocial(" + data["IdRedSocial"] + "," + data["Estado"] + " )'></button>";
                            }
                        },
                        {
                            data: null,
                            sortable: false,
                            render: function (data, type, full) {
                                return "<button class='btn btn-danger fa fa-trash' onclick='EliminarRedSocial(" + data["IdRedSocial"] + ")'></button>";
                            }
                        }

                    ]
                });
            }
        },
        error: function () {
            $("#msjError").html("Error al obtener las redes sociales");
            $('#ModalError').modal('show');
        }



    });
}


function DesactivarActivarRedSocial(IdRedSocial, Estado) {

    if (Estado) {
        Estado = false;
    } else {
        Estado = true;
    }

    $.ajax({
        type: "POST",
        dataType: "JSON",
        data: { IdRedSocial, Estado },
        url: "/Mantenimientos/DesactivarActivarRedSocial/",
        success: function (Info) {
            if (Info) {
               // ObtenerTodasRedesSociales();
            }

        },
        error: function (Error) {
            $("#msjError").html("Error al cambiar el estado");
            $('#ModalError').modal('show');
        }




    });


}

$(document).ready(function () {
    ObtenerTodasRedesSociales();
});