let bellIconBtn = document.querySelector(".bellIcon");
bellIconBtn.addEventListener("click", function (e) {
    let bellDropDownContent = document.querySelector(".bell-dropdown-menu");
    bellIconBtn.classList.toggle("active");
    bellDropDownContent.classList.toggle("bell-dropdown-menu-show");
});

//let bellRedCount = bellIconBtn.nextElementSibling;
//let bellContent = document.querySelectorAll(".bellContent");
//console.log(bellContent.length);
// TODO: fix if content is default value
//bellRedCount.textContent = bellContent.length;
//bellIconBtn.textContent =
//console.log(bellRedCount);
//bellIconBtn.textContent

//let bellContentHtml = `<li>
//                           <a href="#" class="d-block btn btn-hover-light rounded-2 d-flex align-items-start gap-2 py-2 px-3 lh-sm text-start">
//                                <div class="row justify-content-center align-items-center flex-grow-1">
//                                    <div class="col-3 text-center">
//                                        <i class="bi bi-info-square info-icon"></i>
//                                    </div>
//                                    <div class="col-9 ">
//                                        <string>無信息</string>
//                                    </div>
//                                </div>
//                            </a>
//                        </li>`;

//let bellContent = document.querySelector(".bellContent");


