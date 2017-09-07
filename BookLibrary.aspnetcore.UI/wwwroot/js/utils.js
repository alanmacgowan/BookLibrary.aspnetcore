
$(document).ready(function () {

    $('body').tooltip({
        selector: '[data-toggle=tooltip]'
    });

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