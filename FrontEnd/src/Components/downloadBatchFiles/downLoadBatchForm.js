import React, {PropTypes} from 'react';

const DownLoadBatchForm = ({batchSources, onChange, onDownload, loading, errors})=>{

    return(
        <form>
            <div className="form-group">
            <label>Email : </label>
                <input className="form-control" 
                    id="UserName"
                    value={batchSources.UserName}
                    onChange={onChange}
                    errors={errors}
                    name="UserName"
                    >
                </input>
            
                {/* {errors && <div className="alert alert-danger">{errors.title}</div>} */}
            </div>
            <div className = "form-group">
            <label> Password : </label>
            <input className="form-control" 
                    id="password"
                    value={batchSources.Password}
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
                    onClick={onDownload}/>
            </div>
        </form>

    );
};

DownLoadBatchForm.propTypes = {
    batchSources: PropTypes.object.isRequired,
    onChange: PropTypes.func.isRequired,
    onDownload: PropTypes.func.isRequired,
    loading: PropTypes.bool,
    errors: PropTypes.object
};

export default DownLoadBatchForm;

