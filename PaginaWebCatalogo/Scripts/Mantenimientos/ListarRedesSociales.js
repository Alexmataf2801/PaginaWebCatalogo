
function ObtenerTodasRedesSociales() {

    $.ajax({
        type: "GET",
        dataType: "JSON",
        url: "/Mantenimientos/ObtenerTodasRedesSociales/",
        data: {},
        success: function (Info) {
            if (Info.length > 0) {

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
                                return "<button class='btn btn-danger fa fa-trash' onclick='ConfirmarEliminarRedSocial(" + data["IdRedSocial"] + ")'></button>";
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

$("#CerrarEliminarRed").click(function () {
    sessionStorage.setItem("RedSocialAEliminar", null);
});

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

function ConfirmarEliminarRedSocial(idRedSocial) {
    $("#IdRedSeleccionada").val(idRedSocial);
    //sessionStorage.setItem("RedSocialAEliminar", idRedSocial);
    $("#msjConf").html("¿Desea eliminar este registro?");
    $('#ModalConfirmacion').modal('show');
}



function EliminarRedSocial() {
    var Id = $("#IdRedSeleccionada").val();
    if (Id !== null || Id !== undefined) {
        //var IdRedSocial = sessionStorage.getItem("RedSocialAEliminar");
        $.ajax({
            type: "POST",
            dataType: "JSON",
            url: "/Mantenimientos/EliminarRedSocial/",
            data: { Id },
            success: function () {
                //ObtenerTodasRedesSociales();
                $("#msjCorrecto").html("Red Social eliminada correctamente");
                $('#ModalCorrecto').modal('show');
            },
            error: function () {
                $("#msjError").html("Error al eliminar la red social");
                $('#ModalError').modal('show');
            }
        });

    }
}



$(document).ready(function () {
       ObtenerTodasRedesSociales();
});

