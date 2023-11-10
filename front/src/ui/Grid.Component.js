import React, { useState } from 'react'
import PropTypes from 'prop-types';
import MarsRover from './MarsRover.Component';

function Grid({ marsRoverRepository }) {
  const [position, setPosition] = useState({ x: 0, y: 0 })

  const grid = [
    [{x: 0, y: 2}, {x: 1, y: 2}, {x: 2, y: 2}],
    [{x: 0, y: 1}, {x: 1, y: 1}, {x: 2, y: 1}],
    [{x: 0, y: 0}, {x: 1, y: 0}, {x: 2, y: 0}],
  ]
  
  const onSendCommands = () => {
    marsRoverRepository.sendCommands()
      .then((movement) => {
        setPosition({
          x: movement.x,
          y: movement.y,
        })
      })
  }

  const onGetRobotPosition = () =>{
    marsRoverRepository.getRobotPosition()
    .then(positions =>{
      const firstPosition = positions[0];
      setPosition({
        x: firstPosition.x,
        y: firstPosition.y,
      })
    }); 
  }

  const isMarsRoverInPosition = (x, y) => {
    return position.x === x && position.y === y
  }

  return (
    <>
     <table className="mars-rover-map">
      <tbody>
        {grid.map((row, rowIndex) => (
            <tr key={`row-${rowIndex}`}>
              {row.map((cell, cellIndex) => {
                return (
                  <td
                    key={`cell-${rowIndex}-${cellIndex}`}
                    className="mars-rover-map-cell"
                    aria-label={`Longitude ${cell.x}, Latitude ${cell.y}`}
                  >
                    {isMarsRoverInPosition(cell.x, cell.y) ? <div className="mars-rover" aria-label="Mars rover">X</div> : null}
                  </td>
                )
              })}
            </tr>
          )
        )}
      </tbody>
     </table>
     <button onClick={onGetRobotPosition}>Get Robot Position</button>
     <p>Commands: <input type='text' id='txtCommands' /></p>
     <button onClick={onSendCommands}>Send commands</button>
    </>
  )
}

Grid.propTypes = {
  marsRoverRepository: PropTypes.shape({
    sendCommands: PropTypes.func.isRequired,
  }).isRequired,
}

export default Grid
