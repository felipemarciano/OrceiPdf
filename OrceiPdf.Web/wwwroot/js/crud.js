$(document).ready(function () {
    $('#modalCrud > .modal').modal('show');

});

//Editar Grid Click
$('.edit-click').on("click", function () {
    $.blockUI();
});

/*
 * Collapse card Cadastro/Alteração
 */
function openCollapseCrud() {
    $(".collapse-crud-show").hide();
    $(".collapse-crud-hide").show();
    $(".body-crud").collapse("show");
    $(".footer-crud").show();
}

function closeCollapseCrud() {
    $(".collapse-crud-hide").hide();
    $(".collapse-crud-show").show();
    $(".body-crud").collapse("hide");
    $(".footer-crud").hide();
}

$(".collapse-crud-show").on("click", function (e) {
    openCollapseCrud();
});

$(".collapse-crud-hide").on("click", function (e) {
    closeCollapseCrud();
})

$(document).ready(function () {
    if ($(".collapse-id").val() != "00000000-0000-0000-0000-000000000000" || $(".validation-summary-errors > ul > li").length > 0) {
        openCollapseCrud();
    }
});