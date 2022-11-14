

function Collapse() {
    $('.sidebar').hide();
    $('#top').hide();
}

function Expand() {
    $('.sidebar').show();
    $('#top').show();
}

function ScrollIntoView(target) {
    const element = document.getElementById(target);

    $('#navbar ul li a').each(function () {

        if ($(this).attr('id') == 'nav' + target) {
            $(this).addClass('active');
        } else {
            $(this).removeClass('active');
        }
    });

    element.scrollIntoView();
}