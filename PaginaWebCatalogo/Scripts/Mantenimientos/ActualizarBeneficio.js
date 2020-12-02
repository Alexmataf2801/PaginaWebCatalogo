function ObtenerDatosBeneficio() {
    var Id = sessionStorage.getItem("IdBeneEditar");
    $.ajax({
        type: "GET",
        dataType: "JSON",
        url: "/Mantenimientos/ObtenerBeneficioXId",
        data: { IdBeneficio: Id },
        success: function (data) {
            ObtenerIconos();
            $("#txtNomBene").val(data.Nombre);
            $("#txtDescripBene").val(data.Descripcion);
            sessionStorage.setItem("IdIconoBene", data.Icono);


        },
        error: function (error) {
            $("#msjError").html("Error al obtener la información ");
            $('#ModalError').modal('show');
        }
    });
}

function ObtenerIconos() {
    var Opciones = '';
    $.ajax({
        type: "GET",
        dataType: "JSON",
        data: {},
        url: "/Mantenimientos/ObtenerIconos/",
        success: function (Info) {

            $.each(Info, function (key, value) {
                Opciones = Opciones + "<option value='" + value.Nombre + "'>" + value.Codigo + "</option>";
            });

            $("#Iconos").html(Opciones);
            $("#Iconos").val(sessionStorage.getItem("IdIconoBene"));

        },
        error: function (Error) {
            $("#msjError").html("Error al obtener los Iconos");
            $('#ModalError').modal('show');
        }

    });
}

function ActualizarBeneficio() {
    var Id = sessionStorage.getItem("IdBeneEditar");
    var Beneficio = {
        Id: Id,
        Nombre: $("#txtNomBene").val(),
        Descripcion: $("#txtDescripBene").val(), 
        Icono: $("#Iconos").val()
    };

    $.ajax({
        type: "POST",
        dataType: "JSON",
        data: { beneficios: Beneficio },
        url: "/Mantenimientos/ActualizarBeneficio/",
        success: function (Info) {
            if (Info) {
                $("#msjCorrectoActBen").html("Información actualizada correctamente");
                $('#ModalCorrectoBen').modal('show');
            }
        },
        error: function (Error) {
            $("#msjError").html("Error al actualizar la red social");
            $('#ModalError').modal('show');
        }

    });

}

function RedireccionarBeneficios() {
    location.href = '/Mantenimientos/ListaBeneficios';
}

$(document).ready(function () {
    ObtenerDatosBeneficio();
});