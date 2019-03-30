import {combineReducers} from 'redux';
import files from './fileReducer';
import token from './AuthReducer';

const rootReducer = combineReducers({
    files,
    token
});

export default rootReducer;