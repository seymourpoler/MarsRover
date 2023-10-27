import React from 'react';
import { fireEvent, render, screen, within } from '@testing-library/react';
import Grid from './Grid.Component';

describe('Grid', () => {
  it('launches the mars rover in an initial coordinate (0, 0)', () => {
    const marsRoverRepository = {
      sendCommands: () => {}
    }
    render(<Grid marsRoverRepository={marsRoverRepository} />)
    
    const initialCell = screen.getByLabelText('Longitude 0, Latitude 0');
    expect(within(initialCell).getByLabelText('Mars rover')).toBeInTheDocument()
  });

  it('moves the mars rover to the next cell horizontally', async () => {
    const marsRoverRepository = {
      sendCommands: () => {
        return Promise.resolve(
          [{
            x: 1,
            y: 0,
          }]
        )
      }
    }
    
    render(<Grid marsRoverRepository={marsRoverRepository} />)
    
    const sendCommandsButton = screen.getByText('Send commands');
    fireEvent.click(sendCommandsButton)

    const destinationCell = screen.getByLabelText('Longitude 1, Latitude 0');
    expect(await within(destinationCell).findByLabelText('Mars rover')).toBeInTheDocument()
  });
})
