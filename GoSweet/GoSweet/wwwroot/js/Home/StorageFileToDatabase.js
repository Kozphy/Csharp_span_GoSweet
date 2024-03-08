let fileUploadFrame = document.querySelector("#fileUpload");
let filesUploadFrame = document.querySelector("#filesUpload");
let StorageFileToDatabaseBtn = document.querySelector("#storageFileToDatabase");

function StorageFileToDatabase() {
    StorageFileToDatabaseBtn.addEventListener("click", function (e) {
        console.log("fileUpload");
        console.log(`fileUploadFrame.nodeValue: ${fileUploadFrame.nodeValue}`);
        console.log(`filesUploadFrame.nodeValue: ${filesUploadFrame.nodeValue}`);
        if (fileUploadFrame.nodeValue || filesUploadFrame.nodeValue) {
            console.log("fileupload have value");
            fileUpload();
            filesUpload();
            console.log(fileUploadFrame.nodeValue);
            console.log(filesUploadFrame.nodeValue);
        }
    });
}

StorageFileToDatabase();


function fileUpload() {
    fileUploadFrame.addEventListener("change", function (e) {
      let file = e.target.files[0];
      console.log("file");
      console.log(file);
    });
}

function filesUpload() {
    filesUploadFrame.addEventListener("change", function (e) {
      let files = e.target.files;
      console.log("files")
      console.log(files);
    });
}

