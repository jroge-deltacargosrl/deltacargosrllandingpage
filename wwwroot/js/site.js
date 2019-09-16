// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

jQuery(document).ready(function () {

    // code: animation color "<li>"
    var $value = $('#top_menu li > a > span').click(function () {
        $value.removeClass('selected');
        $(this).addClass('selected');
    });




});

