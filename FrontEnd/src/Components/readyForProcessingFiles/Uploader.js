import React, { Component } from 'react';
import axios from 'axios';

function Uploader () {

  function handleUploadFile(event) {

    const data = new FormData();
    data.append('UploadedImage', event.target.files[0]);
    data.append('name', 'UploadedImage');
    data.append('description', 'UploadedImage');
    axios.post('http://localhost:64339/api/Documents/UploadFiles', data,
                      {
                        headers: {
                          Authorization: {
                            toString () {
                              return `Bearer ${localStorage.getItem('token')}`;
                            }
                          }}
                      }
    ).then((response) => {
      debugger;
      console.log(response); // do something with the response
    });

  
   
}


  return(
  <div>
    <input type="file" onChange={handleUploadFile} />
  </div>
  );

}

export default Uploader;