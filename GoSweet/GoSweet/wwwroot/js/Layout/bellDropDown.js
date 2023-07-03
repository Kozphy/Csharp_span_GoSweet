let bellIconBtn = document.querySelector(".bellIcon");
bellIconBtn.addEventListener("click", function (e) {
    let bellDropDownContent = document.querySelector(".bell-dropdown-menu");
    bellIconBtn.classList.toggle("active");
    bellDropDownContent.classList.toggle("bell-dropdown-menu-show");
});
