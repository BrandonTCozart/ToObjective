// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
// Write your JavaScript code.

$(document).ready(function () {
    completeDeleteOnclicks();

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
        deletePermanently();
        toggleModal();
    });

    $("#edit-button").on("click", function () {
        if ($("#title-input-box").val() && $("#complete-by-input-box").val()) {
            loadingAnim();
            hideShowTable();
            $("#create-button").hide();
        }
    })

    $("#create-button").on("click", function () {
        if ($("#title-input-box").val() && $("#complete-by-input-box").val()) {
            loadingAnim();
            hideShowTable();
            $("#create-button").hide();
        }
    });
});

function completeOnClick() {
    $.ajax({
        type: "PUT",
        url: "/Objective/completeObjective",
        data: { id: parseInt(this.getAttribute("data-objective-id")) },
        beforeSend: function () {
            loadingAnim();
            hideShowTable();
        },
        success: function (data) {
            getTable();
        },
        error: function (error) {
            console.log("Not Nice")
        },
        complete: function () {
            loadingAnim();
            hideShowTable();
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
            loadingAnim();
            hideShowTable();
        },
        success: function (data) {
            getTable();
        },
        error: function () {
            console.log("Not Nice")
        },
        complete: function () {
            loadingAnim();
            hideShowTable();
        }
    });
}

function completeDeleteOnclicks() {
    //$(document).on("click", .classname,function () { completeOnClick() })
    //$(document).on("click", .classname,function () { deleteButtonOnClick() })
    $(".complete-button").on("click", completeOnClick);
    $(".delete-button").on("click", deleteButtonOnClick);
    $(".edit-button").on("click", loadingAnim, hideShowTable);
}

/*
function completeDeleteOnclicks() {
    $(document).on("click", ".complete-button", function () { completeOnClick() });
    $(document).on("click", ".delete-button", function () { deleteButtonOnClick() });
    $(document).on("click", ".edit-button", function () {
        loadingAnim();
        hideShowTable();
    });
    //$(".complete-button").on("click", completeOnClick);
    //$(".delete-button").on("click", deleteButtonOnClick);
    //$(".edit-button").on("click", loadingAnim, hideShowTable);
}
*/

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
                completeDeleteOnclicks();
            },
            error: function (error) {
                console.log(error);
            }
        });
    }
}

function loadingAnim() {
    $("#loader").toggleClass("hide");
}

function hideShowTable() {
    $(".container").toggleClass("blur-table");
}
