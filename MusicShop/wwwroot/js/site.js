var dtable;
$(document).ready(function () {
    dtable = $('#myTable').DataTable({
        "ajax": { "url": "/Nstrument/AllNstrument" },
        "columns": [
            { "data": "Name" },
            { "data": "Price" },
            { "data": "QuantInStock" },
            { "data": "Manufacturer.Id" },
            {
                "data": "Id",
                "render": function (data) {
                    return `
                        <a href="/Nstrument/CreateUpdate?id${data}"><i class="bi bi-pencil-square"></i></a>
                <a onclick=RemoveProduct("/Nstrument/Delete/${data}")><i class="bi bi-trash"></i></a>
`
                }
            }
        ]
    });
});
function RemoveProduct(url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You'll lose the data",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes,delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    if (data.success) {
                        dtable.ajax.reload();
                        toastr.success(data.message);
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    }
    )
