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
            { "data": "studentid", "width": "15%" },
            { "data": "firstname", "wdith": "15%" },
            { "data": "middlename", "wdith": "15%" },
            { "data": "lastname", "wdith": "15%" },
            { "data": "grade", "wdith": "15%" },
            { "data": "gender", "wdith": "15%" },
            {
                "data": "studentid",
                "render": function (data) {
                    return `
                    <div class="text-center">
                        <a href="/Index/Edit?=${data}" class='btn btn-success text-white' style='cursor:pointer; width:70px;'>
                        Edit
                        </a>
                        &nbsp;
                        <a class='btn btn-danger text-white' style='cursor:pointer; width:70px;' onclick=Delete('api/student?id='+${data})>
                        Delete
                        </a>
                    </div>`;
                }, "width": "40%"
            }
        ],
        "language": {
            "emptyTable": "No Data Found"
        },
        "width": "100%"
    });
}