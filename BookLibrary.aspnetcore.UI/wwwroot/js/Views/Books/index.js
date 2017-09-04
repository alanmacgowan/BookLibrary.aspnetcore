
$(document).ready(function () {

    $('#booksTable').DataTable();

});

function deleteBook(id) {
    BootstrapDialog.show({
        title: 'Delete Book',
        message: 'Do you want to delete this book?',
        buttons: [{
            label: 'Yes',
            cssClass: 'btn-success',
            action: function (dialog) {

                utils.post({ url: '/Books/DeleteBook/' + id, successMessage: 'Book successfully deleted.' });

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