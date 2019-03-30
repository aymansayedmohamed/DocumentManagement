import * as types from '../constants/actionTypes';
import fileApi from '../api/filesApi';
import { saveAs } from 'file-saver';

export function loadDocumentsSuccess(files){
    debugger;
    return{type: types.LOAD_DOCUMENTS_SUCCESS, files};
}

export function signInSUCCESS(token){
    debugger;
    return {type: types.Sign_In_SUCCESS, token};
}




export function signIn(user){
    debugger
    return function(dispatch){
        
        return fileApi.signIn(user).then(Response =>{
            localStorage.setItem('token', Response.data.access_token);
            dispatch(signInSUCCESS(Response.data.access_token));
        }).catch(error => {
            debugger;
            throw(error);
        });
    };
}

export function loadDocuments(){
    return function(dispatch){
        
        return fileApi.getAllDocuments().then(Response =>{
            debugger;
            dispatch(loadDocumentsSuccess(Response.data));
        }).catch(error => {
            debugger;
            throw(error);
        });
    };
}

export function downloadDocument(file){
    fileApi.downloadDocument(file.DocumentID).then(response => {
        saveAs(response.data, file.DocumentName);
        })
        .catch(error => {
            console.log(error);
        });
}


