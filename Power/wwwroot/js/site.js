// Write your JavaScript code.
//var headerImageContainer = document.getElementById("header-image-container");
//headerImageContainer.style.backgroundColor = "red";

$(document).ready(function () {

    $("#toggle-button").on("click", function () {

        if ($("#toggle-button").val() == "See less") {
            $("#toggle-button").val("See more");
        }
        else $("#toggle-button").val("See less");

        $("p:last").toggle(100);
    });

});

