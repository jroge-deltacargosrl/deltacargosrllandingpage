$(document).ready(function () {
    $('#quotationForms').children('div').hide();
    $('#quotationForms').children('#4').show();
    //$('#quotationForms').children('.weight-volume').show();
    $('#quotationForms').children('.comment').show();
    $('#servicesSelect').on('change', function () {

        

        var s = "#" + $(this).val();
        $('#quotationForms').children('div').hide();
        var divsNotSelect = $('#quotationForms').children('div');
        // limpiar los campos de texto
        divsNotSelect.each(function (index) {
            $(this).find('input').val('');
        });
        //divsNotSelect.find('input:text').val('');

        $('#quotationForms').children(s).show();
        if (s != "#2") {
            $('#quotationForms').children('.weight-volume').show();
            if (s == "#5") {
                $('.urbanRoute').show();
            } else {
                $('.urbanRoute').hide();
            }
        }
        $('#quotationForms').children('.comment').show();
    });
    /*var $selects = $('select');
    $selects.on('change', function () {

        var $select = $(this),
            $options = $selects.not($select).find('option'),
            selectedText = $select.children('option:selected').text();
        var $optionsToDisable = $options.filter(function () {
            return $(this).text() == selectedText;
        });
        $optionsToDisable.prop('disabled', true);*/
    var $selects = $('select');
    $selects.on('change', function () {
        $("option", $selects).prop("disabled", false);
        $selects.each(function () {
            var $select = $(this),
                $options = $selects.not($select).find('option'),
                selectedText = $select.children('option:selected').text();
            $options.each(function () {
                if ($(this).text() == selectedText) {
                    $(this).prop("disabled", true);
                }
            });
        });
    });
    //$selects.eq(0).trigger('change');
});


