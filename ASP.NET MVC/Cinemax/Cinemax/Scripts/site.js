$.fn.clearValidation = function () {
    var v = $(this).validate();

    $('input.form-control', this).each(function () {
        $(this).val('');
        v.successList.push(this);
        v.showErrors();
    });
    $('textarea.form-control').each(function () {
        $(this).val('');
        v.successList.push(this);
        v.showErrors();
    });
    $('input:radio.radio-inline').each(function () {
        $(this).attr('checked', false);
        v.successList.push(this);
        v.showErrors();
    });
    v.resetForm();
    v.reset();
};