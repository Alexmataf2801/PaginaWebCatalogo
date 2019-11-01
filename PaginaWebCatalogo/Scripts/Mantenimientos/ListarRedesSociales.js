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
                        { data: 'IdRedSocial' },
                        { data: 'Nombre' },
                        { data: 'Descripcion' },
                        {
                            render: function (data, type, full) {
                                if (full["Estado"]) {
                                    return "<span style='background-color: #1F9E3C; padding:5px 15px 5px 15px; border-radius: 5px; color : #ffffff; font-weight: bold; text-align:center' >Activo</span>";
                                } else {
                                    return "<span style='background-color: #EE2626; padding:5px 10px 5px 10px; border-radius: 5px; color : #ffffff; font-weight: bold' >Inactivo</span>";
                                }

                            
                            }

                        },
                        {
                            data: null,
                            sortable: false,
                            render: function (data, type, full) {
                                return "<button class='btn btn-primary fa fa-power-off' onclick='DesactivarRedSocial(" + data["IdRedSocial"] + ")'></button>";
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
            alert("Error");
        }



    });
}

$(document).ready(function () {
    ObtenerTodasRedesSociales();
});