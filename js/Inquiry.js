$(document).ready(function () {
    showinquirydtls();
});


function showinquirydtls() {
    $.ajax({
        type: "POST",
        url: inquiryurl,
        contentType: "application/json; charset-utf-8",
        success: function (data) {
            if (data != "" && data != null) {
                showeproductdata(data);
            }
        }

    });
}
function showeproductdata(data) {
    $("#inq-dtl-tbl").DataTable().destroy();

    if (data != null && data.length > 0) {
        $("#inq-dtl-tbl").find("tbody").html("");
        var tbody = "";
        for (var i = 0; i < data.length; i++) {
            tbody = tbody + "<tr class='datagrid-row' height='20px'>" +
                "<td>" + data[i].ProductId + "</td>" +
                "<td>" + data[i].ProductName + "</td>" +
                "<td>" + data[i].CategoryId + "</td>" +
                "<td>" + data[i].CategoryName + "</td></tr>";
        }
        $("#inq-dtl-tbl").find("tbody").html(tbody);

        $("#inq-dtl-tbl").DataTable();
    }
}


