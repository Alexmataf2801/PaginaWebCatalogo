
function ObtenerTodasRedesSociales() {

    $.ajax({
        type: "GET",
        dataType: "JSON",
        url: "/Mantenimientos/ObtenerTodasRedesSociales/",
        data: {},
        success: function (Info) {

            var TablaRedes = $('#tbRedes').DataTable(
                {
                    autoWidth: false,
                    dom: 'frtip',
                    lengthChange: false,
                    "language": {
                        "url": "../../Content/Spanish.json"
                    },
                    retrieve: true,
                    responsive: true,
                    searching: true
                }
            );

            TablaRedes.clear().draw();
            $(Info).each(function (key, value) {
                var estado = '';
                if (value.Estado) {
                    estado = "<span class='EstadoActivo' >Activo</span>";
                } else {
                    estado = "<span class='EstadoInactivo' >Inactivo</span>";
                }
                var Editar = "<a type='button' class='btn btn-success fa fa-pencil' onclick='EditarRedSocial(" + value.IdRedSocial + ")'></a>";
                var CambiarEstado = "<a type='button' class='btn btn-primary fa fa-power-off' onclick='DesactivarActivarRedSocial(" + value.IdRedSocial + "," + value.Estado + " )'></a>";
                var Eliminar = "<a type='button' class='btn btn-danger fa fa-trash' onclick='ConfirmarEliminarRedSocial(" + value.IdRedSocial + ")'></a>";

                TablaRedes.row.add([ Editar, value.Nombre, estado, CambiarEstado, Eliminar]).draw();
            });
            
        },
        error: function () {
            $("#msjError").html("Error al obtener las redes sociales");
            $('#ModalError').modal('show');
        }



    });
}
function EditarRedSocial(Id) {
    sessionStorage.setItem("IdRedSocial", Id);
    window.location.href = "/Mantenimientos/ActualizarRedSocial";
}

$("#CerrarEliminarRed").click(function () {
    $("#IdRedSeleccionada").val(0);
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
                ObtenerTodasRedesSociales();
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
    $("#msjConf").html("¿Desea eliminar este registro?");
    $('#ModalConfirmacion').modal('show');

}



function EliminarRedSocial() {
    var Id = $("#IdRedSeleccionada").val();
    $('#ModalConfirmacion').modal('hide');
    if (Id !== null || Id !== undefined) {
        $.ajax({
            type: "POST",
            dataType: "JSON",
            url: "/Mantenimientos/EliminarRedSocial/",
            data: { IdRedSocial: Id },
            success: function () {
                $("#msjCorrecto").html("Red Social eliminada correctamente");
                $('#ModalCorrecto').modal('show');
                ObtenerTodasRedesSociales();
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

