import React, {PropTypes} from 'react';
import {connect} from 'react-redux';
import fileApi from '../../api/filesApi';
import {bindActionCreators} from 'redux';
import * as fileActions from '../../actions/fileActions';


class Uploader extends React.Component{

  constructor(props, context){
      super(props,context);
      this.handleUploadFile = this.handleUploadFile.bind(this);
  }


  handleUploadFile(event) {
 
    const data = new FormData();
    data.append('UploadedDocument', event.target.files[0]);
    data.append('name', 'UploadedDocument');
    data.append('description', 'UploadedDocument');
    this.props.actions.uploadDocument(data);
}


render(){
    return(
      <div>
        <input type="file"  onChange={this.handleUploadFile} />
      </div>
    );
}

}


Uploader.propTypes = {
  actions: PropTypes.object.isRequired
};

function mapStateToProps(state, ownProps){
  debugger;
  return {
      document : state.document
  };
}

function mapDispatchToProps(dispatch){
  return{
      actions : bindActionCreators(fileActions,dispatch)
  };
}

export default connect(mapStateToProps, mapDispatchToProps)(Uploader);