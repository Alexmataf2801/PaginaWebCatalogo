
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
            $("#msjCorrecto").html("Información actualizada correctamente");
            $('#ModalCorrecto').modal('show');

        },
        error: function (error) {
           alert("Error")
        }
    });

}