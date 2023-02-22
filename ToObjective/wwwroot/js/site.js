// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
let objectives;

$(document).ready(function () {

    completeOnClick();
    deleteOnClick();

    $("#title-input-box").on("blur", function (){
        if(this.value.trim() == "") {
            this.value = "";
        }
    });

    $("#table-search-box").on('keyup', function () {
        $.ajax({
            url: "/Objective/LoadTableRows",
            data: { input: $("#table-search-box").val()},
            success: function (data) {
                newTable(data);
            },
            error: function (error) {
                console.log(error);
            }
        });
    });
});

function completeOnClick() {
    $(".complete-button").on("click", function () {
        $.ajax({
            type: "PUT",
            url: "/Objective/completeObjective",
            data: { id: parseInt(this.getAttribute("data-objective-id")) },
            success: function (data) {
                newTable(data)
            },
            error: function (error) {
                console.log(error)
            }
        });
    });
}

function deleteOnClick() {
    $(".delete-button").on("click", function () {
        $.ajax({
            type: "DELETE",
            url: "/Objective/delete",
            data: { id: parseInt(this.getAttribute("data-objective-id")) },
            success: function (data) {
                newTable(data)
            },
            error: function () {
                console.log("Not Nice")
            }
        });
    });
}

function newTable(data) {
    $("#to-do-table").remove();
    $(".table-container").append(data);
    completeOnClick();
    deleteOnClick();
}


