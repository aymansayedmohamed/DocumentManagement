import * as types from '../constants/actionTypes';

export default function AuthReducer(state = "",action){
    debugger;
    switch (action.type){
        
        case types.Sign_In_SUCCESS:
        return action.token;

        default:
            return state;
    }
}