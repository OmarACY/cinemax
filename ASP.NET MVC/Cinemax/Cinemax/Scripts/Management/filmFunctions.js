function updateLounges(selection) {
    if (selection !== undefined) {
        var cinema = '.cine-' + selection;
        $('#clave_sal').find('option').hide();
        $('#clave_sal').find(cinema.toString()).show();
        $('#clave_sal').selectpicker('refresh');
        $('#clave_sal').selectpicker('val', $('#clave_sal').find(cinema.toString())[0].text);
    }
    else {
        var selectedText = $('#clave_cin').find("option:selected").text();
        var cinema = '.cine-' + selectedText;
        $('#clave_sal').find('option').hide();
        $('#clave_sal').find(cinema.toString()).show();
        $('#clave_sal').selectpicker('refresh');
        $('#clave_sal').selectpicker('val', $('#clave_sal').find(cinema.toString())[0].text);
    }
}

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
                components = '<div title="Seleccionar función"><button class="btn btn-primary" data-id=" ' + row.clave_fun + '">' +
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
                if (value.clave_fun == id) {
                    $("#functions-form").clearValidation();
                    $("#clave_fun").val(value.clave_fun);
                    fecha = value.fecha_grid.split("/");
                    $('#clave_pel').selectpicker('val', value.clave_pel);
                    $('#clave_cin').selectpicker('val', value.clave_cin);
                    updateLounges(value.clave_cin);
                    $('#clave_sal').selectpicker('val', value.clave_sal);
                    $("#fecha").val(fecha.pop() + '/' + fecha.pop() + '/' + fecha.pop());
                    $("#hora_ini").val(value.hora_ini);
                    $("#hora_fin").val(value.hora_fin);
                    $("#add-function").addClass("disabled");
                    $("#remove-function").removeClass("disabled");
                    $("#edit-function").removeClass("disabled");
                    $("#cancel-action").removeClass("disabled");
                }
            });
        });
    });

    $('#fecha-funcion').datetimepicker({
        format: "YYYY/MM/DD",
        locale: 'es'
    });

    $('#hora-ini').datetimepicker({
        format: "hh:mm a",
        locale: 'es'
    });

    $('#hora-fin').datetimepicker({
        format: "hh:mm a",
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
            $('.selectpicker').selectpicker('val', null);
            return false;
        }
    });

    $('.selectpicker').selectpicker({});

    $('#clave_cin').on('changed.bs.select', function (e) {
        updateLounges();
    });

    $('.selectpicker').selectpicker('val', null);

    $("#hora-ini").on("dp.change", function (e) {
        console.log(e.date._d);
        var hours = (e.date._d.getHours() + 1) % 24;
        $('#hora_fin').val((hours == 0 ? "12" : hours > 12 ? hours - 12 : hours) + ":" + e.date._d.getMinutes() + (hours == 0 ? " am" : hours > 12 ? " pm" : " am"));
    });
});