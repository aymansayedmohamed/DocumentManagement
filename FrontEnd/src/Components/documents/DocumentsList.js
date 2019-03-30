import React, {PropTypes} from 'react';
import DocumentRow from './DocumentRow';

const DocumentsList = ({files}) => {
    
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
                    <DocumentRow key = {file.DocumentID} file ={file}/>
                    )
                
            }
        </tbody>
        </table>
    );

};

DocumentsList.propTypes = {
    files: PropTypes.array.isRequired
};

export default DocumentsList;