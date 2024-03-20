let fileUploadFrame = document.querySelector("#fileUpload");
let filesUploadFrame = document.querySelector("#filesUpload");
let StorageFileToDatabaseBtn = document.querySelector("#storageFileToDatabase");

filesUpload();

// #region js get dataFrom DOM
function filesUpload() {
    StorageFileToDatabaseBtn.addEventListener("click", function (e) {
        let formData = new FormData()
        if (fileUploadFrame.value) {
            formData.append("fileUpload", fileUploadFrame.files[0]);
        }

        if (filesUploadFrame.value) {
            for (let file of filesUploadFrame.files) {
                formData.append("filesUpload", file)
            }
        }

        let totalUploadFiles = fileUploadFrame.attributes.length + filesUploadFrame.attributes.length;

        if (totalUploadFiles > 0) {
            Upload(formData);
        }
    });
}
// #endregion



// #region Post to backend
async function Upload(formData) {
    //console.log(`formDataContent:,
    //${formData.get('fileUpload')}
    //${formData.get('filesUpload')}`)
    try {
        let baseURL = 'http://localhost:5183/Home/UploadFiles';
        // jquery post
        $.ajax({
            url: baseURL,
            type: 'POST',
            data: formData,
            processData: false,
            contentType: false,
            success: function (response) {
                alert('Upload successful!')
                console.log(response);
            },
            error: function (error) {
                alert('Error occurred during upload.')
            }
        });

        // axios post
        //const axiosInstance = axios.create({
        //    baseURL: baseURL,
        //    timeout:1000,
        //    headers:
        //    {
        //        "Content-Type": "multipart/form-data" // Removed the trailing semicolon
        //    }
        //});
        //let res = await axiosInstance.post(formData);
        //if (res.status === 200) {
        //    console.log(`res: ${res}`);
        //    alert("upload file success")
        //} else {
        //    alert("upload file fail")
        //}


        // alova post
        //const alovaInstance = createAlova({
        //    requestAdapter: GlobalFetch()
        //});

        //let res = await alovaInstance.Post('http://localhost:5183/Home/StorageFileToDatabase',
        //    {
        //        files: formData
        //    }
        //)

    } catch (err) {
        console.log(`err: ${err}`);
    }

}
// #endregion


