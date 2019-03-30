import React, {PropTypes} from 'react';

const SignInForm = ({user, onChange, onSignIn, loading, errors})=>{

    return(
        <form>
            <div className="form-group">
            <label>Email : </label>
                <input className="form-control" 
                    id="UserName"
                    value={user.UserName}
                    onChange={onChange}
                    errors={errors}
                    name="UserName"
                    >
                </input>
            
                {/* {errors && <div className="alert alert-danger">{errors.title}</div>} */}
            </div>
            <div className = "form-group">
            <label> Password : </label>
            <input type="password" className="form-control" 
                    id="password"
                    value={user.Password}
                    onChange={onChange}
                    errors={errors}
                    name="Password"
                    >
                </input>
            </div>
            <div className="form-group">
                <input
                    type="submit"
                    disabled={loading}
                    value={loading? '...' : 'Sign In'}
                    className="btn btn-primary"
                    onClick={onSignIn}/>
            </div>
        </form>

    );
};

SignInForm.propTypes = {
    user: PropTypes.object.isRequired,
    onChange: PropTypes.func.isRequired,
    onSignIn: PropTypes.func.isRequired,
    loading: PropTypes.bool,
    errors: PropTypes.object
};

export default SignInForm;

