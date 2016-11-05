$.fn.clearValidation = function () {
    var v = $(this).validate();

    $('input.form-control', this).each(function () {
        $(this).val('');
        v.successList.push(this);
        v.showErrors();
    });
    v.resetForm();
    v.reset();
};