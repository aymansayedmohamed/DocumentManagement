import {combineReducers} from 'redux';
import documents from './fileReducer';
import token from './AuthReducer';
import error from './errorReducer';


const rootReducer = combineReducers({
    documents,
    token,
    error
});

export default rootReducer;