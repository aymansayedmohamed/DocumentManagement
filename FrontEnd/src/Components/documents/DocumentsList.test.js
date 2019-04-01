import expect from 'expect';
import React from 'react';
import{mount,shallow} from 'enzyme';
import TestUtils from 'react-addons-test-utils';
import DocumentsList from './DocumentsList';

function setup(documents){
    let props ={
        documents: documents
    };

    return shallow(<DocumentsList {...props}/>);

}

describe('DocumentsList component tests', () => {

it('DocumentsList renders table',() => {
    const wrapper = setup([]);
    expect(wrapper.find('table').length).toBe(1);
});


it('DocumentsList renders number of row equal to the documents count',() => {
    debugger;
    const wrapper = setup([{},{}]);
    expect(wrapper.find('DocumentRow').length).toBe(2);

});

});








