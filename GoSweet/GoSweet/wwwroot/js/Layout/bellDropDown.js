// #region 取得 html 標籤 
let bellIconBtn = document.querySelector(".bellIcon");
let bellDropDownContent = document.querySelector(".bell-dropdown-menu");
let messageHaveReadBtn = document.querySelector(".messageHaveReadBtn");
let firmMessageHaveReadBtn = document.querySelector(".firmMessageHaveReadBtn");
// #endregion

// #region 通知欄顯示與隱藏
bellIconBtn.addEventListener("click", function (e) {
    bellIconBtn.classList.toggle("active");
    bellDropDownContent.classList.toggle("bell-dropdown-menu-show");
});
// #endregion 

// #region 通知訊息按鈕檢測是 Home or Firm

if (messageHaveReadBtn) {
    clearNotifyMessage(messageHaveReadBtn, "Home");
} else {
    clearNotifyMessage(firmMessageHaveReadBtn, "Firm");
}
// #endregion

// #region 清除通知訊息
function clearNotifyMessage(btn, controllerName) {
    let spinnerBtn = btn.nextElementSibling;
    btn.addEventListener("click", async function (e) {
        btn.classList.add("d-none");
        spinnerBtn.classList.remove("d-none");

        let res = await sendClearInfo(controllerName);
        let notifyMessageArray = res.data;


        if (notifyMessageArray.length === 0) {
            // 通知欄訊息清除 
            //while (bellDropDownContent.firstChild) {
            //    bellDropDownContent.removeChild(bellDropDownContent.lastChild);
            //}
            for (let i = bellDropDownContent.childElementCount - 1; i >= 0; i--) {
                bellDropDownContent.children[i].remove();
            }
            renderDropDownBellMessageToNull(btn, spinnerBtn);
        }
    });
}
// #endregion

// #region 觸發清除到 Home or Firm controller
async function sendClearInfo(controllerName) {
    let res = await axios.post(`http://localhost:5183/${controllerName}/BellMessageHaveRead`);
    if (res.status !== 200) {
        console.log(res.status);
    }
    return res;
}

// #endregion

// #region 清除通知訊息
function renderDropDownBellMessageToNull(btn, spinnerBtn) {

    btn.classList.remove("d-none");
    spinnerBtn.classList.add("d-none");


    // html content
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


    bellDropDownContent.insertAdjacentHTML("beforeend", htmlStr);
    document.querySelector(".notify-message-counter").textContent = 0;
}
// #endregion
