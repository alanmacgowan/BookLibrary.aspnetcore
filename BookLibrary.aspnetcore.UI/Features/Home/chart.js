$(document).ready(function () {

    utils.http.get({ 'url': '/Home/GetChartData' }, function (response) {

        if (response.data.length > 0) {
            Morris.Line({
                element: 'chart',
                data: response.data,
                xkey: 'year',
                ykeys: ['value'],
                labels: ['value', 'year'],
                resize: true,
                dateFormat: function (d) {
                    return d;
                }
            });
        }

    });

});
