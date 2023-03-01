// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
// Write your JavaScript code.

$(document).ready(function () {
    completeDeleteOnclicks();

    $("#title-input-box").on("blur", function () {
        this.value = this.value.trim();
    });

    let timeOut;
    $("#table-search-box").on('keyup', function () {
        clearTimeout(timeOut);
        timeOut = setTimeout(function () { getTable(); }, 500);
    });

    $("#modal-cancel-button").add("#modal-close-button").on("click", closeModal);


    $("#modal-submit-button").on("click", function () {
        deletePermanently();
        toggleModal();
    });

    $("#create-button").on("click", function () {
        if ($("#title-input-box").val() && $("#complete-by-input-box").val()) {
            loadingSection();
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
            loadingSection();
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
            loadingSection();
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
                loadingSection();
            }
            $("#table-container").html(data);
            completeDeleteOnclicks();
        },
        error: function (error) {
            console.log(error);
        }
    });
}

function completeDeleteOnclicks() {
    //$(document).on("click", .classname,function () { completeOnClick() })
    //$(document).on("click", .classname,function () { deleteButtonOnClick() })

    $(".complete-button").on("click", completeOnClick);
    $(".delete-button").on("click", deleteButtonOnClick);
    $(".edit-button").on("click", loadingSection);

}

function toggleModal() {
    $("#reuseable-modal").toggleClass("hide");
}

function closeModal() {
    localStorage.removeItem("itemToDelete");
    toggleModal();
}

function loadingSection() {
    $("#loader").toggleClass("hide");
    $(".container").toggleClass("blur-table");
}

