import React, {PropTypes} from 'react';
import {connect} from 'react-redux';
import * as fileActions from '../../actions/fileActions';
import {bindActionCreators} from 'redux';
import DocumentsList from './DocumentsList';
import Uploader from './Uploader';

class DocumentsPage extends React.Component{

    constructor(props, context){
        super(props,context);
    }

   

    render(){
        //const {files} = this.props;
        return(
            <div>
                <br/>
                <div className="text-right">
                <Uploader/>
                </div>
                <DocumentsList files={this.props.files}/>                
            </div>
        );
    }
}

DocumentsPage.propTypes = {
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

export default connect(mapStateToProps, mapDispatchToProps)(DocumentsPage);