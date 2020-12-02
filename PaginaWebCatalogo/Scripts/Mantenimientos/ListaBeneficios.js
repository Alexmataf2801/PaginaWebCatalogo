function ObtenerTodosBeneficios() {

    $.ajax({
        type: "POST",
        dataType: "JSON",
        url: "/Mantenimientos/ObtenerTodosLosBeneficios/",
        data: {},
        success: function (Info) {

            var TablaBene = $('#tbBeneficios').DataTable(
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

            TablaBene.clear().draw();
            $(Info).each(function (key, value) {
                var estado = '';
                if (value.Estado) {
                    estado = "<span class='EstadoActivo' >Activo</span>";
                } else {
                    estado = "<span class='EstadoInactivo' >Inactivo</span>";
                }
                var Editar = "<a type='button' class='btn btn-success fa fa-pencil' onclick='EditarBeneficio(" + value.Id + ")'></a>";
                var CambiarEstado = "<a type='button' class='btn btn-primary fa fa-power-off' onclick='DesactivarActivarBeneficio(" + value.Id + "," + value.Estado + " )'></a>";
                var Eliminar = "<a type='button' class='btn btn-danger fa fa-trash' onclick='ConfirmarEliminarBeneficio(" + value.Id + ")'></a>";

                TablaBene.row.add([Editar, value.Nombre, value.Descripcion, estado, CambiarEstado, Eliminar]).draw();
            });

        },
        error: function () {
            $("#msjError").html("Error al obtener los registros");
            $('#ModalError').modal('show');
        }



    });
}

function EditarBeneficio(Id) {
    sessionStorage.setItem("IdBeneEditar", Id);
    window.location.href = "/Mantenimientos/ActualizarDatosBeneficio";
}



function ConfirmarEliminarBeneficio(Id) {
    $("#IdBeneficioSeleccionado").val(Id);
    $("#msjConfBene").html("¿Desea eliminar este registro?");
    $('#ModalConfirmacionBene').modal('show');

}

function EliminarBeneficio() {
    var Id = $("#IdBeneficioSeleccionado").val();
    $('#ModalConfirmacionBene').modal('hide');
    if (Id !== null || Id !== undefined) {
        $.ajax({
            type: "POST",
            dataType: "JSON",
            url: "/Mantenimientos/EliminarBeneficio/",
            data: { IdBeneficio: Id },
            success: function () {
                $("#msjCorrecto").html("Registro eliminado correctamente");
                $('#ModalCorrecto').modal('show');
                ObtenerTodosBeneficios();
            },
            error: function () {
                $("#msjError").html("Error al eliminar el registro");
                $('#ModalError').modal('show');
            }
        });

    }
}

function DesactivarActivarBeneficio(IdBeneficio, Estado) {

    if (Estado) {
        Estado = false;
    } else {
        Estado = true;
    }

    $.ajax({
        type: "POST",
        dataType: "JSON",
        data: { IdBeneficio, Estado },
        url: "/Mantenimientos/DesactivarActivarBeneficios/",
        success: function (Info) {
            if (Info) {
                ObtenerTodosBeneficios();
            }

        },
        error: function (Error) {
            $("#msjError").html("Error al cambiar el estado");
            $('#ModalError').modal('show');
        }
    });


}

$(document).ready(function () {
    ObtenerTodosBeneficios();
});