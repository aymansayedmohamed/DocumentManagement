/*import expect from 'expect';
import React from 'react';
import{mount,shallow} from 'enzyme';
import {SignInPage} from './signInPage';

function setup(user){

    const props = {
        user: user,
        actions: {downloadBatchFiles: (user) => {return Promise.resolve();}}
    };
    return mount(<SignInPage {...props} />);

}

describe('SignInPage component tests', () => {



it('set error message when trying to save download empty sources',() => {
    const wrapper = setup();
    const downloadButton = wrapper.find('input').last();
    expect(downloadButton.prop('type')).toBe('submit');
    downloadButton.simulate('click');
    expect(wrapper.state().errors.title).toBe('Sources is required');
});



});




*/