$(document).ready(function () {

    $('#account-btn').click(function (e) {
        if ($('#search').hasClass('active')) {
            $('#search').removeClass('active');
            $('#search-btn').removeClass('active');

            setTimeout(
                function () {
                    $('#account-btn').toggleClass('active');
                    $('#account').toggleClass('active');
                }, 1000);

        } else {
            $('#account-btn').toggleClass('active');
            $('#account').toggleClass('active');
        }
    });

    $('#search-btn').click(function (e) {
        if ($('#account').hasClass('active')) {
            $('#account').removeClass('active');
            $('#account-btn').removeClass('active');

            setTimeout(
                function () {
                    $('#search-btn').toggleClass('active');
                    $('#search').toggleClass('active');
                }, 1000);

        } else {
            $('#search-btn').toggleClass('active');
            $('#search').toggleClass('active');
        }
    });
});


