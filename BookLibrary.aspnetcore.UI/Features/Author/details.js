var booksTable = null;

$(document).ready(function () {

    booksTable = $('#booksTable').DataTable({
        "paging": false,
        "searching": false,
        "responsive": true,
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
                "render": function (data, type, row) {
                    var cell = '';
                    cell += '<a href="/Book/Edit/' + row.id + '" data-toggle="tooltip" title="Edit Book">' + row.title + '</a>';
                    return cell;
                }
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
                "sTitle": "Publisher",
                "mData": "publisherName"
            }
        ],
        "initComplete": function (settings, json) {
            bindTable();
        }

    });

});

function bindTable() {
    booksTable = $('#booksTable').DataTable();
    var result = JSON.parse(decodeURIComponent($('#BookList').val()));
    if (result.length > 0) {
        booksTable.rows.add(result).draw();
    }
}