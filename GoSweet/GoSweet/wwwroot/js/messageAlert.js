function showSwal(icon=false, title, message, ) {
    if (icon == false) {
        Swal.fire({
            title: title,
            text: message,
        });
    } else {
        Swal.fire({
            icon: icon,
            title: title,
            text: message,
        });
    }
}
