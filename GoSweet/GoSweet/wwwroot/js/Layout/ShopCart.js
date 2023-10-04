// #region 取得 html tag
let shopCartBtn = document.querySelector(".shopCartIcon");
// #endregion

// #region 購物車顯示，隱藏
shopCartBtn.addEventListener("click", function (e) {
    let shopCartContent = document.querySelector(".shopCart-dropdown-menu");
    shopCartBtn.classList.toggle("active");
    shopCartContent.classList.toggle("shopCart-dropdown-menu-show");
});
// #endregion
