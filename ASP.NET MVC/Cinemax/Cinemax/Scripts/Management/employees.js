$(function () {
    $("#grid-employees").bootgrid({
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
        sorting: false
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
            $("#employees-form").clearValidation();
            return false;
        }
    });
});