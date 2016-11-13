$(function () {
    $("#grid-clients").bootgrid({
        ajax: true,
        post: function () {
            return {
            };
        },
        url: urlGetClients,
        formatters: {
            "select": function (column, row) {
                components = '<div title="Seleccionar cliente"><button class="btn btn-primary" data-id=" ' + row.clave_mem + '">' +
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
        $("#grid-clients").find(".btn.btn-primary").on("click", function (e) {
            var id = $(this).data("id");
            rows = $("#grid-clients").bootgrid().data('.rs.jquery.bootgrid').currentRows;
            $.each(rows, function (key, value) {
                if (value.clave_mem == id) {
                    fechaNacimiento = value.fecha_nacimiento_grid.split("/");
                    $("#clave_mem").val(value.clave_mem);
                    $("#tipo").val(value.tipo);
                    $("#puntos").val(value.puntos);
                    $("#nombre").val(value.nombre);
                    $("#app").val(value.app);
                    $("#apm").val(value.apm);
                    $("#fecha_nac").val(fechaNacimiento.pop() + '/' + fechaNacimiento.pop() + '/' + fechaNacimiento.pop());
                    $("#colonia").val(value.colonia);
                    $("#calle").val(value.calle);
                    $("#numero").val(value.numero);
                    $("#add-client").addClass("disabled");
                    $("#remove-client").removeClass("disabled");
                    $("#edit-client").removeClass("disabled");
                    $("#cancel-action").removeClass("disabled");
                }
            });
        });
    });

    $('#fecha-nacimiento').datetimepicker({
        format: "YYYY/MM/DD",
        locale: 'es'
    });

    $('#buttons-container .btn').bind('click', function () {
        action = $(this).data('action');
        if (action !== 'Cancel') {
            $('#Accion').val(action);
        }
        else {
            $("#clients-form").clearValidation();
            $("#add-client").removeClass("disabled");
            $("#remove-client").addClass("disabled");
            $("#edit-client").addClass("disabled");
            $("#cancel-action").addClass("disabled");
            return false;
        }
    });

    $('.selectpicker').selectpicker({});
});