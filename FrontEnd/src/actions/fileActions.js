import * as types from '../constants/actionTypes';
import fileApi from '../api/filesApi';
import { saveAs } from 'file-saver';

export function loadFilesSuccess(files){
    debugger;
    return{type: types.LOAD_FILES_SUCCESS, files};
}

export function approveFileSuccess(file){
    return {type: types.APPROVE_FILE_SUCCESS, file};
}

export function rejectFileSuccess(file){
    return {type: types.REJECT_FILE_SUCCESS, file};
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

export function loadFiles(){
    return function(dispatch){
        
        return fileApi.getAllFiles().then(Response =>{
            debugger;
            dispatch(loadFilesSuccess(Response.data));
        }).catch(error => {
            debugger;
            throw(error);
        });
    };
}

export function downloadFile(file){
    fileApi.approveFile(file.DocumentID).then(response => {
        saveAs(response.data, file.DocumentName);
        })
        .catch(error => {
            console.log(error);
        });
}

export function approveFile(fileId){

    return function(dispatch,getState){

        return fileApi.approveFile(fileId).then(Response =>{
            debugger;
           // dispatch(approveFileSuccess(Response.data));
        }).catch(error => {
            debugger;
            throw(error);
        });

    };
}

export function rejectFile(file){

    return function(dispatch,getState){

        return fileApi.rejectFile(file).then(Response => {
            dispatch(rejectFileSuccess(Response.data));
        }).catch(error => {
            throw(error);

        });
    };
}