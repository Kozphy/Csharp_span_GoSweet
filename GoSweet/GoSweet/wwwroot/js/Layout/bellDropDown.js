let bellIconBtn = document.querySelector(".bellIcon");
bellIconBtn.addEventListener("click", function (e) {
    let bellDropDownContent = document.querySelector(".bell-dropdown-menu");
    bellIconBtn.classList.toggle("active");
    bellDropDownContent.classList.toggle("bell-dropdown-menu-show");
});

let bellContentHtml = `<li>
                        <a href="#" class="btn btn-hover-light rounded-2 d-flex align-items-start gap-2 py-2 px-3 lh-sm text-start">
                            <div class=" h-100 flex-grow-1 d-flex justify-content-center align-items-center">
                                <i class="bi bi-info-square info-icon"></i>
                            </div>
                            <div class="flex-grow-1">
                                <strong class="d-block">Main product</strong>
                                <small>Take a tour through the product</small>
                            </div>
                        </a>
                    </li>`;

                    
