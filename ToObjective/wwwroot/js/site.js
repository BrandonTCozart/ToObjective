// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {

    $(".complete-button").on("click", completeOnClick)
    $(".delete-button").on("click", deleteOnClick)

    $("#title-input-box").on("blur", function () {
        this.value.trim()
    });

    $("#table-search-box").on('keyup', function () {
        $.ajax({
            url: "/Objective/LoadTableRows",
            data: { input: $("#table-search-box").val()},
            success: function (data) {
                getTable(data);
            },
            error: function (error) {
                console.log(error);
            }
        });
    });
});

function completeOnClick() {
    $.ajax({
        type: "PUT",
        url: "/Objective/completeObjective",
        data: { id: parseInt(this.getAttribute("data-objective-id")) },
        success: function (data) {
            getTable(data)
        },
        error: function (error) {
            console.log(error)
        }
    });
}

function deleteOnClick() {
    $.ajax({
        type: "DELETE",
        url: "/Objective/delete",
        data: { id: parseInt(this.getAttribute("data-objective-id")) },
        success: function (data) {
            getTable(data)
        },
        error: function () {
            console.log("Not Nice")
        }
    });
}

function getTable(data) {
    $(".table-container").html(data);
}


