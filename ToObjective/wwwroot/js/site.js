// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {

    $("#new-objective-button").on("click", function () {
        hideShowModal();
    });

    $("#modal-submit-button").on("click", function () {
        hideShowModal()
    });

    $("#new-objective-button").on("click", function () {
        $.get("/Objective/getIndex", null, function(data) {
            console.log(data);
        }); 
    });

    $("#create-button").on("click", function () {
        //var object = { title: $("#title-input-box").val(), description: $("#description-input-box").val(), completeByDate: $("#complete-by-input-box").val() }
        console.log("hello?")
        $.ajax({
            type: "POST",
            url: "/Objective/postIndex",
            data: { title: $("#title-input-box").val(), description: $("#description-input-box").val(), completeByDate: $("#complete-by-input-box").val() },
            success: function (data) {
                console.log("Nice")
            },
            error: function () {
                console.log("Not Nice")
            }
        });
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
});

function hideShowModal() {
}