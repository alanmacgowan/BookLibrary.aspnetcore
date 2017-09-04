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
                "sTitle": "Publish Date",
                "mData": "publishDate",
                "render": function (data, type, row) {
                    return data != null ? moment(data).format("MM/DD/YYYY") : '';
                }
            }, {
                "sTitle": "Title",
                "mData": "title"
            }, {
                "sTitle": "Category",
                "mData": "category"
            }, {
                "sTitle": "Author",
                "mData": "authorName"
            }, {
                "sTitle": "Publisher",
                "mData": "publisherName"
            }, {
                "sTitle": "",
                "render": function (data, type, row) {
                    var cell = '';
                    cell += '<a class="btn btn-default" asp-action="Edit" href="/Books/Edit/' + row.id + '"><i class="fa fa-pencil"></i></a>&nbsp;';
                    cell += '<a class="btn btn-info" asp-action="Details" href="/Books/Details/' + row.id + '"><i class="fa fa-info-circle"></i></a>&nbsp;';
                    cell += '<a class="btn btn-danger" href="javascript:void(0)" onclick="deleteBook(' + row.id + ')"><i class="fa fa-trash-o"></i></a>';
                    return cell;
                },
                "sName": "Select",
                "targets": 0
            }
        ],
        "initComplete": function (settings, json) {
            bindTable();
        }

    });

});

function bindTable() {
    axios.get('/Books/GetBooks')
        .then(function (response) {
            booksTable.clear().draw();

            if (response.data.length > 0) {
                booksTable.rows.add(response.data).draw();
            }
        })
        .catch(function (error) {
            toastr.error('There was an error processing the operation.');
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
                axios.post('/Books/DeleteBook/' + id, null, config)
                    .then(function (response) {
                        if (response) {
                            toastr.success('Book successfully deleted.');
                            bindTable();
                        } else {
                            toastr.error('There was an error processing the operation.');
                        }
                    })
                    .catch(function (error) {
                        toastr.error('There was an error processing the operation.');
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
    }).open();
};