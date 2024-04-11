
$(function () {

    $('#form-address').on("click", ".btn-save", function () {

        var clientId = $('#client-id').val();
        var addressId = $('#address-id').val();
        var data = getFormData($("#form-address"));
        

        var url = '/api/client/' + clientId + '/address';
        var type = 'POST';

        if (addressId !== '') {
            url = '/api/address/' + addressId;
            type = 'PUT';
            data["idClient"] = clientId;
        }

        $.ajax({
            url: url,
            data: JSON.stringify(data),
            cache: false,
            processData: false,
            contentType: "application/json; charset=utf-8",
            type: type,
            success: function (response) {
                // do something with the result
                console.log(response);

                resetInput('#form-address');
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

