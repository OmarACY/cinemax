function seleccionaSalas(clave_cin) {
        var cinema = '.cine-' + clave_cin;
        $('#sala').find('option').hide();
        $('#sala').find(cinema.toString()).show();
        $('#sala').selectpicker('refresh');
        $('#sala').selectpicker('val', $('#sala').find(cinema.toString())[0].text);
    
}

$(function () {
    $("#grid-teathers").bootgrid({
        ajax: true,
        post: function () {
            return {
            };
        },
        url: urlGetTeathers,
        formatters: {
            "select": function (column, row) {
                components = '<div title="Seleccionar cine"><button class="btn btn-primary" data-id=" ' + row.clave_cin + '">' +
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
        $("#grid-teathers").find(".btn.btn-primary").on("click", function (e) {
            var id = $(this).data("id");            
            rows = $("#grid-teathers").bootgrid().data('.rs.jquery.bootgrid').currentRows;
            $.each(rows, function (key, value) {
                if (value.clave_cin == id) {
                    seleccionaSalas(value.clave_cin);
                    $("#teathers-form").clearValidation();
                    $("#clave_cin").val(value.clave_cin);
                    $("#nombre").val(value.nombre);
                    $("#telefono").val(value.telefono);
                    $("#num_salas").val(value.num_salas);
                    $("#colonia").val(value.colonia);
                    $("#calle").val(value.calle);
                    $("#numero").val(value.numero);
                    $("#add-teather").addClass("disabled");
                    $("#edit-lounges").removeClass("disabled");
                    $("#remove-teather").removeClass("disabled");
                    $("#edit-teather").removeClass("disabled");
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
            $("#teathers-form").clearValidation();
            $("#add-teather").removeClass("disabled");
            $("#edit-lounges").addClass("disabled");
            $("#remove-teather").addClass("disabled");
            $("#edit-teather").addClass("disabled");
            $("#cancel-action").addClass("disabled");
            return false;
        }
    });

    $('#edit-lounges').click(function () {
        $('#cupoSalas').modal("show");
    });

    $('.selectpicker').selectpicker({});

    $('#sala').on('changed.bs.select', function (e) {
        
    });

    $('.selectpicker').selectpicker('val', null);

});