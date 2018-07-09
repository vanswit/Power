// Write your JavaScript code.
//var headerImageContainer = document.getElementById("header-image-container");
//headerImageContainer.style.backgroundColor = "red";

$(document).ready(function () {

    $("#toggle-button").on("click", function () {

        if ($("#toggle-button").val() === "See less") {
            $("#toggle-button").val("See more");
        }
        else $("#toggle-button").val("See less");

        $("p:last").toggle(100);
    });

    $("#image-selector-visible").on("click", function () {
        $("#image-selector-hidden").trigger("click");
    });

    $("#image-selector-hidden").on("change", function () {
        var fileName = $(this).val().split('/').pop().split('\\').pop();
        var temp = fileName.split('.');
        var extension = temp.pop();

        var imageExtensions = ["jpeg", "jpg", "bmp", "tiff", "png"];

        if ($.inArray(extension, imageExtensions) != -1) {

            $("#image-selected").val(fileName);
        }
        else $("#extension-error-label").css("display", "inline");
    });
});

