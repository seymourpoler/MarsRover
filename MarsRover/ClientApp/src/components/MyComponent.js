import React, { Component } from 'react';
import axios from 'axios';

class MyComponent extends Component {
    constructor() {
        super();
        this.state = {
            data: {
                // Your data to send in the request body
                name: 'John Doe',
                email: 'john.doe@example.com',
            },
        };
    }

    handleSubmit = async () => {
        try {
            //const response = await axios.post('api/v0/people', this.state.data);
            const response = await axios.post('http://localhost:44422/api/v0/people');
            console.log('Response from API:', response.data);
        } catch (error) {
            console.error('Error:', error);
        }
    };

    render() {
        return (
            <div>
                <button onClick={this.handleSubmit}>Send POST Request</button>
            </div>
        );
    }
}

export default MyComponent;