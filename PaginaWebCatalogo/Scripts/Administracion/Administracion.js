
function ObtenerRedesSociales() {
    var RedesSociales = '';
    $.ajax({
        type: "GET",
        url: "/Home/ObtenerRedesSociales",
        data: {},
        dataType: "JSON",
        success: function (data) {
            if (data.length > 0) {
                RedesSociales = RedesSociales + "<li class='share'>Redes Sociales: </li>";

                $.each(data, function (key, value) {
                    RedesSociales = RedesSociales + "<li><a style='background-color:"+value.Color+"' target='_blank' href='" + value.Url + "'><div class='front'><i class='" + value.Icono + "' aria-hidden='true'></i></div><div class='back'><i aria-hidden='true'></i></div></a></li>";

                });

                $("#RedesSociales").html(RedesSociales);
                $("#RedesSocialesFooter").html(RedesSociales);
            }
        },
        error: function (error) {
            console.log(error);
        }
    });
}
function ObtenerInformacionEmpresa() {
    $.ajax({
        type: "GET",
        url: "/Home/ObtenerInformacionEmpresa",
        data: {},
        dataType: "JSON",
        success: function (data) {

            $("#TelefonoEmpresa").html(data.Telefono);
            $("#CorreoElectronicoEmpresa").html(data.CorreoElectronico);
            $("#NombreEmpresa").html(data.Nombre);
            $("#NombreEmpresaFooter").html(data.Nombre);
            $("#NombreEmpresaFooter2").html(data.Nombre);
            $("#TelefonoFooter").html(data.Telefono);
            $("#CorreoElectronicoFooter").html(data.CorreoElectronico);
            $("#DireccionFooter").html(data.Direccion);

            $("#NombreAbout").html(data.Nombre);
            $("#CorreoAbout").html(data.CorreoElectronico);
            $("#TelefonoAbout").html(data.Telefono);
            $("#DireccionAbout").html(data.Direccion);
            $("#DescripcionAbout").html(data.Descripcion);

            $("#LogoEmpresa").append("<img src='" + data.Url + data.NombreImagen + data.Raiz + "' >");

        },
        error: function (error) {
            console.log(error);
        }
    });
}
function GuardarUsuario(a) {
    var usuario = {
        Identificacion: $("#txtIdentificacion").val(),
        Nombre: $("#txtNombre").val(),
        PrimerApellido: $("#txtPrimerApellido").val(),
        SegundoApellido: $("#txtSegundoApellido").val(),
        CorreoElectronico: $("#txtCorreoElectronico").val(),
        Telefono: $("#txtTelefono").val(),
        Direccion: $("#txtDireccion").val(),
        Genero: $("#ddlGenero").val() === "1" ? true : false
    };

    if (usuario.Identificacion !== '' && usuario.Nombre !== '' && usuario.PrimerApellido !== '' && usuario.CorreoElectronico !== '' && usuario.Direccion !== '') {
        $.ajax({
            url: "/Home/RegistrarUsuario",
            type: "POST",
            dataType: "JSON",
            data: { usuario },
            success: function (info) {
                if (info === 1) {

                    $('#myModal2').modal('hide');
                    $("#msjCorrecto").html("Se registro el usuario correctamente");
                    $('#ModalCorrecto').modal('show');

                } else if (info === 2) {

                    $("#msjInfo").html("Ya existe un usuario con ese numero de identificación");
                    $('#ModalInformacion').modal('show');

                } else if (info === 3) {

                    $("#msjInfo").html("Ya existe un usuario con ese correo electrónico");
                    $('#ModalInformacion').modal('show');

                } else {

                    $("#msjError").html("Fallo el registro del usuario");
                    $('#ModalError').modal('show');
                }
            },
            error: function () {
                $('#myModal2').modal('hide');
                $("#msjError").html("Fallo el registro del usuario");
                $('#ModalError').modal('show');
            }

        });
    } else {

        $("#msjInfo").html("Le falta llenar algunos campos del formulario");
        $('#ModalInformacion').modal('show');
    }


}
function Modal() {
    $('.modal').on('show.bs.modal', function () {
        if ($(document).height() > $(window).height()) {
            // no-scroll
            $('body').addClass("modal-open-noscroll");
        }
        else {
            $('body').removeClass("modal-open-noscroll");
        }
    });
    $('.modal').on('hide.bs.modal', function () {
        $('body').removeClass("modal-open-noscroll");
    });
}
function ValidarUsuario() {

    var login = {
        Usuario: $("#usuario").val(),
        Contrasena: $("#contrasena").val()
    };

    $.ajax({
        type: "POST",
        dataType: "JSON",
        url: "/Home/ValidarLogin",
        data: { login },
        success: function (Info) {

            if (Info.IdUsuario > 0) {
                var Nombre = Info.Nombre + ' ' + Info.PrimerApellido + ' ' + Info.SegundoApellido;

                if (Info.IdPerfil === 1) {

                    $('#ModalIngreso').modal('hide');
                    sessionStorage.setItem("Nombre", Nombre);
                    window.location.href = "/Mantenimientos/Index";

                } else {

                    $('#ModalIngreso').modal('hide');
                    sessionStorage.setItem("Nombre", Nombre);
                    window.location.href = "/Home/Index";

                }
            } else {
                $("#msjInfo").html("Usuario o Contraseña Incorrecto");
                $('#ModalInformacion').modal('show');
            }
            

           
            
        },
        error: function (Error) {
            $("#msjError").html("Error al obtener validar su usuario");
            $('#ModalError').modal('show');
        }


    });
}


$(document).ready(function () {
    Modal();
    if (sessionStorage.getItem("Nombre") !== null) {
        $("#NombrePerfil").html(sessionStorage.getItem("Nombre"));
        $("#Perfil  ").css("display", "inline-block");
    } else {
        $("#Perfil  ").css("display", "none");
    }

});