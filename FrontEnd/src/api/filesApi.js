import axios from 'axios';

class FilesApi {

  static signIn(user) {  
    debugger;       
    return axios.post(`http://localhost:64339/token`
                      , 'grant_type=password&username='+user.UserName+'&password='+user.Password
                      ,
                      {
                        headers: {
                                'Content-Type': 'application/x-www-form-urlencoded' ,
                                'Accept': 'application/json'                                       
                                 }
                      }
                    );
  }

  static getAllFiles() {
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

  static approveFile(fileId) {
     //return axios.get(`http://localhost:64339/api/Documents/DownloadFiles/`+fileId  );

    return axios(`http://localhost:64339/api/Documents/DownloadFiles/`+fileId , {
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

  static rejectFile(file) {
    
     return axios.put(`http://localhost:59346/api/Download/RejectFile`,file  );
  }
  

 
}

export default FilesApi;