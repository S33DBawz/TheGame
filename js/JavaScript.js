$(function () {

    SlideLoginBoxes();

});

function SlideLoginBoxes() {

    var actionBox = $('.action-box'),
        loginBox = $('.login-box'),
        signupBox = $('.signup-box');


    $('.login').click(function () {

        actionBox.addClass('slide');
        loginBox.addClass('slide');
        signupBox.removeClass('slide');

    });


    $('.signup').click(function () {

        actionBox.addClass('slide');
        signupBox.addClass('slide');
        loginBox.removeClass('slide');

    });

    $(".back").click(function () {

        signupBox.removeClass('slide');
        loginBox.removeClass('slide');
        actionBox.removeClass('slide'); RemoveSliderClass();

    });

    $('.overlay').click(function () {

        signupBox.removeClass('slide');
        loginBox.removeClass('slide');
        actionBox.removeClass('slide');

    });

    $('aside').removeClass('slide-in');


}