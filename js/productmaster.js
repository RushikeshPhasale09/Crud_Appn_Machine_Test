$(document).ready(function () {
    $("#btnupdate").hide();
    showproductdtls();
})
$("#btnsubmit").click(function () {
    if (($("#txtproductname").val() == "") && ($("#txtproductid").val() == "")) {
        alert("Please Enter Product Id And Product Name");
        return;
    }
    if ($("#txtproductid").val() == "") {
        alert("Please Enter Product Id");
        return;
    }
    if ($("#txtproductname").val() == "") {
        alert("Please Enter Product Name");
        return;
    }


    var obj = {
        ProductId: $("#txtproductid").val(),
        ProductName: $("#txtproductname").val()
    }
    $.ajax({
        type: "POST",
        url: productdtlurl,
        data: JSON.stringify(obj),
        contentType: "application/json",
        success: function (data) {
            if (data == "Success") {
                alert("Data Inserted Successfully");
                $("#txtproductid").val("");
                $("#txtproductname").val("");

            }
            else {
                alert("Failed To Insert Data");
            }
        }
    })

})



function showproductdtls() {
    $.ajax({
        type: "POST",
        url: getproddataurl,
        contentType: "application/json",
        success: function (data) {
            if (data != "" && data != null) {
                showeproductdata(data);
            }
        }

    })
}
function showeproductdata(data) {
    $("#product-dtl-tbl").DataTable().destroy();

    if (data != null) {
        $("#product-dtl-tbl").find("tbody").html("");
        var tbody = "";
        for (var i = 0; i < data.length; i++) {
            tbody = tbody + "<tr class='datagrid-row' height='20px'>" +
                "<td>" + data[i].ProductId + "</td>" +
                "<td>" + data[i].ProductName + "</td>" +
                "<td>"
                + "<button type='button' onclick='editdata(this);' class='btn btn-default'><span class='fa fa-pencil-square-o'/></button>"+ 
         
                "<button type='button' onclick='deletedata(this);' class='btn btn-default'><span class='fa fa-trash-o'/></button>" +
                "</td></tr > ";


        }
        $("#product-dtl-tbl").DataTable();

        $("#product-dtl-tbl").find("tbody").html(tbody);
    }
}

function editdata(e, i) {

    var tr = e.closest("tr");
    if (tr != null) {
        var pid = tr.children[0].innerHTML.trim();
        var pname = tr.children[1].innerHTML.trim();
    }


    $("#btnsubmit").hide();

    $("#btnupdate").show();
    $("#txtproductid").val(pid);
    $("#txtproductid").prop('disabled', true);
    $("#txtproductname").val(pname);

    $("#btnupdate").click(function () {
        if (($("#txtproductname").val() == "") && ($("#txtproductid").val() == "")) {
            alert("Please Enter Product Id And Product Name");
            return;
        }
        if ($("#txtproductid").val() == "") {
            alert("Please Enter Product Id");
            return;
        }
        if ($("#txtproductname").val() == "") {
            alert("Please Enter Product Name");
            return;
        }


        var obj = {
            ProductId: $("#txtproductid").val(),
            ProductName: $("#txtproductname").val()
        }
        $.ajax({
            type: "POST",
            url: editdataurl,
            data: JSON.stringify(obj),
            dataType: "json",
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                if (data == "Success") {
                    alert("Data Updated Successfully");
                    window.location.reload();
                    $("#btnsubmit").show();

                    $("#btnupdate").hide();
                    $("#txtproductid").val('');
                    $("#txtproductid").prop('disabled', false);
                    $("#txtproductname").val('');
                }
                else {
                    alert("Failed To Update Data");
                }
            }
        })

    });


}

function deletedata(e, i) {
    var tr = e.closest("tr");
    if (tr != null) {
        var id = tr.children[0].innerHTML.trim();
    }
    $.ajax({
        type: "POST",
        url: Deletedataurl,
        data: JSON.stringify({ id: id }),
        dataType: "json",
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            if (data == "Success") {
                alert("Data Deleted Successfully");

            }
            else {
                alert("Failed To Delete Data");
            }
        }
    })

}