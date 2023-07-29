let bellIconBtn = document.querySelector(".bellIcon");
let bellDropDownContent = document.querySelector(".bell-dropdown-menu");
bellIconBtn.addEventListener("click", function (e) {
    bellIconBtn.classList.toggle("active");
    bellDropDownContent.classList.toggle("bell-dropdown-menu-show");
});

//let bellRedCount = bellIconBtn.nextElementSibling;
//let bellContent = document.querySelectorAll(".bellContent");
//console.log(bellContent.length);


let messageHaveReadBtn = document.querySelector(".messageHaveReadBtn");
let spinnerBtn = messageHaveReadBtn.nextElementSibling;
console.log(messageHaveReadBtn);
messageHaveReadBtn.addEventListener("click", async function (e) {
    let res = await axios.post("http://localhost:5183/Home/BellMessageHaveRead");
    if (res.status !== 200) {
        console.log(res.status);
    }
    messageHaveReadBtn.classList.add("d-none");
    spinnerBtn.classList.remove("d-none");

    let notifyMessageArray = res.data;
    if (notifyMessageArray.length === 0) {
        messageHaveReadBtn.classList.remove("d-none");
        spinnerBtn.classList.add("d-none");
        let htmlStr = `<a href="#" class="btn btn-hover-light rounded-0" style="width:300px">
                                            <div class="row align-items-center gy-2 gx-0">
                                                <div class="col-3 text-center">
                                                    <i class="bi bi-info-square info-icon"></i>
                                                </div>
                                                <div class="col-9 ">
                                                    <string>無信息</string>
                                                </div>
                                            </div>
                                        </a>
                                        <button class="btn btn-light ms-auto d-none" type="button" disabled>
                                        <span class="spinner-border spinner-border-sm" aria-hidden="true"></span>
                                        <span role="status">Loading...</span>
                                        </button>
                                        `;

        // remove all child element
        for (let i = bellDropDownContent.childElementCount - 1; i >= 0; i--) {
            bellDropDownContent.children[i].remove();
        }

        bellDropDownContent.insertAdjacentHTML("beforeend", htmlStr);
    }

});

