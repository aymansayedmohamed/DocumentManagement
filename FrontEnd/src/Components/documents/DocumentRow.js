import React, {PropTypes} from 'react';
import * as fileActions from '../../actions/fileActions';

const DocumentRow = ({file}) => {

    function dowloadDocument(event){
        event.preventDefault();
        fileActions.downloadDocument(file);
    }

    return (
        <tr>
            <td><button className="btn" onClick={dowloadDocument}>Dowload</button></td>
            <td>{file.DocumentName}</td>
            <td>{file.DocumentSize}</td>
            <td>{file.UploadDate}</td>
            <td>{file.LastAccessedDate}</td>

        </tr>
    );
};

DocumentRow.propTypes = {
    file : PropTypes.object.isRequired 
};

export default DocumentRow;
