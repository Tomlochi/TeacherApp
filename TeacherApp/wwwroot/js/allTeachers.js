function hide(a) {
    $(a).addClass('hidden');
}
function show() {
    if ($('.btaval').hasClass('hidden')) {
        $('.btaval').removeClass('hidden');
    }
}
function test() {
    $(".formtest").submit(function (e) {
        var result = $(this).serialize();
        alert(result);
        e.preventDefault();
    });
}