
function LimpiarTipo() {
    $("#txtCodigoTipo").val("");
    $("#txtNombreTipo").val("");
    $("#txtDescripcionTIpo").val("");
}

function GuardarTipoProducto() {

    var tipo = {
        Codigo: $("#txtCodigoTipo").val(),
        Nombre: $("#txtNombreTipo").val(),
        Descripcion: $("#txtDescripcionTIpo").val()

    };

    $.ajax({
        type: "POST",
        dataType: "JSON",
        url: "/Mantenimientos/InsertarTipoProducto/",
        data: { tipo },
        success: function (Info) {

            if (Info) {
                LimpiarTipo();
                $("#msjCorrectoAgrTip").html("Tipo agregado con exito");
                $('#ModalCorrectoAgrTip').modal('show');
            }

        },
        error: function (Error) {
            $("#msjError").html("Error al guardar el tipo de producto");
            $('#ModalError').modal('show');
        }

    });


}


function RedireccionarTip() {
    location.href = '/Mantenimientos/ListaTipos/';
}


