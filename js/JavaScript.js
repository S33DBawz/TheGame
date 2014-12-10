$(function () {

    SlideLoginBoxes();

    ToolTipStats();

    ToolTipEquipment();

    ToolTipInventory();

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

function ToolTipStats() {

    var item = $('.stat-unit');

    item.hover(function() {

        $('.tooltip').show();
        $('.tooltip ul').hide();
        $('.tooltip p').hide();


        var $this = $(this),
            itemTitle = $this.find('.stat-title').text(),
            itemDesc = $this.data('description');

        $('.tooltip h6').text(itemTitle);
        $('.tooltip blockquote').text(itemDesc);

    });

    item.mouseleave(function() {

        $('.tooltip').hide();
        $('.tooltip ul').show();
        $('.tooltip p').show();



    });

};

function ToolTipEquipment() {

};

function ToolTipInventory() {

    var item = $('.sidebar ul li img');

    item.hover(function () {

        $('.tooltip').show();

        var $this = $(this),
            itemTitle = $this.data('title'),
            itemStats = $this.data('stats'),
            itemDesc = $this.data('desc'),
            itemPrice = $this.data('price');

        $('.tooltip h6').text(itemTitle);
        $('.tooltip ul li').text(itemStats);
        $('.tooltip blockquote').text(itemDesc);
        $('.tooltip p span').text(itemPrice);

    });

    item.mouseleave(function () {

        $('.tooltip').hide();

    });
};