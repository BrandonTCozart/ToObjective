// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
// Write your JavaScript code.

$(document).ready(function () {

    $(".complete-button").on("click", completeOnClick)
    $(".delete-button").on("click", deleteButtonOnClick)

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

    $("#modal-cancel-button").on("click", function () {
        localStorage.removeItem("itemToDelete");
        $("#reuseable-modal").toggleClass("hide");
    });

    $("#modal-close-button").on("click", function () {
        localStorage.removeItem("itemToDelete");
        $("#reuseable-modal").toggleClass("hide");
    });

    $("#modal-submit-button").on("click", function () {
        deletePermanently();
        $("#reuseable-modal").toggleClass("hide");
    });

});

function completeOnClick() {
    $.ajax({
        type: "PUT",
        url: "/Objective/completeObjective",
        data: { id: parseInt(this.getAttribute("data-objective-id")) },
        beforeSend: function () {
            //$(".table-container").fadeOut(1000);
            //$("#loader").toggleClass("hide");
        },
        success: function (data) {
            //$("#loader").toggleClass("hide");
            //$(".table-container").fadeIn();
            getTable(data);

        },
        error: function (error) {
            console.log(error)
        }
    });
}

function deleteButtonOnClick() {
    $("#reuseable-modal").toggleClass("hide");
    localStorage.setItem("itemToDelete", this.getAttribute("data-objective-id"));
}

function deletePermanently() {
    $.ajax({
        type: "DELETE",
        url: "/Objective/delete",
        data: { id: parseInt(localStorage.getItem("itemToDelete")) },
        beforeSend: function () {
            //$(".table-container").fadeOut(1000);
            //$("#loader").toggleClass("hide");
        },
        success: function (data) {
            //$("#loader").toggleClass("hide");
            //$(".table-container").fadeIn();
            getTable(data);
        },
        error: function () {
            console.log("Not Nice")
        }
    });
    localStorage.removeItem("itemToDelete");
}

function getTable(data) {
    $(".table-container").html(data);
    $(".complete-button").on("click", completeOnClick)
    $(".delete-button").on("click", deleteButtonOnClick)
}


