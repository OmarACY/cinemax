$(function () {
    $("#grid-employees").bootgrid({
        ajax: true,
        post: function () {
            return {
            };
        },
        url: urlGetEmployees,
        formatters: {
            "select": function (column, row) {
                components = '<div title="Seleccionar empleado"><button class="btn btn-primary" data-id=" ' + row.Clave + '">' +
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
        $("#grid-employees").find(".btn.btn-primary").on("click", function (e) {
            var id = $(this).data("id");
            rows = $("#grid-employees").bootgrid().data('.rs.jquery.bootgrid').currentRows;
            /*$("#grid-employees").bootgrid().data('.rs.jquery.bootgrid').currentRows.each(function (index) {
                console.log(index + ": " + $(this));
            });*/
            $.each(rows, function (key, value) {
                if (value.Clave == id) {
                    fechaNacimiento = value.FechaNacGrid.split("/");
                    $("#Clave").val(value.Clave);
                    $("#NombreUsuario").val(value.NombreUsuario);
                    $("#Password").val(value.Password);
                    $("#Nombre").val(value.Nombre);
                    $("#ApPaterno").val(value.ApPaterno);
                    $("#ApMaterno").val(value.ApMaterno);
                    $("#FechaNac").val(fechaNacimiento.pop() + '/' + fechaNacimiento.pop() + '/' + fechaNacimiento.pop());
                    $("#Email").val(value.Email);
                    $("#Telefono").val(value.Telefono);
                    $("#Colonia").val(value.Colonia);
                    $("#Calle").val(value.Calle);
                    $("#Numero").val(value.Numero);
                    $("#add-employee").addClass("disabled");
                    $("#remove-employee").removeClass("disabled");
                    $("#edit-employee").removeClass("disabled");
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
            if (action === 'Add')
                $("#Clave").val('2016');
            $('#Accion').val(action);
        }
        else {
            $("#employees-form").clearValidation();
            $("#add-employee").removeClass("disabled");
            $("#remove-employee").addClass("disabled");
            $("#edit-employee").addClass("disabled");
            $("#cancel-action").addClass("disabled");
            return false;
        }
    });
});