let resetEmailInputBox = document.querySelector(".resetEmailInputBox");
let sendResetEmailBtn = document.querySelector(".sendResetEmailBtn");


sendResetEmailBtn.addEventListener("click", function (e) {
    if (resetEmailInputBox.value == "") {
        e.preventDefault();
        alert("Please input email");
    } else {
        // 顯示 loading
        sendResetEmailBtn.classList.add("d-none");
        let spinner = sendResetEmailBtn.nextElementSibling;
        spinner.classList.remove("d-none");
    }



});


// 隱藏 loading
if (document.readyState == "complete") {
    let spinner = sendResetEmailBtn.nextElementSibling;

    if (sendResetEmailBtn.classList.contains("d-none")) {
        sendResetEmailBtn.classList.remove("d-none");
    }
    if (!spinner.classList.contains("d-none")) {
        spinner.classList.add("d-none");
    }
}

