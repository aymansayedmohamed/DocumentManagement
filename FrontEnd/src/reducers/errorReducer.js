import * as types from '../constants/actionTypes';

export default function errorReducer(state ='' ,action){
    debugger;
    switch (action.type){
      
        case types.UPLOAD_DOCUMENT_FAIL:
            return action.error;

        case types.SIGN_IN_FAILED:
            return action.error;

        case types.DOWNLOAD_DOCUMENT_FAIL:
             return action.error;

        case types.LOAD_DOCUMENT_FAIL:
             return action.error;

        default:
            return state;
    }
}