import React , {PropTypes} from 'react';
import {connect} from 'react-redux';
import {bindActionCreators} from 'redux';
import SignInForm from './signInForm';
import * as fileActions from '../../actions/fileActions';

export class SignInPage extends React.Component{

    constructor(props, context){
        super(props, context);
        
        this.state={
            user : Object.assign({}, this.props.user),
            errors:{}
            };
        this.updateSourcesState = this.updateSourcesState.bind(this);
        this.signIn = this.signIn.bind(this);
    }

    updateSourcesState(event){
        const field = event.target.name;
        let user = this.state.user;
        user[field] = event.target.value;
        return this.setState({user: user});
    }

    signInFormValid(){
        let formIsValid = true;
        let errors = {};

        if(this.state.user.Sources && this.state.user.Sources.length<1){
            errors.title = "Sources is required";
            formIsValid = false;
        }

        this.setState({errors: errors});
        return formIsValid;
    }

    signIn(event){
        event.preventDefault();

        if(!this.signInFormValid()){
            return;
        }

        this.props.actions.signIn(this.state.user);
        this.context.router.push('/documents');
    }

    render(){
         return(
             <div>
                <h1>Sign In</h1>
                <SignInForm
                onSignIn={this.signIn}
                onChange={this.updateSourcesState}
                user={this.state.user}
                errors={this.state.errors}
                />
             </div>
         );
    }

}

//Pull in the React Router context so router is available on this.context.router
SignInPage.contextTypes ={
    router: PropTypes.object
};

SignInPage.propTypes ={
    user: PropTypes.object.isRequired,
    actions: PropTypes.object.isRequired
    };

function mapStateToProps(state , ownProps){
    
    let user = {Sources:""};
    return{
        user: user
    };
}
function mapDispatchToProps(dispatch){
    return{
    actions : bindActionCreators(fileActions, dispatch)
    };
}
export default connect(mapStateToProps,mapDispatchToProps)(SignInPage);