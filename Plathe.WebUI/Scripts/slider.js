$(function () {
    slider.init();
});

var slideTime = 3000;
var animateTime = 1000;

var slider = {

    timer: null,

    animating: false,

    init: function () {
        slider.timer = setTimeout(slider.slide, slideTime);
    },

    slide: function () {

        this.animating = true;

        clearTimeout(slider.timer);

        $("#slider .slide").last().animate({ right: "100%" }, animateTime, function () {

            $(this).parent().prepend($(this));
            $(this).animate({ right: "0" }, 0);

            slider.animating = false;

            slider.timer = setTimeout(slider.slide, slideTime);

        });
    },

    sliderNext: function () {

        if (slider.animating == true)
            return;

        clearTimeout(slider.timer);

        slider.timer = slider.slide();

    },

    sliderPrev: function () {

        if (slider.animating == true)
            return;

        this.animating = true;

        clearTimeout(slider.timer);

        $("#slider .slide").first().animate({ right: "100%" }, 0, function () {

            $(this).parent().append($(this));
            $(this).animate({ right: "0" }, animateTime, function () {

                slider.animating = false;

            });

            slider.timer = setTimeout(slider.slide, slideTime);
        });

    }

};
