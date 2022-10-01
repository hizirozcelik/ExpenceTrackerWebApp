var dataTable;

$(document).ready(function () {
    loadDataTable();
});
function loadDataTable() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/api/Expence",
            "type": "GET",
            "datatype": "json"

        },
        "columns": [
            { "data": "expenceDate", "width": "30%" },
            { "data": "cost", "width": "30%" },
            { "data": "description", "width": "30%" },
            {
                "data": "id",
                "render": function (data) {
  
                    return ` <div class="text-center">
                                  <a href="/ExpenceList/Edit?id=${data}" class="btn btn-success text-white" style="cursor:pointer; width:100px;">
                                      Edit
                                   </a>
                                   &nbsp
                                   <a class="btn btn-danger text-white" style="cursor:pointer; width:100px;">
                                       Delete
                                   </a>
                            </div>`
                }, "width": "30%"
            }
        ],
        "language": {
            "emptyTable": "no data found"
        },
        "width": "100%"
    });
}