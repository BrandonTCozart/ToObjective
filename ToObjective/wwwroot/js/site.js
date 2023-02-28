// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
// Write your JavaScript code.

$(document).ready(function () {
    $("#table-container").toggleClass("blur-table");


    $(".complete-button").on("click", completeOnClick)
    $(".delete-button").on("click", deleteButtonOnClick)

    $("#title-input-box").on("blur", function () {
        this.value = this.value.trim();
    });

    let timeOut;
    $("#table-search-box").on('keyup', function () {
        clearTimeout(timeOut);
        timeOut = setTimeout(function () { getTable(); }, 800);
    });

    $("#modal-cancel-button").on("click", function () {
        localStorage.removeItem("itemToDelete");
        toggleModal();
    });

    $("#modal-close-button").on("click", function () {
        localStorage.removeItem("itemToDelete");
        toggleModal();
    });

    $("#modal-submit-button").on("click", function () {
        deletePermanently();
        toggleModal();
    });

});

function completeOnClick() {
    $.ajax({
        type: "PUT",
        url: "/Objective/completeObjective",
        data: { id: parseInt(this.getAttribute("data-objective-id")) },
        beforeSend: function () {
            $("#loader").toggleClass("hide");
            $("#table-container").toggleClass("blur-table");

        },
        success: function (data) {
            getTable();

        },
        error: function (error) {
            console.log(error)
        }
    });
}

function deleteButtonOnClick() {
    toggleModal();
    $("#reuseable-modal").data("id", this.getAttribute("data-objective-id"));
}

function deletePermanently() {
    $.ajax({
        type: "DELETE",
        url: "/Objective/Delete",
        data: { id: parseInt($("#reuseable-modal").data("id")) },
        beforeSend: function () {
            $("#loader").toggleClass("hide");
            $("#table-container").toggleClass("blur-table");

        },
        success: function (data) {
            getTable();
        },
        error: function () {
            console.log("Not Nice")
        }
    });
}


function getTable() {

    $.ajax({
        url: "/Objective/LoadTableRows",
        data: { input: $("#table-search-box").val() },
        success: function (data) {
            if (!$("#loader").hasClass("hide")) {

                $("#loader").toggleClass("hide");
                $("#table-container").toggleClass("blur-table");
            }

            $("#table-container").html(data);
            $(".complete-button").on("click", completeOnClick)
            $(".delete-button").on("click", deleteButtonOnClick)
            //return data;
        },
        error: function (error) {
            console.log(error);
        }
    });
}

function toggleModal() {
    $("#reuseable-modal").toggleClass("hide");
}

