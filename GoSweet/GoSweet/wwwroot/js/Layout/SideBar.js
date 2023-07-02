let openSideBarBtn = document.querySelector(".open-menu");
let sidebar = document.querySelector(".sideBar-section");

openSideBarBtn.addEventListener("click", function (e) {
    sidebar.classList.add("sideBar-section-show");
});

let closeSideBarBtn = document.querySelector(".sidebarClose");

closeSideBarBtn.addEventListener("click", function (e) {
    sidebar.classList.remove("sideBar-section-show");
});
