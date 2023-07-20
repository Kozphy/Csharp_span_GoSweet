$(document).scroll(function (e) {
    localStorage['page'] = document.URL;
    localStorage['scrollTop'] = $(document).scrollTop();
});

// https://stackoverflow.com/questions/34727664/how-to-scrollto-without-animation
console.log(document.URL);
console.log(localStorage['scrollTop']);
$(document).ready(function (e) {
    window.scrollTo(localStorage['scrollTop'], { duration: 0 });
});