import axios from 'axios';

class AuthApi {

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

 
}

export default AuthApi;