
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