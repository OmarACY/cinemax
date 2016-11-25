cinema = -1;
movie = -1;
function updateCinema(selection) {
    if (selection !== undefined) {
        cinema = selection;
    }
    else {
        cinema = $('#clave_cin').find("option:selected").text();
    }
    $('#clave_pel').selectpicker('val', null);
    $('#clave_fun').selectpicker('val', null);
    $('#clave_sal').val('');
}

function updateMovie(selection) {
    if (selection !== undefined) {
        movie = selection;
    }
    else {
        movie = $('#clave_pel').find("option:selected").text();
    }
}

function updateInitHour(selection) {
    var selector = '.cinema-' + cinema + '.movie-' + movie;
    $('#clave_fun').find('option').hide();
    $('#clave_fun').find(selector.toString()).show();
    $('#clave_fun').selectpicker('refresh');
    $('#clave_fun').selectpicker('val', null);
    $('#clave_sal').val('');
}

function updateLounge() {
    var lounge = $('#clave_fun').find("option:selected").data('sala');
    console.log(lounge);
    $('#clave_sal').val(lounge);
}

$(function () {
    $('.selectpicker').selectpicker({});

    $('#clave_cin').on('changed.bs.select', function (e) {
        updateCinema();
    });

    $('#clave_pel').on('changed.bs.select', function (e) {
        updateMovie();
        updateInitHour();
    });

    $('#clave_fun').on('changed.bs.select', function (e) {
        updateLounge();
    });

    $('.selectpicker').selectpicker('val', null);

    $('.efectivo').bind('click', function () {
        $('#num_tarjeta').prop('disabled', true);
        $('#cod_seguridad').prop('disabled', true);
        $('#mes_ven').prop('disabled', true);
        $('#anio_ven').prop('disabled', true);
    });

    $('.tarjeta').bind('click', function () {
        $('#num_tarjeta').prop('disabled', false);
        $('#cod_seguridad').prop('disabled', false);
        $('#mes_ven').prop('disabled', false);
        $('#anio_ven').prop('disabled', false);
    });

    $('.available-place').bind('click', function () {
        $(this).toggleClass('selected-place');
    });

    $('.efectivo').prop('checked', true);
    $('#num_tarjeta').prop('disabled', true);
    $('#cod_seguridad').prop('disabled', true);
    $('#mes_ven').prop('disabled', true);
    $('#anio_ven').prop('disabled', true);
});