var booksTable = null;

$(document).ready(function () {

    booksTable = $('#booksTable').DataTable({
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
                "sTitle": "Title",
                "mData": "title"
            }, {
                "sTitle": "Publish Date",
                "mData": "publishDate",
                "render": function (data, type, row) {
                    return data != null ? moment(data).format("MM/DD/YYYY") : '';
                }
            }, {
                "sTitle": "Category",
                "mData": "category"
            }, {
                "sTitle": "Author",
                "render": function (data, type, row) {
                    var cell = '';
                    cell += '<a href="/Author/Edit/' + row.id + '" data-toggle="tooltip" title="Edit Author">' + row.authorName + '</a>';
                    return cell;
                }
            }, {
                "sTitle": "Publisher",
                "mData": "publisherName"
            }, {
                "sTitle": "",
                "render": function (data, type, row) {
                    var cell = '';
                    cell += '<a class="btn btn-default" asp-action="Edit" href="/Book/Edit/' + row.id + '" data-toggle="tooltip" title="Edit"><i class="fa fa-pencil"></i></a>&nbsp;';
                    cell += '<a class="btn btn-info" asp-action="Details" href="/Book/Details/' + row.id + '" data-toggle="tooltip" title="Details"><i class="fa fa-info-circle"></i></a>&nbsp;';
                    cell += '<a class="btn btn-danger" href="javascript:void(0)" onclick="deleteBook(' + row.id + ')" data-toggle="tooltip" title="Delete"><i class="fa fa-trash-o"></i></a>';
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

    utils.http.get({ 'url': '/Book/GetBooks' }, function (response) {
        booksTable.clear().draw();
        if (response.data.length > 0) {
            booksTable.rows.add(response.data).draw();
        }
    });

}

function deleteBook(id) {
    BootstrapDialog.show({
        title: 'Delete Book',
        message: 'Do you want to delete this book?',
        buttons: [{
            label: 'Yes',
            cssClass: 'btn-success',
            action: function (dialog) {

                utils.http.post({ 'url': '/Book/DeleteBook/' + id }, function (response) {
                    if (response) {
                        toastr.success('Book successfully deleted.');
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