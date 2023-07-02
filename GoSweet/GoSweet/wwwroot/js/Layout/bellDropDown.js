let bellIconBtn = document.querySelector(".bellIcon");
bellIconBtn.addEventListener("click", function (e) {
    let bellDropDownContent = document.querySelector(".bell-dropdown-menu");
    bellIconBtn.classList.toggle("active");
    if (bellDropDownContent.classList.contains("bell-dropdown-menu-show")) {
        bellDropDownContent.classList.remove("bell-dropdown-menu-show");
        bellDropDownContent.classList.add("bell-dropdown-menu-close");
    } else
    {
        bellDropDownContent.classList.add("bell-dropdown-menu-show");
        bellDropDownContent.classList.remove("bell-dropdown-menu-close");
    }

});
