import React, {PropTypes} from 'react';
import {connect} from 'react-redux';
import {bindActionCreators} from 'redux';
import * as fileActions from '../../actions/fileActions';

class DocumentRow extends React.Component{

    constructor(props, context){
        super(props,context);
        this.dowloadDocument = this.dowloadDocument.bind(this);
    }
  

     dowloadDocument(event){
         debugger;
        event.preventDefault();
        this.props.actions.downloadDocument(this.props.file);
    }

    render(){
    return (
        <tr>
            <td><button className="btn" onClick={this.dowloadDocument}>Dowload</button></td>
            <td>{this.props.file.DocumentName}</td>
            <td>{this.props.file.DocumentSize}</td>
            <td>{this.props.file.UploadDate}</td>
            <td>{this.props.file.LastAccessedDate}</td>

        </tr>
    );
    }
}



DocumentRow.propTypes = {
    actions: PropTypes.object.isRequired,
    file : PropTypes.object.isRequired 

  };
  
  function mapStateToProps(state, ownProps){
    return {
    };
  }
  
  function mapDispatchToProps(dispatch){
    return{
        actions : bindActionCreators(fileActions,dispatch)
    };
  }
  
  export default connect(mapStateToProps, mapDispatchToProps)(DocumentRow);
