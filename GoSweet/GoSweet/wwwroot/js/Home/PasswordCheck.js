let userPassword = document.querySelector("#UserPassword");
let userCheckPassword = document.querySelector("#UserPasswordCheck");


let signUpBtn = document.querySelector(".SignUpBtn");
signUpBtn.addEventListener("click", function (e) {
    console.log(userPassword != userCheckPassword);
    let checkPasswordResult = document.querySelector(".passwordCheckResult");
    if (userPassword != userCheckPassword) {
        e.preventDefault(); 
        checkPasswordResult.textContent = "Password is not match";
        //console.log(checkPasswordResult);
    }

    checkPasswordResult.classList.remove("text-danger");
    checkPasswordResult.classList.add("text-success");
    checkPasswordResult.textContent = "Password match";
    
});