// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
let objectives;

$(document).ready(function () {

    let allToDo = tableState();

    $("#new-objective-button").on("click", function () {
        
    });

    completeDeleteOnClick();


    $("#title-input-box").on("blur", function (){
        if(this.value.trim() == "") {
            this.value = "";
        }
    });

    $("#table-search-box").on('keyup', function () {
        let searchValue = $("#table-search-box").val();
        if (searchValue.trim() == "") {
            $("#to-do-table-tbody tr").remove();
            $(document.getElementById("to-do-table-tbody")).append(allToDo);
        } else {
            let tableLength = $("#to-do-table-tbody tr").length;
            for (let i = 0; i <= tableLength; i++) {
                if ($("#to-do-table-tbody tr").eq(i).find('td').eq(0).text().trim().includes(searchValue) != true) {
                    $("#to-do-table-tbody").find("tr").eq(i).css("display", "none");
                    $("#to-do-table-tbody").find("tr").eq(i).find('button').css("display", "none");
                } else {
                    $("#to-do-table-tbody").find("tr").eq(i).css("display", "");
                    $("#to-do-table-tbody").find("tr").eq(i).find('button').css("display", "");
                    $("#to-do-table-tbody").find("tr").eq(i).find('button').unbind();
                }
            }
        }
        completeDeleteOnClick();
    });

});

function tableState() {
    let tableLength = $("#to-do-table-tbody tr").length;
    let newRow = "";
    for (let i = 0; i <= tableLength; i++) {
        newRow = newRow.concat($("#to-do-table-tbody").find("tr").eq(i).prop('outerHTML'));
    }
    return newRow;
}

function completeDeleteOnClick() {
    $(".delete-button").on("click", function () {
        let table = document.getElementById("to-do-table");
        table.deleteRow(this.closest('tr').rowIndex);
        let objId = this.getAttribute("data-objective-id");
        $.ajax({
            type: "DELETE",
            url: "/Objective/delete",
            data: { id: parseInt(objId) },
            success: function (data) {
                console.log("Nice")
            },
            error: function () {
                console.log("Not Nice")
            }
        });
    });

    $(".complete-button").on("click", function () {

        this.closest('tr').classList.toggle('row-color');
        $(this).closest('tr').find('#edit-button-id').prop("disabled", true);
        this.setAttribute('disabled', true);
        let objId = this.getAttribute("data-objective-id");
        $.ajax({
            type: "PUT",
            url: "/Objective/completeObjective",
            data: { id: parseInt(objId) },
            success: function (data) {
                console.log("Nice")
            },
            error: function () {
                console.log("Not Nice")
            }
        });
    });
}


