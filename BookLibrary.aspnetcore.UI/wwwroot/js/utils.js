
$(document).ready(function () {

    $('body').tooltip({
        selector: '[data-toggle=tooltip]'
    });

    $('.datectrl').mask('00/00/0000');
    $('.time').mask('00:00:00');
    $('.date_time').mask('00/00/0000 00:00:00');
    $('.isbn13').mask('000-0000000000');
    $('.phone').mask('0000-0000');
    $('.phone_with_ddd').mask('(00) 0000-0000');
    $('.phone_us').mask('(000) 000-0000');
    $('.mixed').mask('AAA 000-S0S');
    $('.cpf').mask('000.000.000-00', { reverse: true });
    $('.money').mask('000.000.000.000.000,00', { reverse: true });

});

(function ($, window) {
    'use strict';

    var utils = window.utils || {};

    var spinner = new Spinner();

    function showSpinner() {
        var target = document.getElementById('main');
        spinner.spin(target);
    }

    function hideSpinner() {
        spinner.stop();
    }

    var successMessage = 'Successful operation.';
    var errorMessage = 'There was an error processing the operation.';

    function successCallbackFunction(response) {
        if (response) {
            toastr.success(successMessage);
        } else {
            toastr.error(errorMessage);
        }
    }

    function errorCallbackFunction() {
        toastr.error(errorMessage);
    }

    function post(options, successCallback, errorCallback) {
        var config = { headers: { 'Content-Type': 'application/json' } };
        var data = options.data || null;
        var successFunction = successCallback || successCallbackFunction;
        var errorFunction = errorCallback || errorCallbackFunction;

        showSpinner();

        axios.post(options.url, data, config)
            .then(function (response) {
                successFunction(response);
                hideSpinner();
            })
            .catch(function (error) {
                errorFunction();
            });
    }

    function get(options, successCallback, errorCallback) {
        var successFunction = successCallback || successCallbackFunction;
        var errorFunction = errorCallback || errorCallbackFunction;

        showSpinner();

        axios.get(options.url)
            .then(function (response) {
                successFunction(response);
                hideSpinner();
           })
            .catch(function (error) {
                errorFunction();
            });
    }

    utils = (function () {
        return {
            constructor: utils,
            post: post,
            get: get,
            showSpinner: showSpinner,
            hideSpinner: hideSpinner
        };
    })();

    window.utils = utils;


})($, window);