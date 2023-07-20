let emailBox = document.querySelector(".emailBox");
let resetPasswordBtn = document.querySelector(".resetPasswordBtn");


resetPasswordBtn.addEventListener("click", function (e) {
    e.preventDefault();
    if (emailBox.value == "") {
        alert("Please input email");
    }
});


