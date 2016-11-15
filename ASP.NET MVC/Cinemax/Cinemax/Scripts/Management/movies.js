$(function () {
    $("#grid-movies").bootgrid({
        ajax: true,
        post: function () {
            return {
            };
        },
        url: urlGetMovies,
        formatters: {
            "select": function (column, row) {
                components = '<div title="Seleccionar película"><button class="btn btn-primary" data-id=" ' + row.clave_pel + '">' +
                            '<span class="glyphicon glyphicon-check" aria-hidden="true"></span></button></div>';
                return components;
            }
        },
        labels: {
            all: "Todos",
            infos: "Mostrando del {{ctx.start}} al {{ctx.end}} de {{ctx.total}} elemento(s)",
            loading: "Cargando",
            noResults: "Ningún resultado!",
            refresh: "Refrescar",
            search: "Buscar"
        },
        templates: {
            search: ""
        },
        sorting: false,
        rowCount: 5
    }).on("loaded.rs.jquery.bootgrid", function () {
        $("#grid-movies").find(".btn.btn-primary").on("click", function (e) {
            var id = $(this).data("id");
            rows = $("#grid-movies").bootgrid().data('.rs.jquery.bootgrid').currentRows;
            $.each(rows, function (key, value) {
                if (value.clave_pel == id) {
                    $("#movies-form").clearValidation();
                    $("#clave_pel").val(value.clave_pel);
                    $("#nombre").val(value.nombre);
                    $("#director").val(value.director);
                    $("#genero").val(value.genero);
                    $('input:radio[name="clasificacion"]').attr('checked', false);
                    $('input:radio[name="clasificacion"]').filter('[value="' + value.clasificacion + '"]').attr('checked', true);
                    $("#sinopsis").val(value.sinopsis);
                    $("#add-movie").addClass("disabled");
                    $("#remove-movie").removeClass("disabled");
                    $("#edit-movie").removeClass("disabled");
                    $("#cancel-action").removeClass("disabled");
                }
            });
        });
    });

    $('#buttons-container .btn').bind('click', function () {
        action = $(this).data('action');
        if (action !== 'Cancel') {
            $('#Accion').val(action);
        }
        else {
            $("#movies-form").clearValidation();
            $("#add-movie").removeClass("disabled");
            $("#remove-movie").addClass("disabled");
            $("#edit-movie").addClass("disabled");
            $("#cancel-action").addClass("disabled");
            return false;
        }
    });

    $('.selectpicker').selectpicker({});
});