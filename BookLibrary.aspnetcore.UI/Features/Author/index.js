var authorsTable = null;

$(document).ready(function () {

    authorsTable = $('#authorsTable').DataTable({
        responsive: true,
        "dom": 'Rlfrtip',
        "aoColumnDefs": [
            { 'bSortable': true, 'aTargets': [0] }
        ],
        "aoColumns": [
            {
                "mData": "id",
                "className": "never"
            }, {
                "sTitle": "AuthorName",
                "mData": "authorName"
            }, {
                "sTitle": "Birth Date",
                "mData": "birthDate",
                "render": function (data, type, row) {
                    return data != null ? moment(data).format("MM/DD/YYYY") : '';
                }
            }, {
                "sTitle": "Country",
                "mData": "country"
            }, {
                "sTitle": "",
                "render": function (data, type, row) {
                    var cell = '';
                    cell += '<a class="btn btn-default" asp-action="Edit" href="/Author/Edit/' + row.id + '" data-toggle="tooltip" title="Edit"><i class="fa fa-pencil"></i></a>&nbsp;';
                    cell += '<a class="btn btn-info" asp-action="Details" href="javascript:void(0)" onclick="showDetails(' + row.id + ')" data-toggle="tooltip" title="Details"><i class="fa fa-info-circle"></i></a>&nbsp;';
                    cell += '<a class="btn btn-danger" href="javascript:void(0)" onclick="deleteAuthor(' + row.id + ')" data-toggle="tooltip" title="Delete"><i class="fa fa-trash-o"></i></a>';
                    return cell;
                },
                "sName": "Select",
                "targets": 0,
                "width": "20%"
            }
        ],
        "initComplete": function (settings, json) {
            bindTable();
        }

    });

});

function bindTable() {

    utils.http.get({ 'url': '/Author/GetAuthors' }, function (response) {
        authorsTable.clear().draw();
        if (response.data.length > 0) {
            authorsTable.rows.add(response.data).draw();
        }
    });

}

function deleteAuthor(id) {
    BootstrapDialog.show({
        title: 'Delete Author',
        message: 'Do you want to delete this author?',
        buttons: [{
            label: 'Yes',
            cssClass: 'btn-success',
            action: function (dialog) {

                utils.http.post({ 'url': '/Author/DeleteAuthor/' + id }, function (response) {
                    if (response) {
                        toastr.success('Author successfully deleted.');
                        bindTable();
                    } else {
                        toastr.error('There was an error processing the operation.');
                    }
                });

                dialog.close();
            }
        }, {
            label: 'No',
            cssClass: 'btn-danger',
            action: function (dialog) {
                dialog.close();
            }
        }]
    });
};

function showDetails(id) {
    utils.http.get({ 'url': '/Author/DetailsPartial/' + id }, function (response) {
        if (response.data) {
            BootstrapDialog.show({
                title: 'Details',
                message: $('<div></div>').html(response.data),
                buttons: [{
                    label: 'Close',
                    cssClass: 'btn-primary',
                    action: function (dialog) {
                        dialog.close();
                    }
                }]
            });
        }
    });
};
