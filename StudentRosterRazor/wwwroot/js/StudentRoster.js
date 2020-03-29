var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#student_roster').DataTable({
        "ajax": {
            "url": "/api/student",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "studentID", "width": "20%" },
            { "data": "firstName", "wdith": "20%" },
            { "data": "middleName", "wdith": "20%" },
            { "data": "lastName", "wdith": "20%" },
            { "data": "grade", "wdith": "20%" },
            { "data": "gender", "wdith": "20%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                    <div class="text-center">
                        <a href="/StudentRoster/Edit?=${data}" class='btn btn-success text-white' style='cursor:pointer; width:70px;'>
                        Edit
                        </a>
                        &nbsp;
                        <a class='btn btn-danger text-white' style='cursor:pointer; width:70px;' onclick=Delete('/api/student?id='+${data})>
                        Delete
                        </a>
                    </div>`;
                }, "width": "20%"
            }
        ],
        "language": {
            "emptyTable": "No Data Found"
        },
        "width": "100%"
    });
}

function Delete(url) {
    swal({
        title: "Are you sure?",
        text: "Once deleted, you will not be able to recover",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    } else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}