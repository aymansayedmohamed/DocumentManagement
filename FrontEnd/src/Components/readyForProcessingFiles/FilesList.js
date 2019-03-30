import React, {PropTypes} from 'react';
import FilesListRow from './FilesListRow';

const FilesList = ({files}) => {
    
    return(
        <table className="table table-striped">
        <thead>
            <tr>
                <th>&nbsp;</th>
                <th>Document Name</th>
                <th>Document Size</th>
                <th>Upload Date</th>
                <th>Last AccessedDate</th>
            </tr>
        </thead>
        <tbody>
            {
                
                files.map(file => 
                    <FilesListRow key = {file.DocumentID} file ={file}/>
                    )
                
            }
        </tbody>
        </table>
    );

};

FilesList.propTypes = {
    files: PropTypes.array.isRequired
};

export default FilesList;