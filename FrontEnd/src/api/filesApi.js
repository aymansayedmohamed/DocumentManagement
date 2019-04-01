import axios from 'axios';

class FilesApi {

  static uploadDocument(file){

    return axios.post('http://localhost:64339/api/Documents/UploadDocument', file,
                    {
                      headers: {
                        Authorization: {
                          toString () {
                            return `Bearer ${localStorage.getItem('token')}`;
                          }
                        }}
                    });
  }

  static getAllDocuments() {
   // return axios.get(`http://localhost:64339/api/Documents/GetAllDocuments`  );
    return axios(`http://localhost:64339/api/Documents/GetAllDocuments`,  {
      method: 'GET',
      headers: {
        Authorization: {
          toString () {
            return `Bearer ${localStorage.getItem('token')}`;
          }
        }}
  });
   }

  static downloadDocument(fileId) {
     //return axios.get(`http://localhost:64339/api/Documents/DownloadDocument/`+fileId  );

    return axios(`http://localhost:64339/api/Documents/DownloadDocument/`+fileId , {
      method: 'GET',
      headers: {
        Authorization: {
          toString () {
            return `Bearer ${localStorage.getItem('token')}`;
          }
        }}
      ,responseType: 'blob' //Force to receive data in a Blob Format
  });

  }

  
  

 
}

export default FilesApi;