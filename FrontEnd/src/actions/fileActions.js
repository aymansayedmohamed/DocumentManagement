import * as types from '../constants/actionTypes';
import fileApi from '../api/filesApi';
import authApi from '../api/authApi';
import { saveAs } from 'file-saver';

export function loadDocumentsSuccess(documents){
    debugger;
    return{type: types.LOAD_DOCUMENTS_SUCCESS, documents};
}

export function uploadDocumentSuccess(document){
    return {type: types.UPLOAD_DOCUMENT_SUCCESS, document}
}

export function uploadDocumentFail(error){
    return {type: types.UPLOAD_DOCUMENT_FAIL, error}
}

export function downloadDocumentFail(error){
    return {type: types.DOWNLOAD_DOCUMENT_FAIL, error}
}

export function loadDocumentFail(error){
    return {type: types.LOAD_DOCUMENT_FAIL, error}
}



export function loadDocuments(){
    return function(dispatch){
        
        return fileApi.getAllDocuments().then(Response =>{
            debugger;
            dispatch(loadDocumentsSuccess(Response.data));
        }).catch(error => {
            debugger;
            if(error.response.status==401)
                dispatch(uploadDocumentFail('You are not autherized to see the dcouments ,please login then try again'));
            else
                dispatch(uploadDocumentFail("Error"));        });
    };
}

export function uploadDocument(document){
    return function(dispatch){
        
        fileApi.uploadDocument(document).then((response) => {
            debugger;
            dispatch(uploadDocumentSuccess(response.data));
          }).catch(error => {
              if(error.response.status==401)
                    dispatch(uploadDocumentFail('You are not autherized to upload ,please login then try again'));
              else
              dispatch(uploadDocumentFail("Error"));
        });
    };
}

export function downloadDocument(file){
    debugger;
    return function(dispatch){
    fileApi.downloadDocument(file.DocumentID).then(response => {
        saveAs(response.data, file.DocumentName);
        })
        .catch(error => {
            if(error.response.status==401)
            dispatch(downloadDocumentFail('You are not autherized to download ,please login then try again'));
            else
              dispatch(downloadDocumentFail("Error"));
        });
    };
}


