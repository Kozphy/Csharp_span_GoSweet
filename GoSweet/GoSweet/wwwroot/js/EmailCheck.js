// #region 取得 html tag
let resetEmailInputBox = document.querySelector(".resetEmailInputBox");
let sendResetEmailBtn = document.querySelector(".sendResetEmailBtn");
// #endregion


// #region 綁定寄送 Email 事件
sendResetEmailBtn.addEventListener("click", function (e) {
    // 沒有輸入 Email
    if (resetEmailInputBox.value === "") {
        e.preventDefault();
        alert("Please input email");
    } else {
        showLoadingHideBtn();
    }
});
// #endregion

// #region 顯示 spinner，寄出 Email btn 隱藏
function showLoadingHideBtn() {
    // 顯示 loading
    sendResetEmailBtn.classList.add("d-none");
    let spinner = sendResetEmailBtn.nextElementSibling;
    spinner.classList.remove("d-none");
}
// #endregion

// #region 寄出完成
if (document.readyState === "complete") {
    showSendBtnHideSpinner();
}
// #endregion 

// #region 隱藏 Spinner, 顯示寄出 Email Btn
function showSendBtnHideSpinner() {
        let spinner = sendResetEmailBtn.nextElementSibling;

        // #region sendResetEmailBtn 顯示
        if (sendResetEmailBtn.classList.contains("d-none")) {
            sendResetEmailBtn.classList.remove("d-none");
        }
        // #endregion

        // #region 隱藏 spinner
        if (!spinner.classList.contains("d-none")) {
            spinner.classList.add("d-none");
        }
        // #endregion
}
// #endregion


