function GuardarBanner() {


    // Checking whether FormData is available in browser  
    if (window.FormData !== undefined) {


        var fileUpload = $("#Imagen").get(0);

        var files = fileUpload.files;

        // Create FormData object  
        var fileData = new FormData();

        // Looping over all files and add it to FormData object  
        for (var i = 0; i < files.length; i++) {
            fileData.append(files[i].name, files[i]);
        }

     

        fileData.append('Titulo', $("#txtTitulo").val());
        fileData.append('Detalle', $("#txtDetalle").val());
        

        $.ajax({
            url: '/Mantenimientos/InsertarBanner',
            type: "POST",
            contentType: false, // Not to set any content header  
            processData: false, // Not to process data  
            data: fileData,
            success: function (Info) {

                if (Info) {
                    $("#msjCorrectoAgrProd").html("Banner agregado con exito");
                    $('#ModalCorrectoAgrProd').modal('show');

                } else {
                    $("#msjError").html("No se pudo insertar el banner o no adjunto ninguna imagen.");
                    $('#ModalError').modal('show');
                }

            },
            error: function (Error) {
                $("#msjError").html("Error al guardar producto");
                $('#ModalError').modal('show');
            }
        });
    } else {
        $("#msjError").html("Error al ejecutar la accion solicitada");
        $('#ModalError').modal('show');
    }

}