
$(document).ready(function () {

    $('select').select2();

    $('.input-group.date').datepicker({
        autoclose: true,
        toggleActive: true
    });

    $('#save').on('click', function () {
        utils.form.saveEdit('Book');
    });

});
