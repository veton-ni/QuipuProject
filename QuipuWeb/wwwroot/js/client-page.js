
$(function () {

    $('.table-address').on("click", "tbody tr", function () {
        var id = $(this).data("id");

        window.location.href = "/Home/AddressEdit/" + id;
    });

    $('.address-list').on("click", "btn-add-address", function () {
        window.location.href = "/Home/AddressNew/";
    });


    $('#form-client').on("click", ".btn-save", function () {

        var data = getFormData($("#form-client"));
        var clientId = $('#client-id').val();
        var url = '/api/client';
        var type = 'POST'

        if (clientId !== '') {
            url += '/' + clientId;
            type = 'PUT';
        }

        $.ajax({
            url: url,
            data: JSON.stringify(data) ,
            cache: false,
            processData: false,
            contentType: "application/json; charset=utf-8",
            type: type,
            success: function (response) {
                console.log(response);
                resetInput('#form-client');
                Swal.fire({
                    title: "Good job!",
                    text: "Client is saved!",
                    icon: "success"
                });
            },
            error: function (error) {
                


                console.log(error.responseJSON.name);
                Swal.fire({
                    title: "Error!",
                    html: JSON.stringify(error.responseJSON),
                    icon: "error"
                });
            }
            
        });


    });


    function resetInput(form) {

        $(':input', form)
            .not(':button, :submit, :reset, :hidden')
            .val('')
            .prop('checked', false)
            .prop('selected', false);

    }
    function getFormData($form) {
        var unindexed_array = $form.serializeArray();
        var indexed_array = {};

        $.map(unindexed_array, function (n, i) {
            indexed_array[n['name']] = n['value'];
        });

        return indexed_array;
    }

});

