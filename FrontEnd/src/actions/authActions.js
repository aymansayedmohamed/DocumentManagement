import * as types from '../constants/actionTypes';
import authApi from '../api/authApi';


export function signInSUCCESS(token){
    debugger;
    return {type: types.Sign_In_SUCCESS, token};
}

export function signInFailed(error){
    return {type: types.SIGN_IN_FAILED, error};
}




export function signIn(user){
    debugger
    return function(dispatch){
        
        return authApi.signIn(user).then(Response =>{
            localStorage.setItem('token', Response.data.access_token);
            dispatch(signInSUCCESS(Response.data.access_token));
        }).catch(error => {
            debugger;
            dispatch(signInFailed("Wrong user name or password."));
        });
    };
}




