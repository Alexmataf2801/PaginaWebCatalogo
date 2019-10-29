


function ObtenerMenuPublico() {
    var Menu = '';
    $.ajax({
        type: "GET",
        url: "/Home/ObtenerMenuPublico",
        data: {},
        dataType: "JSON",
        success: function (data) {
            if (data.length > 0) {
                $.each(data, function (key, value) {
                    if (value.IsPadre) {
                        Menu = Menu + "<li class='menu__item dropdown'>";

                        var Hijos = data.filter(data => data.IdPadre === value.IdMenu);
                        if (Hijos.length > 0) {

                            Menu = Menu + "<a class='menu__link'  href='#' class='dropdown-toggle' data-toggle='dropdown'>" + value.Nombre + " <b class='caret'></b></a>";
                            Menu = Menu + "<ul class='dropdown-menu agile_short_dropdown'>";

                            $.each(Hijos, function (key2, value2) {

                                Menu = Menu + " <li><a href='" + value2.Url + "?TipoProducto=" + value2.TipoProducto + "&SubTipoProducto=" + value2.SubTipo +"'>" + value2.Nombre + "</a></li>";
                            });
                            Menu = Menu + "</ul>";

                        } else {

                            Menu = Menu + "<a class='menu__link' href='" + value.Url + "'>" + value.Nombre + "</a></li >";
                        }
                    }
                });

                $("#MenuPublico").html(Menu);
            }
        },
        error: function (error) {
            console.log(error);
        }
    });
}

$(document).ready(function () {
    ObtenerMenuPublico();

});