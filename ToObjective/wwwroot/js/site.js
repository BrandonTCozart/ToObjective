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
});