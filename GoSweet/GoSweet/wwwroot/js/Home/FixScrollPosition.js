$(document).scroll(function (e) {
    localStorage['page'] = document.URL;
    localStorage['scrollTop'] = $(document).scrollTop();
});

// https://stackoverflow.com/questions/34727664/how-to-scrollto-without-animation
console.log(document.URL);
console.log(localStorage['scrollTop']);
$(document).ready(function (e) {
    console.log(1);
    position = {
        top: localStorage['scrollTop'],
        left: 0,
        behavior: "instant"
    }
    window.scrollTo(position);
});