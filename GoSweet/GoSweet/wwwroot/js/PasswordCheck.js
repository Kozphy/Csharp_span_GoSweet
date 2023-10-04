// #region 取得 html tag
let userPassword = document.querySelector("#UserPassword");
let userCheckPassword = document.querySelector("#UserPasswordCheck");
let signUpBtn = document.querySelector(".SignUpBtn");
// #endregion

// #region password 檢查，與是否有輸入
signUpBtn.addEventListener("click", function (e) {
    let checkPasswordResult = document.querySelector(".passwordCheckResult");
    if (userPassword.value.length == 0 || userCheckPassword.value.length == 0) {
        checkPasswordResult.textContent = "Please input password for signUp";
        return;
    }

    if (userPassword.value !== userCheckPassword.value || userPassword.length !== userCheckPassword.length) {
        e.preventDefault(); 
        checkPasswordResult.textContent = "Password is not match";
        return;
    }

    checkPasswordResult.classList.remove("text-danger");
    checkPasswordResult.classList.add("text-success");
    checkPasswordResult.textContent = "Password match";
});
// #endregion