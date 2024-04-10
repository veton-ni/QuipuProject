$(document).ready(function () {

    let table = new DataTable('.table-clients');

    $('.table-clients').on("click", "tbody tr", function () {
        var id = $(this).data("id");

        window.location.href = "/Home/ClientEdit/" + id;
    });

});

