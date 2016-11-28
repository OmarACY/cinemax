
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
                    $("#teathers-form").clearValidation();
                    $("#clave_cin").val(value.clave_cin);
                    $("#nombre").val(value.nombre);
                    $("#telefono").val(value.telefono);
                    $("#num_salas").val(value.num_salas);
                    $("#colonia").val(value.colonia);
                    $("#calle").val(value.calle);
                    $("#numero").val(value.numero);
                    $("#num_salas").prop("disabled", true);
                    $("#add-teather").addClass("disabled");
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
            $("#num_salas").prop("disabled", false);
            return false;
        }
    });

    $('.selectpicker').selectpicker({});

    $('#sala').on('changed.bs.select', function (e) {
        
    });

    $('.selectpicker').selectpicker('val', null);

});