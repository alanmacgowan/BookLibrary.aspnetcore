
$(document).ready(function () {

    var offset = 300,
        offset_opacity = 1200,
        scroll_top_duration = 700,
        $back_to_top = $('.cd-top');

    $(window).scroll(function () {
        ($(this).scrollTop() > offset) ? $back_to_top.addClass('cd-is-visible') : $back_to_top.removeClass('cd-is-visible cd-fade-out');
        if ($(this).scrollTop() > offset_opacity) {
            $back_to_top.addClass('cd-fade-out');
        }
    });

    $back_to_top.on('click', function (event) {
        event.preventDefault();
        $('body,html').animate({
            scrollTop: 0,
        }, scroll_top_duration
        );
    });

});

(function ($, window) {
    'use strict';

    var utils = window.utils || {};

    function post(options) {
        var config = { headers: { 'Content-Type': 'application/json' } };
        var data = options.data || null;
        var successMessage = options.successMessage || 'Successful operation.';
        var errorMessage = options.errorMessage || 'There was an error processing the operation.';

        axios.post(options.url, data, config)
            .then(function (response) {
                if (response) {
                    toastr.success(successMessage);
                } else {
                    toastr.error(errorMessage);
                }
            })
            .catch(function (error) {
                toastr.error(errorMessage);
            });
    }

    utils = (function () {
        return {
            constructor: utils,
            post: post,
        };
    })();

    window.utils = utils;


})($, window);