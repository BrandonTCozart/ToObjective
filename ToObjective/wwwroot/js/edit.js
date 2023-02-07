// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$(document).ready(function () {
    let editId = localStorage.getItem("editId");
    $("#edit-submit-button").on("click", function () {
        $.ajax({
            type: "PUT",
            url: "/Objective/editObjective",
            data: {id: editId , title: $("#edit-title").val(), description: $("#edit-description").val(), date: $("#edit-do-date").val() },
            success: function (data) {
                console.log("Nice")
            },
            error: function () {
                console.log("Not Nice")
            }
        });

    });
});