function GuardarEmpresa() {

    // Checking whether FormData is available in browser  
    if (window.FormData !== undefined) {


        var fileUpload = $("#Logo").get(0);

        var files = fileUpload.files;

        // Create FormData object  
        var fileData = new FormData();

        // Looping over all files and add it to FormData object  
        for (var i = 0; i < files.length; i++) {
            fileData.append(files[i].name, files[i]);
        }

        fileData.append('Nombre', $("#txtNombreEmpresa").val());
        fileData.append('Descripcion', $("#txtDescripcion").val());
        fileData.append('Correo', $("#txtCorreo").val());
        fileData.append('Telefono', $("#txtTelefono").val());
        fileData.append('Direccion', $("#txtDireccion").val());
        fileData.append('Mapa', $("#txtUrlMapa").val());

        $.ajax({
            url: '/Mantenimientos/InsertarEmpresa',
            type: "POST",
            contentType: false, // Not to set any content header  
            processData: false, // Not to process data  
            data: fileData,
            success: function (Info) {

                if (Info) {
                    $("#msjCorrectoAgrEmp").html("Datos de empresa agregados con exito");
                    $('#ModalCorrectoAgrEmp').modal('show');
                    LimpiarDatosEmpresa();

                } else {
                    $("#msjError").html("No se pudo insertar los datos de la empresa, intente nuevamente y si el error persiste contecte al administrador del sistema");
                    $('#ModalError').modal('show');
                }

            },
            error: function (Error) {
                $("#msjError").html("No se pudo insertar los datos de la empresa, intente nuevamente y si el error persiste contecte al administrador del sistema");
                $('#ModalError').modal('show');
            }
        });
    } else {
        $("#msjError").html("Error al ejecutar la accion solicitada");
        $('#ModalError').modal('show');
    }

}

function LimpiarDatosEmpresa() {
    $("#txtNombreEmpresa").val("");
    $("#txtDescripcion").val("");
    $("#txtCorreo").val("");
    $("#txtTelefono").val("");
    $("#txtDireccion").val("");
}