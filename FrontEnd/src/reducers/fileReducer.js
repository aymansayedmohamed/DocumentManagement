import * as types from '../constants/actionTypes';

export default function fileReducer(state = [],action){
    debugger;
    switch (action.type){
      
        case types.LOAD_DOCUMENTS_SUCCESS:
            return action.files;


        case types.DOWNLOAD_BATCH_FILES_SUCCESS:
        return [
                ...action.files
            ];

        default:
            return state;
    }
}