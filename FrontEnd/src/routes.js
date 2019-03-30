import React  from 'react';
import {Route, IndexRoute} from 'react-router';
import App from './Components/App';
import HomePage from './Components/home/HomePage';
import AboutPage from './Components/about/AboutPage';
import DocumentsPage from './Components/documents/DocumentsPage';
import signInPage from './Components/SignIn/signInPage';

export default(
    <Route path="/" component={App}>
    <IndexRoute component={HomePage}/>
    <Route path="about" component={AboutPage}/>
    <Route path="documents" component={DocumentsPage}/>
    <Route path="signIn" component={signInPage}/>
    </Route>
);