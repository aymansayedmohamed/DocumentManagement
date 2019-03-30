import React, {PropTypes} from 'react';
import {connect} from 'react-redux';
import * as fileActions from '../../actions/fileActions';
import {bindActionCreators} from 'redux';
import FilesList from './FilesList';
import Uploader from './Uploader';

class FilesPage extends React.Component{

    constructor(props, context){
        super(props,context);
    }

   

    render(){
        //const {files} = this.props;
        return(
            <div>
                <Uploader/>
                <FilesList files={this.props.files}/>                
            </div>
        );
    }
}

FilesPage.propTypes = {
    actions: PropTypes.object.isRequired,
    files: PropTypes.array.isRequired
};

function mapStateToProps(state, ownProps){
    return {
        files : state.files
    };
}

function mapDispatchToProps(dispatch){
    return{
        actions : bindActionCreators(fileActions,dispatch)
    };
}

export default connect(mapStateToProps, mapDispatchToProps)(FilesPage);