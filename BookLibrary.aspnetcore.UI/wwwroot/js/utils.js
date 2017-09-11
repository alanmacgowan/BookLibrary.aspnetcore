
$(document).ready(function () {

    $('body').tooltip({
        selector: '[data-toggle=tooltip]'
    });

    $('.datectrl').mask('00/00/0000');
    $('.time').mask('00:00:00');
    $('.date_time').mask('00/00/0000 00:00:00');
    $('.isbn13').mask('000-0000000000');
    $('.phone').mask('0000-0000');
    $('.phone_us').mask('(000) 000-0000');
    $('.money').mask('000.000.000.000.000,00', { reverse: true });

});

(function ($, window) {
    'use strict';

    var utils = window.utils || {};

    var form = (function () {

        function saveEdit(controller, data) {
            saveData(controller, data, 'Edit');
        }

        function saveCreate(controller, data) {
            saveData(controller, data, 'Create');
        }

        function saveData(controller, data, action) {
            var values = data || $('form').serializeObject();
            var validator = $("form").validate();
            if (validator.form()) {
                utils.http.post({ url: '/' + controller + '/' + action, data: values }, function (response) {
                    if (response.data) {
                        for (var key in response.data) {
                            var elem = $('#' + key);
                            if (elem != null) {
                                $(elem).addClass('invalid-field').removeClass('valid-field');
                            }                      
                        }
                        toastr.warning('There are some invalid fields.');
                    } else {
                        toastr.success('Successfully created.');
                        location.href = '/' + controller;
                    }
                });
            } else {
                validator.invalidElements().each(function (index, element) {
                    $(element).addClass('invalid-field').removeClass('valid-field');
                });
                validator.validElements().each(function (index, element) {
                    $(element).addClass('valid-field').removeClass('invalid-field');
                });
                toastr.warning('There are some invalid fields.');
            }
        }

        return {
            saveCreate: saveCreate,
            saveEdit: saveEdit
        }

    })();

    var ui = (function () {

        var spinner = new Spinner();

        function showSpinner() {
            var target = document.getElementById('main');
            spinner.spin(target);
        }

        function hideSpinner() {
            spinner.stop();
        }

        return {
            showSpinner: showSpinner,
            hideSpinner: hideSpinner
        }

    })();

    var http = (function () {

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
            var config = { headers: { 'Content-Type': 'application/json; charset=utf-8' } };
            var data = options.data || null;
            var successFunction = successCallback || successCallbackFunction;
            var errorFunction = errorCallback || errorCallbackFunction;

            ui.showSpinner();

            axios.post(options.url, data, config)
                .then(function (response) {
                    successFunction(response);
                    ui.hideSpinner();
                })
                .catch(function (error) {
                    errorFunction();
                    ui.hideSpinner();
         });
        }

        function get(options, successCallback, errorCallback) {
            var successFunction = successCallback || successCallbackFunction;
            var errorFunction = errorCallback || errorCallbackFunction;

            ui.showSpinner();

            axios.get(options.url)
                .then(function (response) {
                    successFunction(response);
                    ui.hideSpinner();
                })
                .catch(function (error) {
                    errorFunction();
                    ui.hideSpinner();
            });
        }

        return {
            post: post,
            get: get
        }

    })();



    utils = (function () {
        return {
            constructor: utils,
            form: form,
            http: http,
            ui: ui
        };
    })();

    window.utils = utils;


})($, window);