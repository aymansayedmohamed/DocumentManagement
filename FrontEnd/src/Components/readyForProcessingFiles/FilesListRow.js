import React, {PropTypes} from 'react';
import fileApi from '../../api/filesApi';
import { saveAs } from 'file-saver';
import * as fileActions from '../../actions/fileActions';

const FilesListRow = ({file}) => {




    function dowloadFile(event){
        event.preventDefault();
        fileActions.downloadFile(file);
    }

    return (
        <tr>
            <td><button onClick={dowloadFile}>Dowload</button></td>
            <td>{file.DocumentName}</td>
            <td>{file.DocumentSize}</td>
            <td>{file.UploadDate}</td>
            <td>{file.LastAccessedDate}</td>

        </tr>
    );
};

FilesListRow.propTypes = {
    file : PropTypes.object.isRequired 
};

export default FilesListRow;
