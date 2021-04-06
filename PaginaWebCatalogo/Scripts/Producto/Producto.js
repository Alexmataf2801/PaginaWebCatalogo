

function ObtenerProductosRandom() {
    $.ajax({
        type: "GET",
        datatype: "JSON",
        data: {},
        url: "/Producto/ObtenerProductosRandom/",
        success: function (info) {
            console.log(info);
        },
        error: function (error) {
            console.log(error);
        }
    });
}

function DetalleProducto(Id) {
    $.ajax({
        type: "GET",
        datatype: "JSON",
        data: { IdProducto: Id },
        url: "/Producto/DetalleProducto/",
        //success: function (info) {
        //    if (info.length > 0) {
        //        window.location.href = "/Producto/DetalleProducto?IdProducto=" + Id;
        //    }

        //},
        //error: function (error) {
        //    console.log(error);
        //}
    });
}

function ObtenerCarrito(a) {
    var Detalle = '';
    var total = 0;

    $.ajax({
        type: "GET",
        datatype: "JSON",
        url: '/Producto/ObtenerProductosCarrito/',
        data: {},
        success: function (info) {

            if (info.length > 0) {

                //var TablaCarrito = $('#DetalleCarrito').DataTable(
                //    {
                //        autoWidth: false,
                //        dom: 'frtip',
                //        lengthChange: false,
                //        "language": {
                //            "url": "../../Content/Spanish.json"
                //        },
                //        retrieve: true,
                //        responsive: true,
                //        searching: true
                //    }
                //);

                //TablaCarrito.clear().draw();

                //$(info).each(function (key, value) {
                //    var estado = '';
                   
                //    var Cantidad = info[key].CantidadTotal;
                //    var Nombre = info[key].NombreProducto;
                //    var Moneda = info[key].Moneda + currencyFormat(parseFloat(info[key].PrecioProducto));
                //    var Imagen = "<img style='max-width: 75px; max-height: 100px' src=" + info[key].UrlImagen +" class='responsive'>";
                //    var Eliminar = "<button class='btn btn-danger fa fa-trash' onclick='EliminarProductoCarrito(" + info[key].IdProducto + ")' ></button>";

                //    TablaCarrito.row.add([Cantidad, Nombre, Moneda, Imagen, Eliminar]).draw();
                //    total = total + parseFloat(info[key].PrecioProducto);
                //});


                Detalle = Detalle + ("<tr ><th style='text-align:center; background-color:#0074D9;color:#ffffff'>Cantidad</th><th style='text-align:center; background-color:#0074D9;color:#ffffff'>Nombre</th><th style='text-align:center; background-color:#0074D9;color:#ffffff'>Precio</th><th style='text-align:center; background-color:#0074D9;color:#ffffff'>Imagen</th><th style='text-align:center; background-color:#0074D9;color:#ffffff'>Accion</th></tr>");

                $.each(info, function (key, value) {
                    Detalle = Detalle + "<td>" + info[key].CantidadTotal + "</td>";
                    Detalle = Detalle + "<td>" + info[key].NombreProducto + "</td>";
                    Detalle = Detalle + "<td>" + info[key].Moneda + currencyFormat(parseFloat(info[key].PrecioProducto)) + "</td>";
                    Detalle = Detalle + "<td><img style='max-width: 75px; max-height: 100px' src=" + info[key].UrlImagen +" class='responsive'></td>";
                    Detalle = Detalle + "<td><button class='btn btn-danger fa fa-trash' onclick='EliminarProductoCarrito(" + info[key].IdProducto + ")' ></button></td></tr>";
                    total = total + parseFloat(info[key].PrecioProducto);
                });

                $("#Total").html("Total: " + info[0].Moneda + currencyFormat(total));
                $("#Total").css("display", "block");
                $("#btnPagar").css("display", "block");
                $("#MensajeCarrito").css("display", "none");


            } else {
                $("#MensajeCarrito").html("<p style='text-align:center; color:#000000'>Su carrito no tiene registrado ningun producto</p>");
                $("#MensajeCarrito  ").css("display", "block");
                $("#Total  ").css("display", "none");
                $("#btnPagar  ").css("display", "none");
            }

            $('#ModalPerfil').modal('hide');
            $("#DetalleCarrito").html(Detalle);
            $('#Carrito').modal('show');

        },
        error: function (error) {
            $("#msjError").html("Error al obtener el carrito");
            $('#ModalError').modal('show');
        }


    });


}

function AgregarAlCarro(IdProducto) {

    $.ajax({
        type: "POST",
        datatype: "JSON",
        url: '/Producto/AgregarProductoCarrito/',
        data: { IdProducto: IdProducto },
        success: function (info) {

            if (info === 1) {

                $("#msjCorrecto").html("Se registro el producto correctamente");
                $('#ModalCorrecto').modal('show');

            } else if (info === -1) {

                $("#msjInfo").html("Debe loguearse para poder agregar productos al carro");
                $('#ModalInformacion').modal('show');

            } else {
                $("#msjError").html("Fallo el registro del producto");
                $('#ModalError').modal('show');
            }

        },
        error: function (error) {
            $("#msjError").html("Error al agregar producto al carrito");
            $('#ModalError').modal('show');
        }
    });


}

function EliminarProductoCarrito(IdProducto) {

    $.ajax({
        type: "POST",
        datatype: "JSON",
        url: '/Producto/EliminarProductoCarrito/',
        data: { IdProducto: IdProducto },
        success: function (info) {

            if (info) {

                $("#DetalleCarrito").empty();
                ObtenerCarrito();

            } else {
                $('#Carrito').modal('hide');
                $("#msjError").html("Fallo la eliminacion del producto");
                $('#ModalError').modal('show');
            }

        },
        error: function (error) {
            $("#msjError").html("Error al eliminar un producto del carrito");
            $('#ModalError').modal('show');
        }
    });


}


function currencyFormat(num) {
    return num.toFixed(2).replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1,');
}

