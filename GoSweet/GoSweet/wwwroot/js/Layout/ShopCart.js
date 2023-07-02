let shopCartBtn = document.querySelector(".shopCartIcon");

shopCartBtn.addEventListener("click", function (e) {
    let shopCartContent = document.querySelector(".shopCart-dropdown-menu");
    shopCartBtn.classList.toggle("active");
    shopCartContent.classList.toggle("shopCart-dropdown-menu-show");
});
