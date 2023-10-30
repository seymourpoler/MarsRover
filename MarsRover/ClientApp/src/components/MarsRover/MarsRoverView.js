import React, { Component } from 'react';
import { createMarsRoverPresenter } from './MarsRoverPresenter';
import { createHttp } from './../../Http'

export class MarsRoverView extends Component {

    constructor(props) {
        super(props);

        this.state = {
            errorMessage: '',
            command: ''
        }
    }

    presenter = createMarsRoverPresenter(this, createHttp());

    onSendCommand = (event) => {
        this.presenter.sendCommand(this.state.command);
    }

    onTxtCommandChangedHandler = (event) => {
        this.setState({ command: event.target.value });
    }

    cleanMessages = () => {
        this.setState({ message: '' });
    }

    showMessage = (message) => {
        this.setState({ errorMessage: message });
    }

    render() {
        return (
            <div>
                <h1>MarsRover</h1>
                <p>Command: <input type='text' id='txtCommand' onChange={this.onTxtCommandChangedHandler} /></p>
                <button className="btn btn-primary" onClick={this.onSendCommand}>SendCommand</button>
                <p>{this.state.message}</p>
            </div>
        );
    }
}

export function createMarsRoverView() {
    return new MarsRoverView();
}
