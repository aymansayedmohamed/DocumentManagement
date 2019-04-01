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
        //const {documents} = this.props;
        return(
            <div>
                <br/>
                <label className="text-danger">{this.props.error}</label>
                <br/>
                <Uploader/>
                <DocumentsList documents={this.props.documents}/>                
            </div>
        );
    }
}

DocumentsPage.propTypes = {
    actions: PropTypes.object.isRequired,
    documents: PropTypes.array.isRequired
};

function mapStateToProps(state, ownProps){
    return {
        documents : state.documents,
        error : state.error
    };
}

function mapDispatchToProps(dispatch){
    return{
        actions : bindActionCreators(fileActions,dispatch)
    };
}

export default connect(mapStateToProps, mapDispatchToProps)(DocumentsPage);