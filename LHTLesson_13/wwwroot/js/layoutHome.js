$(function() {
    $('#navbar ul li a').click(function() {
        $('#navbar ul li a').removeClass('active');
        $(this).addClass('active');
    });
});