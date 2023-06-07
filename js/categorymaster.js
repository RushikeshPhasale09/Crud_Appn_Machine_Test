$(document).ready(function () {
    $("#btnupdate").hide();

    showproductdtls();
})
$("#btnsubmit").click(function () {
    if (($("#txtproductid").val() == "") && ($("#txtcategoryid").val() == "") && ($("#txtcategoryname").val()=="")) {
        alert("Please Enter All Values");
        return;
    }
    if ($("#txtproductid").val() == "") {
        alert("Please Enter Product Id");
        return;
    }
    if ($("#txtcategoryid").val() == "") {
        alert("Please Enter Category Id");
        return;
    }
    if ($("#txtcategoryname").val() == "") {
        alert("Please Enter Category Name");
        return;
    }


    var obj = {
        ProductId: $("#txtproductid").val(),
        CategoryId: $("#txtcategoryid").val(),
        CategoryName: $("#txtcategoryname").val()
    }
    $.ajax({
        type: "POST",
        url: Categorydtlurl,
        data: JSON.stringify(obj),
        contentType: "application/json",
        success: function (data) {
            if (data == "Success") {
                alert("Data Inserted Successfully");
                $("#txtproductid").val("");
                $("#txtcategoryid").val("");
                $("#txtcategoryname").val("");

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
        url: getcategorydataurl,
        contentType: "application/json",
        success: function (data) {
            if (data != "" && data != null) {
                showeproductdata(data);
            }
        }

    })
}
function showeproductdata(data) {
    $("#category-dtl-tbl").DataTable().destroy();

    if (data != null) {
        $("#category-dtl-tbl").find("tbody").html("");
        var tbody = "";
        for (var i = 0; i < data.length; i++) {
            tbody = tbody + "<tr class='datagrid-row' height='20px'>" +
                "<td >" + data[i].ProductId + "</td>" +
                "<td >" + data[i].CategoryId + "</td>" +
                "<td >" + data[i].CategoryName + "</td>" +
                "<td>"
                + "<button type='button' onclick='editdata(this);' class='btn btn-default'><span class='fa fa-pencil-square-o'/></button>"+ 
               
                 "<button type='button' onclick='deletedata(this);' class='btn btn-default'><span class='fa fa-trash-o'/></button>" +
                "</td></tr > ";


        }
        $("#category-dtl-tbl").DataTable({
            paging: false,
            info: false,
            searching: true,
        });

        $("#category-dtl-tbl").find("tbody").html(tbody);
    }
}

function editdata(e, i) {

    var tr = e.closest("tr");

    if (tr != null) {
        var pid = tr.children[0].innerHTML.trim();
        var cid = tr.children[1].innerHTML.trim();
        var cname = tr.children[2].innerHTML.trim();
    }


    $("#btnsubmit").hide();

    $("#btnupdate").show();
    $("#txtproductid").val(pid);
    $("#txtproductid").prop('disabled', true);
    $("#txtcategoryid").val(cid);
    $("#txtcategoryname").val(cname);

    $("#btnupdate").click(function () {
        if (($("#txtcategoryname").val() == "") && ($("#txtproductid").val() == "") && ($("#txtcategoryid").val() == "")) {
            alert("Please Enter Product Id And Product Name");
            return;
        }
        if ($("#txtproductid").val() == "") {
            alert("Please Enter Product Id");
            return;
        }
        if ($("#txtcategoryid").val() == "") {
            alert("Please Enter Category Id");
            return;
        }

        if ($("#txtcategoryname").val() == "") {
            alert("Please Enter Category Name");
            return;
        }
        

        var obj = {
            ProductId: $("#txtproductid").val(),
            CategoryId: $("#txtcategoryid").val(),
            CategoryName: $("#txtcategoryname").val()
        }
        $.ajax({
            type: "POST",
            url: Editcategoryurl,
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
                    $("#txtcategoryid").val('');
                    $("#txtcategoryname").val('');
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
        url: Deletecatdataurl,
        data: JSON.stringify({ id: id }),
        dataType: "json",
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            if (data == "Success") {
                alert("Data Deleted Successfully");
                window.location.reload();

            }
            else {
                alert("Failed To Delete Data");
            }
        }
    })

}