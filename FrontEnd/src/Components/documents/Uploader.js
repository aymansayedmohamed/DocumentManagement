import React, { Component } from 'react';
import fileApi from '../../api/filesApi';

function Uploader () {

  function handleUploadFile(event) {
 
    const data = new FormData();
    data.append('UploadedImage', event.target.files[0]);
    data.append('name', 'UploadedImage');
    data.append('description', 'UploadedImage');
    fileApi.uploadFile(data).then((response) => {
      debugger;
      console.log(response); // do something with the response
    });

  
   
}


  return(
  <div>
    <input type="file"  onChange={handleUploadFile} />
  </div>
  );

}

export default Uploader;