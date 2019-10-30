

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

function ObtenerDetalleProducto(Id) {
    $.ajax({
        type: "GET",
        datatype: "JSON",
        data: { IdProducto: Id },
        url: "/Producto/ObtenerDetalleProducto/",
        success: function (info) {
            if (info.length > 0) {
                window.location.href = "/Producto/DetalleProducto?IdProducto=" + Id;
            }

        },
        error: function (error) {
            console.log(error);
        }
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
            //var objeto = JSON.parse(info);

            // $('#DetalleCarrito').dataTable().fnDestroy();
            // $("#DetalleCarrito").dataTable({
            //    autoWidth: false,
            //    responsive: true,
            //    //dom: 'Bfrtip', // Descomentar para habilitar botones de acciones
            //     lengthChange: false, // Habilita combo de opciones para mostrar
            //     language: {
            //         "url": "../Content/Spanish.json"
            //     },

            //    data: info,
            //    columns: [
            //        { data: 'Codigo'},
            //        { data: 'CantidadTotal'},
            //        { data: 'NombreProducto'},
            //        { data: 'PrecioProducto'},
            //        {
            //            data: null,
            //            sortable: false,
            //            render: function (data, type, full) {
            //                return "<button class='btn btn-danger fa fa-trash' onclick='EliminarProductoCarrito(" + data["IdProducto"] + ")'></button>";
            //            }
            //        }

            //    ]


            // });

            //if (info.length > 0) {

            //    $.each(info, function (key, value) {
            //        total = total + parseFloat(info[key].PrecioProducto);
            //    });

            //    $("#Total").css("display", "block");
            //} else {
            //    $("#Total").css("display", "none");
            //}

            //$('#Carrito').modal('show');

            if (info.length > 0) {

                Detalle = Detalle + ("<tr ><th style='text-align:center; background-color:#0074D9;color:#ffffff'>Cantidad</th><th style='text-align:center; background-color:#0074D9;color:#ffffff'>Nombre</th><th style='text-align:center; background-color:#0074D9;color:#ffffff'>Precio</th><th style='text-align:center; background-color:#0074D9;color:#ffffff'>Accion</th></tr>");

                $.each(info, function (key, value) {
                    //Detalle = Detalle + "<tr  style='border: 1px solid #ddd'><td>" + info[key].Codigo + "</td>";
                    Detalle = Detalle + "<td>" + info[key].CantidadTotal + "</td>";
                    Detalle = Detalle + "<td>" + info[key].NombreProducto + "</td>";
                    Detalle = Detalle + "<td>" + info[key].Moneda + currencyFormat(parseFloat(info[key].PrecioProducto)) + "</td>";
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
            alert("Error!");
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
            }
            else {
                $("#msjError").html("Fallo el registro del producto");
                $('#ModalError').modal('show');
            }

        },
        error: function (error) {
            alert("Error!");
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
            alert("Error!");
        }
    });


}


function currencyFormat(num) {
    return num.toFixed(2).replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1,');
}

