import React, { Component } from 'react';

export class MarsRover extends Component {

    constructor(props) {
        super(props);
    }

    sendCommand() {
    }

    render() {
        return (
            <div>
                <h1>MarsRover</h1>

                <button className="btn btn-primary" onClick={this.sendCommand}>SendCommand</button>
            </div>
        );
    }
}
