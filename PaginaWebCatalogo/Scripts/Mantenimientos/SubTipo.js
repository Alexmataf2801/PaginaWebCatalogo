function GuardarSubTipoProducto() {

    var subTipo = {
        Codigo: $("#txtCodigoSubTipo").val(),
        Nombre: $("#txtNombreSubTipo").val(),
        Descripcion: $("#txtDescripcionSubTipo").val(),
        IdTipo: $("#ddlTipoProd").val()
    };

    $.ajax({
        type: "POST",
        dataType: "JSON",
        url: "/Mantenimientos/InsertarSubTipoProducto/",
        data: { subTipo },
        success: function (Info) {

            if (Info) {
                $("#msjCorrectoAgrSubTip").html("SubTipo agregado con exito");
                $('#ModalCorrectoAgrSubTip').modal('show');
            }

        },
        error: function (Error) {
            $("#msjError").html("Error al guardar el subtipo de producto");
            $('#ModalError').modal('show');
        }

    });


}

function RedireccionarSubTip() {
    location.href = '/Mantenimientos/ListaSubTipos/';
}

function ObtenerTipos() {
    var Opciones = '';
    $.ajax({
        type: "GET",
        dataType: "JSON",
        data: {},
        url: "/Mantenimientos/ObtenerTipoProducto/",
        success: function (Info) {

            $.each(Info, function (key, value) {
                Opciones = Opciones + "<option value='" + value.IdTipo + "'>" + value.Nombre + "</option>";
            });

            $("#ddlTipoProd").html(Opciones);
        },
        error: function (Error) {
            $("#msjError").html("Error al obtener los tipos");
            $('#ModalError').modal('show');
        }

    });

}

$(document).ready(function () {
    ObtenerTipos();
});