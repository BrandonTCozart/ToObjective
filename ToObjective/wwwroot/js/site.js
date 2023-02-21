// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
let objectives;

$(document).ready(function () {

    let allToDo = tableState();
    completeDeleteOnClick();

    $("#title-input-box").on("blur", function (){
        if(this.value.trim() == "") {
            this.value = "";
        }
    });

    ////////////////////////////////////////////////////////////////////////////////////////
    $("#table-search-box").on('keyup', function () {
        let searchValue = $("#table-search-box").val();
        if (searchValue.trim() == "") {
            $("#to-do-table-tbody tr").remove();

        } else {
            $("#to-do-table-tbody tr").remove();
            $.ajax({
                url: "/Objective/LoadTableRows",
                data: { input: searchValue },
                success: function (data) {
                    console.log(data);
                },
                error: function (error) {
                    console.log(error)
                }

            });
        }
    });
    ////////////////////////////////////////////////////////////////////////////////////////
});

function tableState() {
    let newRow = "";
    for (let i = 0; i <= $("#to-do-table-tbody tr").length; i++) {
        newRow = newRow.concat($("#to-do-table-tbody").find("tr").eq(i).prop('outerHTML'));
    }
    return newRow;
}

function completeDeleteOnClick() {
    $(".delete-button").on("click", function () {
        document.getElementById("to-do-table").deleteRow(this.closest('tr').rowIndex);
        $.ajax({
            type: "DELETE",
            url: "/Objective/delete",
            data: { id: parseInt(this.getAttribute("data-objective-id")) },
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
        $.ajax({
            type: "PUT",
            url: "/Objective/completeObjective",
            data: { id: parseInt(this.getAttribute("data-objective-id")) },
            success: function (data) {
                console.log("Nice")
            },
            error: function () {
                console.log("Not Nice")
            }
        });
    });
}


