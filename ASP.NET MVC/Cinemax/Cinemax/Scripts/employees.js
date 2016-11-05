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
        format: "MM/DD/YYYY",
        locale: 'es'
    });
});