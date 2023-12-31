﻿let productCategoryBtns = document.querySelectorAll(".productCategoryBtn");
let productCategoryTitles = document.querySelectorAll(".product-category-title");


// #region 商品種類點擊 
async function sendCategoryInfo(category) {
    let res = await axios.get(`http://localhost:5183/Home/HandleProductCategory?Category=${category}`,
        {
            headers: {
                "content-type": "application/x-www-form-urlencoded"
            },
        })
    if (res.status !== 200) {
        console.log(res.status);
    }
    return res;
}

function renderCategoryProducts(data) {
        let splideProducts = document.querySelector(".splideProducts");
        splideProducts.remove();

        let allhtml = [`<section class="splide splideProducts">
                <div class="splide__track">
                    <ul class="splide__list">`];

        data.forEach((el, index) => {
            let htmlstr =
                `<li class="splide__slide">
                    <div class="splide__slide__container">
                        <div class="product-rank-card card">
                            <div class="position-relative">
                                <div class="product-rank-hover-content d-flex">
                                    <form method="get" action="/Search/Product" class="m-auto">
                                        <input type="hidden" name="pid" value="${el.ProductId}">
                                        <button type="submit" class="btn btn-outline-light rounded-0 btnGo">GO >></button>
                                    </form>
                                </div>
                                <img class="card-img-top" src="${el.ProductPicture}" />
                            </div>
                            <div class="card-title mb-0 py-2 text-center product-card-title">
                                ${el.ProductName}
                            </div>
                            <div class="card-body">
                                <div class="text-center card-text multiline-ellipsis-3">
                                ${el.ProductDescription}
                                </div>
                            </div>
                            <div class="card-footer">
                                大約 ${el.ProductTotalBuyNumber} 人購買
                            </div>
                        </div>
                    </div>
                </li>`;

            allhtml.push(htmlstr);
        });
        allhtml.push(`</ul></div</section>`);
        allhtml = allhtml.join("");

        let productRank = document.querySelector(".product-rank");
        productRank.insertAdjacentHTML('beforeend', allhtml);

        let splide = new Splide('.splideProducts', {
            mediaQuery: 'min',
            grid: false,
            breakpoints: {
                800: {
                    grid: {
                        rows: 2,
                        cols: 3,
                        gap: {
                            row: '2rem',
                            col: '1.5rem',
                        },
                    },
                },
            },
            type: 'loop',
            autoplay: 'pause',
            gap: '1rem',
            pagination: false,
            arrows: false,
        });
        splide.mount(window.splide.Extensions);


}

productCategoryBtns.forEach((element, index) => {
    element.addEventListener("click",
        async function(e) {
            e.preventDefault();
            let category = productCategoryTitles[index].textContent;
            // change small title
            changeCategorySmallTitle(category);

            // send category to controller
            let res = await sendCategoryInfo(category);

            let data = JSON.parse(res.data);
            renderCategoryProducts(data);
        });
});
// #endregion

// #region 商品種類 title 切換
function changeCategorySmallTitle(category) {
    let productRankSmallTitle = document.querySelector(".product-rank-small-title");
    productRankSmallTitle.textContent = `${category}熱銷排行(下方滑鼠可左右拖曳)`;
}

// #endregion
