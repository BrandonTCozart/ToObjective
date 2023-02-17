// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
let objectives;

$(document).ready(function () {

    $("#new-objective-button").on("click", function () {
        
    });

    $(".delete-button").on("click", function () {
        let table = document.getElementById("to-do-table");
        table.deleteRow(this.closest('tr').rowIndex);
        let objId = this.getAttribute("data-objective-id");
        $.ajax({
            type: "DELETE",
            url: "/Objective/delete",
            data: {id: parseInt(objId)},
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


    $("#title-input-box").on("blur", function (){
        if(this.value.trim() == "") {
            this.value = "";
        }
    });


    // For Search //
    $("#table-search-button").on("click", function () {
        let searchValue = $("#table-search-box").val();
        let newRow = "";
        if (searchValue.trim() == "") {

        } else {
            let tableLength = $("#to-do-table-tbody tr").length;
            for (let i = 0; i <= tableLength; i++) {
                if ($("#to-do-table-tbody tr").eq(i).find('td').eq(0).text().trim().includes(searchValue)) {
                    newRow = newRow.concat($("#to-do-table-tbody").find("tr").eq(i).prop('outerHTML'));
                }
            }
            $("#to-do-table-tbody tr").remove();
            $(document.getElementById("to-do-table-tbody")).append(newRow);
        }
    });
});

//function that gets all the row eements. This will be called every time there is a new addition, and on application launch.
function tableState() {
    let tableLength = $("#to-do-table-tbody tr").length;
    let newRow = "";
    for (let i = 0; i <= tableLength; i++) {
        newRow = newRow.concat($("#to-do-table-tbody").find("tr").eq(i).prop('outerHTML'));
    }
    return newRow;
}

