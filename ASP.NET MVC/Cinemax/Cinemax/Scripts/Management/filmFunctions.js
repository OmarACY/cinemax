$(function () {
    $("#grid-functions").bootgrid({
        ajax: true,
        post: function () {
            return {
            };
        },
        url: urlGetFunctions,
        formatters: {
            "select": function (column, row) {
                components = '<div title="Seleccionar función"><button class="btn btn-primary" data-id=" ' + row.clave_cin + '">' +
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
        $("#grid-functions").find(".btn.btn-primary").on("click", function (e) {
            var id = $(this).data("id");
            rows = $("#grid-functions").bootgrid().data('.rs.jquery.bootgrid').currentRows;
            $.each(rows, function (key, value) {
                if (value.clave_cin == id) {
                    $("#functions-form").clearValidation();
                    fechaNacimiento = value.FechaNacGrid.split("/");
                    $("#clave_cin").val(value.clave_cin);
                    $("#add-function").addClass("disabled");
                    $("#remove-function").removeClass("disabled");
                    $("#edit-function").removeClass("disabled");
                    $("#cancel-action").removeClass("disabled");
                }
            });
        });
    });

    $('#fecha').datetimepicker({
        format: "YYYY/MM/DD",
        locale: 'es'
    });

    $('#hora-ini').datetimepicker({
        format: "LT",
        locale: 'es'
    });

    $('#hora-fin').datetimepicker({
        format: "LT",
        locale: 'es'
    });

    $('#buttons-container .btn').bind('click', function () {
        action = $(this).data('action');
        if (action !== 'Cancel') {
            $('#Accion').val(action);
        }
        else {
            $("#functions-form").clearValidation();
            $("#add-function").removeClass("disabled");
            $("#remove-function").addClass("disabled");
            $("#edit-function").addClass("disabled");
            $("#cancel-action").addClass("disabled");
            return false;
        }
    });

    $('.selectpicker').selectpicker({});

    $('#clave_cin').change(function () {
        var selectedText = $(this).find("option:selected").text();
        var cinema = '.cine-' + selectedText;
        $('#clave_sal').find('option').hide();
        $('#clave_sal').find(cinema.toString()).show();
        $('#clave_sal').selectpicker('refresh');
        $('#clave_sal').selectpicker('val', $('#clave_sal').find(cinema.toString())[0].text);
    });

    $('.selectpicker').selectpicker('val', null);
});