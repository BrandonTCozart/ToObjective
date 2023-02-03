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
        var object = { title: $("#title-input-box").val(), description: $("#description-input-box").val(), completeByDate: $("#complete-by-input-box").val() }
        $.ajax({
            type: "POST",
            url: "/Objective/postIndex",
            data: object,
            success: function (data) {
                console.log("Nice")
            },
            error: function () {
                console.log("Not Nice")
            }
        });
    });

    /*
     var object = { title: 'Random', description: 'Randescription', completeByDate: Date() }
    $.ajax({
        type: "POST", 
        url: "/Objective/postIndex",
        data: object,
        success: function (data) {
            console.log(data)
        },
        error: function () {
            console.log("Not Nice")
        }
    });
    */
});

function hideShowModal() {
}