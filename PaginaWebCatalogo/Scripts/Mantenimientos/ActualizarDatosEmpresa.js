
function ActualizarDatosEmpresa(IdEmpresa) {

    var empresa = {
        IdRegistro: IdEmpresa,
        Nombre: $("#txtActNombreEmpresa").val(),
        Descripcion: $("#txtActDescripcion").val(),
        CorreoElectronico: $("#txtActCorreo").val(),
        Telefono: $("#txtActTelefono").val(),
        Direccion: $("#txtActDireccion").val()
    };

    $.ajax({
        type: "POST",
        dataType: "JSON",
        url: "/Mantenimientos/ActualizarInfoEmpresa",
        data: { DatosEmpresa: empresa },
        success: function (data) {
            $("#msjCorrectoActEmpresa").html("Información actualizada correctamente");
            $('#ModalCorrectoActEmpresa').modal('show');

        },
        error: function (error) {
            $("#msjError").html("Error al actualizar los datos de la empresa");
            $('#ModalError').modal('show');
        }
    });

}

function RedireccionarIndex() {
    location.href = '/Mantenimientos/Index/';
}