$(document).ready(function () {


    //========================================================    Account     ======================================
    var arr = [];
    $('.cbAcc').on('change', function () {
        if ($(this).is(':checked') == true) {
            arr.push(parseInt($(this).val()));

        } else if ($(this).is(':checked') == false) {
            arr.splice($.inArray(parseInt($(this).val()), arr), 1);
        }

    });


    $('#AllCbAccount').on('change', function () {
        if ($(this).is(':checked') == true) {
            $('.cbAcc').prop('checked', true);
            arr = $('.cbAcc:checked').map(function () {
                return parseInt(this.value);
            }).get();
        } else if ($(this).is(':checked') == false) {
            $('.cbAcc').prop('checked', false);
            arr = [];
        }
    });

    $('.btnRemove').on('click', function () {
        if (arr.length > 0) {
            Swal.fire({
                title: 'Are you sure?',
                text: 'Remove ' + arr.length + ' Account permanently !!',
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Yes, delete it!'
            }).then((result) => {
                if (result.value) {
                    $.ajax({
                        type: 'POST',
                        url: '/admin/account/removeAcc',
                        cache: false,
                        contentType: 'application/json, charset=UTF-8',
                        dataType: 'json',
                        data: JSON.stringify(arr),
                        success: function (data) {
                            if (data == "1") {
                                alertSuccess_OnClose_ReloadUrl('Successfully deleted account !!');
                            }
                            else if (data == "0") {
                                alertError('Deleting account failed. Please check again !!')
                            }

                        }
                    });
                }
            })
        };
    });

    $('.cbActive').on('change', function () {
        var idAcc = $(this).val();
        var ischeck = $(this).prop('checked');

        var info = {
            idAcc: idAcc,
            ischeck: ischeck
        }

        $.ajax({
            type: "POST",
            url: '/admin/account/updateActive',
            contentType: 'application/json, charset=UTF-8',
            cache: false,
            dataType: 'json',
            data: JSON.stringify(info),
            success: function (data) {
                if (data == "1") {
                    alertSuccess_OnClose_ReloadUrl('Update Active Success !!')
                } else if (data == "0") {
                    alertError('Update Active faild. Please check again !!')
                }
            }
        })
    })

})















//======================================================================================================================================

function ChangeImg() {
    document.getElementById("photoImg").src = window.URL.createObjectURL(document.getElementsByName("photo")[0].files[0]);
} 