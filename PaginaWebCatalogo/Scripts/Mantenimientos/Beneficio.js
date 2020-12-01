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

            $("#ddlIconos").html(Opciones);
        },
        error: function (Error) {
            $("#msjError").html("Error al obtener los Iconos");
            $('#ModalError').modal('show');
        }

    });
}

function LimpiarBeneficio() {
    $("#txtNomBene").val("");
    $("#txtDescripBene").val("");

}

function RedireccionarBeneficios() {
    location.href = '/Mantenimientos/ListaBeneficios';
}

function GuardarBeneficio() {

    var Beneficio = {
        Nombre: $("#txtNomBene").val(),
        Descripcion: $("#txtDescripBene").val(),
        Icono: $("#ddlIconos").val(),

    };

    $.ajax({
        type: "POST",
        dataType: "JSON",
        url: "/Mantenimientos/InsertarBeneficio/",
        data: { Beneficio },
        success: function (Info) {
            if (Info) {
                LimpiarBeneficio();
                $("#msjCorrectoBen").html("Beneficio agregado con exito");
                $('#ModalCorrectoBen').modal('show');
            }

        },
        error: function (Error) {
            $("#msjError").html("Error al guardar el registro");
            $('#ModalError').modal('show');
        }

    });


}


$(document).ready(function () {
    ObtenerIconos();
});