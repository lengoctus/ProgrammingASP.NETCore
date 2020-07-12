
//  ===================================================     ALERT SUCCESS       =======================================
function alertSuccess(title) {
    Swal.fire({
        icon: 'success',
        title: title,
        showConfirmButton: false,
        timer: 1500
    })
}

function alertSuccess_OnClose_ReplaceUrl(title, url) {
    Swal.fire({
        icon: 'success',
        title: title,
        showConfirmButton: false,
        timer: 2000,
        onClose: () => {
            location.replace(url);
        }
    })
}

function alertSuccess_OnClose_ReloadUrl(title) {
    Swal.fire({
        icon: 'success',
        title: title,
        showConfirmButton: false,
        timer: 2000,
        onClose: () => {
            location.reload();
        }
    })
}


//  ===================================================     ALERT ERROR       =======================================
function alertError(text) {
    Swal.fire({
        icon: 'error',
        title: 'Fail!!',
        text: text,
    })
}
