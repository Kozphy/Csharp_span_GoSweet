// #region html tag 標籤綁定
let openSideBarBtn = document.querySelector(".open-menu");
let sidebar = document.querySelector(".sideBar-section");
let closeSideBarBtn = document.querySelector(".sidebarClose");
// #endregion


// #region sidebar show 
openSideBarBtn.addEventListener("click", function (e) {
    sidebar.classList.add("sideBar-section-show");
});
// #endregion

// #region sidebar hidden
closeSideBarBtn.addEventListener("click", function (e) {
    sidebar.classList.remove("sideBar-section-show");
});
// #endregion
