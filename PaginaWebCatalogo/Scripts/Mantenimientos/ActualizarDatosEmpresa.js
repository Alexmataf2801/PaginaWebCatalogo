//function ObtenerDatosEmpresa() {
//    $.ajax({
//        type: "GET",
//        url: "/Home/ObtenerInformacionEmpresa",
//        data: {},
//        dataType: "JSON",
//        success: function (data) {

//            $("#IdEmpresa").html(data.IdRegistro);
//            $("#txtActNombreEmpresa").html(data.Nombre);
//            $("#txtActDescripcion").html(data.Descripcion);
//            $("#txtActCorreo").html(data.CorreoElectronico);
//            $("#txtActTelefono").html(data.Telefono);
//            $("#txtActDireccion").html(data.Direccion);
           
//        },
//        error: function (error) {
//            console.log(error);
//        }
//    });

//}

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