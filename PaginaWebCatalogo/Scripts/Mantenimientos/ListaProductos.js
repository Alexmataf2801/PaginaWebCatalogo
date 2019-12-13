function ObtenerTodosProductos() {

    $.ajax({
        type: "POST",
        dataType: "JSON",
        url: "/Mantenimientos/ObtenerTodosProductos/",
        data: {},
        success: function (Info) {

            var TablaProd = $('#tbProductos').DataTable(
                {
                    autoWidth: false,
                    dom: 'frtip',
                    lengthChange: false,
                    "language": {
                        "url": "../../Content/Spanish.json"
                    },
                    retrieve: true,
                    responsive: true,
                    searching: false
                }
            );

            TablaProd.clear().draw();
            $(Info).each(function (key, value) {
                var estado = '';
                if (value.Estado) {
                    estado = "<span class='EstadoActivo' >Activo</span>";
                } else {
                    estado = "<span class='EstadoInactivo' >Inactivo</span>";
                }
                var Editar = "<a type='button' class='btn btn-success fa fa-pencil' onclick='EditarProducto(" + value.IdProducto + ")'></a>";
                var CambiarEstado = "<a type='button' class='btn btn-primary fa fa-power-off' onclick='DesactivarActivarProducto(" + value.IdProducto + "," + value.Estado + " )'></a>";
                var Eliminar = "<a type='button' class='btn btn-danger fa fa-trash' onclick='ConfirmarEliminarProducto(" + value.IdProducto + ")'></a>";

                TablaProd.row.add([Editar, value.Codigo, value.Nombre, estado, CambiarEstado, Eliminar]).draw();
            });

        },
        error: function () {
            $("#msjError").html("Error al obtener los productos");
            $('#ModalError').modal('show');
        }



    });
}

function DesactivarActivarProducto(IdProducto, Estado) {

    if (Estado) {
        Estado = false;
    } else {
        Estado = true;
    }

    $.ajax({
        type: "POST",
        dataType: "JSON",
        data: { IdProducto, Estado },
        url: "/Mantenimientos/DesactivarActivarProducto/",
        success: function (Info) {
            if (Info) {
                ObtenerTodosProductos();
            }

        },
        error: function (Error) {
            $("#msjError").html("Error al cambiar el estado");
            $('#ModalError').modal('show');
        }
    });


}

function ConfirmarEliminarProducto(IdProducto) {
    $("#IdProductoSeleccionado").val(IdProducto);
    $("#msjConfProd").html("¿Desea eliminar este registro?");
    $('#ModalConfirmacionProd').modal('show');

}

function EditarProducto(Id) {
    sessionStorage.setItem("IdProdEditar", Id);
    window.location.href = "/Mantenimientos/ActualizarProducto";
}



function EliminarProducto() {
    var Id = $("#IdProductoSeleccionado").val();
    $('#ModalConfirmacionProd').modal('hide');
    if (Id !== null || Id !== undefined) {
        $.ajax({
            type: "POST",
            dataType: "JSON",
            url: "/Mantenimientos/EliminarProducto/",
            data: { IdProducto: Id },
            success: function () {
                $("#msjCorrecto").html("Producto eliminado correctamente");
                $('#ModalCorrecto').modal('show');
                ObtenerTodosProductos();
            },
            error: function () {
                $("#msjError").html("Error al eliminar el producto");
                $('#ModalError').modal('show');
            }
        });

    }
}

$(document).ready(function () {
    ObtenerTodosProductos();
});