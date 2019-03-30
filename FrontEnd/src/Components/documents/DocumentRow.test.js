import expect from 'expect';
import React from 'react';
import{mount,shallow} from 'enzyme';
import TestUtils from 'react-addons-test-utils';
import DocumentRow from './DocumentRow';

function setup(file){
    let props ={
        file: file
    };

    return shallow(<DocumentRow {...props}/>);

}

describe('DocumentRow component tests', () => {


it('DocumentRow renders tr',() => {
    const wrapper = setup({});
    expect(wrapper.find('tr').length).toBe(1);
});

it('DocumentRow renders correct Source data',() => {
    const wrapper = setup({Source: "Source"});
    expect(wrapper.find('td').get(1).props.children).toEqual('Source');
});

it('DocumentRow renders correct ProcessingStatus data',() => {
    const wrapper = setup({ProcessingStatus: "ProcessingStatus"});
    expect(wrapper.find('td').get(2).props.children).toEqual('ProcessingStatus');
});



});




