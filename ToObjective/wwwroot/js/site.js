// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
// Write your JavaScript code.

$(document).ready(function () {
    completeDeleteEditOnclicks();

    $("#title-input-box").on("blur", function () {
        this.value = this.value.trim();
    });

    let searchBoxValue;
    $("#table-search-box").on('keydown', function () {
        searchBoxValue = $("#table-search-box").val().trim();
    });

    let timeOut;
    $("#table-search-box").on('keyup', function () {
        if (searchBoxValue == $("#table-search-box").val().trim()) {
            return;
        }
        clearTimeout(timeOut);
        timeOut = setTimeout(function () { getTable(); }, 500);
    });

    $("#modal-cancel-button").add("#modal-close-button").on("click", toggleModal);


    $("#modal-submit-button").on("click", function () {
        deleteRequest();
        toggleModal();
    });

    $("#edit-button").on("click", function () {
        if ($("#title-input-box").val() && $("#complete-by-input-box").val()) {
            loadingAnimation();
            hideShowTable();
            $("#create-button").hide();
        }
    })

    $("#create-button").on("click", function () {
        if ($("#title-input-box").val() && $("#complete-by-input-box").val()) {
            loadingAnimation();
            hideShowTable();
            $("#create-button").hide();
        }
    });
});

function completeRequest(element) {
    $.ajax({
        type: "PUT",
        url: "/Objective/completeObjective",
        data: { id: parseInt(element.getAttribute("data-objective-id")) },
        beforeSend: function () {
            loadingAnimation();
            hideShowTable();
        },
        success: function (data) {
            getTable();
        },
        error: function (error) {
            // try again toast message
            console.log("Not Nice");
            errorSlide("Error completing task, try again");
        },
        complete: function () {
            loadingAnimation();
            hideShowTable();
        }
    });
}

function deleteButtonOnClick(element) {
    toggleModal();
    $("#reuseable-modal").data("id", element.getAttribute("data-objective-id"));
}

function deleteRequest() {
    $.ajax({
        type: "DELETE",
        url: "/Objective/Delete",
        data: { id: parseInt($("#reuseable-modal").data("id")) },
        beforeSend: function () {
            loadingAnimation();
            hideShowTable();
        },
        success: function (data) {
            getTable();
        },
        error: function () {
            console.log("Not Nice")
            errorSlide("Error deleting task, try again");
        },
        complete: function () {
            loadingAnimation();
            hideShowTable();
        }
    });
}

function completeDeleteEditOnclicks() {
    $(document).on("click", ".complete-button",function () { completeRequest(this) })
    $(document).on("click", ".delete-button", function () { deleteButtonOnClick(this) })
    $(document).on("click", ".edit-button", function () { loadingAnimation(), hideShowTable() })
}

function toggleModal() {
    $("#reuseable-modal").toggleClass("hide");
}

function getTable() {
    if ($("#table-search-box").val() == "" || $("#table-search-box").val().trim() != "") {
        $.ajax({
            url: "/Objective/LoadTableRows",
            data: { input: $("#table-search-box").val().trim() },
            success: function (data) {
                $("#table-container").html(data);
            },
            error: function (error) {
                console.log(error);
                errorSlide("Error try again");

            }
        });
    }
}

function loadingAnimation() {
    $("#loader").toggleClass("hide");
}


function errorSlide(errorText = "") {
    $("#error-container").slideToggle(1000);
    $("#error-message").text(errorText);
    if (errorText != "") {
        setTimeout(function () { $("#error-container").hide() }, 3000);
    }
}

function hideShowTable() {
    $(".container").toggleClass("blur-table");
}
