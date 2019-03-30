import React, {PropTypes} from 'react';
import {Link, IndexLink } from 'react-router';

const Header = () => {
    return(
        <nav>
            <IndexLink to="/" activeClassName="active">Home</IndexLink>
            {" | "}
            <Link to="/about" activeClassName="active">About</Link>
            {" | "}
            <Link to="/readyForProcessingFiles" activeClassName="active">Documents</Link>
            {" | "}
            <Link to="/downloadBatchFiles" activeClassName="active">Login</Link>
        </nav>
    );
};

export default Header;