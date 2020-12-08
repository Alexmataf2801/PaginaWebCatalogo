
function ActualizarDatosEmpresa(IdEmpresa) {


    if (window.FormData !== undefined) {

        var fileUpload = $("#LogoAct").get(0);

        var files = fileUpload.files;

        var fileData = new FormData();

        for (var i = 0; i < files.length; i++) {
            fileData.append(files[i].name, files[i]);
        }

        fileData.append('IdRegistro', IdEmpresa);
        fileData.append('Nombre', $("#txtActNombreEmpresa").val());
        fileData.append('Descripcion', $("#txtActDescripcion").val());
        fileData.append('CorreoElectronico', $("#txtActCorreo").val());
        fileData.append('Telefono', $("#txtActTelefono").val());
        fileData.append('Direccion', $("#txtActDireccion").val());
        fileData.append('Mapa', $("#txtUrlMapa").val());

    }

    $.ajax({
        type: "POST",
        url: "/Mantenimientos/ActualizarInfoEmpresa",
        contentType: false, // Not to set any content header  
        processData: false, // Not to process data  
        data: fileData,
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