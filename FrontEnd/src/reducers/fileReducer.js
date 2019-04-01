import * as types from '../constants/actionTypes';

export default function fileReducer(state = [],action){
    debugger;
    switch (action.type){
      
        case types.LOAD_DOCUMENTS_SUCCESS:
            return action.documents;


        case types.DOWNLOAD_BATCH_FILES_SUCCESS:
        return [
                ...action.documents
            ];

        case types.UPLOAD_DOCUMENT_SUCCESS:
        return [
            action.document,
            ...state
            ];

        default:
            return state;
    }
}