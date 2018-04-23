$(document).ready(function () {

    $('#account-btn').click(function (e) {
        if ($('#search').hasClass('active')) {
            $('#search').removeClass('active');
            $('#search-btn').removeClass('active');
            $('#search-btn').removeClass('inverse');

            setTimeout(
                function () {
                    $('#account-btn').toggleClass('active');
                    $('#account-btn').toggleClass('inverse');
                    $('#account').toggleClass('active');
                }, 1000);

        } else {
            $('#account-btn').toggleClass('active');
            $('#account-btn').toggleClass('inverse');
            $('#account').toggleClass('active');
        }
    });

    $('#search-btn').click(function (e) {
        if ($('#account').hasClass('active')) {
            $('#account').removeClass('active');
            $('#account-btn').removeClass('active');
            $('#account-btn').removeClass('inverse');

            setTimeout(
                function () {
                    $('#search-btn').toggleClass('active');
                    $('#search-btn').toggleClass('inverse');
                    $('#search').toggleClass('active');
                }, 1000);

        } else {
            $('#search-btn').toggleClass('active');
            $('#search-btn').toggleClass('inverse');
            $('#search').toggleClass('active');
        }
    });

    //MOVE THIS TO MAINMAV.SLIDEOUT AND PUT IN BUNDLE
    $('#genre-btn').click(function (e) {
        var button = $('#genre-btn');

        if (!button.hasClass('inverse')) {
            setUpNav(button);
            $('#genre-nav').addClass('active');
        }
        else {
            resetNav();
        }
    });

    $('#medium-btn').click(function (e) {
        var button = $('#medium-btn');

        if (!button.hasClass('inverse')) {
            setUpNav(button);
            $('#medium-nav').addClass('active');
        }
        else {
            resetNav();
        }
    });

    $('#artist-btn').click(function (e) {
        var button = $('#artist-btn');

        if (!button.hasClass('inverse')) {
            setUpNav(button);
            $('#artist-nav').addClass('active');
        }
        else {
            resetNav();
        }

    });

    $('#year-btn').click(function (e) {
        var button = $('#year-btn');

        if (!button.hasClass('inverse')) {
            setUpNav(button);
            $('#year-nav').addClass('active');
        }
        else {
            resetNav();
        }
    });

    function setUpNav(button) {
        $('.nav-button').removeClass("inverse");
        $('.nav-slider-inner').removeClass("active");
        button.addClass("inverse");

        if (!$('#nav-slider').hasClass('active')) {
            $('#nav-slider').addClass('active');
        }
    }

    function resetNav() {
        $('#nav-slider').removeClass('active');
        $('.nav-button').removeClass("inverse");
        $('.nav-slider-inner').removeClass("active");
    }

    //Inner nav swapping
     $(".nav-slider-inner").on("click", ".fa-angle-right", function () {
         var menu = $(this).parent();
         var currentli = menu.find('.selected');
         console.log(currentli);
         var nextli = currentli.next();

         if (nextli.length === 0) {
             nextli = menu.children('ul').children('li').first();
         }

         
         nextli.addClass('selected');
         currentli.removeClass('selected');
         currentli = nextli;
         if (menu.is($("#genre-nav"))) {
             $("#currentGenre").html(currentli.html());
         } else if (menu.is($("#medium-nav"))) {
             $("#currentMedium").html(currentli.html());
         }
         
    });

     $(".nav-slider-inner").on("click", ".fa-angle-left", function () {
         var menu = $(this).parent();
         var currentli = menu.find('.selected');
         var nextli = currentli.prev();

         if (nextli.length === 0) {
             nextli = menu.children('ul').children('li').last();
         }

         nextli.addClass('selected');
         currentli.removeClass('selected');
         currentli = nextli;
         if (menu.is($("#genre-nav"))) {
             $("#currentGenre").html(currentli.html());
         } else if (menu.is($("#medium-nav"))) {
             $("#currentMedium").html(currentli.html());
         }
     });

});


