let fileUploadBtn = document.querySelector("#fileUpload");
let filesUploadBtn = document.querySelector("#filesUpload");



fileUploadBtn.addEventListener("change", function (e) {
  let file = e.target.files[0];
  console.log("file");
  console.log(file);
});


filesUploadBtn.addEventListener("change", function (e) {
  let files = e.target.files;
  console.log("files")
  console.log(files);
});


//class fileUpload {
//    button
//    constructor(button) {
//        this.button = button;
//    }

//    change() {
//        this.button.addEventListener("change", function (e) {
//            let files = null;
//            if (e.target.files.length == 1) {
//                files = e.target.files[0];
//            } else {
//                files = e.target.files;
//            }
//        }
//        , false)
//    }
//}
